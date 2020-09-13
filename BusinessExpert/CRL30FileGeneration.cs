using Carrington_Service.Infrastructure;
using ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Framework.Data;
using WMS.Framework.Data.Records.CustomerRecords;
using WMS.Framework.Data.Records.WorkflowRecords;

namespace ODHS_EDelivery.BusinessExpert
{
    public class CRL30FileGeneration
    {
        public ILogger Logger;
        /// <summary>The output file path and name.</summary>
        private static string _outputFile;

        private const string Ncp05Description = "First Tech HELOC-Mortgage XML File";

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

        /// <summary>
        /// This dictionary is used to store the calculated field names and values, which are identified with a Description of "BusinessRule" within the model classes.
        /// This will be included in the CRL30 as the last Account record, record type = "TOTAL".
        /// </summary>
        //private static List<string> _businessRulesValues = new List<string>();
        private static Dictionary<string, string> _businessRulesValues = new Dictionary<string, string>();

        private static string _accountTypeHold;

        public CRL30FileGeneration(ILogger logger)
        {
            Logger = logger;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="mortgageLoanBillingFileModel"></param>
        public void GenerateCRL30File(MortgageLoanBillingFileModel mortgageLoanBillingFileModel)
        {
            using (var output = new StandardFile())
            {
                Logger.Info("Creating NCP Header records...");
                var lineCnt = 3;
                output.CreateNew(_outputFile, "BHM");
                //var fileInfo = new FileInfo(_inputFile);
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
                //output.AddLogRecord("CONV", "START", "Carrington_Mortgage + CONVERSION STARTED.");
                output.AddLogRecord("CONV", "INFO", $"LoanBillExtractInfo - FileDate = {mortgageLoanBillingFileModel.InputFileDate}");
                //output.AddLogRecord("CONV", "INFO", $"LoanBillExtractInfo - MessageText = {loanBillExtract.MessageText}");
                //output.AddLogRecord("CONV", "INFO", $"LoanBillExtractInfo - ProgramName = {loanBillExtract.ProgramName}");
                //output.AddLogRecord("CONV", "INFO", $"LoanBillExtractInfo - QueNbr = {loanBillExtract.QueNbr}");
                //output.AddLogRecord("CONV", "INFO", $"LoanBillExtractInfo - ApplNbr = {loanBillExtract.ApplNbr}");
                //output.AddLogRecord("CONV", "INFO", $"LoanBillExtractInfo - QueSubNbr = {loanBillExtract.QueSubNbr}");
                //output.AddLogRecord("CONV", "INFO", $"LoanBillExtractInfo - Institution = {loanBillExtract.Institution.Name}");
                //output.AddLogRecord("CONV", "INFO",
                //    loanBillExtract.Institution.Phone != null
                //        ? $"LoanBillExtractInfo - Institution Phone = {loanBillExtract.Institution.Phone.FormattedPhone}"
                //        : $"LoanBillExtractInfo - Institution Phone = {string.Empty}");
                //output.AddLogRecord("CONV", "INFO", $"LoanBillExtractInfo - Institution Website = {loanBillExtract.Institution.WebSite}");
                //output.AddLogRecord("CONV", "INFO", $"LoanBillExtractInfo - Accounts Total Count = {loanBillExtract.NbrOfAcctExtracted}");
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
                    _businessRulesValues = new Dictionary<string, string>();

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

                    

                    lineCnt++;

                    line.Clear();
                    line.Append(extractAccount.MasterFileDataPart_1Model.Rssi_Acct_No);
                   // line.Append(Delimiter).Append(extractAccount.AcctDesc);
                    // DE8558: MAS 7/10/2020 - Updated to support multiple AddrLine elements
                    //foreach (var addrLine in extractAccount.MailReturnAddress.Address.AddrLine)
                    //{
                    //    if (addrLine != null)
                    //        line.Append(Delimiter).Append(addrLine.Text.Trim());
                    //    else
                    //        line.Append(Delimiter);
                    //}

                    line.Append(Delimiter).Append(extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1);
                    line.Append(Delimiter).Append(extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2);
                    line.Append(Delimiter).Append(extractAccount.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3);




                    // End DE8558
                    //line.Append(Delimiter).Append(extractAccount.MailReturnAddress.Address.CityName);
                    //line.Append(Delimiter).Append(extractAccount.MailReturnAddress.Address.StateCd);
                    //line.Append(Delimiter).Append(extractAccount.MailReturnAddress.Address.ZipCd);
                    //line.Append(Delimiter).Append(extractAccount.MailReturnAddress.Address.ZipSuf);
                    //line.Append(Delimiter).Append(extractAccount.MailReturnAddress.Address.CtryCD);
                    //line.Append(Delimiter).Append(extractAccount.MailReturnAddress.Address.MailCd);
                    //line.Append(Delimiter).Append(extractAccount.MailReturnAddress.Address.CtrySubDivCd);
                    //line.Append(Delimiter).Append(extractAccount.ConsElecPmtsYN);
                    //line.Append(Delimiter).Append(extractAccount.TaxOwner.Name);
                    //line.Append(Delimiter).Append(extractAccount.TaxOwner.MemberNumber);
                    //// DE8558: MAS 7/10/2020 - Updated to support multiple AddrLine elements
                    //foreach (var addrLine in extractAccount.TaxOwner.Address.AddrLine)
                    //{
                    //    if (addrLine != null)
                    //        line.Append(Delimiter).Append(addrLine.Text.Trim());
                    //    else
                    //        line.Append(Delimiter);
                    //}

                    // End DE8558
                    //var cus = new CustomerRecord_1("ACCT");
                    //cus.ChunkDataString = line;

                    ICustomerRecord c = new CustomerRecord_1("ACCT");
                    c.ChunkData = Encoding.ASCII.GetBytes(Convert.ToString(line));
                    account.AddCustomerRecord(c);


                    //account.AddCustomerRecord(cus);
                    //account.AddCustomerRecord(FormatCustomer.BuildRecord("ACCT", primaryIndex, line));
                    lineCnt++;       

                   
                    account.SequenceTransactions();
                    output.AddAccount(account);
                    primaryIndex++;
                }

                output.CloseFile();
                Logger.Info($"Lines written: {lineCnt}");
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
            account.MarkAsReject("FirstTech_HELOC_Mort", "8888", message);
        }

       



    }
}
