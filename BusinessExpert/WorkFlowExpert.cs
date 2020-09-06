using Carrington_Service.Infrastructure;
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
        public WorkFlowExpert(IConfigHelper configHelper, ILogger logger, IAgentApi apiAgent)
        {
            ConfigHelper = configHelper;
            Logger = logger;
            ApiAgent = apiAgent;
            //configHelper.Model.DatabaseSetting = DbService.GetDataBaseSettings();

        }

        #endregion

        public bool StartWorkFlow()
        {
            try
            {
                Logger.Trace("STARTED: Start WorkFlow Service Method");
                //ReadCMSBillInputFileDetRecord(@"C:\NCP-Carrington\Input\CMS_BILLINPUT02_06232020.txt");
                //ReadEConsentRecord(@"C:\NCP-Carrington\Input\Carrington_Econsent_Setups_06232020.txt");
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

        private static void TimeWatch()
        {
            //Time when method needs to be called
            var DailyTime = "15:08:00";
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
            string path = @"C:\NCP-Carrington\Input";
            //waits certan time and run the code
            Task.Delay(ts).ContinueWith((x) => MonitorDirectory(path));

            Console.Read();
        }
        private static void MonitorDirectory(string path)

        {

            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();

            fileSystemWatcher.Path = path;

            fileSystemWatcher.Created += FileSystemWatcher_Created;

            //fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;

            //fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;

            fileSystemWatcher.EnableRaisingEvents = true;

        }

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {

            Console.WriteLine("File created: {0}", e.Name);
        }

        private static void FileSystemWatcher_Renamed(object sender, FileSystemEventArgs e)

        {

            Console.WriteLine("File renamed: {0}", e.Name);

        }

        private static void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)

        {

            Console.WriteLine("File deleted: {0}", e.Name);

        }

        #endregion

        #region New Code


        public void readData()
        {
            string FileNameWithPath = @"D:\Carrington\06232020011800.testfebil06232020141628.ETOA";

            int numOfBytes = 4010;
            InputFileStream = new System.IO.FileStream(FileNameWithPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);

            byte[] currentByteLine = new byte[numOfBytes];
            int iBytesRead = InputFileStream.Read(currentByteLine, 0, numOfBytes);
            int count = 0;
            int startPos = 0;
            int fieldLength = 1;
            while (iBytesRead > 0)
            {
                string inputValue = Encoding.Default.GetString(currentByteLine, startPos, fieldLength);

                if (inputValue == "H")
                {
                    GetHeaderRecord(currentByteLine);
                }
                else if (inputValue == "B")
                {
                    GetInstitutionRecord(currentByteLine);
                }
                else if (inputValue == "A")
                {
                    GetMasterFileDataPart_1(currentByteLine);
                }
                iBytesRead = InputFileStream.Read(currentByteLine, 0, numOfBytes);
            }

        }
        //List<MortgageLoanBillingFileModel> MortgageLoanBillingFileList = new List<MortgageLoanBillingFileModel>();

        MortgageLoanBillingFileModel MortgageLoanBillingFile = new MortgageLoanBillingFileModel();

        public FileStream InputFileStream { get; private set; }

        public void GetHeaderRecord(byte[] currentByte)
        {
            MortgageLoanBillingFile.HeaderRecords = new HeaderRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 0, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                Filler1 = GetPositionData(currentByte, 5, 10),
                Filler2 = GetPositionData(currentByte, 15, 5),
                FileIdentifier = GetPositionData(currentByte, 20, 24)
            };

        }
        public void GetInstitutionRecord(byte[] currentByte)
        {
            MortgageLoanBillingFile.InstitutionRecords = new InstitutionRecordModel()
            {
                RecordIdentifier = GetPositionData(currentByte, 0, 1),
                InstitutionNumber = GetPositionData(currentByte, 2, 3),
                Filler = GetPositionData(currentByte, 5, 10),
                SequenceNumber = GetPositionData(currentByte, 15, 5),
                InstitutionName = GetPositionData(currentByte, 20, 35),
                InstitutionAddress1 = GetPositionData(currentByte, 55, 35),
                InstitutionAddress2 = GetPositionData(currentByte, 90, 35),
                InstitutionCity = GetPositionData(currentByte, 125, 21),
                InstitutionState = GetPositionData(currentByte, 146, 1),
                InstitutionZip = GetPositionData(currentByte, 148, 10),
                InstitutionPhone = GetPositionData(currentByte, 158, 10),
                AlternativeCouponAddress1 = GetPositionData(currentByte, 168, 35),
                AlternativeCouponAddress2 = GetPositionData(currentByte, 203, 35),
                AlternativeCouponCity = GetPositionData(currentByte, 238, 21),
                AlternativeCouponState = GetPositionData(currentByte, 259, 1),
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

        public void GetPL_Record(byte[] currentByte)
        {
            MortgageLoanBillingFile.AccountModelList = new List<AccountsModel>()
                {
                   new AccountsModel
                   { PL_RecordModel = new PL_RecordModel()
                    {
                       RecordIdentifier=GetPositionData(currentByte, 1, 1),
                       InstitutionNumber=GetPositionData(currentByte, 2,3),

                       AccountNumber=GetPositionData(currentByte, 5,10),
                       SequenceNumber=GetPositionData(currentByte, 15,5),

                       PL_Entity=GetPositionData(currentByte, 20,3),
                       PLSSGroup=GetPositionData(currentByte, 23,8),

                       PL_EntityStatus=GetPositionData(currentByte, 31,1),
                       PLSSEntityBrandingName=GetPositionData(currentByte, 32,35),

                       EntityBrandingAddressLine1=GetPositionData(currentByte, 67,35), 
                       EntityBrandingAddressLine2=GetPositionData(currentByte, 102,21),

                       EntityBrandingCity=GetPositionData(currentByte, 137,21),
                       EntityBrandingState=GetPositionData(currentByte, 158,35),

                       EntityBrandingZipCode=GetPositionData(currentByte, 193,10),
                       EntityBrandingPhone=GetPositionData(currentByte, 203,10),

                       PL_EntityTaxIdentificationNumber=GetPositionData(currentByte, 213,09),
                       MERSOrganizationID=GetPositionData(currentByte, 222,07),

                       HUDIDNumber=GetPositionData(currentByte, 229,12),
                       VAID=GetPositionData(currentByte, 241,06),

                       EntityRHSLenderBranchID=GetPositionData(currentByte, 247,03),
                       EntityHUDContactNameFirst=GetPositionData(currentByte, 250,10),

                       EntityHUDContactNameLast=GetPositionData(currentByte, 260,20),
                       EntityHUDContactTelephone=GetPositionData(currentByte, 280,10),

                       EntityHUDPrincipalServicingOfficeCity=GetPositionData(currentByte, 290,21),
                       EntityHUDPrincipalServicingOfficeState=GetPositionData(currentByte, 311,2),

                       EntityHUDPrincipalServicingOfficeZipCode=GetPositionData(currentByte, 313,09),
                       EntityHUDCompanyHeadquartersStateCode=GetPositionData(currentByte, 322,03),

                       EntityLockboxAddressLine1=GetPositionData(currentByte, 325,35),
                       EntityLockboxAddressLine2=GetPositionData(currentByte, 360,35),

                       EntityLockboxCity=GetPositionData(currentByte, 395,21),
                       EntityLockboxState=GetPositionData(currentByte, 416,2),

                       EntityLockboxZipCode=GetPositionData(currentByte, 418,10),
                       EntityAlternateAddress1=GetPositionData(currentByte, 428,35),

                       EntityAlternateAddress2=GetPositionData(currentByte, 463,35),
                       EntityAlternateCity=GetPositionData(currentByte, 498,21),

                       EntityAlternateState=GetPositionData(currentByte, 519,2),
                       EntityAlternateZipCode=GetPositionData(currentByte, 521,10),

                       EntityAlternatePhoneNumber1Desc=GetPositionData(currentByte, 531,20),
                       EntityAlternatePhoneNumber1=GetPositionData(currentByte, 551,10),

                       EntityAlternatePhoneNumber2Desc=GetPositionData(currentByte, 561,20),
                       EntityAlternatePhoneNumber2=GetPositionData(currentByte, 581,10),

                       EntityAlternatePhoneNumber3Desc=GetPositionData(currentByte, 591,20),
                       EntityAlternatePhoneNumber3=GetPositionData(currentByte, 611,10),

                       EntityAlternatePhoneNumber4Desc=GetPositionData(currentByte, 621,20),
                       EntityAlternatePhoneNumber4=GetPositionData(currentByte, 641,10),

                       EntityAlternatePhoneNumber5Desc=GetPositionData(currentByte, 651,20),
                       EntityAlternatePhoneNumber5=GetPositionData(currentByte, 671,10),

                   }
                   } 
            };
        }
        public void GetMasterFileDataPart_1(byte[] currentByte)
        {

            MortgageLoanBillingFile.AccountModelList = new List<AccountsModel>()
                {
                   new AccountsModel
                   { MasterFileDataPart_1Model = new MasterFileDataPart_1Model()
                    {
                         RecordIdentifier = GetPositionData(currentByte, 0, 1),
                         InstitutionNumber=GetPositionData(currentByte, 2, 3),

                         AccountNumber=GetPositionData(currentByte, 5, 10),
                         SequenceNumber=GetPositionData(currentByte, 15, 5),

                         CreditInsurancePayment=GetPositionData(currentByte, 20, 4),
                         PrincipalBalance=GetPositionData(currentByte, 24, 6),

                         EscrowBalance=GetPositionData(currentByte, 30, 6),
                         LoanType=GetPositionData(currentByte, 36, 1),

                         LoanSubtype=GetPositionData(currentByte, 37, 1),
                         P_IPayment=GetPositionData(currentByte, 38, 6),

                         EscrowPayment=GetPositionData(currentByte, 44, 5),
                         InvestorOwnershipCode=GetPositionData(currentByte, 49, 1),

                         InvestorInformationOccurrences=GetPositionData(currentByte, 50, 280),
                         InvestorCode=GetPositionData(currentByte, 50, 3),

                         InvestorPrimaryName=GetPositionData(currentByte, 53, 35),
                         InvestorBlockCode=GetPositionData(currentByte, 88, 3),

                         InvestorPercentOwned=GetPositionData(currentByte, 91, 34),
                         InvestorRate=GetPositionData(currentByte, 95, 4),

                         InvestorServiceFeeCode=GetPositionData(currentByte, 99, 1),
                         InvestorServiceFeeRate=GetPositionData(currentByte, 100, 4),

                         InvestorAccountNumber=GetPositionData(currentByte, 104, 15),
                         Filler1=GetPositionData(currentByte, 119, 1),

                         LastStatementDate=GetPositionData(currentByte, 330, 6),
                         PrecalculatedInterestAmount=GetPositionData(currentByte, 336, 6),

                         UnappliedFundsBalanceFirst=GetPositionData(currentByte, 342, 6),
                         PropertyTypeCode=GetPositionData(currentByte, 348, 2),

                         InterestPaidYearToDate=GetPositionData(currentByte, 350, 6),
                         PurposeCode=GetPositionData(currentByte, 356, 2),

                         UnappliedFundsCodeFirst=GetPositionData(currentByte, 358, 1),
                         StateCode=GetPositionData(currentByte, 359, 2),

                         DueDate=GetPositionData(currentByte, 361, 6),
                         PaymentsPastDue=GetPositionData(currentByte, 367, 7),

                         PaymentDueCounter=GetPositionData(currentByte, 374, 2),
                         LateChargeAmount=GetPositionData(currentByte, 376, 4),

                         LateChargeDue=GetPositionData(currentByte, 380, 4),
                         PrepaidFlag=GetPositionData(currentByte, 384, 1),

                         EscrowInterestYTD=GetPositionData(currentByte, 385, 4),
                         RunDate=GetPositionData(currentByte, 389, 6),

                         PrimaryBorrowersName=GetPositionData(currentByte, 395, 35),
                         SecondaryBorrowersName=GetPositionData(currentByte, 430, 35),

                         MailingAddress=GetPositionData(currentByte, 465, 35),
                         PropertyAddress=GetPositionData(currentByte, 570, 35),

                         DueDateGrace=GetPositionData(currentByte, 675, 6),
                         CurrentPayment=GetPositionData(currentByte, 681, 6),

                         BranchNumber=GetPositionData(currentByte, 687, 3),
                         PastDueAmtTotalDue=GetPositionData(currentByte, 690, 7),

                         LateCharge=GetPositionData(currentByte, 697, 5),
                         PaymentCycleCode=GetPositionData(currentByte, 702, 1),

                         WarningCode=GetPositionData(currentByte, 703, 1),
                         DistributionMailCode=GetPositionData(currentByte, 704, 1),

                         LastActivityDate=GetPositionData(currentByte, 705, 4),
                         AnnualPercentageRate=GetPositionData(currentByte, 709, 3),

                         NegativeAmortizationTaken=GetPositionData(currentByte, 712, 6),
                         GraceDays=GetPositionData(currentByte, 718, 2),

                         TaxesPaidYearToDate=GetPositionData(currentByte, 720, 5),
                         InterestPaidToDate=GetPositionData(currentByte, 725, 6),

                         CurrentDueDate=GetPositionData(currentByte, 731, 7),
                         UncollectedCreditInsurance=GetPositionData(currentByte, 737, 6),

                         UncollectedInterest=GetPositionData(currentByte, 743, 6),
                         NoteRate=GetPositionData(currentByte, 749, 4),

                         NegativeAmortizationAssessedYTD=GetPositionData(currentByte, 753, 5),
                         NegativeAmortizationPaidYTD=GetPositionData(currentByte, 758, 5),

                         NoteRateOverUnder=GetPositionData(currentByte, 763, 4),
                         OriginalRateOverUnder=GetPositionData(currentByte, 767, 4),

                         BillableNumber=GetPositionData(currentByte, 771, 9),
                         BankTransitRoutingNumber=GetPositionData(currentByte, 780, 5),

                         WithholdingInterestYTD=GetPositionData(currentByte, 785, 4),
                         NegativeAmortizationFlag=GetPositionData(currentByte, 789, 1),

                         InterestOnPymtDue=GetPositionData(currentByte, 790, 6),
                         SecondMortgageCode=GetPositionData(currentByte, 796, 1),

                         SecondaryMortgageAccountNumber=GetPositionData(currentByte, 797, 6),
                         SecondaryMortgagePaymentAmount=GetPositionData(currentByte, 803, 6),

                         FeeReceivable=GetPositionData(currentByte, 809, 4),
                         PastDuePayments=GetPositionData(currentByte, 813, 8),

                         PastPaymentDueDate=GetPositionData(currentByte, 813, 6),
                         PastRegularAmount=GetPositionData(currentByte, 819, 6),

                         PastLateAmount=GetPositionData(currentByte, 825, 6),
                         BillingOption=GetPositionData(currentByte, 921, 1),

                         AlternativeOverUnder=GetPositionData(currentByte, 923, 4),
                         CurrentIndexDate=GetPositionData(currentByte, 926, 4),

                         CurrentIndexRate=GetPositionData(currentByte, 930, 4),
                         EmployeeDiscountedMargin=GetPositionData(currentByte, 934, 4),

                         InterestOnlyPayment=GetPositionData(currentByte, 938, 6),
                         FullyAmortizePayment=GetPositionData(currentByte, 944, 6),

                         BillMethod=GetPositionData(currentByte, 950, 1),
                         ACHAccountNumber=GetPositionData(currentByte, 951, 20),

                         AnalysisIndexRate=GetPositionData(currentByte, 971, 4),
                         InterestMethod=GetPositionData(currentByte, 975, 2),

                         CrossSellFlag=GetPositionData(currentByte, 977, 1),
                         MultipleLoanFlag=GetPositionData(currentByte, 978, 1),

                         Filler=GetPositionData(currentByte, 979, 1),
                         PrimaryBorrowerSocialSecurityNumber=GetPositionData(currentByte, 980, 4),

                         RepaymentPlanNextDueDate=GetPositionData(currentByte, 984, 6),
                         AmortizedFeePayment=GetPositionData(currentByte, 990, 5),

                         RepaymentPlanNextPaymentDueAmount=GetPositionData(currentByte,995 , 4),
                         PlanRemainingBalance=GetPositionData(currentByte, 999, 6),

                         EmailBillIndicator=GetPositionData(currentByte, 1005, 1),
                         PrimaryBorrowerEmailAddress=GetPositionData(currentByte, 1006, 40),

                         PrimaryBorrowerFaxNumber=GetPositionData(currentByte, 1046, 11),
                         PrimaryBorrowerCellPhoneNumber=GetPositionData(currentByte, 1052, 11),

                         DirectMailIndicator=GetPositionData(currentByte, 1058, 2),
                         TelemarketIndicator=GetPositionData(currentByte, 1060, 2),

                         FeeReceivablePart2=GetPositionData(currentByte, 1062, 5),
                         ServicingDate=GetPositionData(currentByte, 1067, 8),

                         FirstStatementonAcquiredLoanIndicator=GetPositionData(currentByte, 1075, 1),
                         MailCode=GetPositionData(currentByte, 1076, 1),

                         SpecialStatementRequest=GetPositionData(currentByte, 1077, 1),
                         StopCode1=GetPositionData(currentByte, 1078, 1),

                         OptInFlag=GetPositionData(currentByte, 1079, 1),
                         OptOutFlag=GetPositionData(currentByte, 1080, 1),

                         SecondaryBorrowerEmailIndicator=GetPositionData(currentByte, 1081, 1),
                         FirstPaymentDate=GetPositionData(currentByte, 1082, 8),

                         MortgageLoanFlag=GetPositionData(currentByte, 1090, 1),
                         PurchasedFrom=GetPositionData(currentByte, 1091, 34),

                         UncollectedNSFFees=GetPositionData(currentByte, 1125, 7),
                         UncollectedExtensionFees=GetPositionData(currentByte, 1132, 7),

                         PrimaryBorrowersHomePhone=GetPositionData(currentByte, 1139, 11),
                         InvestorTaxID=GetPositionData(currentByte, 1150, 11),

                         ForceOrderCoverageFlagFire=GetPositionData(currentByte, 1161, 1),
                         ForceOrderCoverageFlagHomeowners=GetPositionData(currentByte, 1162, 1),

                         ForceOrderCoverageFlagFlood=GetPositionData(currentByte, 1163, 1),
                         ForceOrderCoverageFlagEarthquake=GetPositionData(currentByte, 1164, 1),

                         ForceOrderCoverageFlagWind=GetPositionData(currentByte, 1165, 1),
                         FillerPart3=GetPositionData(currentByte, 1166, 5),

                         SecondaryBorrowersSocialSecurityNumber=GetPositionData(currentByte, 1171, 4),
                         ClosingDate=GetPositionData(currentByte, 1175, 8),

                         InterestStartDateAccruals=GetPositionData(currentByte, 1183, 8),
                         TermofLoan=GetPositionData(currentByte, 1191, 3),

                         FieldmanSolicitorCode=GetPositionData(currentByte, 1194, 5),
                         UpdatedTerm=GetPositionData(currentByte, 1199, 3),

                         ModificationDate=GetPositionData(currentByte, 1202, 8),
                         AlternativeMortgageIndicator=GetPositionData(currentByte, 1210, 1),

                         NameChangeIndicator=GetPositionData(currentByte, 1211, 1),
                         AddressChangeIndicator=GetPositionData(currentByte, 1212, 1),

                         BalloonDate=GetPositionData(currentByte, 1213, 8),
                         ThirtyDaysDelinquentCount=GetPositionData(currentByte, 1221, 3),

                         SixtyDaysDelinquentCount=GetPositionData(currentByte, 1224, 3),
                         NinetyDaysDelinquentCount=GetPositionData(currentByte, 1227, 3),

                         TotalNSFCounter=GetPositionData(currentByte, 1230, 3),
                         PrimaryBorrowersBirthdate=GetPositionData(currentByte, 1233, 8),

                         CreditBureauScore1=GetPositionData(currentByte, 1241, 15),
                         CreditBureauScore2=GetPositionData(currentByte, 1256, 15),

                         CreditBureauScore3=GetPositionData(currentByte, 1271, 15),
                         LastExtensionPostDate=GetPositionData(currentByte, 1286, 8),

                         TotalActivatedExtensions=GetPositionData(currentByte, 1294, 3),
                         PreNotificationFlag=GetPositionData(currentByte, 1297, 1),

                         PrimaryBorrowersWorkNumber=GetPositionData(currentByte, 1298, 11),
                         EOYGrossInterestPaid=GetPositionData(currentByte, 1309, 11),

                         ForeclosureAdvance=GetPositionData(currentByte, 1320, 7),
                         NetInvestment=GetPositionData(currentByte, 1327, 11),

                         DiscountQuotedOriginalDiscountAmount=GetPositionData(currentByte, 1338, 9),
                         TotalPaymentsForLifeOfLoan=GetPositionData(currentByte, 1347, 11),

                         MonthlyInterestRate=GetPositionData(currentByte, 1360, 7),
                         NumberOfDaysDelinquent=GetPositionData(currentByte, 1367, 5),

                         LossMitAnalysisOptionDate=GetPositionData(currentByte, 1372, 8),
                         PriorAccountNumber=GetPositionData(currentByte, 1380, 20),

                         LastPaymentDate=GetPositionData(currentByte, 1400, 8),
                         PrimaryBorrowersMaritalStatus=GetPositionData(currentByte, 1408, 1),

                         CloseCode=GetPositionData(currentByte, 1409, 1),
                         REOIndicator=GetPositionData(currentByte, 1410, 1),

                         MaturityDate=GetPositionData(currentByte, 1411, 8),
                         PartialChargeOffTaken=GetPositionData(currentByte, 1419, 11),

                         LockoutCode=GetPositionData(currentByte, 1430, 1),
                         StopCode2=GetPositionData(currentByte, 1431, 1),

                         StopCode3=GetPositionData(currentByte, 1432, 1),
                         FairIssacsCreditScore=GetPositionData(currentByte, 1433, 5),

                         NSFIndicator=GetPositionData(currentByte, 1438, 1),
                         EmployeeCode=GetPositionData(currentByte, 1439, 1),

                         AuditDate=GetPositionData(currentByte, 1440, 8),
                         PrimaryBorrowersAge=GetPositionData(currentByte, 1448, 3),

                         SecondaryBorrowersAge=GetPositionData(currentByte, 1451, 3),
                         RealtorBuilderCode=GetPositionData(currentByte, 1454, 5),

                         UserField001=GetPositionData(currentByte, 1459, 4),
                         TotalFeesDue=GetPositionData(currentByte, 1463, 5),

                         RecurringDraftStatus=GetPositionData(currentByte, 1468, 1),
                         InternalRefinanceCode=GetPositionData(currentByte, 1469, 1),

                         UserField007=GetPositionData(currentByte, 1470, 2),
                         UserField036=GetPositionData(currentByte, 1472, 1),

                         UncollectedExtensionInterest=GetPositionData(currentByte, 1473, 6),
                         StatementFrequency=GetPositionData(currentByte, 1479, 2),

                         StatementFrequencyChangeDate=GetPositionData(currentByte, 1481, 8),
                         APDSParticipation=GetPositionData(currentByte, 1489, 1),

                         PaymentProgramIndicator=GetPositionData(currentByte, 1490, 2),
                         OrganizationUnitCode1=GetPositionData(currentByte, 1492, 5),

                         PLSSEntity=GetPositionData(currentByte, 1497, 3),
                         RateNextChangeDate=GetPositionData(currentByte, 1500, 8),

                         PrepaymentPenaltyAmount=GetPositionData(currentByte, 1508, 6),
                         PrincipalPaidYTD=GetPositionData(currentByte, 1514, 6),

                         EscrowPaidYTD=GetPositionData(currentByte, 1520, 6),
                         FeesPaidYTD=GetPositionData(currentByte, 1526, 5),

                         LateChargesPaidYTD=GetPositionData(currentByte, 1531, 5),
                         PastPaidPaymentDueDate01=GetPositionData(currentByte, 1536, 6),

                         PastPaidPaymentPaidDate01=GetPositionData(currentByte, 1542, 6),
                         PastPaidPaymentDueDate02=GetPositionData(currentByte, 1548, 6),

                         PastPaidPaymentPaidDate02=GetPositionData(currentByte, 1554, 6),
                         PastPaidPaymentDueDate03=GetPositionData(currentByte, 1560, 6),

                         PastPaidPaymentPaidDate03=GetPositionData(currentByte, 1566, 6),
                         PastPaidPaymentDueDate04=GetPositionData(currentByte, 1572, 6),

                         PastPaidPaymentPaidDate04=GetPositionData(currentByte, 1578, 6),
                         PastPaidPaymentDueDate05=GetPositionData(currentByte, 1572, 6),

                         PastPaidPaymentPaidDate05=GetPositionData(currentByte, 1590, 6),
                         PastPaidPaymentDueDate06=GetPositionData(currentByte, 1596, 6),

                         PastPaidPaymentPaidDate06=GetPositionData(currentByte, 1602, 6),
                         PrincipalPaidSinceLastStatement=GetPositionData(currentByte, 1608, 7),

                         InterestPaidSinceLastStatement=GetPositionData(currentByte, 1615, 7),
                         EscrowPaidSinceLastStatement=GetPositionData(currentByte, 1622, 7),

                         LateChargesPaidSinceLastStatement=GetPositionData(currentByte, 1629, 6),
                         FeesPaidSinceLastStatement=GetPositionData(currentByte, 1635, 7),

                         PartialPaymentsPaidSinceLastStatement=GetPositionData(currentByte, 1642, 6),
                         TotalAmountPaidSinceLastStatement=GetPositionData(currentByte, 1648, 8),

                         FeesAssessedSinceLastStatement=GetPositionData(currentByte, 1656, 6),
                         LateChargesAccruedSinceLastStatement=GetPositionData(currentByte, 1662, 6),

                         LossMitigationFlag=GetPositionData(currentByte, 1668, 1),
                         FirstContactName=GetPositionData(currentByte, 1669, 20),

                         FirstContactAddress1=GetPositionData(currentByte, 1689, 50),
                         FirstContactCity=GetPositionData(currentByte, 1739, 20),

                         FirstContactState=GetPositionData(currentByte, 1759, 2),
                         FirstContactZipCode=GetPositionData(currentByte, 1761, 10),

                         FirstContactPhoneNumber=GetPositionData(currentByte, 1771, 15),
                         FirstContactExtension=GetPositionData(currentByte, 1786, 5),

                         PastPaymentDueDateR=GetPositionData(currentByte, 1791, 6),
                         PastRegularAmountR=GetPositionData(currentByte, 1797, 6),
                         PastLateAmountR=GetPositionData(currentByte, 1803, 6),

                         PastPaidPaymentDueDate7=GetPositionData(currentByte, 2187, 6),
                         PastPaidPaymentPaidDate7=GetPositionData(currentByte, 2193, 6),

                         PastPaidPaymentDueDate8=GetPositionData(currentByte, 2199, 6),
                         PastPaidPaymentPaidDate8=GetPositionData(currentByte, 2205, 6),

                         PastPaidPaymentDueDate9=GetPositionData(currentByte, 2211, 6),
                         PastPaidPaymentPaidDate9=GetPositionData(currentByte, 2217, 6),

                         PastPaidPaymentDueDate10=GetPositionData(currentByte, 2223, 6),
                         PastPaidPaymentPaidDate10=GetPositionData(currentByte, 2229, 6),

                         PastPaidPaymentDueDate11=GetPositionData(currentByte, 2235, 6),
                         PastPaidPaymentPaidDate11=GetPositionData(currentByte, 2241, 6),

                         PastPaidPaymentDueDate12=GetPositionData(currentByte, 2247, 6),
                         PastPaidPaymentPaidDate12=GetPositionData(currentByte, 2253, 6),

                         PastPaidPaymentDueDate13=GetPositionData(currentByte, 2259, 6),
                         PastPaidPaymentPaidDate13=GetPositionData(currentByte, 2265, 6),

                         PastPaidPaymentDueDate14=GetPositionData(currentByte, 2271, 6),
                         PastPaidPaymentPaidDate13Part2=GetPositionData(currentByte, 2277, 6),

                         PastPaidPaymentDueDate15=GetPositionData(currentByte, 2283, 6),
                         PastPaidPaymentPaidDate15=GetPositionData(currentByte, 2289, 6),

                         PastPaidPaymentDueDate16=GetPositionData(currentByte, 2295, 6),
                         PastPaidPaymentPaidDate16=GetPositionData(currentByte, 2301, 6),

                          PastPaidPaymentDueDate17=GetPositionData(currentByte, 2307, 6),
                         PastPaidPaymentPaidDate16Part2=GetPositionData(currentByte, 2313, 6),

                         PastPaidPaymentDueDate18=GetPositionData(currentByte, 2319, 6),
                         PastPaidPaymentPaidDate18=GetPositionData(currentByte, 2325, 6),

                         PastPaidPaymentDueDate19=GetPositionData(currentByte, 2331, 6),
                         PastPaidPaymentPaidDate19=GetPositionData(currentByte, 2337, 6),

                         PastPaidPaymentDueDate20=GetPositionData(currentByte, 2343, 6),
                         PastPaidPaymentPaidDate20=GetPositionData(currentByte, 2349, 6),

                         PastPaidPaymentDueDate21=GetPositionData(currentByte, 2355, 6),
                         PastPaidPaymentPaidDate21=GetPositionData(currentByte, 2361, 6),

                         PastPaidPaymentDueDate22=GetPositionData(currentByte, 2367, 6),
                         PastPaidPaymentPaidDate22=GetPositionData(currentByte, 2373, 6),


                         PastPaidPaymentDueDate23=GetPositionData(currentByte, 2379, 6),
                         PastPaidPaymentPaidDate23=GetPositionData(currentByte, 2385, 6),

                         PastPaidPaymentDueDate24=GetPositionData(currentByte, 2391, 6),
                         PastPaidPaymentPaidDate24=GetPositionData(currentByte, 2397, 6),

                         PastPaidPaymentDueDate25=GetPositionData(currentByte, 2403, 6),
                         PastPaidPaymentPaidDate25=GetPositionData(currentByte, 2409, 6),

                         PastPaidPaymentDueDate26=GetPositionData(currentByte, 2415, 6),
                         PastPaidPaymentPaidDate26=GetPositionData(currentByte, 2421, 6),

                         PastPaidPaymentDueDate27=GetPositionData(currentByte, 2427, 6),
                         PastPaidPaymentPaidDate27=GetPositionData(currentByte, 2433, 6),

                         PastPaidPaymentDueDate28=GetPositionData(currentByte, 2439, 6),
                         PastPaidPaymentPaidDate28=GetPositionData(currentByte, 2445, 6),

                         CashElectronicTransferOptOut=GetPositionData(currentByte, 2451, 1),
                         MultipleLoanIndicator=GetPositionData(currentByte, 2452, 1),

                         LastAnnualStatementDate=GetPositionData(currentByte, 2453, 4),
                         LastPrivacyStatementMethod=GetPositionData(currentByte, 2457, 2),

                         OptOutType=GetPositionData(currentByte, 2459, 1),
                         OptOutDate=GetPositionData(currentByte, 2460, 4),

                         SpecialContactCode=GetPositionData(currentByte, 2464, 5),
                         LastDisclosureNoticeDate=GetPositionData(currentByte, 2469, 4),

                         LastDisclosureNoticeMethod=GetPositionData(currentByte, 2473, 2),
                         PrimarySolicitationOptOutType=GetPositionData(currentByte, 2475, 1),

                         PrimarySolicitationOptOutDate=GetPositionData(currentByte, 2476, 4),
                         SecondarySolicitationOptOutType=GetPositionData(currentByte, 2480, 1),
                         SecondarySolicitationOptOutDate=GetPositionData(currentByte, 2481, 4),

                         CoborrowerSolicitationOptOutType01=GetPositionData(currentByte, 2485, 1),
                         CoborrowerSolicitationOptOutDate01=GetPositionData(currentByte, 2486, 4),

                         CoborrowerSolicitationOptOutType02=GetPositionData(currentByte, 2490, 1),
                         CoborrowerSolicitationOptOutDate02=GetPositionData(currentByte, 2491, 4),

                         CoborrowerSolicitationOptOutType03=GetPositionData(currentByte, 2495, 1),
                         CoborrowerSolicitationOptOutDate03=GetPositionData(currentByte, 2496, 4),

                         CoborrowerSolicitationOptOutType04=GetPositionData(currentByte, 2500, 1),
                         CoborrowerSolicitationOptOutDate04=GetPositionData(currentByte, 2501, 4),

                         CoborrowerSolicitationOptOutType05=GetPositionData(currentByte, 2505, 1),
                         CoborrowerSolicitationOptOutDate05=GetPositionData(currentByte, 2506, 4),

                         CoborrowerSolicitationOptOutType06=GetPositionData(currentByte, 2510, 1),
                         CoborrowerSolicitationOptOutDate06=GetPositionData(currentByte, 2511, 4),

                         CoborrowerSolicitationOptOutType07=GetPositionData(currentByte, 2515, 1),
                         CoborrowerSolicitationOptOutDate07=GetPositionData(currentByte, 2516, 4),

                         CoborrowerSolicitationOptOutType08=GetPositionData(currentByte, 2520, 1),
                         CoborrowerSolicitationOptOutDate08=GetPositionData(currentByte, 2521, 4),

                         CoborrowerSolicitationOptOutType09=GetPositionData(currentByte, 2525, 1),
                         CoborrowerSolicitationOptOutDate09=GetPositionData(currentByte, 2526, 4),

                         CoborrowerSolicitationOptOutType10=GetPositionData(currentByte, 2530, 1),
                         CoborrowerSolicitationOptOutDate10=GetPositionData(currentByte, 2531, 4),

                         AcceleratedDate=GetPositionData(currentByte, 2535, 4),
                         AcceleratedAccruedInterest=GetPositionData(currentByte, 2539, 6),

                         PrintStatement=GetPositionData(currentByte, 2545, 1),
                        PartialPaymentsYearToDate=GetPositionData(currentByte, 2546, 5),

                        ClosingInterest=GetPositionData(currentByte, 2551, 6),
                        PayoffAmount=GetPositionData(currentByte, 2557, 6),

                        PrimaryBorrowerAttention=GetPositionData(currentByte, 2563, 35),
                        DsiAccruedInterest=GetPositionData(currentByte, 2598, 6),

                        AcceleratedAmount=GetPositionData(currentByte, 2604, 7),
                        ReinstatementDate=GetPositionData(currentByte, 2611, 4),

                        ReinstatementAmount=GetPositionData(currentByte, 2615, 7),
                        TaskCompletionDate=GetPositionData(currentByte, 2622, 4),

                        NextAchDraftDate=GetPositionData(currentByte, 2626, 4),
                        MostRecentBreachLetterDate=GetPositionData(currentByte, 2630, 4),

                        FullFinalChargeOffDate=GetPositionData(currentByte, 2634, 2),
                        PromiseDate=GetPositionData(currentByte, 2638, 4),

                        PromiseAmount=GetPositionData(currentByte, 2642, 6),
                        PromiseToPayBrokenDate=GetPositionData(currentByte, 2647, 4),

                        PromiseToPayKeptDate=GetPositionData(currentByte, 2651, 4),
                        FillerPart4=GetPositionData(currentByte, 2655, 1356),

                   }
                   }
            };
        }

        public void GetMasterFileDataPart_2(byte[] currentByte)
        {
            MortgageLoanBillingFile.AccountModelList = new List<AccountsModel>()
                {
                   new AccountsModel
                   { MasterFileDataPart2Model = new MasterFileDataPart2Model()
                    {
                       RecordIdentifier = GetPositionData(currentByte, 1, 1),
                       InstitutionNumber = GetPositionData(currentByte, 2, 3),
                       AccountNumber= GetPositionData(currentByte, 5, 10),
                       SequenceNumber= GetPositionData(currentByte, 15, 5),

                       UnappliedFundsBalance2= GetPositionData(currentByte, 20, 5),
                       UnappliedFundsCode2= GetPositionData(currentByte, 25, 1),

                       UnappliedFundsBalance3= GetPositionData(currentByte, 26, 5),
                       UnappliedFundsCode3= GetPositionData(currentByte, 31, 1),

                       UnappliedFundsBalance4= GetPositionData(currentByte, 32, 5),
                       UnappliedFundsCode4= GetPositionData(currentByte, 37, 1),

                       UnappliedFundsBalance5= GetPositionData(currentByte, 38, 5),
                       UnappliedFundsCode5= GetPositionData(currentByte, 43, 1),

                       UnappliedFundsBalanceTotal= GetPositionData(currentByte, 44, 6),
                       TotalAmountToBeDrafted= GetPositionData(currentByte, 50, 6),

                       RecurringDraftBankTotalDraftAmount= GetPositionData(currentByte, 56, 6),
                       Filler= GetPositionData(currentByte, 62, 26),

                       UncollectedP_IAdvance= GetPositionData(currentByte, 88, 6),
                       OriginalMaturityDate= GetPositionData(currentByte, 94, 5),

                       DelinquentCounselorCode= GetPositionData(currentByte, 99, 3),
                       BillingMessageCode01= GetPositionData(currentByte, 102, 6),

                       BillingMessageCode02= GetPositionData(currentByte, 108, 6),
                       BillingMessageCode03= GetPositionData(currentByte, 114, 6),

                       BillingMessageCode04= GetPositionData(currentByte, 120, 6),
                       BillingMessageCode05= GetPositionData(currentByte, 126, 6),

                       BillingMessageCode06= GetPositionData(currentByte, 132, 6),
                       BillingMessageCode07= GetPositionData(currentByte, 138, 6),

                       BillingMessageCode08= GetPositionData(currentByte, 144, 6),
                       BillingMessageCode09= GetPositionData(currentByte, 150, 6),

                       BillingMessageCode10= GetPositionData(currentByte, 156, 6),
                       BillingMessageCode11= GetPositionData(currentByte, 162, 6),

                       BillingMessageCode12= GetPositionData(currentByte, 168, 6),
                       BillingMessageCode13= GetPositionData(currentByte, 174, 6),

                       BillingMessageCode14= GetPositionData(currentByte, 180, 6),
                       BillingMessageCode15= GetPositionData(currentByte, 186, 6),

                       BillingMessageCode16= GetPositionData(currentByte, 192, 6),
                       BillingMessageCode17= GetPositionData(currentByte, 198, 6),

                       BillingMessageCode18= GetPositionData(currentByte, 204, 6),
                       BillingMessageCode19= GetPositionData(currentByte, 210, 6),
                       BillingMessageCode20= GetPositionData(currentByte, 216, 6),

                       PrimaryBorrowerMailingForeign= GetPositionData(currentByte, 222, 1),
                       AlternativeAddressForeignAddressFlag= GetPositionData(currentByte, 223, 1),

                       PropertyForeignAddressIndicator= GetPositionData(currentByte, 224, 1),
                       TotalDeferredItemsBalance= GetPositionData(currentByte, 225, 7),

                       DeferredInterestBalance= GetPositionData(currentByte, 232, 6),
                       DeferredLateChargesBalance= GetPositionData(currentByte, 238, 4),

                       DeferredEscrowAdvancesBalance= GetPositionData(currentByte, 242,6),
                       DeferredDrmExpenseAdvancesPaidBalance= GetPositionData(currentByte, 248, 6),

                       DeferredDrmExpenseAdvancesUnpaidBalance= GetPositionData(currentByte, 254, 6),
                       DeferredAdministrativeFeesBalance= GetPositionData(currentByte, 260, 6),

                       PrimaryBorrowerSLanguage= GetPositionData(currentByte, 266, 1),
                       UncollectedEscrowShortage= GetPositionData(currentByte, 267, 6),

                       DeferredOptionalProductPremiums= GetPositionData(currentByte, 273, 5),
                       ClosingAgentCode= GetPositionData(currentByte, 278, 5),

                       FillerPart2= GetPositionData(currentByte, 283, 13),
                       DeferredPrincipalBalance= GetPositionData(currentByte, 296, 11),

                       CombinedPrincipalBalance= GetPositionData(currentByte, 302, 6),
                       OriginalPrincipalReductionAmount= GetPositionData(currentByte, 308, 6),

                       RemainingPraAmount= GetPositionData(currentByte, 314, 6),
                       PraTakenAmount= GetPositionData(currentByte, 320, 6),

                       LossMitigationProgram= GetPositionData(currentByte, 326, 3),
                       FclActionStartDate= GetPositionData(currentByte, 329, 6),

                       MostRecentBreachLetterDate= GetPositionData(currentByte, 335, 6),
                       HigherPricedMortgageLoanFlag= GetPositionData(currentByte, 341, 1),

                       HpmlEscrowRequiredThroughDate= GetPositionData(currentByte, 342, 8),
                       Filler3=GetPositionData(currentByte, 350, 187),

                       CurrentOccupancyCode=GetPositionData(currentByte, 537, 1),
                       Filler4=GetPositionData(currentByte, 538, 965),
                    }
                   }
                };
        }


        public string GetPositionData(byte[] currentByte, int startPos, int fieldLength)
        {
            return Encoding.Default.GetString(currentByte, startPos, fieldLength);
        }
        private (List<DetModel>,List<TransModel>) ReadCMSBillInputFileDetRecord(string path)
        {
            var fileContents = File.ReadAllLines(path);
            var splitFileContents = (from f in fileContents select f.Split(',')).ToArray();
            List<DetModel> detList = new List<DetModel>();
            List<TransModel> transList = new List<TransModel>();
            CmsBillInput CmsBillInput = new CmsBillInput();
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
            EConsentInput EConsentInput = new EConsentInput();
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
        #endregion
    }
}
