using Carrington_Service.Calculation_Classes;
using Carrington_Service.Infrastructure;
using CarringtonMortgage.FlexFields_Calculation;
using CarringtonMortgage.Helpers;
using CarringtonMortgage.Models.InputCopyBookModels.MortgageLoanBillingModels;
using CarritonMortgage.Calculation_Classes;
using Common;
using System;
using System.IO;
using System.Linq;
using System.Text;
using WMS.Framework.Data;
using WMS.Framework.Data.Records.WorkflowRecords;

namespace ODHS_EDelivery.BusinessExpert
{
    public class CRL30FileGeneration :  ICRL30FileGeneration
    {
        public ILogger Logger;
        private readonly IConfigHelper ConfigHelper;
        private readonly IStatementType StatementType;
        private readonly IChapterSevenBillingStatement ChapterSevenBillingStatement;
        private readonly IChapterSevenOptionARMStatement ChapterSevenOptionARMStatement;
        private readonly IChapterThirteenBillingStatement ChapterThirteenBillingStatement;
        private readonly IChapterThirteenOptionARMStatement ChapterThirteenOptionARMStatement;
        private readonly IOptionARMBillingStatement OptionARMBillingStatement;
        private readonly IStandardBillingStatement StandardBillingStatement;
        /// <summary>The output file.</summary>
        private const string OutputFile = "output.ncp";

        /// <summary>The output file path and name.</summary>
        private static string _outputFile;

        private const string Ncp05Description = "Carriton Mortgage File";

        /// <summary>The NCP05 version.</summary>
        private const string Ncp05Version = "01";

        /// <summary>The NCP09 data key category.</summary>
        private const string Ncp09DataKeyCategory = "CLIENT-TRAILER-DATA";

        /// <summary>The ncp 09 data key orders total count.</summary>
        private const string Ncp09DataKeyAccountsTotalCount = "ACCOUNTS-TOTAL-COUNT";

        /// <summary>The NCP10 version.</summary>
        private const string Ncp10Version = "03";

        /// <summary>The delimiter.</summary>
        private const string Delimiter = "|";

        /// <summary>
        /// The Product Number to assign to accounts that are rejected.
        /// </summary>
        private const string RejectProductNumber = "XXXXX";

        /// <summary>
        /// The option number to assign to accounts that are rejected.
        /// </summary>
        private const int RejectOptionNumber = 9999999;

        private static string _accountTypeHold;
        /// <summary>
        /// Cons CRL30 File Generation
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="configHelper"></param>
        public CRL30FileGeneration(ILogger logger, IConfigHelper configHelper, IStandardBillingStatement standardBillingStatement, IStatementType statementType,
            IChapterSevenBillingStatement chapterSevenBillingStatement, IChapterSevenOptionARMStatement chapterSevenOptionARMStatement,
            IChapterThirteenBillingStatement chapterThirteenBillingStatement, IChapterThirteenOptionARMStatement
            chapterThirteenOptionARMStatement, IOptionARMBillingStatement optionARMBillingStatement)
        {
            Logger = logger;
            ConfigHelper = configHelper;
            StandardBillingStatement = standardBillingStatement;
            StatementType = statementType;
            ChapterSevenBillingStatement = chapterSevenBillingStatement;
            ChapterSevenOptionARMStatement = chapterSevenOptionARMStatement;
            ChapterThirteenBillingStatement = chapterThirteenBillingStatement;
            ChapterThirteenOptionARMStatement = chapterThirteenOptionARMStatement;
            OptionARMBillingStatement = optionARMBillingStatement;
        }

        /// <summary>
        /// This method is used for generating CRL30 File. 
        /// </summary>
        /// <param name="mortgageLoanBillingFileModel"></param>
        public void GenerateCRL30File(MortgageLoanBillingFileModel mortgageLoanBillingFileModel, string inputFile)
        {
            try
            {
                // Creating output file path
                CreateOutputPath(inputFile);
                using (var output = new StandardFile())
                {
                    Logger.Info("Creating NCP Header records...");
                    var lineCnt = 3;
                    output.CreateNew(_outputFile, "BHM");
                    var ncp05 = RecordManager.NewInputFileInfoRecord(Ncp05Version);
                    ncp05.Description = Ncp05Description;
                    ncp05.FileReceivedDate = DateTime.Now;
                    ncp05.InputFileName = mortgageLoanBillingFileModel.InputFileName; //TODO:Add properties in mortgage model
                    ncp05.InputFileSize = mortgageLoanBillingFileModel.InputFileSize;
                    ncp05.FileNumber = 1;
                    ncp05.TrackingId = 0;
                    output.AddInputFileInfoRecord(ncp05);
                    lineCnt++;

                    Logger.Info("Creating NCP07 records...");
                    //TODO: Revisit
                    output.AddLogRecord("CONV", "START", "Carrington_Mortgage + CONVERSION STARTED.");
                    output.AddLogRecord("CONV", "INFO", $"LoanBillExtractInfo - FileDate = {mortgageLoanBillingFileModel.InputFileDate}");
                    output.AddLogRecord("CONV", "INFO", $"LoanBillExtractInfo - Institution = {mortgageLoanBillingFileModel.InstitutionRecords.Rssi_Institution_Name}");
                    output.AddLogRecord("CONV", "INFO",
                        mortgageLoanBillingFileModel.InstitutionRecords.Rssi_Inst_Phone != null
                            ? $"LoanBillExtractInfo - Institution Phone = {mortgageLoanBillingFileModel.InstitutionRecords.Rssi_Inst_Phone}"
                            : $"LoanBillExtractInfo - Institution Phone = {mortgageLoanBillingFileModel.InstitutionRecords.Rssi_Alt_Coup_Ph_No_1}");
                    lineCnt += 10;

                    Logger.Info("Creating NCP09 records...");
                    output.AddAttribute(Ncp09DataKeyCategory, Ncp09DataKeyAccountsTotalCount, Convert.ToString(mortgageLoanBillingFileModel.TotalNumberOfAccount));
                    lineCnt++;

                    Logger.Info("Starting Account records process...");
                    var primaryIndex = 1;
                    var line = new StringBuilder();

                    foreach (var extractAccount in mortgageLoanBillingFileModel.AccountModelList)
                    {
                        _accountTypeHold = string.Empty;

                        var account = new CustomerAccount(primaryIndex, 1)
                        {
                            Standard = RecordManager.NewStandardRecord(Ncp10Version),
                            Workflow = new WorkflowRecord_NCP11_2
                            {
                                PrintDelivery = true,
                                ElectronicDelivery = true,
                                ElectronicDeliveryMethod = "A",
                                IMBIndicator = "I",
                                OptionNumber = null
                            }
                        };

                        account.Standard.AccountNumber = extractAccount.MasterFileDataPart_1Model.Rssi_Acct_No;
                        account.Standard.AccountSequenceNumber = primaryIndex;

                        //Mailing address
                        account.Standard.OriginalAddressLine1 = extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                        account.Standard.OriginalAddressLine2 = extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                        account.Standard.OriginalAddressLine3 = extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;

                        //City,State and Zip
                        account.Standard.OriginalCity = extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                        //account.Standard.OriginalState = extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                        //account.Standard.OriginalZip4 = extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                        //account.Standard.OriginalZip5 = extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;


                        //Assigning Flex fields for Primary borrower
                        var borrowerList = StatementType.GetPrimaryStandardStatement(extractAccount);

                        account.Standard.FlexField1 = borrowerList.FirstOrDefault().FlexField1;
                        account.Standard.FlexField2 = borrowerList.FirstOrDefault().FlexField2;
                        account.Standard.FlexField3 = borrowerList.FirstOrDefault().FlexField3;
                        account.Standard.FlexField4 = borrowerList.FirstOrDefault().FlexField4;
                        account.Standard.FlexField5 = borrowerList.FirstOrDefault().FlexField5;
                        account.Standard.FlexField6 = borrowerList.FirstOrDefault().FlexField6;

                       

                        account.Standard.SSN = extractAccount.MasterFileDataPart_1Model.Rssi_Primary_Social_Sec;
                        account.Standard.StatementDate = CommonHelper.GetFormatedDateTime(extractAccount.MasterFileDataPart_1Model.Rssi_Run_Date);

                        account.Standard.PaymentDueDate = CommonHelper.GetFormatedDateTime(extractAccount.MasterFileDataPart_1Model.Rssi_Due_Date) >
                            CommonHelper.GetFormatedDateTime(extractAccount.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte) ?
                            CommonHelper.GetFormatedDateTime(extractAccount.MasterFileDataPart_1Model.Rssi_Run_Date) :
                            CommonHelper.GetFormatedDateTime(extractAccount.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte);
                        account.Standard.LatePaymentDueDate = CommonHelper.GetFormatedDateTime(extractAccount.LateChargeDetailRecordModel.Rssi_Lcd_Pymt_Due_Dt_PackedData);

                        //account.Standard.LatePaymentAmount = StandardBillingStatement.GetLatePaymentAmount(extractAccount) != null ? Convert.ToDecimal(StandardBillingStatement.GetLatePaymentAmount(extractAccount)): 0;//TODO: Convert the calling method
                        account.Standard.EmailAddress = extractAccount.MasterFileDataPart_1Model.Rssi_Primary_Email_Adr;
                        account.Standard.FormattedAccount = extractAccount.MasterFileDataPart_1Model.Rssi_Acct_No;
                        account.Standard.TwoDRecordCode = 3;


                        lineCnt++;
                        line.Clear();

                        //Get Statement based on the Flex fields for account
                        switch (borrowerList.FirstOrDefault().FlexField2)
                        {

                            //For Chapter 7 Option ARM Statement
                            case "A07":
                                //line = ChapterSevenOptionARMStatement.GetFinalChapterSevenOptionARMStatement(extractAccount);
                                line.Append("Test1");
                                account.AddCustomerRecord(FormatCustomer.BuildRecord("A07", primaryIndex, line));
                                break;

                            //For Chapter 13 Option ARM Statement
                            case "A13":
                                //line = ChapterThirteenOptionARMStatement.GetFinalChapterThirteenOptionARMStatement(extractAccount);
                                line.Append("Test2");
                                account.AddCustomerRecord(FormatCustomer.BuildRecord("A13", primaryIndex, line));
                                break;

                            //For Option ARM Billing  Statement
                            case "ARM":
                                //line = OptionARMBillingStatement.(extractAccount);
                                line.Append("Test3");
                                account.AddCustomerRecord(FormatCustomer.BuildRecord("ARM", primaryIndex, line));
                                break;

                            //For Chapter 7 Billing Statement
                            case "S07":
                                // line = ChapterSevenBillingStatement.GetFinalChapterSevenBillingStatement(extractAccount);
                                line.Append("Test4");
                                account.AddCustomerRecord(FormatCustomer.BuildRecord("S07", primaryIndex, line));
                                break;

                            //For Chapter 13 Billing Statement
                            case "S13":
                                //line = ChapterThirteenBillingStatement.(extractAccount);
                                line.Append("Test5");
                                account.AddCustomerRecord(FormatCustomer.BuildRecord("S13", primaryIndex, line));
                                break;

                            //For Standard Billing Statement
                            case "STD":
                                //line = StandardBillingStatement.GetFinalStringStandardBilling(extractAccount);
                                line.Append("Test6");
                                account.AddCustomerRecord(FormatCustomer.BuildRecord("STD", primaryIndex, line));
                                break;

                            default:
                                break;

                        }

                        //Removing the primary borrower from the list leaving co borrower details inside
                        borrowerList.RemoveAt(0);

                        //Check if primary account is rejected or not 
                        var primaryAccountRejected = RejectStatement.IsRejectAccount(extractAccount);
                        if (primaryAccountRejected)
                            RejectAccount(account, "Invalid Account");


                        account.SequenceTransactions();
                        output.AddAccount(account);
                        primaryIndex++;

                        //Add records for Co-Borrower Section 
                        foreach (var borrower in borrowerList)
                        {

                            if (borrower.DistinctAdditionalRecord)
                            {
                                //Setting FlexFields according to co-borrower conditions
                                account.Standard.FlexField1 = borrower.FlexField1;
                                account.Standard.FlexField2 = borrower.FlexField2;
                                account.Standard.FlexField3 = borrower.FlexField3;
                                account.Standard.FlexField4 = borrower.FlexField4;
                                account.Standard.FlexField5 = borrower.FlexField5;
                                account.Standard.FlexField6 = borrower.FlexField6;

                                switch (borrower.FlexField2)
                                {

                                    //For Chapter 7 Option ARM Statement
                                    case "A07":
                                        //Set Mailing address according to the conditions
                                        account.Standard.OriginalAddressLine1 = ChapterSevenOptionARMStatement.GetMailingBKAttorneyAddressLine1(extractAccount);
                                        account.Standard.OriginalAddressLine2 = ChapterSevenOptionARMStatement.GetMailingBKAttorneyAddressLine2(extractAccount);
                                        break;

                                    //For Chapter 13 Option ARM Statement
                                    case "A13":
                                        //Set Mailing address according to the conditions
                                        account.Standard.OriginalAddressLine1 = ChapterThirteenOptionARMStatement.GetMailingBKAttorneyAddressLine1(extractAccount);
                                        account.Standard.OriginalAddressLine2 = ChapterThirteenOptionARMStatement.GetMailingBKAttorneyAddressLine2(extractAccount);
                                        break;

                                    //For Option ARM Billing  Statement
                                    case "ARM":
                                        //Set Mailing address according to the conditions
                                        account.Standard.OriginalAddressLine1 = OptionARMBillingStatement.GetMailingAddressLine1(extractAccount);
                                        account.Standard.OriginalAddressLine2 = OptionARMBillingStatement.GetMailingAddressLine2(extractAccount);
                                        break;

                                    //For Chapter 7 Billing Statement
                                    case "S07":
                                        //Set Mailing address according to the conditions
                                        account.Standard.OriginalAddressLine1 = ChapterSevenBillingStatement.GetMailingBKAttorneyAddressLine1(extractAccount);
                                        account.Standard.OriginalAddressLine2 = ChapterSevenBillingStatement.GetMailingBKAttorneyAddressLine2(extractAccount);
                                        break;

                                    //For Chapter 13 Billing Statement
                                    case "S13":
                                        //Set Mailing address according to the conditions
                                        account.Standard.OriginalAddressLine1 = ChapterThirteenBillingStatement.GetMailingBKAttorneyAddressLine1(extractAccount);
                                        account.Standard.OriginalAddressLine2 = ChapterThirteenBillingStatement.GetMailingBKAttorneyAddressLine2(extractAccount);
                                        break;

                                    //For Standard Billing Statement
                                    case "STD":
                                        //Set Mailing address according to the conditions
                                        account.Standard.OriginalAddressLine1 = StandardBillingStatement.GetMailingAddressLine1(extractAccount);
                                        account.Standard.OriginalAddressLine2 = StandardBillingStatement.GetMailingAddressLine2(extractAccount);
                                        account.Standard.OriginalAddressLine3 = StandardBillingStatement.GetMailingCityStateZip(extractAccount);
                                        break;

                                    default:
                                        break;

                                }

                                //Reject co-borrower account if the primary account is rejected
                                if (primaryAccountRejected)
                                    RejectAccount(account, "Invalid Account");

                                account.SequenceTransactions();
                                output.AddAccount(account);
                                primaryIndex++;//TODO: Need to check this when this task is complete                          
                            }
                        }

                        //Setting to false for other primary accounts
                        primaryAccountRejected = false;
                    }

                    output.CloseFile();
                    Logger.Info($"Lines written: {lineCnt}");
                }
            }
            catch(Exception ex)
            {
                Logger.Error(ex, "GenerateCRL30File Failed :");
            }

        }

        /// <summary>Rejected account</summary>
        /// <param name="account">The account.</param>
        /// <param name="message">The message.</param>
        private static void RejectAccount(CustomerAccount account, string message)
        {
            account.Workflow.IsReject = true;
            account.Workflow.ProductNumber = RejectProductNumber;
            account.Workflow.OptionNumber = RejectOptionNumber;
            account.MarkAsReject("Carriton_Mort", "8888", message);
        }
        /// <summary>
        /// This method is used for creating output file path
        /// </summary>
        private void CreateOutputPath(string inputFile)
        {
            if (string.IsNullOrWhiteSpace(_outputFile))
            {
                var outPath = inputFile.Substring(0, inputFile.LastIndexOf('\\'));
                _outputFile = Path.Combine(outPath, OutputFile);
                Logger.Info($"Output file name: {_outputFile}");
            }
        }
    }
}
