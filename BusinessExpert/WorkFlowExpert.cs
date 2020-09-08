using Carrington_Service.Helpers;
using Carrington_Service.Infrastructure;
using Carrington_Service.Interfaces;
using Carrington_Service.Services;
using Microsoft.VisualBasic.Logging;
using ODHS_EDelivery.Models;
using ODHS_EDelivery.Models.InputCopyBookModels;
using ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrington_Service.BusinessExpert
{
    public class WorkFlowExpert : IWorkFlowExpert
    {
        #region Class Members Definitions & Constructor

        public ILogger Logger;
        private readonly IConfigHelper ConfigHelper;
        private readonly IAgentApi ApiAgent;
        public FileStream InputFileStream;
        public IEmailService EmailService;
        MortgageLoanBillingFileModel MortgageLoanBillingFile = new MortgageLoanBillingFileModel();
        CmsBillInput CmsBillInput = new CmsBillInput();
        EConsentInput EConsentInput = new EConsentInput();
        AccountsModel accountsModel;
        public WorkFlowExpert(IConfigHelper configHelper, ILogger logger, IAgentApi apiAgent, IEmailService emailService)
        {
            ConfigHelper = configHelper;
            Logger = logger;
            ApiAgent = apiAgent;
            EmailService = emailService;
            //configHelper.Model.DatabaseSetting = DbService.GetDataBaseSettings();
        }

        #endregion

        public bool StartWorkFlow()
        {
            try
            {
                Logger.Trace("STARTED: Start WorkFlow Service Method");
                EmailService.SendNotification("");

                ReadPMFile(@"D:\Carrington\Mapping File\TESTDATA.ETOA");
                (List<DetModel> detData, List<TransModel> transData) = ReadCMSBillInputFileDetRecord(@"D:\Carrington\Mapping File\CMS_BILLINPUT02_06232020.txt");
                List<EConsentModel> EconsentData = ReadEConsentRecord(@"D:\Carrington\Mapping File\Carrington_Econsent_Setups_06232020.txt");

                foreach (AccountsModel accountDetails in MortgageLoanBillingFile.AccountModelList)
                {
                    string accountToMatch = accountDetails.MasterFileDataPart_1Model.AccountNumber;
                    bool isAccountMatched = false;
                    if (detData.Any(df => df.LoanNumber == accountToMatch))
                    {
                        if (EconsentData.Any(df => df.LoanNumber == accountToMatch))
                        {
                            isAccountMatched = true;
                        }
                    }
                    else if (transData.Any(df => df.LoanNumber == accountToMatch))
                    {
                        if (EconsentData.Any(df => df.LoanNumber == accountToMatch))
                        {
                            isAccountMatched = true;
                        }
                    }
                    if (isAccountMatched)
                    {
                        accountDetails.IsMatched = true;
                    }
                }

                TimeWatch();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return false;
            }
        }


        #region  Private Methods - Workflow Steps Definitions 

        /// </summary> Step - 1 Execute workflow to send mail alongwith the Campaigning Request./// <summary>
        /// <param name="WFSID"></param>
        /// <param name="clientId"></param>
        /// <param name="batchId"></param>
        /// <returns></returns>
        /// Note:- Don't change method name and parameters.
        private bool SendCampaignRequest(int WFSID, int clientId, int batchId = 0)
        {
            //Before start of work flow step Insert history
            long sessionID = DateTime.Now.Ticks;

            try
            {
                Logger.Trace("STARTED:  Step - 1 Execute workflow to send mail alongwith the Campaigning Request using Send Campaign Request with WFSID =" + WFSID.ToString());

                Logger.Trace("ENDED:    Step - 1 Send Campaign Request with WFSID =" + WFSID.ToString());
                return true;
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                return false;
            }
        }

        private void TimeWatch()
        {
            //24 hours timer is working perfectly
            string path = @"C:\NCP-Carrington\Input";
            var DailyTime = "16:36:00";
            var timeParts = DailyTime.Split(new char[1] { ':' });

            var dateNow = DateTime.Now;
            var date = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day,
                       int.Parse(timeParts[0]), int.Parse(timeParts[1]), int.Parse(timeParts[2]));
            TimeSpan ts;
            if (date > dateNow)
                ts = date - dateNow;
            else
            {
                date = date.AddDays(1);
                ts = date - dateNow;
            }
            //waits certan time and run the code
            Task.Delay(ts).ContinueWith((x) => MonitorDirectory(path));
        }
        private void MonitorDirectory(string path)
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();

            fileSystemWatcher.Path = path;

            fileSystemWatcher.Created += FileSystemWatcher_Created;

            fileSystemWatcher.EnableRaisingEvents = true;

        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileName = e.Name;
            Logger.Trace("File created: " + fileName + "");
            if (File.Exists(@"C:\NCP-Carrington\Input\" + fileName))
            {
                EmailService.SendNotification("");
            }
        }
        #endregion       


        public void ReadPMFile(string fileNameWithPath)
        {

            int numOfBytes = 4010;
            InputFileStream = new System.IO.FileStream(fileNameWithPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);

            byte[] currentByteLine = new byte[numOfBytes];


            int iBytesRead = InputFileStream.Read(currentByteLine, 0, numOfBytes);
            int counter = 0;
            int startPos = 0;
            int fieldLength = 1;
            bool firstRecord = false;
            while (iBytesRead > 0)
            {
                string inputValue = Encoding.Default.GetString(currentByteLine, startPos, fieldLength);
                if (counter <= 1)
                {
                    if (inputValue == "H")
                    {
                        GetHeaderRecord(currentByteLine);
                    }
                    else if (inputValue == "B")
                    {
                        GetInstitutionRecord(currentByteLine);
                    }
                }
                else if (counter > 1)
                {
                    if (inputValue == "P")
                    {
                        GetPL_Record(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "A")
                    {
                        if (firstRecord)
                        {
                            MortgageLoanBillingFile.AccountModelList.Add(accountsModel);
                            accountsModel = null;
                        }
                        accountsModel = new AccountsModel();
                        firstRecord = true;
                        GetMasterFileDataPart_1(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "2")
                    {
                        GetMasterFileDataPart_2(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "U")
                    {
                        GetUserFieldRecord(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "L")
                    {
                        GetMultiLockboxRecordModel(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "R")
                    {
                        GetRateReductionRecord(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "E")
                    {
                        GetEscrowRecordModel(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "O")
                    {
                        GetOptionalItemEscrowRecordModel(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "F")
                    {
                        GetFeeRecordModel(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "S")
                    {
                        GetSolicitationRecordModel(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "T")
                    {
                        GetTransactionRecordModel(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "C")
                    {
                        GetForeignInformationRecordModel(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "D")
                    {
                        GetBlendedRateInformationRecordModel(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "I")
                    {
                        GetCoBorrowerRecordModel(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "<")
                    {
                        GetLateChargeInformationRecordModel(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "-")
                    {
                        GetLateChargeDetailRecordModel(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "J")
                    {
                        GetActiveBankruptcyInformationRecordModel(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "K")
                    {
                        GetArchivedBankruptcyDetailRecordModel(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "X")
                    {
                        GetEmailAddressRecordModel(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "3")
                    {
                        GetDisasterTrackingRecordModel(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "4")
                    {
                        GetRHCDRecords(currentByteLine, ref accountsModel);
                    }
                    else if (inputValue == "Z")
                    {
                        GetTrailerRecords(currentByteLine, ref accountsModel);
                    }

                }
                iBytesRead = InputFileStream.Read(currentByteLine, 0, numOfBytes);
                counter++;
            }
            MortgageLoanBillingFile.AccountModelList.Add(accountsModel);

        }

        private (List<DetModel>, List<TransModel>) ReadCMSBillInputFileDetRecord(string path)
        {
            var fileContents = File.ReadAllLines(path);
            var splitFileContents = (from f in fileContents select f.Split(',')).ToArray();
            List<DetModel> detList = new List<DetModel>();
            List<TransModel> transList = new List<TransModel>();

            foreach (var line in splitFileContents)
            {
                if (line[1].ToString() == "DET")
                {
                    CmsBillInput.DetRecord = new DetModel()
                    {
                        SnapShotDate = line[0].ToString(),
                        FieldDescription = line[1].ToString(),
                        LoanNumber = line[2].ToString(),
                        Eligible = line[3].ToString(),
                        PriorMoAmnt = line[4].ToString(),
                        YTDAmnt = line[5].ToString(),
                        SentNO631_ = line[6].ToString(),
                        FlagRecordIndicator = line[7].ToString(),
                        CurrentDate = line[8].ToString(),
                        NYOrdinance = line[9].ToString(),
                        PriorServicerLoanNumber = line[10].ToString(),
                        PrimaryBorrowerName = line[11].ToString(),
                        MailingAddressLine1 = line[12].ToString(),
                        MailingAddressLine2 = line[13].ToString(),
                        MailingAddressCity = line[14].ToString(),
                        MailingAddressState = line[15].ToString(),
                        MailingAddressZip = line[16].ToString(),
                        PropertAddressLine1 = line[17].ToString(),
                        PropertyAddressLine2 = line[18].ToString(),
                        PropertyAddressCity = line[19].ToString(),
                        PropertyAddressState = line[20].ToString(),
                        PropertyAddressZip = line[21].ToString(),
                        OriginationDate = line[22].ToString(),
                        OriginalLoanAmount = line[23].ToString(),
                        CurrentPrincipalBalance = line[24].ToString(),
                        MaturityDate = line[25].ToString(),
                        TotalAmountDue = line[26].ToString(),
                        MERSFlag = line[27].ToString(),
                        PriorServicerName = line[28].ToString(),
                        PriorServicerAddressLine1 = line[29].ToString(),
                        PriorServicerAddressLine2 = line[30].ToString(),
                        PriorServicerCity = line[31].ToString(),
                        PriorServicerState = line[32].ToString(),
                        PriorServicerZip = line[33].ToString(),
                        PriorServicerPhoneNumber = line[34].ToString(),
                        CMSCSHoursofOperation = line[35].ToString(),
                        ServiceTransferDate = line[36].ToString(),
                        PriorServicerReleaseDate = line[37].ToString(),
                        SaleDate = line[38].ToString(),
                        InvestorCreditorName = line[39].ToString(),
                        TrusteeName = line[40].ToString(),
                        TrusteeAddressLine1 = line[41].ToString(),
                        TrusteeAddressLine2 = line[42].ToString(),
                        TrusteeCity = line[43].ToString(),
                        TrusteeState = line[44].ToString(),
                        TrusteeZip = line[45].ToString(),
                        TrusteePhone = line[46].ToString(),
                        CMSCustomerServicePhone = line[47].ToString(),
                        SecondaryBorrowerName = line[48].ToString(),
                        Originator = line[49].ToString(),
                        ACH_Verbiage = line[50].ToString(),
                        SecurityPosition = line[51].ToString(),
                        OnboardingFlyer = line[52].ToString(),
                        TrusteePart1 = line[53].ToString(),
                        TrusteePart2 = line[54].ToString(),
                        DealName = line[55].ToString(),
                        TotalDue = line[56].ToString(),
                        LockBoxAddress = line[57].ToString()
                    };
                    detList.Add(CmsBillInput.DetRecord);
                }
                if (line[1].ToString() == "TRN")
                {
                    CmsBillInput.TransRecord = new TransModel()
                    {
                        SnapShotDate = line[0].ToString(),
                        FieldDescription = line[1].ToString(),
                        LoanNumber = line[2].ToString(),
                        TransactionDate = line[3].ToString(),
                        TransactionAmount = line[4].ToString(),
                        PrincipalAmount = line[5].ToString(),
                        InterestAmount = line[6].ToString(),
                        EscrowAmount = line[7].ToString(),
                        LateChargeAmount = line[8].ToString()
                    };
                    transList.Add(CmsBillInput.TransRecord);
                }

            }
            return (detList, transList);
        }

        private List<EConsentModel> ReadEConsentRecord(string path)
        {
            var fileContents = File.ReadAllLines(path);
            var splitFileContents = (from f in fileContents select f.Split(',')).ToArray();
            List<EConsentModel> eConsentList = new List<EConsentModel>();

            foreach (var line in splitFileContents)
            {
                //DateTime date = DateTime.Parse(line[0].ToString());
                EConsentInput.EConsentRecord = new EConsentModel()
                {
                    FileDate = Convert.ToDateTime(DateTime.ParseExact(line[0].ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture)),
                    LoanNumber = line[1].ToString(),
                    DocumentType = line[2].ToString(),
                    EConsentFlag = line[3].ToString(),
                    EConsentDate = line[4].ToString(),
                    EMailAddress = line[5].ToString(),
                    Filler = line[6].ToString()
                };
                eConsentList.Add(EConsentInput.EConsentRecord);
            }
            return eConsentList;
        }


        #region PM File Mapping

        // H Header Record. One record per file.
        public void GetHeaderRecord(byte[] currentByte)
        {
            MortgageLoanBillingFile.HeaderRecords = new HeaderRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                Filler1 = GetPositionData(currentByte, 5, 10),
                Filler2 = GetPositionData(currentByte, 15, 5),
                FileIdentifier = GetPositionData(currentByte, 20, 24)
            };

        }

        // B Institution Record.One record per institution.
        public void GetInstitutionRecord(byte[] currentByte)
        {
            MortgageLoanBillingFile.InstitutionRecords = new InstitutionRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                Filler = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                InstitutionName = GetPositionData(currentByte, 20, 35),
                InstitutionAddress1 = GetPositionData(currentByte, 55, 35),
                InstitutionAddress2 = GetPositionData(currentByte, 90, 35),
                InstitutionCity = GetPositionData(currentByte, 125, 21),
                InstitutionState = GetPositionData(currentByte, 146, 2),
                InstitutionZip = GetPositionData(currentByte, 148, 10),
                InstitutionPhone = GetPositionData(currentByte, 158, 10),
                AlternativeCouponAddress1 = GetPositionData(currentByte, 168, 35),
                AlternativeCouponAddress2 = GetPositionData(currentByte, 203, 35),
                AlternativeCouponCity = GetPositionData(currentByte, 238, 21),
                AlternativeCouponState = GetPositionData(currentByte, 259, 2),
                AlternativeCouponZip = GetPositionData(currentByte, 261, 10),
                AlternativePhoneNumberDescription1 = GetPositionData(currentByte, 271, 20),
                AlternativePhoneNumber1 = GetPositionData(currentByte, 291, 10),
                AlternativePhoneNumberDescription2 = GetPositionData(currentByte, 301, 20),
                AlternativePhoneNumber2 = GetPositionData(currentByte, 321, 10),
                AlternativePhoneNumberDescription3 = GetPositionData(currentByte, 331, 20),
                AlternativePhoneNumber3 = GetPositionData(currentByte, 351, 10),
                AlternativePhoneNumberDescription4 = GetPositionData(currentByte, 361, 20),
                AlternativePhoneNumber4 = GetPositionData(currentByte, 381, 10),
                AlternativePhoneNumberDescription5 = GetPositionData(currentByte, 391, 20),
                AlternativePhoneNumber5 = GetPositionData(currentByte, 411, 10),
                LockboxAddress1 = GetPositionData(currentByte, 421, 35),
                LockboxAddress2 = GetPositionData(currentByte, 456, 35),
                LockboxCity = GetPositionData(currentByte, 491, 21),
                LockboxState = GetPositionData(currentByte, 512, 2),
                LockboxZipCode = GetPositionData(currentByte, 514, 10)
            };
        }

        // P PL$$ Entity Record.One record per Entity within Institution if applicable.
        public void GetPL_Record(byte[] currentByte, ref AccountsModel acc)
        {
            acc.PL_RecordModel = new PL_RecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),

                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),

                PL_Entity = GetPositionData(currentByte, 20, 3),
                PLSSGroup = GetPositionData(currentByte, 23, 8),

                PL_EntityStatus = GetPositionData(currentByte, 31, 1),
                PLSSEntityBrandingName = GetPositionData(currentByte, 32, 35),

                EntityBrandingAddressLine1 = GetPositionData(currentByte, 67, 35),
                EntityBrandingAddressLine2 = GetPositionData(currentByte, 102, 35),

                EntityBrandingCity = GetPositionData(currentByte, 137, 21),
                EntityBrandingState = GetPositionData(currentByte, 158, 35),

                EntityBrandingZipCode = GetPositionData(currentByte, 193, 10),
                EntityBrandingPhone = GetPositionData(currentByte, 203, 10),

                PL_EntityTaxIdentificationNumber = GetPositionData(currentByte, 213, 09),
                MERSOrganizationID = GetPositionData(currentByte, 222, 07),

                HUDIDNumber = GetPositionData(currentByte, 229, 12),
                VAID = GetPositionData(currentByte, 241, 06),

                EntityRHSLenderBranchID = GetPositionData(currentByte, 247, 03),
                EntityHUDContactNameFirst = GetPositionData(currentByte, 250, 10),

                EntityHUDContactNameLast = GetPositionData(currentByte, 260, 20),
                EntityHUDContactTelephone = GetPositionData(currentByte, 280, 10),

                EntityHUDPrincipalServicingOfficeCity = GetPositionData(currentByte, 290, 21),
                EntityHUDPrincipalServicingOfficeState = GetPositionData(currentByte, 311, 2),

                EntityHUDPrincipalServicingOfficeZipCode = GetPositionData(currentByte, 313, 09),
                EntityHUDCompanyHeadquartersStateCode = GetPositionData(currentByte, 322, 03),

                EntityLockboxAddressLine1 = GetPositionData(currentByte, 325, 35),
                EntityLockboxAddressLine2 = GetPositionData(currentByte, 360, 35),

                EntityLockboxCity = GetPositionData(currentByte, 395, 21),
                EntityLockboxState = GetPositionData(currentByte, 416, 2),

                EntityLockboxZipCode = GetPositionData(currentByte, 418, 10),
                EntityAlternateAddress1 = GetPositionData(currentByte, 428, 35),

                EntityAlternateAddress2 = GetPositionData(currentByte, 463, 35),
                EntityAlternateCity = GetPositionData(currentByte, 498, 21),

                EntityAlternateState = GetPositionData(currentByte, 519, 2),
                EntityAlternateZipCode = GetPositionData(currentByte, 521, 10),

                EntityAlternatePhoneNumber1Desc = GetPositionData(currentByte, 531, 20),
                EntityAlternatePhoneNumber1 = GetPositionData(currentByte, 551, 10),

                EntityAlternatePhoneNumber2Desc = GetPositionData(currentByte, 561, 20),
                EntityAlternatePhoneNumber2 = GetPositionData(currentByte, 581, 10),

                EntityAlternatePhoneNumber3Desc = GetPositionData(currentByte, 591, 20),
                EntityAlternatePhoneNumber3 = GetPositionData(currentByte, 611, 10),

                EntityAlternatePhoneNumber4Desc = GetPositionData(currentByte, 621, 20),
                EntityAlternatePhoneNumber4 = GetPositionData(currentByte, 641, 10),

                EntityAlternatePhoneNumber5Desc = GetPositionData(currentByte, 651, 20),
                EntityAlternatePhoneNumber5 = GetPositionData(currentByte, 671, 10),
            };
        }

        // A Master File Data Part 1 Record.One record per loan.
        public void GetMasterFileDataPart_1(byte[] currentByte, ref AccountsModel acc)
        {

            acc.MasterFileDataPart_1Model = new MasterFileDataPart_1Model()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),

                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),

                CreditInsurancePayment = GetPositionData(currentByte, 20, 4),
                PrincipalBalance = GetPositionData(currentByte, 24, 6),

                EscrowBalance = GetPositionData(currentByte, 30, 6),
                LoanType = GetPositionData(currentByte, 36, 1),

                LoanSubtype = GetPositionData(currentByte, 37, 1),
                P_IPayment = GetPositionData(currentByte, 38, 6),

                EscrowPayment = GetPositionData(currentByte, 44, 5),
                InvestorOwnershipCode = GetPositionData(currentByte, 49, 1),

                InvestorInformationOccurrences = GetPositionData(currentByte, 50, 280),
                InvestorCode = GetPositionData(currentByte, 50, 3),

                InvestorPrimaryName = GetPositionData(currentByte, 53, 35),
                InvestorBlockCode = GetPositionData(currentByte, 88, 3),

                InvestorPercentOwned = GetPositionData(currentByte, 91, 34),
                InvestorRate = GetPositionData(currentByte, 95, 4),

                InvestorServiceFeeCode = GetPositionData(currentByte, 99, 1),
                InvestorServiceFeeRate = GetPositionData(currentByte, 100, 4),

                InvestorAccountNumber = GetPositionData(currentByte, 104, 15),
                Filler1 = GetPositionData(currentByte, 119, 1),

                LastStatementDate = GetPositionData(currentByte, 330, 6),
                PrecalculatedInterestAmount = GetPositionData(currentByte, 336, 6),

                UnappliedFundsBalanceFirst = GetPositionData(currentByte, 342, 6),
                PropertyTypeCode = GetPositionData(currentByte, 348, 2),

                InterestPaidYearToDate = GetPositionData(currentByte, 350, 6),
                PurposeCode = GetPositionData(currentByte, 356, 2),

                UnappliedFundsCodeFirst = GetPositionData(currentByte, 358, 1),
                StateCode = GetPositionData(currentByte, 359, 2),

                DueDate = GetPositionData(currentByte, 361, 6),
                PaymentsPastDue = GetPositionData(currentByte, 367, 7),

                PaymentDueCounter = GetPositionData(currentByte, 374, 2),
                LateChargeAmount = GetPositionData(currentByte, 376, 4),

                LateChargeDue = GetPositionData(currentByte, 380, 4),
                PrepaidFlag = GetPositionData(currentByte, 384, 1),

                EscrowInterestYTD = GetPositionData(currentByte, 385, 4),
                RunDate = GetPositionData(currentByte, 389, 6),

                PrimaryBorrowersName = GetPositionData(currentByte, 395, 35),
                SecondaryBorrowersName = GetPositionData(currentByte, 430, 35),

                MailingAddress = GetPositionData(currentByte, 465, 35),
                PropertyAddress = GetPositionData(currentByte, 570, 35),

                DueDateGrace = GetPositionData(currentByte, 675, 6),
                CurrentPayment = GetPositionData(currentByte, 681, 6),

                BranchNumber = GetPositionData(currentByte, 687, 3),
                PastDueAmtTotalDue = GetPositionData(currentByte, 690, 7),

                LateCharge = GetPositionData(currentByte, 697, 5),
                PaymentCycleCode = GetPositionData(currentByte, 702, 1),

                WarningCode = GetPositionData(currentByte, 703, 1),
                DistributionMailCode = GetPositionData(currentByte, 704, 1),

                LastActivityDate = GetPositionData(currentByte, 705, 4),
                AnnualPercentageRate = GetPositionData(currentByte, 709, 3),

                NegativeAmortizationTaken = GetPositionData(currentByte, 712, 6),
                GraceDays = GetPositionData(currentByte, 718, 2),

                TaxesPaidYearToDate = GetPositionData(currentByte, 720, 5),
                InterestPaidToDate = GetPositionData(currentByte, 725, 6),

                CurrentDueDate = GetPositionData(currentByte, 731, 7),
                UncollectedCreditInsurance = GetPositionData(currentByte, 737, 6),

                UncollectedInterest = GetPositionData(currentByte, 743, 6),
                NoteRate = GetPositionData(currentByte, 749, 4),

                NegativeAmortizationAssessedYTD = GetPositionData(currentByte, 753, 5),
                NegativeAmortizationPaidYTD = GetPositionData(currentByte, 758, 5),

                NoteRateOverUnder = GetPositionData(currentByte, 763, 4),
                OriginalRateOverUnder = GetPositionData(currentByte, 767, 4),

                BillableNumber = GetPositionData(currentByte, 771, 9),
                BankTransitRoutingNumber = GetPositionData(currentByte, 780, 5),

                WithholdingInterestYTD = GetPositionData(currentByte, 785, 4),
                NegativeAmortizationFlag = GetPositionData(currentByte, 789, 1),

                InterestOnPymtDue = GetPositionData(currentByte, 790, 6),
                SecondMortgageCode = GetPositionData(currentByte, 796, 1),

                SecondaryMortgageAccountNumber = GetPositionData(currentByte, 797, 6),
                SecondaryMortgagePaymentAmount = GetPositionData(currentByte, 803, 6),

                FeeReceivable = GetPositionData(currentByte, 809, 4),
                PastDuePayments = GetPositionData(currentByte, 813, 8),

                PastPaymentDueDate = GetPositionData(currentByte, 813, 6),
                PastRegularAmount = GetPositionData(currentByte, 819, 6),

                PastLateAmount = GetPositionData(currentByte, 825, 6),
                BillingOption = GetPositionData(currentByte, 921, 1),

                AlternativeOverUnder = GetPositionData(currentByte, 923, 4),
                CurrentIndexDate = GetPositionData(currentByte, 926, 4),

                CurrentIndexRate = GetPositionData(currentByte, 930, 4),
                EmployeeDiscountedMargin = GetPositionData(currentByte, 934, 4),

                InterestOnlyPayment = GetPositionData(currentByte, 938, 6),
                FullyAmortizePayment = GetPositionData(currentByte, 944, 6),

                BillMethod = GetPositionData(currentByte, 950, 1),
                ACHAccountNumber = GetPositionData(currentByte, 951, 20),

                AnalysisIndexRate = GetPositionData(currentByte, 971, 4),
                InterestMethod = GetPositionData(currentByte, 975, 2),

                CrossSellFlag = GetPositionData(currentByte, 977, 1),
                MultipleLoanFlag = GetPositionData(currentByte, 978, 1),

                Filler = GetPositionData(currentByte, 979, 1),
                PrimaryBorrowerSocialSecurityNumber = GetPositionData(currentByte, 980, 4),

                RepaymentPlanNextDueDate = GetPositionData(currentByte, 984, 6),
                AmortizedFeePayment = GetPositionData(currentByte, 990, 5),

                RepaymentPlanNextPaymentDueAmount = GetPositionData(currentByte, 995, 4),
                PlanRemainingBalance = GetPositionData(currentByte, 999, 6),

                EmailBillIndicator = GetPositionData(currentByte, 1005, 1),
                PrimaryBorrowerEmailAddress = GetPositionData(currentByte, 1006, 40),

                PrimaryBorrowerFaxNumber = GetPositionData(currentByte, 1046, 11),
                PrimaryBorrowerCellPhoneNumber = GetPositionData(currentByte, 1052, 11),

                DirectMailIndicator = GetPositionData(currentByte, 1058, 2),
                TelemarketIndicator = GetPositionData(currentByte, 1060, 2),

                FeeReceivablePart2 = GetPositionData(currentByte, 1062, 5),
                ServicingDate = GetPositionData(currentByte, 1067, 8),

                FirstStatementonAcquiredLoanIndicator = GetPositionData(currentByte, 1075, 1),
                MailCode = GetPositionData(currentByte, 1076, 1),

                SpecialStatementRequest = GetPositionData(currentByte, 1077, 1),
                StopCode1 = GetPositionData(currentByte, 1078, 1),

                OptInFlag = GetPositionData(currentByte, 1079, 1),
                OptOutFlag = GetPositionData(currentByte, 1080, 1),

                SecondaryBorrowerEmailIndicator = GetPositionData(currentByte, 1081, 1),
                FirstPaymentDate = GetPositionData(currentByte, 1082, 8),

                MortgageLoanFlag = GetPositionData(currentByte, 1090, 1),
                PurchasedFrom = GetPositionData(currentByte, 1091, 34),

                UncollectedNSFFees = GetPositionData(currentByte, 1125, 7),
                UncollectedExtensionFees = GetPositionData(currentByte, 1132, 7),

                PrimaryBorrowersHomePhone = GetPositionData(currentByte, 1139, 11),
                InvestorTaxID = GetPositionData(currentByte, 1150, 11),

                ForceOrderCoverageFlagFire = GetPositionData(currentByte, 1161, 1),
                ForceOrderCoverageFlagHomeowners = GetPositionData(currentByte, 1162, 1),

                ForceOrderCoverageFlagFlood = GetPositionData(currentByte, 1163, 1),
                ForceOrderCoverageFlagEarthquake = GetPositionData(currentByte, 1164, 1),

                ForceOrderCoverageFlagWind = GetPositionData(currentByte, 1165, 1),
                FillerPart3 = GetPositionData(currentByte, 1166, 5),

                SecondaryBorrowersSocialSecurityNumber = GetPositionData(currentByte, 1171, 4),
                ClosingDate = GetPositionData(currentByte, 1175, 8),

                InterestStartDateAccruals = GetPositionData(currentByte, 1183, 8),
                TermofLoan = GetPositionData(currentByte, 1191, 3),

                FieldmanSolicitorCode = GetPositionData(currentByte, 1194, 5),
                UpdatedTerm = GetPositionData(currentByte, 1199, 3),

                ModificationDate = GetPositionData(currentByte, 1202, 8),
                AlternativeMortgageIndicator = GetPositionData(currentByte, 1210, 1),

                NameChangeIndicator = GetPositionData(currentByte, 1211, 1),
                AddressChangeIndicator = GetPositionData(currentByte, 1212, 1),

                BalloonDate = GetPositionData(currentByte, 1213, 8),
                ThirtyDaysDelinquentCount = GetPositionData(currentByte, 1221, 3),

                SixtyDaysDelinquentCount = GetPositionData(currentByte, 1224, 3),
                NinetyDaysDelinquentCount = GetPositionData(currentByte, 1227, 3),

                TotalNSFCounter = GetPositionData(currentByte, 1230, 3),
                PrimaryBorrowersBirthdate = GetPositionData(currentByte, 1233, 8),

                CreditBureauScore1 = GetPositionData(currentByte, 1241, 15),
                CreditBureauScore2 = GetPositionData(currentByte, 1256, 15),

                CreditBureauScore3 = GetPositionData(currentByte, 1271, 15),
                LastExtensionPostDate = GetPositionData(currentByte, 1286, 8),

                TotalActivatedExtensions = GetPositionData(currentByte, 1294, 3),
                PreNotificationFlag = GetPositionData(currentByte, 1297, 1),

                PrimaryBorrowersWorkNumber = GetPositionData(currentByte, 1298, 11),
                EOYGrossInterestPaid = GetPositionData(currentByte, 1309, 11),

                ForeclosureAdvance = GetPositionData(currentByte, 1320, 7),
                NetInvestment = GetPositionData(currentByte, 1327, 11),

                DiscountQuotedOriginalDiscountAmount = GetPositionData(currentByte, 1338, 9),
                TotalPaymentsForLifeOfLoan = GetPositionData(currentByte, 1347, 11),

                MonthlyInterestRate = GetPositionData(currentByte, 1360, 7),
                NumberOfDaysDelinquent = GetPositionData(currentByte, 1367, 5),

                LossMitAnalysisOptionDate = GetPositionData(currentByte, 1372, 8),
                PriorAccountNumber = GetPositionData(currentByte, 1380, 20),

                LastPaymentDate = GetPositionData(currentByte, 1400, 8),
                PrimaryBorrowersMaritalStatus = GetPositionData(currentByte, 1408, 1),

                CloseCode = GetPositionData(currentByte, 1409, 1),
                REOIndicator = GetPositionData(currentByte, 1410, 1),

                MaturityDate = GetPositionData(currentByte, 1411, 8),
                PartialChargeOffTaken = GetPositionData(currentByte, 1419, 11),

                LockoutCode = GetPositionData(currentByte, 1430, 1),
                StopCode2 = GetPositionData(currentByte, 1431, 1),

                StopCode3 = GetPositionData(currentByte, 1432, 1),
                FairIssacsCreditScore = GetPositionData(currentByte, 1433, 5),

                NSFIndicator = GetPositionData(currentByte, 1438, 1),
                EmployeeCode = GetPositionData(currentByte, 1439, 1),

                AuditDate = GetPositionData(currentByte, 1440, 8),
                PrimaryBorrowersAge = GetPositionData(currentByte, 1448, 3),

                SecondaryBorrowersAge = GetPositionData(currentByte, 1451, 3),
                RealtorBuilderCode = GetPositionData(currentByte, 1454, 5),

                UserField001 = GetPositionData(currentByte, 1459, 4),
                TotalFeesDue = GetPositionData(currentByte, 1463, 5),

                RecurringDraftStatus = GetPositionData(currentByte, 1468, 1),
                InternalRefinanceCode = GetPositionData(currentByte, 1469, 1),

                UserField007 = GetPositionData(currentByte, 1470, 2),
                UserField036 = GetPositionData(currentByte, 1472, 1),

                UncollectedExtensionInterest = GetPositionData(currentByte, 1473, 6),
                StatementFrequency = GetPositionData(currentByte, 1479, 2),

                StatementFrequencyChangeDate = GetPositionData(currentByte, 1481, 8),
                APDSParticipation = GetPositionData(currentByte, 1489, 1),

                PaymentProgramIndicator = GetPositionData(currentByte, 1490, 2),
                OrganizationUnitCode1 = GetPositionData(currentByte, 1492, 5),

                PLSSEntity = GetPositionData(currentByte, 1497, 3),
                RateNextChangeDate = GetPositionData(currentByte, 1500, 8),

                PrepaymentPenaltyAmount = GetPositionData(currentByte, 1508, 6),
                PrincipalPaidYTD = GetPositionData(currentByte, 1514, 6),

                EscrowPaidYTD = GetPositionData(currentByte, 1520, 6),
                FeesPaidYTD = GetPositionData(currentByte, 1526, 5),

                LateChargesPaidYTD = GetPositionData(currentByte, 1531, 5),
                PastPaidPaymentDueDate01 = GetPositionData(currentByte, 1536, 6),

                PastPaidPaymentPaidDate01 = GetPositionData(currentByte, 1542, 6),
                PastPaidPaymentDueDate02 = GetPositionData(currentByte, 1548, 6),

                PastPaidPaymentPaidDate02 = GetPositionData(currentByte, 1554, 6),
                PastPaidPaymentDueDate03 = GetPositionData(currentByte, 1560, 6),

                PastPaidPaymentPaidDate03 = GetPositionData(currentByte, 1566, 6),
                PastPaidPaymentDueDate04 = GetPositionData(currentByte, 1572, 6),

                PastPaidPaymentPaidDate04 = GetPositionData(currentByte, 1578, 6),
                PastPaidPaymentDueDate05 = GetPositionData(currentByte, 1572, 6),

                PastPaidPaymentPaidDate05 = GetPositionData(currentByte, 1590, 6),
                PastPaidPaymentDueDate06 = GetPositionData(currentByte, 1596, 6),

                PastPaidPaymentPaidDate06 = GetPositionData(currentByte, 1602, 6),
                PrincipalPaidSinceLastStatement = GetPositionData(currentByte, 1608, 7),

                InterestPaidSinceLastStatement = GetPositionData(currentByte, 1615, 7),
                EscrowPaidSinceLastStatement = GetPositionData(currentByte, 1622, 7),

                LateChargesPaidSinceLastStatement = GetPositionData(currentByte, 1629, 6),
                FeesPaidSinceLastStatement = GetPositionData(currentByte, 1635, 7),

                PartialPaymentsPaidSinceLastStatement = GetPositionData(currentByte, 1642, 6),
                TotalAmountPaidSinceLastStatement = GetPositionData(currentByte, 1648, 8),

                FeesAssessedSinceLastStatement = GetPositionData(currentByte, 1656, 6),
                LateChargesAccruedSinceLastStatement = GetPositionData(currentByte, 1662, 6),

                LossMitigationFlag = GetPositionData(currentByte, 1668, 1),
                FirstContactName = GetPositionData(currentByte, 1669, 20),

                FirstContactAddress1 = GetPositionData(currentByte, 1689, 50),
                FirstContactCity = GetPositionData(currentByte, 1739, 20),

                FirstContactState = GetPositionData(currentByte, 1759, 2),
                FirstContactZipCode = GetPositionData(currentByte, 1761, 10),

                FirstContactPhoneNumber = GetPositionData(currentByte, 1771, 15),
                FirstContactExtension = GetPositionData(currentByte, 1786, 5),

                PastPaymentDueDateR = GetPositionData(currentByte, 1791, 6),
                PastRegularAmountR = GetPositionData(currentByte, 1797, 6),
                PastLateAmountR = GetPositionData(currentByte, 1803, 6),

                PastPaidPaymentDueDate7 = GetPositionData(currentByte, 2187, 6),
                PastPaidPaymentPaidDate7 = GetPositionData(currentByte, 2193, 6),

                PastPaidPaymentDueDate8 = GetPositionData(currentByte, 2199, 6),
                PastPaidPaymentPaidDate8 = GetPositionData(currentByte, 2205, 6),

                PastPaidPaymentDueDate9 = GetPositionData(currentByte, 2211, 6),
                PastPaidPaymentPaidDate9 = GetPositionData(currentByte, 2217, 6),

                PastPaidPaymentDueDate10 = GetPositionData(currentByte, 2223, 6),
                PastPaidPaymentPaidDate10 = GetPositionData(currentByte, 2229, 6),

                PastPaidPaymentDueDate11 = GetPositionData(currentByte, 2235, 6),
                PastPaidPaymentPaidDate11 = GetPositionData(currentByte, 2241, 6),

                PastPaidPaymentDueDate12 = GetPositionData(currentByte, 2247, 6),
                PastPaidPaymentPaidDate12 = GetPositionData(currentByte, 2253, 6),

                PastPaidPaymentDueDate13 = GetPositionData(currentByte, 2259, 6),
                PastPaidPaymentPaidDate13 = GetPositionData(currentByte, 2265, 6),

                PastPaidPaymentDueDate14 = GetPositionData(currentByte, 2271, 6),
                PastPaidPaymentPaidDate13Part2 = GetPositionData(currentByte, 2277, 6),

                PastPaidPaymentDueDate15 = GetPositionData(currentByte, 2283, 6),
                PastPaidPaymentPaidDate15 = GetPositionData(currentByte, 2289, 6),

                PastPaidPaymentDueDate16 = GetPositionData(currentByte, 2295, 6),
                PastPaidPaymentPaidDate16 = GetPositionData(currentByte, 2301, 6),

                PastPaidPaymentDueDate17 = GetPositionData(currentByte, 2307, 6),
                PastPaidPaymentPaidDate16Part2 = GetPositionData(currentByte, 2313, 6),

                PastPaidPaymentDueDate18 = GetPositionData(currentByte, 2319, 6),
                PastPaidPaymentPaidDate18 = GetPositionData(currentByte, 2325, 6),

                PastPaidPaymentDueDate19 = GetPositionData(currentByte, 2331, 6),
                PastPaidPaymentPaidDate19 = GetPositionData(currentByte, 2337, 6),

                PastPaidPaymentDueDate20 = GetPositionData(currentByte, 2343, 6),
                PastPaidPaymentPaidDate20 = GetPositionData(currentByte, 2349, 6),

                PastPaidPaymentDueDate21 = GetPositionData(currentByte, 2355, 6),
                PastPaidPaymentPaidDate21 = GetPositionData(currentByte, 2361, 6),

                PastPaidPaymentDueDate22 = GetPositionData(currentByte, 2367, 6),
                PastPaidPaymentPaidDate22 = GetPositionData(currentByte, 2373, 6),


                PastPaidPaymentDueDate23 = GetPositionData(currentByte, 2379, 6),
                PastPaidPaymentPaidDate23 = GetPositionData(currentByte, 2385, 6),

                PastPaidPaymentDueDate24 = GetPositionData(currentByte, 2391, 6),
                PastPaidPaymentPaidDate24 = GetPositionData(currentByte, 2397, 6),

                PastPaidPaymentDueDate25 = GetPositionData(currentByte, 2403, 6),
                PastPaidPaymentPaidDate25 = GetPositionData(currentByte, 2409, 6),

                PastPaidPaymentDueDate26 = GetPositionData(currentByte, 2415, 6),
                PastPaidPaymentPaidDate26 = GetPositionData(currentByte, 2421, 6),

                PastPaidPaymentDueDate27 = GetPositionData(currentByte, 2427, 6),
                PastPaidPaymentPaidDate27 = GetPositionData(currentByte, 2433, 6),

                PastPaidPaymentDueDate28 = GetPositionData(currentByte, 2439, 6),
                PastPaidPaymentPaidDate28 = GetPositionData(currentByte, 2445, 6),

                CashElectronicTransferOptOut = GetPositionData(currentByte, 2451, 1),
                MultipleLoanIndicator = GetPositionData(currentByte, 2452, 1),

                LastAnnualStatementDate = GetPositionData(currentByte, 2453, 4),
                LastPrivacyStatementMethod = GetPositionData(currentByte, 2457, 2),

                OptOutType = GetPositionData(currentByte, 2459, 1),
                OptOutDate = GetPositionData(currentByte, 2460, 4),

                SpecialContactCode = GetPositionData(currentByte, 2464, 5),
                LastDisclosureNoticeDate = GetPositionData(currentByte, 2469, 4),

                LastDisclosureNoticeMethod = GetPositionData(currentByte, 2473, 2),
                PrimarySolicitationOptOutType = GetPositionData(currentByte, 2475, 1),

                PrimarySolicitationOptOutDate = GetPositionData(currentByte, 2476, 4),
                SecondarySolicitationOptOutType = GetPositionData(currentByte, 2480, 1),
                SecondarySolicitationOptOutDate = GetPositionData(currentByte, 2481, 4),

                CoborrowerSolicitationOptOutType01 = GetPositionData(currentByte, 2485, 1),
                CoborrowerSolicitationOptOutDate01 = GetPositionData(currentByte, 2486, 4),

                CoborrowerSolicitationOptOutType02 = GetPositionData(currentByte, 2490, 1),
                CoborrowerSolicitationOptOutDate02 = GetPositionData(currentByte, 2491, 4),

                CoborrowerSolicitationOptOutType03 = GetPositionData(currentByte, 2495, 1),
                CoborrowerSolicitationOptOutDate03 = GetPositionData(currentByte, 2496, 4),

                CoborrowerSolicitationOptOutType04 = GetPositionData(currentByte, 2500, 1),
                CoborrowerSolicitationOptOutDate04 = GetPositionData(currentByte, 2501, 4),

                CoborrowerSolicitationOptOutType05 = GetPositionData(currentByte, 2505, 1),
                CoborrowerSolicitationOptOutDate05 = GetPositionData(currentByte, 2506, 4),

                CoborrowerSolicitationOptOutType06 = GetPositionData(currentByte, 2510, 1),
                CoborrowerSolicitationOptOutDate06 = GetPositionData(currentByte, 2511, 4),

                CoborrowerSolicitationOptOutType07 = GetPositionData(currentByte, 2515, 1),
                CoborrowerSolicitationOptOutDate07 = GetPositionData(currentByte, 2516, 4),

                CoborrowerSolicitationOptOutType08 = GetPositionData(currentByte, 2520, 1),
                CoborrowerSolicitationOptOutDate08 = GetPositionData(currentByte, 2521, 4),

                CoborrowerSolicitationOptOutType09 = GetPositionData(currentByte, 2525, 1),
                CoborrowerSolicitationOptOutDate09 = GetPositionData(currentByte, 2526, 4),

                CoborrowerSolicitationOptOutType10 = GetPositionData(currentByte, 2530, 1),
                CoborrowerSolicitationOptOutDate10 = GetPositionData(currentByte, 2531, 4),

                AcceleratedDate = GetPositionData(currentByte, 2535, 4),
                AcceleratedAccruedInterest = GetPositionData(currentByte, 2539, 6),

                PrintStatement = GetPositionData(currentByte, 2545, 1),
                PartialPaymentsYearToDate = GetPositionData(currentByte, 2546, 5),

                ClosingInterest = GetPositionData(currentByte, 2551, 6),
                PayoffAmount = GetPositionData(currentByte, 2557, 6),

                PrimaryBorrowerAttention = GetPositionData(currentByte, 2563, 35),
                DsiAccruedInterest = GetPositionData(currentByte, 2598, 6),

                AcceleratedAmount = GetPositionData(currentByte, 2604, 7),
                ReinstatementDate = GetPositionData(currentByte, 2611, 4),

                ReinstatementAmount = GetPositionData(currentByte, 2615, 7),
                TaskCompletionDate = GetPositionData(currentByte, 2622, 4),

                NextAchDraftDate = GetPositionData(currentByte, 2626, 4),
                MostRecentBreachLetterDate = GetPositionData(currentByte, 2630, 4),

                FullFinalChargeOffDate = GetPositionData(currentByte, 2634, 2),
                PromiseDate = GetPositionData(currentByte, 2638, 4),

                PromiseAmount = GetPositionData(currentByte, 2642, 6),
                PromiseToPayBrokenDate = GetPositionData(currentByte, 2647, 4),

                PromiseToPayKeptDate = GetPositionData(currentByte, 2651, 4),
                FillerPart4 = GetPositionData(currentByte, 2655, 1356),

            };
        }

        // 2 Master File Data Part 2 Record.One record per loan.
        public void GetMasterFileDataPart_2(byte[] currentByte, ref AccountsModel acc)
        {

            acc.MasterFileDataPart2Model = new MasterFileDataPart2Model()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),

                UnappliedFundsBalance2 = GetPositionData(currentByte, 20, 5),
                UnappliedFundsCode2 = GetPositionData(currentByte, 25, 1),

                UnappliedFundsBalance3 = GetPositionData(currentByte, 26, 5),
                UnappliedFundsCode3 = GetPositionData(currentByte, 31, 1),

                UnappliedFundsBalance4 = GetPositionData(currentByte, 32, 5),
                UnappliedFundsCode4 = GetPositionData(currentByte, 37, 1),

                UnappliedFundsBalance5 = GetPositionData(currentByte, 38, 5),
                UnappliedFundsCode5 = GetPositionData(currentByte, 43, 1),

                UnappliedFundsBalanceTotal = GetPositionData(currentByte, 44, 6),
                TotalAmountToBeDrafted = GetPositionData(currentByte, 50, 6),

                RecurringDraftBankTotalDraftAmount = GetPositionData(currentByte, 56, 6),
                Filler = GetPositionData(currentByte, 62, 26),

                UncollectedP_IAdvance = GetPositionData(currentByte, 88, 6),
                OriginalMaturityDate = GetPositionData(currentByte, 94, 5),

                DelinquentCounselorCode = GetPositionData(currentByte, 99, 3),
                BillingMessageCode01 = GetPositionData(currentByte, 102, 6),

                BillingMessageCode02 = GetPositionData(currentByte, 108, 6),
                BillingMessageCode03 = GetPositionData(currentByte, 114, 6),

                BillingMessageCode04 = GetPositionData(currentByte, 120, 6),
                BillingMessageCode05 = GetPositionData(currentByte, 126, 6),

                BillingMessageCode06 = GetPositionData(currentByte, 132, 6),
                BillingMessageCode07 = GetPositionData(currentByte, 138, 6),

                BillingMessageCode08 = GetPositionData(currentByte, 144, 6),
                BillingMessageCode09 = GetPositionData(currentByte, 150, 6),

                BillingMessageCode10 = GetPositionData(currentByte, 156, 6),
                BillingMessageCode11 = GetPositionData(currentByte, 162, 6),

                BillingMessageCode12 = GetPositionData(currentByte, 168, 6),
                BillingMessageCode13 = GetPositionData(currentByte, 174, 6),

                BillingMessageCode14 = GetPositionData(currentByte, 180, 6),
                BillingMessageCode15 = GetPositionData(currentByte, 186, 6),

                BillingMessageCode16 = GetPositionData(currentByte, 192, 6),
                BillingMessageCode17 = GetPositionData(currentByte, 198, 6),

                BillingMessageCode18 = GetPositionData(currentByte, 204, 6),
                BillingMessageCode19 = GetPositionData(currentByte, 210, 6),
                BillingMessageCode20 = GetPositionData(currentByte, 216, 6),

                PrimaryBorrowerMailingForeign = GetPositionData(currentByte, 222, 1),
                AlternativeAddressForeignAddressFlag = GetPositionData(currentByte, 223, 1),

                PropertyForeignAddressIndicator = GetPositionData(currentByte, 224, 1),
                TotalDeferredItemsBalance = GetPositionData(currentByte, 225, 7),

                DeferredInterestBalance = GetPositionData(currentByte, 232, 6),
                DeferredLateChargesBalance = GetPositionData(currentByte, 238, 4),

                DeferredEscrowAdvancesBalance = GetPositionData(currentByte, 242, 6),
                DeferredDrmExpenseAdvancesPaidBalance = GetPositionData(currentByte, 248, 6),

                DeferredDrmExpenseAdvancesUnpaidBalance = GetPositionData(currentByte, 254, 6),
                DeferredAdministrativeFeesBalance = GetPositionData(currentByte, 260, 6),

                PrimaryBorrowerSLanguage = GetPositionData(currentByte, 266, 1),
                UncollectedEscrowShortage = GetPositionData(currentByte, 267, 6),

                DeferredOptionalProductPremiums = GetPositionData(currentByte, 273, 5),
                ClosingAgentCode = GetPositionData(currentByte, 278, 5),

                FillerPart2 = GetPositionData(currentByte, 283, 13),
                DeferredPrincipalBalance = GetPositionData(currentByte, 296, 11),

                CombinedPrincipalBalance = GetPositionData(currentByte, 302, 6),
                OriginalPrincipalReductionAmount = GetPositionData(currentByte, 308, 6),

                RemainingPraAmount = GetPositionData(currentByte, 314, 6),
                PraTakenAmount = GetPositionData(currentByte, 320, 6),

                LossMitigationProgram = GetPositionData(currentByte, 326, 3),
                FclActionStartDate = GetPositionData(currentByte, 329, 6),

                MostRecentBreachLetterDate = GetPositionData(currentByte, 335, 6),
                HigherPricedMortgageLoanFlag = GetPositionData(currentByte, 341, 1),

                HpmlEscrowRequiredThroughDate = GetPositionData(currentByte, 342, 8),
                Filler3 = GetPositionData(currentByte, 350, 187),

                CurrentOccupancyCode = GetPositionData(currentByte, 537, 1),
                Filler4 = GetPositionData(currentByte, 538, 965),

            };
        }

        // U User Field Record. One record per loan if applicable.
        public void GetUserFieldRecord(byte[] currentByte, ref AccountsModel acc)
        {
            acc.UserFieldRecordModel = new UserFieldRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                UserField02 = GetPositionData(currentByte, 20, 4),
                UserField03 = GetPositionData(currentByte, 24, 1),
                UserField04 = GetPositionData(currentByte, 25, 1),
                UserField05 = GetPositionData(currentByte, 26, 1),
                UserField06 = GetPositionData(currentByte, 27, 1),
                UserField08 = GetPositionData(currentByte, 28, 2),
                UserField09 = GetPositionData(currentByte, 30, 2),
                UserField10 = GetPositionData(currentByte, 32, 2),
                UserField11 = GetPositionData(currentByte, 34, 3),
                UserField12 = GetPositionData(currentByte, 37, 3),
                UserField13 = GetPositionData(currentByte, 40, 3),
                UserField14 = GetPositionData(currentByte, 43, 6),
                UserField15 = GetPositionData(currentByte, 49, 4),
                UserField16 = GetPositionData(currentByte, 53, 4),
                UserField17 = GetPositionData(currentByte, 57, 5),
                UserField18 = GetPositionData(currentByte, 62, 15),
                UserField19 = GetPositionData(currentByte, 77, 5),
                UserField20 = GetPositionData(currentByte, 82, 2),
                UserField21 = GetPositionData(currentByte, 84, 10),
                UserField22 = GetPositionData(currentByte, 94, 10),
                UserField23 = GetPositionData(currentByte, 104, 6),
                UserField24 = GetPositionData(currentByte, 110, 6),
                UserField25 = GetPositionData(currentByte, 116, 4),
                UserField26 = GetPositionData(currentByte, 120, 4),
                UserField27 = GetPositionData(currentByte, 124, 4),
                UserField28 = GetPositionData(currentByte, 128, 4),
                UserField29 = GetPositionData(currentByte, 132, 4),
                UserField30 = GetPositionData(currentByte, 136, 4),
                UserField31 = GetPositionData(currentByte, 140, 6),
                UserField32 = GetPositionData(currentByte, 146, 6),
                UserField33 = GetPositionData(currentByte, 152, 6),
                UserField34 = GetPositionData(currentByte, 158, 6),
                UserField35 = GetPositionData(currentByte, 164, 1),
                UserField37 = GetPositionData(currentByte, 165, 1),
                UserField38 = GetPositionData(currentByte, 166, 1),
                UserField39 = GetPositionData(currentByte, 167, 2),
                UserField40 = GetPositionData(currentByte, 169, 2),
                UserField41 = GetPositionData(currentByte, 171, 2),
                UserField42 = GetPositionData(currentByte, 173, 2),
                UserField43 = GetPositionData(currentByte, 175, 3),
                UserField44 = GetPositionData(currentByte, 178, 6),
                UserField45 = GetPositionData(currentByte, 184, 6),
                UserField46 = GetPositionData(currentByte, 190, 15),
                UserField47 = GetPositionData(currentByte, 205, 15),
                UserField48 = GetPositionData(currentByte, 220, 15),
                UserField49 = GetPositionData(currentByte, 235, 15),
                UserField50 = GetPositionData(currentByte, 250, 15),
                UserField51 = GetPositionData(currentByte, 265, 35),
                UserField52 = GetPositionData(currentByte, 300, 35),
                UserField53 = GetPositionData(currentByte, 335, 35),
                UserField54 = GetPositionData(currentByte, 370, 1),
                UserField55 = GetPositionData(currentByte, 371, 1),
                UserField56 = GetPositionData(currentByte, 372, 1),
                UserField57 = GetPositionData(currentByte, 373, 1),
                UserField58 = GetPositionData(currentByte, 374, 1),
                UserField59 = GetPositionData(currentByte, 375, 1),
                UserField60 = GetPositionData(currentByte, 376, 1),
                UserField61 = GetPositionData(currentByte, 377, 1),
                UserField62 = GetPositionData(currentByte, 378, 1),
                UserField63 = GetPositionData(currentByte, 379, 1),
                UserField64 = GetPositionData(currentByte, 380, 1),
                UserField65 = GetPositionData(currentByte, 381, 1),
                UserField66 = GetPositionData(currentByte, 382, 1),
                UserField67 = GetPositionData(currentByte, 383, 1),
                UserField68 = GetPositionData(currentByte, 384, 1),
                UserField69 = GetPositionData(currentByte, 385, 1),
                UserField70 = GetPositionData(currentByte, 386, 1),
                UserField71 = GetPositionData(currentByte, 387, 1),
                UserField72 = GetPositionData(currentByte, 388, 1),
                UserField73 = GetPositionData(currentByte, 389, 1),
                UserField74 = GetPositionData(currentByte, 390, 2),
                UserField75 = GetPositionData(currentByte, 392, 2),
                UserField76 = GetPositionData(currentByte, 394, 2),
                UserField77 = GetPositionData(currentByte, 396, 2),
                UserField78 = GetPositionData(currentByte, 398, 2),
                UserField79 = GetPositionData(currentByte, 400, 2),
                UserField80 = GetPositionData(currentByte, 402, 2),
                UserField81 = GetPositionData(currentByte, 404, 2),
                UserField82 = GetPositionData(currentByte, 406, 2),
                UserField83 = GetPositionData(currentByte, 408, 2),
                UserField84 = GetPositionData(currentByte, 410, 2),
                UserField85 = GetPositionData(currentByte, 412, 2),
                UserField86 = GetPositionData(currentByte, 414, 2),
                UserField87 = GetPositionData(currentByte, 416, 2),
                UserField88 = GetPositionData(currentByte, 418, 2),
                UserField89 = GetPositionData(currentByte, 420, 2),
                UserField90 = GetPositionData(currentByte, 422, 2),
                UserField91 = GetPositionData(currentByte, 424, 2),
                UserField92 = GetPositionData(currentByte, 426, 2),
                UserField93 = GetPositionData(currentByte, 428, 2),
                UserField94 = GetPositionData(currentByte, 430, 6),
                UserField95 = GetPositionData(currentByte, 436, 6),
                UserField96 = GetPositionData(currentByte, 442, 6),
                UserField97 = GetPositionData(currentByte, 448, 6),
                UserField98 = GetPositionData(currentByte, 454, 6),
                UserField99 = GetPositionData(currentByte, 460, 6),
                UserField100 = GetPositionData(currentByte, 466, 6),
                UserField101 = GetPositionData(currentByte, 472, 6),
                UserField102 = GetPositionData(currentByte, 478, 6),
                UserField103 = GetPositionData(currentByte, 484, 6),
                UserField104 = GetPositionData(currentByte, 490, 6),
                UserField105 = GetPositionData(currentByte, 496, 6),
                UserField106 = GetPositionData(currentByte, 502, 6),
                UserField107 = GetPositionData(currentByte, 508, 6),
                UserField108 = GetPositionData(currentByte, 514, 6),
                UserField109 = GetPositionData(currentByte, 520, 6),
                UserField110 = GetPositionData(currentByte, 526, 6),
                UserField111 = GetPositionData(currentByte, 532, 6),
                UserField112 = GetPositionData(currentByte, 538, 6),
                UserField113 = GetPositionData(currentByte, 544, 10),
                UserField114 = GetPositionData(currentByte, 554, 10),
                UserField115 = GetPositionData(currentByte, 564, 10),
                UserField116 = GetPositionData(currentByte, 574, 10),
                UserField117 = GetPositionData(currentByte, 584, 10),
                UserField118 = GetPositionData(currentByte, 594, 10),
                UserField119 = GetPositionData(currentByte, 604, 10),
                UserField120 = GetPositionData(currentByte, 614, 10),
                UserField121 = GetPositionData(currentByte, 624, 10),
                UserField122 = GetPositionData(currentByte, 634, 10),
                UserField123 = GetPositionData(currentByte, 644, 10),
                UserField124 = GetPositionData(currentByte, 654, 10),
                UserField125 = GetPositionData(currentByte, 664, 10),
                UserField126 = GetPositionData(currentByte, 674, 10),
                UserField127 = GetPositionData(currentByte, 684, 10),
                UserField128 = GetPositionData(currentByte, 694, 10),
                UserField129 = GetPositionData(currentByte, 704, 10),
                UserField130 = GetPositionData(currentByte, 714, 10),
                UserField131 = GetPositionData(currentByte, 724, 10),
                UserField132 = GetPositionData(currentByte, 734, 10),
                UserField133 = GetPositionData(currentByte, 744, 15),
                UserField134 = GetPositionData(currentByte, 759, 15),
                UserField135 = GetPositionData(currentByte, 774, 15),
                UserField136 = GetPositionData(currentByte, 789, 15),
                UserField137 = GetPositionData(currentByte, 804, 15),
                UserField138 = GetPositionData(currentByte, 819, 15),
                UserField139 = GetPositionData(currentByte, 834, 15),
                UserField140 = GetPositionData(currentByte, 849, 15),
                UserField141 = GetPositionData(currentByte, 864, 15),
                UserField142 = GetPositionData(currentByte, 879, 15),
                UserField143 = GetPositionData(currentByte, 894, 15),
                UserField144 = GetPositionData(currentByte, 909, 15),
                UserField145 = GetPositionData(currentByte, 924, 15),
                UserField146 = GetPositionData(currentByte, 939, 0),
                UserField147 = GetPositionData(currentByte, 954, 15),
                UserField148 = GetPositionData(currentByte, 969, 15),
                UserField149 = GetPositionData(currentByte, 984, 15),
                UserField150 = GetPositionData(currentByte, 999, 15),
                UserField151 = GetPositionData(currentByte, 1014, 15),
                UserField152 = GetPositionData(currentByte, 1029, 15),
                UserField153 = GetPositionData(currentByte, 1044, 35),
                UserField154 = GetPositionData(currentByte, 1079, 35),
                UserField155 = GetPositionData(currentByte, 1114, 35),
                UserField156 = GetPositionData(currentByte, 1149, 35),
                UserField157 = GetPositionData(currentByte, 1184, 35),
                UserField158 = GetPositionData(currentByte, 1219, 35),
                UserField159 = GetPositionData(currentByte, 1254, 35),
                UserField160 = GetPositionData(currentByte, 1289, 35),
                UserField161 = GetPositionData(currentByte, 1324, 35),
                UserField162 = GetPositionData(currentByte, 1359, 35),
                UserField163 = GetPositionData(currentByte, 1394, 35),
                UserField164 = GetPositionData(currentByte, 1429, 35),
                UserField165 = GetPositionData(currentByte, 1464, 35),
                UserField166 = GetPositionData(currentByte, 1499, 35),
                UserField167 = GetPositionData(currentByte, 1534, 35),
                UserField168 = GetPositionData(currentByte, 1569, 35),
                UserField169 = GetPositionData(currentByte, 1604, 35),
                UserField170 = GetPositionData(currentByte, 1639, 35),
                UserField171 = GetPositionData(currentByte, 1674, 35),
                UserField172 = GetPositionData(currentByte, 1709, 35),
                UserField173 = GetPositionData(currentByte, 1744, 60),
                UserField174 = GetPositionData(currentByte, 1804, 60),
                UserField175 = GetPositionData(currentByte, 1864, 60),
                UserField176 = GetPositionData(currentByte, 1924, 60),
                UserField177 = GetPositionData(currentByte, 1984, 60),
                UserField178 = GetPositionData(currentByte, 2044, 60),
                UserField179 = GetPositionData(currentByte, 2104, 60),
                UserField180 = GetPositionData(currentByte, 2164, 60),
                UserField181 = GetPositionData(currentByte, 2224, 60),
                UserField182 = GetPositionData(currentByte, 2284, 60),
                UserField183 = GetPositionData(currentByte, 2344, 60),
                UserField184 = GetPositionData(currentByte, 2404, 60),
                UserField185 = GetPositionData(currentByte, 2464, 60),
                UserField186 = GetPositionData(currentByte, 2524, 60),
                UserField187 = GetPositionData(currentByte, 2584, 60),
                UserField188 = GetPositionData(currentByte, 2644, 60),
                UserField189 = GetPositionData(currentByte, 2704, 60),
                UserField190 = GetPositionData(currentByte, 2764, 60),
                UserField191 = GetPositionData(currentByte, 2824, 60),
                UserField192 = GetPositionData(currentByte, 2884, 60),
                UserField193 = GetPositionData(currentByte, 2944, 75),
                UserField194 = GetPositionData(currentByte, 3019, 75),
                UserField195 = GetPositionData(currentByte, 3094, 1),
                UserField196 = GetPositionData(currentByte, 3095, 1),
                UserField197 = GetPositionData(currentByte, 3096, 1),
                UserField198 = GetPositionData(currentByte, 3097, 1),
                UserField199 = GetPositionData(currentByte, 3098, 1),
                UserField200 = GetPositionData(currentByte, 3099, 1),
                UserField201 = GetPositionData(currentByte, 3100, 1),
                UserField202 = GetPositionData(currentByte, 3101, 1),
                UserField203 = GetPositionData(currentByte, 3102, 1),
                UserField204 = GetPositionData(currentByte, 3103, 1),
                UserField205 = GetPositionData(currentByte, 3104, 1),
                UserField206 = GetPositionData(currentByte, 3105, 1),
                UserField207 = GetPositionData(currentByte, 3106, 1),
                UserField208 = GetPositionData(currentByte, 3107, 1),
                UserField209 = GetPositionData(currentByte, 3108, 1),
                UserField210 = GetPositionData(currentByte, 3109, 1),
                UserField211 = GetPositionData(currentByte, 3110, 1),
                UserField212 = GetPositionData(currentByte, 3111, 1),
                UserField213 = GetPositionData(currentByte, 3112, 1),
                UserField214 = GetPositionData(currentByte, 3113, 1),
                UserField215 = GetPositionData(currentByte, 3114, 2),
                UserField216 = GetPositionData(currentByte, 3116, 2),
                UserField217 = GetPositionData(currentByte, 3118, 2),
                UserField218 = GetPositionData(currentByte, 3120, 2),
                UserField219 = GetPositionData(currentByte, 3122, 2),
                UserField220 = GetPositionData(currentByte, 3124, 2),
                UserField221 = GetPositionData(currentByte, 3126, 2),
                UserField222 = GetPositionData(currentByte, 3128, 2),
                UserField223 = GetPositionData(currentByte, 3130, 2),
                UserField224 = GetPositionData(currentByte, 3132, 2),
                UserField225 = GetPositionData(currentByte, 3134, 2),
                UserField226 = GetPositionData(currentByte, 3136, 2),
                UserField227 = GetPositionData(currentByte, 3138, 2),
                UserField228 = GetPositionData(currentByte, 3140, 2),
                UserField229 = GetPositionData(currentByte, 3142, 2),
                UserField230 = GetPositionData(currentByte, 3144, 2),
                UserField231 = GetPositionData(currentByte, 3146, 2),
                UserField232 = GetPositionData(currentByte, 3148, 2),
                UserField233 = GetPositionData(currentByte, 3150, 2),
                UserField234 = GetPositionData(currentByte, 3152, 2),
                UserField235 = GetPositionData(currentByte, 3154, 4),
                UserField236 = GetPositionData(currentByte, 3158, 4),
                UserField237 = GetPositionData(currentByte, 3162, 4),
                UserField238 = GetPositionData(currentByte, 3166, 4),
                UserField239 = GetPositionData(currentByte, 3170, 4),
                UserField240 = GetPositionData(currentByte, 3174, 4),
                UserField241 = GetPositionData(currentByte, 3178, 4),
                UserField242 = GetPositionData(currentByte, 3182, 4),
                UserField243 = GetPositionData(currentByte, 3186, 4),
                UserField244 = GetPositionData(currentByte, 3190, 4),
                UserField245 = GetPositionData(currentByte, 3194, 4),
                UserField246 = GetPositionData(currentByte, 3198, 4),
                UserField247 = GetPositionData(currentByte, 3202, 4),
                UserField248 = GetPositionData(currentByte, 3206, 4),
                UserField249 = GetPositionData(currentByte, 3210, 4),
                UserField250 = GetPositionData(currentByte, 3214, 4),
                UserField251 = GetPositionData(currentByte, 3218, 4),
                UserField252 = GetPositionData(currentByte, 3222, 4),
                UserField253 = GetPositionData(currentByte, 3226, 4),
                UserField254 = GetPositionData(currentByte, 3230, 4),
                UserField255 = GetPositionData(currentByte, 3234, 6),
                UserField256 = GetPositionData(currentByte, 3240, 6),
                UserField257 = GetPositionData(currentByte, 3246, 6),
                UserField258 = GetPositionData(currentByte, 3252, 6),
                UserField259 = GetPositionData(currentByte, 3258, 6),
                UserField260 = GetPositionData(currentByte, 3264, 6),
                UserField261 = GetPositionData(currentByte, 3270, 6),
                UserField262 = GetPositionData(currentByte, 3276, 6),
                UserField263 = GetPositionData(currentByte, 3282, 6),
                UserField264 = GetPositionData(currentByte, 3288, 6),
                UserField265 = GetPositionData(currentByte, 3294, 6),
                UserField266 = GetPositionData(currentByte, 3300, 6),
                UserField267 = GetPositionData(currentByte, 3306, 6),
                UserField268 = GetPositionData(currentByte, 3312, 6),
                UserField269 = GetPositionData(currentByte, 3318, 6),
                UserField270 = GetPositionData(currentByte, 3324, 6),
                UserField271 = GetPositionData(currentByte, 3330, 6),
                UserField272 = GetPositionData(currentByte, 3336, 6),
                UserField273 = GetPositionData(currentByte, 3342, 6),
                UserField274 = GetPositionData(currentByte, 3348, 6),
                UserField275 = GetPositionData(currentByte, 3354, 4),
                UserField276 = GetPositionData(currentByte, 3358, 4),
                UserField277 = GetPositionData(currentByte, 3362, 4),
                UserField278 = GetPositionData(currentByte, 3366, 4),
                UserField279 = GetPositionData(currentByte, 3370, 4),
                UserField280 = GetPositionData(currentByte, 3374, 4),
                UserField281 = GetPositionData(currentByte, 3378, 4),
                UserField282 = GetPositionData(currentByte, 3382, 4),
                UserField283 = GetPositionData(currentByte, 3386, 4),
                UserField284 = GetPositionData(currentByte, 3390, 4),
                UserField285 = GetPositionData(currentByte, 3394, 4),
                UserField286 = GetPositionData(currentByte, 3398, 4),
                UserField287 = GetPositionData(currentByte, 3402, 4),
                UserField288 = GetPositionData(currentByte, 3406, 4),
                UserField289 = GetPositionData(currentByte, 3410, 4),
                UserField290 = GetPositionData(currentByte, 3414, 4),
                UserField291 = GetPositionData(currentByte, 3418, 4),
                UserField292 = GetPositionData(currentByte, 3422, 4),
                UserField293 = GetPositionData(currentByte, 3426, 4),
                UserField294 = GetPositionData(currentByte, 3430, 4),
                UserField295 = GetPositionData(currentByte, 3434, 5),
                UserField296 = GetPositionData(currentByte, 3439, 5),
                UserField297 = GetPositionData(currentByte, 3444, 5),
                UserField298 = GetPositionData(currentByte, 3449, 5),
                UserField299 = GetPositionData(currentByte, 3454, 5),
                UserField300 = GetPositionData(currentByte, 3459, 5),
                UserField301 = GetPositionData(currentByte, 3464, 5),
                UserField302 = GetPositionData(currentByte, 3469, 5),
                UserField303 = GetPositionData(currentByte, 3474, 5),
                UserField304 = GetPositionData(currentByte, 3479, 5),
                UserField305 = GetPositionData(currentByte, 3484, 5),
                UserField306 = GetPositionData(currentByte, 3489, 5),
                UserField307 = GetPositionData(currentByte, 3494, 5),
                UserField308 = GetPositionData(currentByte, 3499, 5),
                UserField309 = GetPositionData(currentByte, 3504, 5),
                UserField310 = GetPositionData(currentByte, 3509, 5),
                UserField311 = GetPositionData(currentByte, 3514, 5),
                UserField312 = GetPositionData(currentByte, 3519, 5),
                UserField313 = GetPositionData(currentByte, 3524, 5),
                UserField314 = GetPositionData(currentByte, 3529, 5),
                UserField315 = GetPositionData(currentByte, 3534, 6),
                UserField316 = GetPositionData(currentByte, 3540, 6),
                UserField317 = GetPositionData(currentByte, 3546, 6),
                UserField318 = GetPositionData(currentByte, 3552, 6),
                UserField319 = GetPositionData(currentByte, 3558, 6),
                UserField320 = GetPositionData(currentByte, 3564, 6),
                UserField321 = GetPositionData(currentByte, 3570, 6),
                UserField322 = GetPositionData(currentByte, 3576, 6),
                UserField323 = GetPositionData(currentByte, 3582, 6),
                UserField324 = GetPositionData(currentByte, 3588, 6),
                UserField325 = GetPositionData(currentByte, 3594, 6),
                UserField326 = GetPositionData(currentByte, 3600, 6),
                UserField327 = GetPositionData(currentByte, 3606, 6),
                UserField328 = GetPositionData(currentByte, 3612, 6),
                UserField329 = GetPositionData(currentByte, 3618, 6),
                UserField330 = GetPositionData(currentByte, 3624, 6),
                UserField331 = GetPositionData(currentByte, 3630, 6),
                UserField332 = GetPositionData(currentByte, 3636, 6),
                UserField333 = GetPositionData(currentByte, 3642, 6),
                UserField334 = GetPositionData(currentByte, 3648, 6),
                UserField335 = GetPositionData(currentByte, 3654, 7),
                UserField336 = GetPositionData(currentByte, 3661, 7),
                UserField337 = GetPositionData(currentByte, 3668, 7),
                UserField338 = GetPositionData(currentByte, 3675, 7),
                UserField339 = GetPositionData(currentByte, 3682, 7),
                UserField340 = GetPositionData(currentByte, 3689, 7),
                UserField341 = GetPositionData(currentByte, 3696, 7),
                UserField342 = GetPositionData(currentByte, 3703, 7),
                UserField343 = GetPositionData(currentByte, 3710, 7),
                UserField344 = GetPositionData(currentByte, 3717, 7),
                UserField345 = GetPositionData(currentByte, 2724, 1007),
                UserField346 = GetPositionData(currentByte, 3731, 7),
                UserField347 = GetPositionData(currentByte, 3738, 7),
                UserField348 = GetPositionData(currentByte, 3745, 7),
                UserField349 = GetPositionData(currentByte, 3752, 7),
                UserField350 = GetPositionData(currentByte, 3759, 7),
                UserField351 = GetPositionData(currentByte, 3766, 7),
                UserField352 = GetPositionData(currentByte, 3773, 7),
                UserField353 = GetPositionData(currentByte, 3780, 7),
                UserField354 = GetPositionData(currentByte, 3787, 4),
                UserField355 = GetPositionData(currentByte, 3791, 4),
                UserField356 = GetPositionData(currentByte, 3795, 4),
                UserField357 = GetPositionData(currentByte, 3799, 4),
                UserField358 = GetPositionData(currentByte, 3803, 4),
                UserField359 = GetPositionData(currentByte, 3807, 4),
                UserField360 = GetPositionData(currentByte, 3811, 4),
                UserField361 = GetPositionData(currentByte, 3815, 4),
                UserField362 = GetPositionData(currentByte, 3819, 4),
                UserField363 = GetPositionData(currentByte, 3823, 4),
                UserField364 = GetPositionData(currentByte, 3827, 4),
                UserField365 = GetPositionData(currentByte, 3831, 4),
                UserField366 = GetPositionData(currentByte, 3835, 4),
                UserField367 = GetPositionData(currentByte, 3839, 4),
                UserField368 = GetPositionData(currentByte, 3843, 4),
                UserField369 = GetPositionData(currentByte, 3847, 4),
                UserField370 = GetPositionData(currentByte, 3851, 4),
                UserField371 = GetPositionData(currentByte, 3855, 4),
                UserField372 = GetPositionData(currentByte, 3859, 4),
                UserField373 = GetPositionData(currentByte, 3863, 4),
                FillerPart3 = GetPositionData(currentByte, 3867, 144),

            };
        }

        // L Multiple Lockbox Record. One record per loan if applicable.
        public void GetMultiLockboxRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.MultiLockboxRecordModel = new MultiLockboxRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                LoanLockboxIdentification = GetPositionData(currentByte, 20, 1),
                LockboxAddress1 = GetPositionData(currentByte, 21, 35),
                LockboxAddress2 = GetPositionData(currentByte, 56, 35),
                LockboxCity = GetPositionData(currentByte, 91, 20),
                LockboxState = GetPositionData(currentByte, 111, 2),
                LockboxZipCode = GetPositionData(currentByte, 113, 10),

            };
        }

        // R Rate Reduction Record. One record per loan if applicable.
        public void GetRateReductionRecord(byte[] currentByte, ref AccountsModel acc)
        {
            acc.RateReductionRecordModel = new RateReductionRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                RateReductionPlanNumber = GetPositionData(currentByte, 20, 6),
                RateReductionLoanStatus = GetPositionData(currentByte, 26, 1),
                RateReductionTotalReductionToDate = GetPositionData(currentByte, 27, 7),
                RateReductionTiersCompletedToDate = GetPositionData(currentByte, 34, 2),
                RateReductionTierStatus = GetPositionData(currentByte, 36, 1),
                RateReductionDisqualificationDate = GetPositionData(currentByte, 37, 8),
                RateReductionDisqualificationDueDate = GetPositionData(currentByte, 45, 8),
                RateReductionCompletionDate = GetPositionData(currentByte, 53, 8),
                RateReductionCompletionDueDate = GetPositionData(currentByte, 61, 8),
                RateReductionReQualificationDate = GetPositionData(currentByte, 69, 8),
                RateReductionReQualificationDueDate = GetPositionData(currentByte, 77, 8),
                RateReductionLoanRequiredOnTimePayments = GetPositionData(currentByte, 85, 3),
                RateReductionOnTimePaymentsCtr = GetPositionData(currentByte, 88, 2),
                RateReductionRemainingPaymentsCtr = GetPositionData(currentByte, 90, 2),
                RateReductionNewRate = GetPositionData(currentByte, 92, 7),
                RateReductionNewPayment = GetPositionData(currentByte, 99, 7),
                RateReductionNewEffDate = GetPositionData(currentByte, 106, 8),
                RateReductionPaymentDifference = GetPositionData(currentByte, 114, 9),
                RateReductionResetDate = GetPositionData(currentByte, 123, 8),
                RateReductionResetDueDate = GetPositionData(currentByte, 131, 8),
                RateReductionBeginningDueDate = GetPositionData(currentByte, 139, 8),
                RateReductionAmount = GetPositionData(currentByte, 147, 7),


            };
        }

        // E Escrow Payee Data Record. Multiple records per loan if applicable.
        public void GetEscrowRecordModel(byte[] currentByte, ref AccountsModel acc)
        {

            acc.EscrowRecordModel = new EscrowRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                PayeeType = GetPositionData(currentByte, 20, 2),
                EscrowLineCompanyCountyCode = GetPositionData(currentByte, 22, 4),
                EscrowLineAgencyTownshipCode = GetPositionData(currentByte, 26, 5),
                PayeePrimaryName = GetPositionData(currentByte, 31, 35),
                PayeeTelephoneNumber = GetPositionData(currentByte, 66, 11),
                ProductName = GetPositionData(currentByte, 77, 35),
                AmountDueForOneCycle = GetPositionData(currentByte, 112, 11),
                TotalNumberOfPaymentsDue = GetPositionData(currentByte, 123, 2),
                EscrowLineExpirationDate = GetPositionData(currentByte, 125, 6),

            };
        }

        // O Optional Items/Escrow Record. Multiple records per loan if applicable.
        public void GetOptionalItemEscrowRecordModel(byte[] currentByte, ref AccountsModel acc)
        {

            acc.OptionalItemEscrowRecordModel = new OptionalItemEscrowRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                ProductName = GetPositionData(currentByte, 20, 35),
                MonthlyAmount = GetPositionData(currentByte, 55, 11),
                PendingAmount = GetPositionData(currentByte, 66, 11),
                PendingDate = GetPositionData(currentByte, 77, 4),
                EscrowType = GetPositionData(currentByte, 81, 2),
                EscrowLineUncollectedOptIns = GetPositionData(currentByte, 83, 7),
                Filler = GetPositionData(currentByte, 90, 11),

            };
        }

        // F Fee Record. Multiple records per loan if applicable.
        public void GetFeeRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.FeeRecordModel = new FeeRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                FeeType = GetPositionData(currentByte, 20, 3),
                FeeDescription = GetPositionData(currentByte, 23, 23),
                FeeLevelAmortizedFeePayment = GetPositionData(currentByte, 46, 7),
                PreviousFeeBalance = GetPositionData(currentByte, 53, 7),
                NewReceivableFeesAssessed = GetPositionData(currentByte, 60, 7),
                AssessedDate = GetPositionData(currentByte, 67, 7),
                FeesInvoiceCredits = GetPositionData(currentByte, 23, 23),
                FeesNotPreviouslyAssessedThatAreCollectedThisBillingCycle = GetPositionData(currentByte, 83, 7),
                FeeBalanceThisBillingCycle = GetPositionData(currentByte, 83, 7),
                FeesWaivedThisBillingCycle = GetPositionData(currentByte, 90, 7),
                FeeCollectedTransactionDate = GetPositionData(currentByte, 104, 7),
                FeeWaivedTransactionDate = GetPositionData(currentByte, 111, 7),
                RecurringFeesDue = GetPositionData(currentByte, 118, 9),
                RecurringFeePaymentsPastDue = GetPositionData(currentByte, 127, 2),
                FillerPart1 = GetPositionData(currentByte, 129, 4),
                InvoiceExpenseType = GetPositionData(currentByte, 133, 1),
                InvoicePurchaseOrderNumber = GetPositionData(currentByte, 134, 2),
                InvoiceExpenseAmountBilled = GetPositionData(currentByte, 146, 4),
                InvoiceExpenseAmountPaid = GetPositionData(currentByte, 150, 4),
                InvoiceRecoverabilityFlag = GetPositionData(currentByte, 154, 1),
                InvoiceDate = GetPositionData(currentByte, 155, 4),
                DateInvoiceWasPaid = GetPositionData(currentByte, 159, 4),
                InvoiceVendorCode = GetPositionData(currentByte, 163, 7),
                InvoiceResponsibilityCode = GetPositionData(currentByte, 170, 2),
                InvoiceExpenseCode = GetPositionData(currentByte, 172, 2),
                InvoiceNumber = GetPositionData(currentByte, 174, 15),
                InvoiceFunctionalArea = GetPositionData(currentByte, 189, 5),
                FillerPart2 = GetPositionData(currentByte, 194, 207),

            };
        }

        // S Solicitation Record. One record per loan if applicable.
        public void GetSolicitationRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.SolicitationRecordModel = new SolicitationRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                LoanSolicitationCampaignId = GetPositionData(currentByte, 20, 5),
                LoanSolicitationCampaignControl = GetPositionData(currentByte, 25, 3),
                LoanSolicitationCampaignMethod = GetPositionData(currentByte, 28, 3),

            };
        }

        // T Transaction Record. Multiple records per loan if applicable.
        public void GetTransactionRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.TransactionRecordModel = new TransactionRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                DayOfTaskInitiation = GetPositionData(currentByte, 20, 4),
                BinaryTimeOfDayOfTaskInitiation = GetPositionData(currentByte, 24, 4),
                TransactionDate = GetPositionData(currentByte, 28, 4),
                PatternID = GetPositionData(currentByte, 32, 8),
                Filler1 = GetPositionData(currentByte, 40, 1),
                LogTransaction = GetPositionData(currentByte, 41, 4),
                Filler2 = GetPositionData(currentByte, 45, 1),
                TellerOverride = GetPositionData(currentByte, 46, 1),
                Filler3 = GetPositionData(currentByte, 47, 1),
                TransactionAmount = GetPositionData(currentByte, 48, 13),
                CashAmount = GetPositionData(currentByte, 56, 13),
                TellerNumber = GetPositionData(currentByte, 64, 3),
                UnappliedFundCodeBefore = GetPositionData(currentByte, 67, 5),
                UnappliedFundCodeAfter = GetPositionData(currentByte, 72, 5),
                TransactionAmountPrincipal = GetPositionData(currentByte, 77, 6),
                TransactionAmountInterest = GetPositionData(currentByte, 83, 6),
                TransactionAmountEscrow = GetPositionData(currentByte, 89, 5),
                TransactionAmountLateCharge = GetPositionData(currentByte, 94, 5),
                TransactionAmountUncollectedOptionalInsurance = GetPositionData(currentByte, 99, 5),
                TransactionAmountUncollectedInterest = GetPositionData(currentByte, 104, 5),
                TransactionAmountPostedToUnappliedFunds = GetPositionData(currentByte, 109, 5),
                TransactionAmountUncollectedLateCharges = GetPositionData(currentByte, 114, 5),
                TransactionAmountConstructionBalance = GetPositionData(currentByte, 119, 5),
                TransactionPaymentCounter = GetPositionData(currentByte, 124, 2),
                TransactionAmountOptionalInsurance = GetPositionData(currentByte, 126, 2),
                PrincipalBalanceAfterTransaction = GetPositionData(currentByte, 131, 6),
                EscrowBalanceAfterTransaction = GetPositionData(currentByte, 137, 6),
                InterestPaidToDateAfterTransaction = GetPositionData(currentByte, 143, 4),
                StandardEscrowPayment = GetPositionData(currentByte, 147, 5),
                UncollectedCreditInsuranceBalanceAfterTransaction = GetPositionData(currentByte, 152, 4),
                UncollectedInterestBalanceAfterTransaction = GetPositionData(currentByte, 157, 6),
                UnappliedFundsBalanceAfterTransaction = GetPositionData(currentByte, 163, 5),
                UncollectedLateChargeBalanceAfterTransaction = GetPositionData(currentByte, 168, 5),
                LastActivityDateBeforeTransaction = GetPositionData(currentByte, 173, 4),
                ConstructionLoanBalanceAfterTransaction = GetPositionData(currentByte, 177, 5),
                LastActivityDateConstructionLoanBeforeTransaction = GetPositionData(currentByte, 182, 4),
                PreCalculationInterestAmountAfterTransaction = GetPositionData(currentByte, 186, 6),
                PreCalculationInterestDateAfterTransaction = GetPositionData(currentByte, 192, 4),
                TransactionAmountFees = GetPositionData(currentByte, 196, 6),
                FeeCode = GetPositionData(currentByte, 202, 3),
                FeeDescription = GetPositionData(currentByte, 205, 23),
                TransactionAmountNegativeAmortizationTaken = GetPositionData(currentByte, 228, 6),
                TransactionAmountNegativeAmortizationPaid = GetPositionData(currentByte, 234, 6),
                EscrowPayeeTypeCode = GetPositionData(currentByte, 240, 2),
                AmortizedFeePayment = GetPositionData(currentByte, 242, 7),
                TransactionAmountUnappliedFunds2 = GetPositionData(currentByte, 249, 9),
                TransactionAmountUnappliedFunds3 = GetPositionData(currentByte, 258, 9),
                TransactionAmountUnappliedFunds4 = GetPositionData(currentByte, 267, 9),
                TransactionAmountUnappliedFunds5 = GetPositionData(currentByte, 276, 9),
                PurchaseOrderExpenseCode = GetPositionData(currentByte, 285, 3),
                ExpenseFeeDescription = GetPositionData(currentByte, 288, 30),
                ExpenseFeeAmount = GetPositionData(currentByte, 318, 8),
                TransactionAmountToP_IShortage = GetPositionData(currentByte, 324, 9),
                TransactionAmountEscrowShortageOverage = GetPositionData(currentByte, 333, 9),
                AmountToHmpBorrowerIncentive = GetPositionData(currentByte, 342, 7),
                TransactionAmountToPra = GetPositionData(currentByte, 349, 11),
                TransactionAmountPostedToDeferredPrincipal = GetPositionData(currentByte, 360, 6),
                DeferredPrincipalBalanceAfterTransaction = GetPositionData(currentByte, 366, 6),
                TranAmountToDeferredInterest = GetPositionData(currentByte, 372, 6),
                DeferredInterestBalanceAfterTransaction = GetPositionData(currentByte, 378, 6),
                TranAmountToDeferredLateCharge = GetPositionData(currentByte, 384, 5),
                DeferredLateChgBalanceAfterTransaction = GetPositionData(currentByte, 389, 6),
                TranAmountToDeferredEscrowAdv = GetPositionData(currentByte, 395, 5),
                DeferredEscrowAdvanceAfterTransaction = GetPositionData(currentByte, 400, 6),
                TranAmountToDeferredPaidExpensesAdv = GetPositionData(currentByte, 406, 6),
                DeferredPaidExpensesAfterTransaction = GetPositionData(currentByte, 412, 6),
                TranAmountToDeferredUnpaidExpenseAdv = GetPositionData(currentByte, 418, 6),
                DeferredUnpaidExpensesAfterTransaction = GetPositionData(currentByte, 424, 6),
                TranAmountToDeferredAdminFees = GetPositionData(currentByte, 430, 6),
                DeferredAdminFeesBalAfterTransaction = GetPositionData(currentByte, 436, 6),
                OptionalDeferredAmount = GetPositionData(currentByte, 442, 5),
                DeferredOptionalInsAfterTransaction = GetPositionData(currentByte, 447, 6),
                TransactionAmountEscrowPart2 = GetPositionData(currentByte, 453, 6),
                Filler4 = GetPositionData(currentByte, 459, 1042),

            };
        }

        // C Foreign Information Record. One record per loan if applicable.
        public void GetForeignInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.ForeignInformationRecordModel = new ForeignInformationRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 2, 4),
                SequenceNumber = GetPositionData(currentByte, 2, 5),
                PrimaryBorrowerSIdNumber = GetPositionData(currentByte, 2, 6),
                PrimaryBorrowerPrefix = GetPositionData(currentByte, 2, 7),
                PrimaryBorrowerSuffix = GetPositionData(currentByte, 2, 8),
                Attention = GetPositionData(currentByte, 2, 9),
                MailCountry = GetPositionData(currentByte, 2, 10),
                MailZipCode = GetPositionData(currentByte, 2, 11),
                PrimaryBorrowerHomeTelephoneNumberCountryCode = GetPositionData(currentByte, 2, 12),
                PrimaryBorrowerHomeTelephoneNumber = GetPositionData(currentByte, 2, 13),
                PrimaryBorrowerWorkTelephoneNumberCountryCode = GetPositionData(currentByte, 2, 14),
                PrimaryBorrowerWorkTelephoneNumber = GetPositionData(currentByte, 2, 15),
                PrimaryBorrowerFaxTelephoneNumberCountryCode = GetPositionData(currentByte, 2, 16),
                PrimaryBorrowerFaxTelephoneNumber = GetPositionData(currentByte, 2, 17),
                PrimaryBorrowerCellTelephoneNumberCountryCode = GetPositionData(currentByte, 2, 18),
                PrimaryBorrowerCellTelephoneNumber = GetPositionData(currentByte, 2, 19),
                PropertyCountry = GetPositionData(currentByte, 2, 20),
                PropertyZipCode = GetPositionData(currentByte, 2, 21),
                AlternateMailCountry = GetPositionData(currentByte, 2, 22),
                AlternateZipCode = GetPositionData(currentByte, 2, 23),
                Filler = GetPositionData(currentByte, 2, 24),

            };
        }

        // D Blended Rate Information Record. One record per loan if applicable.
        public void GetBlendedRateInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.BlendedRateInformationRecordModel = new BlendedRateInformationRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                SpecialProductType = GetPositionData(currentByte, 20, 1),
                SpecialLoanTypeId = GetPositionData(currentByte, 21, 1),
                AlternativeChangeAmount1 = GetPositionData(currentByte, 22, 6),
                AlternativeChangeAmount2 = GetPositionData(currentByte, 28, 6),
                AlternativeChangeAmount3 = GetPositionData(currentByte, 34, 6),
                AlternativeChangeAmount4 = GetPositionData(currentByte, 40, 6),
                AlternativePaymentAmount1 = GetPositionData(currentByte, 46, 6),
                AlternativePaymentAmount2 = GetPositionData(currentByte, 52, 6),
                AlternativePaymentAmount3 = GetPositionData(currentByte, 58, 6),
                AlternativePaymentAmount4 = GetPositionData(currentByte, 64, 6),
                BlendedAdjustableRate = GetPositionData(currentByte, 70, 4),
                BlendedFixedRate = GetPositionData(currentByte, 74, 4),
                BlendedRateAdjustableComponent = GetPositionData(currentByte, 78, 4),
                BlendedRateFixedComponent = GetPositionData(currentByte, 82, 4),
                BlendedRateFlag = GetPositionData(currentByte, 86, 1),
                BlendedRateMargin = GetPositionData(currentByte, 87, 4),
                BlendedRateTerm = GetPositionData(currentByte, 91, 2),
                OriginalBlendedAdjustablePercent = GetPositionData(currentByte, 93, 4),
                OriginalBlendedFixedPercent = GetPositionData(currentByte, 97, 4),
                BlendedRateLoanOptionIndicator = GetPositionData(currentByte, 101, 1),
                CurrentBlendedRateFixedPerc = GetPositionData(currentByte, 102, 11),
                CurrentBlendedRateAdjustablePerc = GetPositionData(currentByte, 113, 11),
                Filler1 = GetPositionData(currentByte, 124, 277),
            };
        }


        //  I Co-borrower Record. One record per loan if applicable.
        public void GetCoBorrowerRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.CoBorrowerRecordModel = new CoBorrowerRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                RecordNumber = GetPositionData(currentByte, 15, 5),
                CoborrowerName01 = GetPositionData(currentByte, 20, 35),
                CoborrowerAddressLine101 = GetPositionData(currentByte, 55, 35),
                CoborrowerAddressLine201 = GetPositionData(currentByte, 90, 35),
                CoborrowerCity01 = GetPositionData(currentByte, 125, 21),
                CoborrowerState01 = GetPositionData(currentByte, 146, 2),
                CoborrowerZipCode01 = GetPositionData(currentByte, 148, 10),
                CoborrowerBillingStatement01 = GetPositionData(currentByte, 158, 1),
                CoborrowerName02 = GetPositionData(currentByte, 159, 35),
                CoborrowerAddressLine102 = GetPositionData(currentByte, 194, 35),
                CoborrowerAddressLine202 = GetPositionData(currentByte, 229, 35),
                CoborrowerCity02 = GetPositionData(currentByte, 264, 21),
                CoborrowerState02 = GetPositionData(currentByte, 285, 2),
                CoborrowerZipCode02 = GetPositionData(currentByte, 287, 10),
                CoborrowerBillingStatement02 = GetPositionData(currentByte, 297, 1),
                CoborrowerName03 = GetPositionData(currentByte, 298, 35),
                CoborrowerAddressLine103 = GetPositionData(currentByte, 333, 35),
                CoborrowerAddressLine203 = GetPositionData(currentByte, 368, 35),
                CoborrowerCity03 = GetPositionData(currentByte, 403, 21),
                CoborrowerState03 = GetPositionData(currentByte, 424, 2),
                CoborrowerZipCode03 = GetPositionData(currentByte, 426, 10),
                CoborrowerStatement03 = GetPositionData(currentByte, 436, 1),
                CoborrowerName04 = GetPositionData(currentByte, 437, 35),
                CoborrowerAddressLine104 = GetPositionData(currentByte, 472, 35),
                CoborrowerAddressLine204 = GetPositionData(currentByte, 507, 35),
                CoborrowerCity04 = GetPositionData(currentByte, 542, 21),
                CoborrowerState04 = GetPositionData(currentByte, 563, 2),
                CoborrowerZipCode04 = GetPositionData(currentByte, 565, 10),
                CoborrowerBillingStatement04 = GetPositionData(currentByte, 575, 1),
                CoborrowerName05 = GetPositionData(currentByte, 576, 35),
                CoborrowerAddressLine105 = GetPositionData(currentByte, 611, 35),
                CoborrowerAddressLine205 = GetPositionData(currentByte, 646, 35),
                CoborrowerCity05 = GetPositionData(currentByte, 681, 21),
                CoborrowerState05 = GetPositionData(currentByte, 702, 2),
                CoborrowerZipCode05 = GetPositionData(currentByte, 704, 10),
                CoborrowerBillingStatement05 = GetPositionData(currentByte, 714, 1),
                CoborrowerName06 = GetPositionData(currentByte, 715, 35),
                CoborrowerAddressLine106 = GetPositionData(currentByte, 750, 35),
                CoborrowerAddressLine206 = GetPositionData(currentByte, 785, -65),
                CoborrowerCity06 = GetPositionData(currentByte, 820, 21),
                CoborrowerState04Part2 = GetPositionData(currentByte, 841, 2),
                CoborrowerZipCode06 = GetPositionData(currentByte, 843, 10),
                CoborrowerBillingStatement06 = GetPositionData(currentByte, 853, 1),
                CoborrowerName07 = GetPositionData(currentByte, 854, 35),
                CoborrowerAddressLine107 = GetPositionData(currentByte, 889, 35),
                CoborrowerAddressLine207 = GetPositionData(currentByte, 924, 35),
                CoborrowerCity07 = GetPositionData(currentByte, 959, 21),
                CoborrowerState07 = GetPositionData(currentByte, 980, 2),
                CoborrowerZipCode07 = GetPositionData(currentByte, 982, 10),
                CoborrowerBillingStatement07 = GetPositionData(currentByte, 992, 1),
                CoborrowerName08 = GetPositionData(currentByte, 993, 35),
                CoborrowerAddressLine108 = GetPositionData(currentByte, 1028, 35),
                CoborrowerAddressLine208 = GetPositionData(currentByte, 1063, 35),
                CoborrowerCity08 = GetPositionData(currentByte, 1098, 21),
                CoborrowerState08 = GetPositionData(currentByte, 1119, 2),
                CoborrowerZipCode08 = GetPositionData(currentByte, 1121, 10),
                CoborrowerBillingStatement08 = GetPositionData(currentByte, 1131, 1),
                CoborrowerName09 = GetPositionData(currentByte, 1132, 35),
                CoborrowerAddressLine109 = GetPositionData(currentByte, 1167, 35),
                CoborrowerAddressLine209 = GetPositionData(currentByte, 1202, 35),
                CoborrowerCity09 = GetPositionData(currentByte, 1237, 121),
                CoborrowerState09 = GetPositionData(currentByte, 1258, 2),
                CoborrowerZipCode09 = GetPositionData(currentByte, 1260, 10),
                CoborrowerBillingStatement09 = GetPositionData(currentByte, 1270, 1),
                CoborrowerName10 = GetPositionData(currentByte, 1271, 35),
                CoborrowerAddressLine110 = GetPositionData(currentByte, 1306, 35),
                CoborrowerAddressLine210 = GetPositionData(currentByte, 1341, 35),
                CoborrowerCity10 = GetPositionData(currentByte, 1376, 21),
                CoborrowerState10 = GetPositionData(currentByte, 1397, 2),
                CoborrowerZipCode10 = GetPositionData(currentByte, 1399, 10),
                CoborrowerBillingStatement10 = GetPositionData(currentByte, 1409, 1),
                Coborrower1CorrespondenceFlag = GetPositionData(currentByte, 1410, 1),
                Coborrower2CorrespondenceFlag = GetPositionData(currentByte, 1411, 1),
                Coborrower3CorrespondenceFlag = GetPositionData(currentByte, 1412, 1),
                Coborrower4CorrespondenceFlag = GetPositionData(currentByte, 1413, 1),
                Coborrower5CorrespondenceFlag = GetPositionData(currentByte, 1414, 1),
                Coborrower6CorrespondenceFlag = GetPositionData(currentByte, 1415, 1),
                Coborrower7CorrespondenceFlag = GetPositionData(currentByte, 1416, 1),
                Coborrower8CorrespondenceFlag = GetPositionData(currentByte, 1417, 1),
                Coborrower9CorrespondenceFlag = GetPositionData(currentByte, 1418, 1),
                Coborrower10CorrespondenceFlag = GetPositionData(currentByte, 1419, 1),
                BorrowerType01 = GetPositionData(currentByte, 1420, 1),
                CoborrowerSiiVerified01 = GetPositionData(currentByte, 1421, 1),
                BorrowerType02 = GetPositionData(currentByte, 1422, 1),
                CoborrowerSiiVerified02 = GetPositionData(currentByte, 1423, 1),
                BorrowerType03 = GetPositionData(currentByte, 1424, 1),
                CoborrowerSiiVerified03 = GetPositionData(currentByte, 1425, 1),
                BorrowerType04 = GetPositionData(currentByte, 1426, 1),
                CoborrowerSiiVerified04 = GetPositionData(currentByte, 1427, 1),
                BorrowerType05 = GetPositionData(currentByte, 1428, 1),
                CoborrowerSiiVerified05 = GetPositionData(currentByte, 1429, 1),
                BorrowerType06 = GetPositionData(currentByte, 1430, 1),
                CoborrowerSiiVerified06 = GetPositionData(currentByte, 1431, 1),
                BorrowerType07 = GetPositionData(currentByte, 1432, 1),
                CoborrowerSiiVerified07 = GetPositionData(currentByte, 1433, 1),
                BorrowerType08 = GetPositionData(currentByte, 1434, 1),
                CoborrowerSiiVerified08 = GetPositionData(currentByte, 1435, 1),
                BorrowerType09 = GetPositionData(currentByte, 1436, 1),
                CoborrowerSiiVerified09 = GetPositionData(currentByte, 1437, 1),
                BorrowerType10 = GetPositionData(currentByte, 1438, 1),
                CoborrowerSiiVerified10 = GetPositionData(currentByte, 1439, 1),
                CoBorrowerEmailIndicator1 = GetPositionData(currentByte, 1440, 1),
                CoBorrowerEmailIndicator2 = GetPositionData(currentByte, 1441, 1),
                CoBorrowerEmailIndicator3 = GetPositionData(currentByte, 1442, 1),
                CoBorrowerEmailIndicator4 = GetPositionData(currentByte, 1443, 1),
                CoBorrowerEmailIndicator5 = GetPositionData(currentByte, 1444, 1),
                CoBorrowerEmailIndicator6 = GetPositionData(currentByte, 1445, 1),
                CoBorrowerEmailIndicator7 = GetPositionData(currentByte, 1446, 1),
                CoBorrowerEmailIndicator8 = GetPositionData(currentByte, 1447, 1),
                CoBorrowerEmailIndicator9 = GetPositionData(currentByte, 1448, 1),
                CoBorrowerEmailIndicator10 = GetPositionData(currentByte, 1449, 1),
                Filler1 = GetPositionData(currentByte, 1450, 2561),

            };
        }

        // < Late Charge Information Record. One record per loan if applicable.
        public void GetLateChargeInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.LateChargeInformationRecordModel = new LateChargeInformationRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                InterestPaidToDate = GetPositionData(currentByte, 20, 4),
                LateChargeCode = GetPositionData(currentByte, 24, 1),
                LateChargeAssessCode = GetPositionData(currentByte, 25, 1),
                LateChargePaidToDate = GetPositionData(currentByte, 26, 4),
                LateChargeCollectionMethod = GetPositionData(currentByte, 30, 1),
                LateChargeFactor = GetPositionData(currentByte, 31, 3),
                LateChargeAssessmentMethod = GetPositionData(currentByte, 34, 1),
                LateChargeMaximum = GetPositionData(currentByte, 35, 4),
                LateChargeMinimum = GetPositionData(currentByte, 39, 4),
                LateChargesAssessmentMaximumAnnual = GetPositionData(currentByte, 43, 5),
                LateChargeAssessmentMaximumLifeTime = GetPositionData(currentByte, 48, 5),
                LateChargeCounter = GetPositionData(currentByte, 53, 2),
                LateChargeFreezeDateTo = GetPositionData(currentByte, 55, 4),
                LateChargeFreezeDateFrom = GetPositionData(currentByte, 59, 4),
                LateChargeFreezeDateType = GetPositionData(currentByte, 63, 1),
                LateChargeYearType = GetPositionData(currentByte, 64, 2),
                LateChargesAssessedLifeOfLoan = GetPositionData(currentByte, 66, 5),
                LateChargesAssessedYtd = GetPositionData(currentByte, 71, 5),
                Filler = GetPositionData(currentByte, 76, 130),

            };
        }

        // - Late Charge Detail Record.One record per loan if applicable.
        public void GetLateChargeDetailRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.LateChargeDetailRecordModel = new LateChargeDetailRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                LateChargePaymentDueDate = GetPositionData(currentByte, 20, 4),
                LateChargeDueDate = GetPositionData(currentByte, 24, 4),
                LateChargeCalculatedDate = GetPositionData(currentByte, 28, 4),
                LateChargeAmountForLcDueDate = GetPositionData(currentByte, 32, 5),
                LateChargePaidDate = GetPositionData(currentByte, 37, 4),
                LateChargeFactor = GetPositionData(currentByte, 41, 3),
                LateChargeCalculationMethod = GetPositionData(currentByte, 44, 1),
                LateChargeWaiverDate = GetPositionData(currentByte, 45, 4),
                LateChargeWaiverCode = GetPositionData(currentByte, 49, 1),
                LateChargeReversalDate = GetPositionData(currentByte, 50, 4),
                LateChargePaidAmount = GetPositionData(currentByte, 54, 5),
                LateChargeWaiverAmount = GetPositionData(currentByte, 59, 5),
                LateChargeReversalAmount = GetPositionData(currentByte, 64, 5),
                LateChargeAdjDate = GetPositionData(currentByte, 69, 4),
                LateChargePaymentDueDate2 = GetPositionData(currentByte, 73, 5),
                LateChargeOsBalance = GetPositionData(currentByte, 78, 5),
                Filler = GetPositionData(currentByte, 83, 123),

            };
        }

        // J Active Bankruptcy Information Record. One record per loan if applicable.
        public void GetActiveBankruptcyInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.ActiveBankruptcyInformationRecordModel = new ActiveBankruptcyInformationRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                BankruptcyType = GetPositionData(currentByte, 20, 1),
                BkrFilingChapterNumberPrior1 = GetPositionData(currentByte, 21, 2),
                BkrFilingCaseNumber1 = GetPositionData(currentByte, 23, 12),
                BkrFiledBy1 = GetPositionData(currentByte, 35, 1),
                BkrFilingDebtorActive = GetPositionData(currentByte, 36, 35),
                BankruptcyFiledByCodebtor = GetPositionData(currentByte, 71, 35),
                BkrFiledByCoborrowerIndicator1 = GetPositionData(currentByte, 106, 1),
                BankruptcyFiledByCoborrowerIndicator2Active = GetPositionData(currentByte, 107, 1),
                BankruptcyFiledByCoborrowerIndicator3Active = GetPositionData(currentByte, 108, 1),
                BankruptcyFiledByCoborrowerIndicator4Active = GetPositionData(currentByte, 109, 1),
                BankruptcyFiledByCoborrowerIndicator5Active = GetPositionData(currentByte, 110, 1),
                BankruptcyFiledByCoborrowerIndicator6Active = GetPositionData(currentByte, 111, 1),
                BankruptcyFiledByCoborrowerIndicator7Active = GetPositionData(currentByte, 112, 1),
                BankruptcyFiledByCoborrowerIndicator8Active = GetPositionData(currentByte, 113, 1),
                BankruptcyFiledByCoborrowerIndicator9Active = GetPositionData(currentByte, 114, 1),
                BankruptcyFiledByCoborrowerIndicator10Active = GetPositionData(currentByte, 115, 1),
                BankruptcyDateFiledActive = GetPositionData(currentByte, 116, 4),
                BankruptcyConversionDateActive = GetPositionData(currentByte, 120, 4),
                BankruptcyReaffirmationDateActive = GetPositionData(currentByte, 124, 4),
                BankruptcyDischargeDateActive = GetPositionData(currentByte, 128, 4),
                BankruptcyDismissedDateActive = GetPositionData(currentByte, 132, 4),
                BankruptcyMotionForReliefActive = GetPositionData(currentByte, 136, 4),
                ConcurrentBankruptcyTypeActive = GetPositionData(currentByte, 140, 1),
                ConcurrentBankruptcyChapterActive = GetPositionData(currentByte, 141, 2),
                ConcurrentBankruptcyCaseNumberActive = GetPositionData(currentByte, 143, 12),
                ConcurrentBankruptcyFiledByCodeActive = GetPositionData(currentByte, 155, 1),
                ConcurrentBankruptcyFiledByNameActive = GetPositionData(currentByte, 156, 25),
                ConcurrentBankruptcyCoDebtorNameActive = GetPositionData(currentByte, 181, 25),
                ConcurrentBankruptcyFiledByCoborrowerIndicator1Active = GetPositionData(currentByte, 206, 1),
                ConcurrentBankruptcyFiledByCoborrowerIndicator2Active = GetPositionData(currentByte, 207, 1),
                ConcurrentBankruptcyFiledByCoborrowerIndicator3Active = GetPositionData(currentByte, 208, 1),
                ConcurrentBankruptcyFiledByCoborrowerIndicator4Active = GetPositionData(currentByte, 209, 1),
                ConcurrentBankruptcyFiledByCoborrowerIndicator5Active = GetPositionData(currentByte, 210, 1),
                ConcurrentBankruptcyFiledByCoborrowerIndicator6Active = GetPositionData(currentByte, 211, 1),
                ConcurrentBankruptcyFiledByCoborrowerIndicator7Active = GetPositionData(currentByte, 212, 1),
                ConcurrentBankruptcyFiledByCoborrowerIndicator8Active = GetPositionData(currentByte, 213, 1),
                ConcurrentBankruptcyFiledByCoborrowerIndicator9Active = GetPositionData(currentByte, 214, 1),
                ConcurrentBankruptcyFiledByCoborrowerIndicator10Active = GetPositionData(currentByte, 215, 1),
                ConcurrentBankruptcyFiledByDateActive = GetPositionData(currentByte, 216, 4),
                ConcurrentBankruptcyConversionDateActive = GetPositionData(currentByte, 220, 4),
                ConcurrentBankruptcyReaffirmationDateActive = GetPositionData(currentByte, 224, 4),
                ConcurrentBankruptcyDischargedDateActive = GetPositionData(currentByte, 228, 4),
                ConcurrentBankruptcyDismissedDateActive = GetPositionData(currentByte, 232, 4),
                ConcurrentBankruptcyReliefGrantedDateActive = GetPositionData(currentByte, 236, 4),
                BankruptcyPostPetitionAmountDue = GetPositionData(currentByte, 240, 6),
                BankruptcyPostPetitionLateChangeAmount = GetPositionData(currentByte, 246, 5),
                TotalReceivedDuringBkrPrePetition = GetPositionData(currentByte, 251, 5),
                PostPetitionFeesAndCharges = GetPositionData(currentByte, 256, 5),
                PrePetitionFundsReceivedLastBillingCycle = GetPositionData(currentByte, 261, 5),
                PrePetitionArrearage = GetPositionData(currentByte, 266, 5),
                BankruptcyStatementNotice = GetPositionData(currentByte, 271, 1),
                BankruptcyAttorneyName = GetPositionData(currentByte, 272, 35),
                BankruptcyAttorneyAddress1 = GetPositionData(currentByte, 307, 35),
                BankruptcyAttorneyAddress2 = GetPositionData(currentByte, 342, 35),
                BankruptcyAttorneyCity = GetPositionData(currentByte, 377, 21),
                BankruptcyAttorneyState = GetPositionData(currentByte, 398, 2),
                BankruptcyAttorneyZip = GetPositionData(currentByte, 400, 10),
                PrePetitionSuspenseBalance = GetPositionData(currentByte, 410, 6),
                PostPetitionSuspenseBalance = GetPositionData(currentByte, 416, 6),
                PostPetitionSuspenseBalanceAgreedOrder = GetPositionData(currentByte, 422, 6),
                PostPetitionAoAmountDue = GetPositionData(currentByte, 428, 5),
                PostPetitionAoDueDate = GetPositionData(currentByte, 433, 4),
                BkrCramDownFlag = GetPositionData(currentByte, 437, 1),
                PastUnpaidPostPetitionAmounts = GetPositionData(currentByte, 438, 5),
                BkrDischarged = GetPositionData(currentByte, 443, 1),
                PostPetitionShortfall = GetPositionData(currentByte, 444, 6),
                PostPetitionAoShortfall = GetPositionData(currentByte, 450, 6),
                PrePetitionDueDate = GetPositionData(currentByte, 456, 4),
                PrePetitionPaymentAmount = GetPositionData(currentByte, 460, 6),
                PrePetitionShortfall = GetPositionData(currentByte, 466, 6),
                PostPetitionPaymentDate = GetPositionData(currentByte, 472, 8),
                PostPetitionPaymentAmount = GetPositionData(currentByte, 480, 6),
                PostPetitionLateChargeAmount = GetPositionData(currentByte, 486, 4),
                Filler = GetPositionData(currentByte, 490, 511),

            };
        }

        // K Archived Bankruptcy Information Record. Multiple records per loan if applicable.
        public void GetArchivedBankruptcyDetailRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.ArchivedBankruptcyDetailRecordModel = new ArchivedBankruptcyDetailRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                BankruptcyTypeArchive = GetPositionData(currentByte, 20, 1),
                BankruptcyChapterArchive = GetPositionData(currentByte, 21, 2),
                BankruptcyCaseNumberArchive = GetPositionData(currentByte, 23, 12),
                BankruptcyFiledByCodeArchive = GetPositionData(currentByte, 35, 1),
                BankruptcyFiledByNameArchive = GetPositionData(currentByte, 36, 35),
                BankruptcyFiledByCodebtorName = GetPositionData(currentByte, 71, 35),
                BankruptcyFiledByCoborrowerIndicator1Archive = GetPositionData(currentByte, 106, 1),
                BankruptcyFiledByCoborrowerIndicator2Archive = GetPositionData(currentByte, 107, 1),
                BankruptcyFiledByCoborrowerIndicator3Archive = GetPositionData(currentByte, 108, 1),
                BankruptcyFiledByCoborrowerIndicator4Archive = GetPositionData(currentByte, 109, 1),
                BankruptcyFiledByCoborrowerIndicator5Archive = GetPositionData(currentByte, 110, 1),
                BankruptcyFiledByCoborrowerIndicator6Archive = GetPositionData(currentByte, 111, 1),
                BankruptcyFiledByCoborrowerIndicator7Archive = GetPositionData(currentByte, 112, 1),
                BankruptcyFiledByCoborrowerIndicator8Archive = GetPositionData(currentByte, 113, 1),
                BankruptcyFiledByCoborrowerIndicator9Archive = GetPositionData(currentByte, 114, 1),
                BankruptcyFiledByCoborrowerIndicator10Archive = GetPositionData(currentByte, 115, 1),
                BankruptcyDateFiledArchive = GetPositionData(currentByte, 116, 4),
                BankruptcyConversionDateArchive = GetPositionData(currentByte, 120, 4),
                BankruptcyReaffirmationDateArchive = GetPositionData(currentByte, 124, 4),
                BankruptcyDischargeDateArchive = GetPositionData(currentByte, 128, 4),
                BankruptcyDismissedDateArchive = GetPositionData(currentByte, 132, 4),
                BankruptcyMotionForReliefArchive = GetPositionData(currentByte, 136, 4),
                BankruptcyStatementNoticeArchive = GetPositionData(currentByte, 140, 1),
                Filler = GetPositionData(currentByte, 141, 160),

            };
        }

        // X Email Addresses Record
        public void GetEmailAddressRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.EmailAddressRecordModel = new EmailAddressRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionCode = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                PrimaryBorrowerEMailAddress = GetPositionData(currentByte, 20, 60),
                SecondaryBorrowerEMailAddress = GetPositionData(currentByte, 80, 60),
                EStatementEmailAddress1 = GetPositionData(currentByte, 140, 60),
                EStatementEmailAddress2 = GetPositionData(currentByte, 200, 60),
                EStatementEmailAddress3 = GetPositionData(currentByte, 260, 60),
                EStatementEmailAddress4 = GetPositionData(currentByte, 320, 60),
                EStatementEmailAddress5 = GetPositionData(currentByte, 380, 60),
                EStatementEmailAddress6 = GetPositionData(currentByte, 440, 60),
                EStatementEmailAddress7 = GetPositionData(currentByte, 500, 60),
                EStatementEmailAddress8 = GetPositionData(currentByte, 560, 60),
                EStatementEmailAddress9 = GetPositionData(currentByte, 620, 60),
                EStatementEmailAddress10 = GetPositionData(currentByte, 680, 60),
                CoBorrowerEmailAddress1 = GetPositionData(currentByte, 740, 60),
                CoBorrowerEmailAddress2 = GetPositionData(currentByte, 800, 60),
                CoBorrowerEmailAddress3 = GetPositionData(currentByte, 860, 60),
                CoBorrowerEmailAddress4 = GetPositionData(currentByte, 920, 60),
                CoBorrowerEmailAddress5 = GetPositionData(currentByte, 980, 60),
                CoBorrowerEmailAddress6 = GetPositionData(currentByte, 1040, 60),
                CoBorrowerEmailAddress7 = GetPositionData(currentByte, 1100, 60),
                CoBorrowerEmailAddress8 = GetPositionData(currentByte, 1160, 60),
                CoBorrowerEmailAddress9 = GetPositionData(currentByte, 1220, 60),
                CoBorrowerEmailAddress10 = GetPositionData(currentByte, 1280, 60),
                Filler = GetPositionData(currentByte, 1340, 2671),

            };
        }

        // 3 Disaster Tracking Record
        public void GetDisasterTrackingRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.DisasterTrackingRecordModel = new DisasterTrackingRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                DisasterOccurrenceNumber = GetPositionData(currentByte, 20, 3),
                DisasterStatus = GetPositionData(currentByte, 23, 1),
                DisasterName = GetPositionData(currentByte, 24, 35),
                DisasterType = GetPositionData(currentByte, 59, 2),
                DesignationDate = GetPositionData(currentByte, 61, 4),
                DisasterEndDate = GetPositionData(currentByte, 65, 4),
                DisasterExtendedEndDate = GetPositionData(currentByte, 69, 4),
                DeclarationNumber = GetPositionData(currentByte, 73, 10),
                ApplicantNumber = GetPositionData(currentByte, 83, 10),
                PropertyImpact = GetPositionData(currentByte, 93, 1),
                PropertyImpactDeterminationDate = GetPositionData(currentByte, 94, 4),
                PropertyImpactResolutionDate = GetPositionData(currentByte, 98, 4),
                PropertyImpactSeverity = GetPositionData(currentByte, 102, 1),
                WorkplaceImpact = GetPositionData(currentByte, 103, 1),
                WorkplaceImpactDeterminationDate = GetPositionData(currentByte, 104, 4),
                WorkplaceImpactResolutionDate = GetPositionData(currentByte, 108, 4),
                WorkplaceImpactSeverity = GetPositionData(currentByte, 112, 1),
                AttemptedContact = GetPositionData(currentByte, 113, 1),
                DateAttempted = GetPositionData(currentByte, 114, 4),
                ContactMade = GetPositionData(currentByte, 118, 1),
                DateContacted = GetPositionData(currentByte, 119, 4),
                Filler = GetPositionData(currentByte, 123, 78),
            };
        }

        // 4 RHCDS Only Record(Only created if RHCDS Option (DB-2: I-RHCDS-OPT) =‘Y’)
        public void GetRHCDRecords(byte[] currentByte, ref AccountsModel acc)
        {
            acc.RHCDSOnlyRecordModel = new RHCDSOnlyRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionCode = GetPositionData(currentByte, 2, 3),
                AccountNumber = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                AssistanceAgreementExpirationDate = GetPositionData(currentByte, 20, 4),
                SubsidyPaidYearToDate = GetPositionData(currentByte, 24, 5),
                MoratoriumEffectiveDate = GetPositionData(currentByte, 29, 4),
                MoratoriumFlag = GetPositionData(currentByte, 33, 1),
                MoratoriumExpirationDate = GetPositionData(currentByte, 34, 4),
                NoticeControl = GetPositionData(currentByte, 38, 1),
                PendingStartDate = GetPositionData(currentByte, 39, 4),
                BankruptcyFlag = GetPositionData(currentByte, 43, 1),
                BankruptcyTypeCode = GetPositionData(currentByte, 44, 1),
                RepaymentPlanStatusFlag = GetPositionData(currentByte, 45, 1),
                RepaymentPlanCancellationDate = GetPositionData(currentByte, 46, 4),
                RepaymentPlanAdditionalPaymentAmount = GetPositionData(currentByte, 50, 5),
                RepaymentPlanTerm = GetPositionData(currentByte, 55, 2),
                RepaymentPlanCreationDate = GetPositionData(currentByte, 57, 4),
                DownpaymentAmount = GetPositionData(currentByte, 61, 5),
                PlanPaymentStartDate = GetPositionData(currentByte, 66, 4),
                AmountOfDwaDelinquency = GetPositionData(currentByte, 70, 4),
                PostPetitionReaffAgrmtPlanSource = GetPositionData(currentByte, 74, 1),

            };
        }

        // Z Trailer. One record per file.
        public void GetTrailerRecords(byte[] currentByte, ref AccountsModel acc)
        {
            acc.TrailerRecordModel = new TrailerRecordModel()
            {

                RecordIdentifier = GetPositionData(currentByte, 1, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                Filler1 = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                TotalNumberOfBRecords = GetPositionData(currentByte, 20, 1),
                TotalNumberOfARecords = GetPositionData(currentByte, 21, 9),
                TotalNumberOfRRecords = GetPositionData(currentByte, 30, 9),
                TotalNumberOfERecords = GetPositionData(currentByte, 30, 15),
                TotalNumberOfTRecords = GetPositionData(currentByte, 54, 15),
                TotalNumberOfORecords = GetPositionData(currentByte, 69, 9),
                TotalNumberOfFRecords = GetPositionData(currentByte, 78, 9),
                TotalNumberOfURecords = GetPositionData(currentByte, 87, 9),
                TotalNumberOf2Records = GetPositionData(currentByte, 96, 9),
                TotalNumberOfPRecords = GetPositionData(currentByte, 105, 9),
                TotalNumberOfLRecords = GetPositionData(currentByte, 114, 9),
                TotalNumberOfSRecords = GetPositionData(currentByte, 123, 9),
                TotalNumberOfFrRecords = GetPositionData(currentByte, 132, 9),
                TotalNumberOfRecordsIncludingHeaderAndTrailerRecords = GetPositionData(currentByte, 141, 15),
                TotalLoanCount = GetPositionData(currentByte, 156, 9),

            };
        }

        public string GetPositionData(byte[] currentByte, int startPos, int fieldLength)
        {
            try
            {
                return Encoding.Default.GetString(currentByte, startPos - 1, fieldLength);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        #endregion


    }
}
