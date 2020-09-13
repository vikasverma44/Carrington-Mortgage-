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
        /// <summary>The NCP10 version.</summary>
        private const string Ncp10Version = "03";

        /// <summary>The delimiter.</summary>
        private const string Delimiter = "|";
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
                ReadPMFile(@"D:\Carrington\Mapping File\TESTDATA.ETOA");
                (List<DetModel> detData, List<TransModel> transData) = ReadCMSBillInputFileDetRecord(@"D:\Carrington\Mapping File\CMS_BILLINPUT02_06232020.txt");
                List<EConsentModel> EconsentData = ReadEConsentRecord(@"D:\Carrington\Mapping File\Carrington_Econsent_Setups_06232020.txt");

                if (detData != null && transData != null)
                {
                    foreach (AccountsModel accountDetails in MortgageLoanBillingFile.AccountModelList)
                    {
                        string accountToMatch = accountDetails.MasterFileDataPart_1Model.Rssi_Acct_No;
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
                        SentNO631 = line[6].ToString(),
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
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

                Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

                Rssi_File_Id = PackedTypeCheckAndUnPackData("Rssi_File_Id", currentByte, 20, 24)
            };

        }

        // B Institution Record.One record per institution.
        public void GetInstitutionRecord(byte[] currentByte)
        {
            MortgageLoanBillingFile.InstitutionRecords = new InstitutionRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

                Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

                Rssi_Institution_Name = PackedTypeCheckAndUnPackData("Rssi_Institution_Name", currentByte, 20, 35),
                Rssi_Inst_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Inst_Adrs_1", currentByte, 55, 35),

                Rssi_Inst_Adrs_2 = PackedTypeCheckAndUnPackData("Rssi_Inst_Adrs_2", currentByte, 90, 35),
                Rssi_Inst_City = PackedTypeCheckAndUnPackData("Rssi_Inst_City", currentByte, 125, 21),

                Rssi_Inst_State = PackedTypeCheckAndUnPackData("Rssi_Inst_State", currentByte, 146, 2),
                Rssi_Inst_Zip = PackedTypeCheckAndUnPackData("Rssi_Inst_Zip", currentByte, 148, 10),

                Rssi_Inst_Phone = PackedTypeCheckAndUnPackData("Rssi_Inst_Phone", currentByte, 158, 10),
                Rssi_Alt_Coup_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Adrs_1", currentByte, 168, 35),

                Rssi_Alt_Coup_Adrs_2 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Adrs_2", currentByte, 203, 35),
                Rssi_Alt_Coup_City = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_City", currentByte, 238, 21),

                Rssi_Alt_Coup_State = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_State", currentByte, 259, 2),
                Rssi_Alt_Coup_Zip = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Zip", currentByte, 261, 10),

                Rssi_Alt_Coup_Ph_Desc_1 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_Desc_1", currentByte, 271, 20),
                Rssi_Alt_Coup_Ph_No_1 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_No_1", currentByte, 291, 10),

                Rssi_Alt_Coup_Ph_Desc_2 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_Desc_2", currentByte, 301, 20),
                Rssi_Alt_Coup_Ph_No_2 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_No_2", currentByte, 321, 10),

                Rssi_Alt_Coup_Ph_Desc_3 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_Desc_3", currentByte, 331, 20),
                Rssi_Alt_Coup_Ph_No_3 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_No_3", currentByte, 351, 10),

                Rssi_Alt_Coup_Ph_Desc_4 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_Desc_4", currentByte, 361, 20),
                Rssi_Alt_Coup_Ph_No_4 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_No_4", currentByte, 381, 10),

                Rssi_Alt_Coup_Ph_Desc_5 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_Desc_5", currentByte, 391, 20),
                Rssi_Alt_Coup_Ph_No_5 = PackedTypeCheckAndUnPackData("Rssi_Alt_Coup_Ph_No_5", currentByte, 411, 10),

                Rssi_Lock_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Lock_Adrs_1", currentByte, 421, 35),
                Rssi_Lock_Adrs_2 = PackedTypeCheckAndUnPackData("Rssi_Lock_Adrs_2", currentByte, 456, 35),

                Rssi_Lock_City = PackedTypeCheckAndUnPackData("Rssi_Lock_City", currentByte, 491, 21),
                Rssi_Lock_State = PackedTypeCheckAndUnPackData("Rssi_Lock_State", currentByte, 512, 2),

                Rssi_Lock_Zip = PackedTypeCheckAndUnPackData("Rssi_Lock_Zip", currentByte, 514, 10)
            };
        }

        // P PL$$ Entity Record.One record per Entity within Institution if applicable.
        public void GetPL_Record(byte[] currentByte, ref AccountsModel acc)
        {
            acc.PL_RecordModel = new PL_RecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

                Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

                Rssi_N1Mx_Plss_Entity = PackedTypeCheckAndUnPackData("Rssi_N1Mx_Plss_Entity", currentByte, 20, 3),
                Rssi_Enty_Plss_Group = PackedTypeCheckAndUnPackData("Rssi_Enty_Plss_Group", currentByte, 23, 8),

                Rssi_Enty_Status = PackedTypeCheckAndUnPackData("Rssi_Enty_Status", currentByte, 31, 1),
                Rssi_Enty_Name = PackedTypeCheckAndUnPackData("Rssi_Enty_Name", currentByte, 32, 35),

                Rssi_Enty_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Enty_Adrs_1", currentByte, 67, 35),
                Rssi_Enty_Adrs_2 = PackedTypeCheckAndUnPackData("Rssi_Enty_Adrs_2", currentByte, 102, 35),

                Rssi_Enty_City = PackedTypeCheckAndUnPackData("Rssi_Enty_City", currentByte, 137, 21),
                Rssi_Enty_State = PackedTypeCheckAndUnPackData("Rssi_Enty_State", currentByte, 158, 35),

                Rssi_Enty_Zip = PackedTypeCheckAndUnPackData("Rssi_Enty_Zip", currentByte, 193, 10),
                Rssi_Enty_Phone = PackedTypeCheckAndUnPackData("Rssi_Enty_Phone", currentByte, 203, 10),

                Rssi_Enty_Tax_Id_Number = PackedTypeCheckAndUnPackData("Rssi_Enty_Tax_Id_Number", currentByte, 213, 09),
                Rssi_I_Mers_Org_Id = PackedTypeCheckAndUnPackData("Rssi_I_Mers_Org_Id", currentByte, 222, 07),

                Rssi_I_Hud_Id = PackedTypeCheckAndUnPackData("Rssi_I_Hud_Id", currentByte, 229, 12),
                Rssi_I_Va_Set264_Id = PackedTypeCheckAndUnPackData("Rssi_I_Va_Set264_Id", currentByte, 241, 06),

                Rssi_Enty_Rhs_Lender_Number = PackedTypeCheckAndUnPackData("Rssi_Enty_Rhs_Lender_Number", currentByte, 247, 03),
                Rssi_Enty_Hud_Cont_Name_First = PackedTypeCheckAndUnPackData("Rssi_Enty_Hud_Cont_Name_First", currentByte, 250, 10),

                Rssi_Enty_Hud_Cont_Name_Last = PackedTypeCheckAndUnPackData("Rssi_Enty_Hud_Cont_Name_Last", currentByte, 260, 20),
                Rssi_Enty_Cont_Phn = PackedTypeCheckAndUnPackData("Rssi_Enty_Cont_Phn", currentByte, 280, 10),

                Rssi_Enty_Hud_Office_City = PackedTypeCheckAndUnPackData("Rssi_Enty_Hud_Office_City", currentByte, 290, 21),
                Rssi_Enty_Hud_Office_State = PackedTypeCheckAndUnPackData("Rssi_Enty_Hud_Office_State", currentByte, 311, 2),

                Rssi_Enty_Hud_Office_Zip = PackedTypeCheckAndUnPackData("Rssi_Enty_Hud_Office_Zip", currentByte, 313, 09),
                Rssi_Enty_Company_Head_St_Cd = PackedTypeCheckAndUnPackData("Rssi_Enty_Company_Head_St_Cd", currentByte, 322, 03),

                Rssi_Enty_Lock_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Enty_Lock_Adrs_1", currentByte, 325, 35),
                Rssi_Enty_Lock_Adrs_2 = PackedTypeCheckAndUnPackData("Rssi_Enty_Lock_Adrs_2", currentByte, 360, 35),

                Rssi_Enty_Lock_City = PackedTypeCheckAndUnPackData("Rssi_Enty_Lock_City", currentByte, 395, 21),
                Rssi_Enty_Lock_State = PackedTypeCheckAndUnPackData("Rssi_Enty_Lock_State", currentByte, 416, 2),

                Rssi_Enty_Lock_Zip = PackedTypeCheckAndUnPackData("Rssi_Enty_Lock_Zip", currentByte, 418, 10),
                Rssi_Enty_Alt_Coup_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Adrs_1", currentByte, 428, 35),

                Rssi_Enty_Alt_Coup_Adrs_2 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Adrs_2", currentByte, 463, 35),
                Rssi_Enty_Alt_Coup_City = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_City", currentByte, 498, 21),

                Rssi_Enty_Alt_Coup_State = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_State", currentByte, 519, 2),
                Rssi_Enty_Alt_Coup_Zip = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Zip", currentByte, 521, 10),

                Rssi_Enty_Alt_Coup_Ph_Desc_1 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_Desc_1", currentByte, 531, 20),
                Rssi_Enty_Alt_Coup_Ph_No_1 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_No_1", currentByte, 551, 10),

                Rssi_Enty_Alt_Coup_Ph_Desc_2 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_Desc_2", currentByte, 561, 20),
                Rssi_Enty_Alt_Coup_Ph_No_2 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_No_2", currentByte, 581, 10),

                Rssi_Enty_Alt_Coup_Ph_Desc_3 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_Desc_3", currentByte, 591, 20),
                Rssi_Enty_Alt_Coup_Ph_No_3 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_No_3", currentByte, 611, 10),

                Rssi_Enty_Alt_Coup_Ph_Desc_4 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_Desc_4", currentByte, 621, 20),
                Rssi_Enty_Alt_Coup_Ph_No_4 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_No_4", currentByte, 641, 10),

                Rssi_Enty_Alt_Coup_Ph_Desc_5 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_Desc_5", currentByte, 651, 20),
                Rssi_Enty_Alt_Coup_Ph_No_5 = PackedTypeCheckAndUnPackData("Rssi_Enty_Alt_Coup_Ph_No_5", currentByte, 671, 10),
            };
        }

        // A Master File Data Part 1 Record.One record per loan.
        public void GetMasterFileDataPart_1(byte[] currentByte, ref AccountsModel acc)
        {

            acc.MasterFileDataPart_1Model = new MasterFileDataPart_1Model()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

                Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

                Rssi_Cr_Ins_Pymt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cr_Ins_Pymt_PackedData", currentByte, 20, 4, 2),
                Rssi_Prin_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Prin_Bal_PackedData", currentByte, 24, 6, 2),

                Rssi_Esc_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Esc_Bal_PackedData", currentByte, 30, 6),
                Rssi_Ln_Type_PackedData = PackedTypeCheckAndUnPackData("Rssi_Ln_Type_PackedData", currentByte, 36, 1),

                Rssi_Sub_Type_PackedData = PackedTypeCheckAndUnPackData("Rssi_Sub_Type_PackedData", currentByte, 37, 1),
                Rssi_P_I_Pymt_PackedData = PackedTypeCheckAndUnPackData("Rssi_P_I_Pymt_PackedData", currentByte, 38, 6),

                Rssi_Esc_Pymt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Esc_Pymt_PackedData", currentByte, 44, 5),
                Rssi_Inv_Own_Cd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Inv_Own_Cd_PackedData", currentByte, 49, 1),

                Rssi_Inv_All = PackedTypeCheckAndUnPackData("Rssi_Inv_All", currentByte, 50, 280),
                Rssi_Inv_Code_PackedData = PackedTypeCheckAndUnPackData("Rssi_Inv_Code_PackedData", currentByte, 50, 3),

                Rssi_Inv_Name = PackedTypeCheckAndUnPackData("Rssi_Inv_Name", currentByte, 53, 35),
                Rssi_Inv_Block_PackedData = PackedTypeCheckAndUnPackData("Rssi_Inv_Block_PackedData", currentByte, 88, 3),

                Rssi_Inv_Pc_Owned_PackedData = PackedTypeCheckAndUnPackData("Rssi_Inv_Pc_Owned_PackedData", currentByte, 91, 4),
                Rssi_Inv_Rate_PackedData = PackedTypeCheckAndUnPackData("Rssi_Inv_Rate_PackedData", currentByte, 95, 4),

                Rssi_Inv_Sv_Code_PackedData = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Code_PackedData", currentByte, 99, 1),
                Rssi_Inv_Sv_Fee_PackedData = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Fee_PackedData", currentByte, 100, 4),

                Rssi_Inv_Sv_Acct = PackedTypeCheckAndUnPackData("Rssi_Inv_Sv_Acct", currentByte, 104, 15),
                Rssi_Inv_Fill = PackedTypeCheckAndUnPackData("Rssi_Inv_Fill", currentByte, 119, 1),

                Rssi_Lip_La_Date = PackedTypeCheckAndUnPackData("Rssi_Lip_La_Date", currentByte, 330, 6),
                Rssi_Pre_Int_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Pre_Int_Amt_PackedData", currentByte, 336, 6),

                Rssi_Esc_Var_PackedData = PackedTypeCheckAndUnPackData("Rssi_Esc_Var_PackedData", currentByte, 342, 6),
                Rssi_Prop_Cd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Prop_Cd_PackedData", currentByte, 348, 2),

                Rssi_Int_Pd_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Int_Pd_Ytd_PackedData", currentByte, 350, 6),
                Rssi_Pur_Code_PackedData = PackedTypeCheckAndUnPackData("Rssi_Pur_Code_PackedData", currentByte, 356, 2),

                Rssi_Unap_Fund_Cd = PackedTypeCheckAndUnPackData("Rssi_Unap_Fund_Cd", currentByte, 358, 1),
                Rssi_State_PackedData = PackedTypeCheckAndUnPackData("Rssi_State_PackedData", currentByte, 359, 2),

                Rssi_Due_Date = PackedTypeCheckAndUnPackData("Rssi_Due_Date", currentByte, 361, 6),
                Rssi_Pymts_Due_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Pymts_Due_Amt_PackedData", currentByte, 367, 7),

                Rssi_Pymts_Due_Ctr_PackedData = PackedTypeCheckAndUnPackData("Rssi_Pymts_Due_Ctr_PackedData", currentByte, 374, 2),
                Rssi_Late_Chg_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Late_Chg_Amt_PackedData", currentByte, 376, 4),

                Rssi_Late_Chg_Due_PackedData = PackedTypeCheckAndUnPackData("Rssi_Late_Chg_Due_PackedData", currentByte, 380, 4),
                Rssi_Prepaid_Flag = PackedTypeCheckAndUnPackData("Rssi_Prepaid_Flag", currentByte, 384, 1),

                Rssi_Esc_Int_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Esc_Int_Ytd_PackedData", currentByte, 385, 4),
                Rssi_Run_Date = PackedTypeCheckAndUnPackData("Rssi_Run_Date", currentByte, 389, 6),

                Rssi_Primary_Name = PackedTypeCheckAndUnPackData("Rssi_Primary_Name", currentByte, 395, 35),
                Rssi_Secondary_Name = PackedTypeCheckAndUnPackData("Rssi_Secondary_Name", currentByte, 430, 35),

                Rssi_Mail_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Mail_Adrs_1", currentByte, 465, 35),
                Rssi_Appl_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_Appl_Adrs_1", currentByte, 570, 35),

                Rssi_Bill_Pmt_Dte = PackedTypeCheckAndUnPackData("Rssi_Bill_Pmt_Dte", currentByte, 675, 6),
                Rssi_Bill_Pmt_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Bill_Pmt_Amt_PackedData", currentByte, 681, 6),

                Rssi_Branch_PackedData = PackedTypeCheckAndUnPackData("Rssi_Branch_PackedData", currentByte, 687, 3),
                Rssi_Bill_Total_Due_PackedData = PackedTypeCheckAndUnPackData("Rssi_Bill_Total_Due_PackedData", currentByte, 690, 7),

                Rssi_Bill_Lc_PackedData = PackedTypeCheckAndUnPackData("Rssi_Bill_Lc_PackedData", currentByte, 697, 5),
                Rssi_Pymt_Cyc_PackedData = PackedTypeCheckAndUnPackData("Rssi_Pymt_Cyc_PackedData", currentByte, 702, 1),

                Rssi_W_Flag_PackedData = PackedTypeCheckAndUnPackData("Rssi_W_Flag_PackedData", currentByte, 703, 1),
                Rssi_Dist_Mail_Cd = PackedTypeCheckAndUnPackData("Rssi_Dist_Mail_Cd", currentByte, 704, 1),

                Rssi_Last_Actvty_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Last_Actvty_Dt_PackedData", currentByte, 705, 4),
                Rssi_Apr_Rate_PackedData = PackedTypeCheckAndUnPackData("Rssi_Apr_Rate_PackedData", currentByte, 709, 3),

                Rssi_Neg_Amort_Taken_PackedData = PackedTypeCheckAndUnPackData("Rssi_Neg_Amort_Taken_PackedData", currentByte, 712, 6),
                Rssi_Grace_Days_PackedData = PackedTypeCheckAndUnPackData("Rssi_Grace_Days_PackedData", currentByte, 718, 2),

                Rssi_Taxpd_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Taxpd_Ytd_PackedData", currentByte, 720, 5),
                Rssi_Pd_To_Date = PackedTypeCheckAndUnPackData("Rssi_Pd_To_Date", currentByte, 725, 6),

                Rssi_Cur_Due_Dte = PackedTypeCheckAndUnPackData("Rssi_Cur_Due_Dte", currentByte, 731, 6),
                Rssi_Prn_Var_PackedData = PackedTypeCheckAndUnPackData("Rssi_Prn_Var_PackedData", currentByte, 737, 6),

                Rssi_Uncol_Int_PackedData = PackedTypeCheckAndUnPackData("Rssi_Uncol_Int_PackedData", currentByte, 743, 6),
                Rssi_Note_Rate_PackedData = PackedTypeCheckAndUnPackData("Rssi_Note_Rate_PackedData", currentByte, 749, 4),

                Rssi_Neg_Am_Ass_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Neg_Am_Ass_Ytd_PackedData", currentByte, 753, 5),
                Rssi_Neg_Am_Paid_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Neg_Am_Paid_Ytd_PackedData", currentByte, 758, 5),

                Rssi_Rate_Ov_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rate_Ov_PackedData", currentByte, 763, 4),
                Rssi_Org_Rate_Ov_PackedData = PackedTypeCheckAndUnPackData("Rssi_Org_Rate_Ov_PackedData", currentByte, 767, 4),

                Rssi_Bill_Number_PackedData = PackedTypeCheckAndUnPackData("Rssi_Bill_Number_PackedData", currentByte, 771, 9),
                Rssi_Bank_Trans_PackedData = PackedTypeCheckAndUnPackData("Rssi_Bank_Trans_PackedData", currentByte, 780, 5),

                Rssi_Withhold_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Withhold_Ytd_PackedData", currentByte, 785, 4),
                Rssi_Neg_Amort_Flag_PackedData = PackedTypeCheckAndUnPackData("Rssi_Neg_Amort_Flag_PackedData", currentByte, 789, 1),

                Rssi_Int_Due_PackedData = PackedTypeCheckAndUnPackData("Rssi_Int_Due_PackedData", currentByte, 790, 6),
                Rssi_Sec_Mort_Cd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Sec_Mort_Cd_PackedData", currentByte, 796, 1),

                Rssi_2Nd_Acct_No_PackedData = PackedTypeCheckAndUnPackData("Rssi_2Nd_Acct_No_PackedData", currentByte, 797, 6),
                Rssi_2Nd_Bill_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_2Nd_Bill_Amt_PackedData", currentByte, 803, 6),

                Rssi_Fees_PackedData = PackedTypeCheckAndUnPackData("Rssi_Fees_PackedData", currentByte, 809, 4),
                Rssi_Past_Payments = PackedTypeCheckAndUnPackData("Rssi_Past_Payments", currentByte, 813, 108),

                Rssi_Past_Date = PackedTypeCheckAndUnPackData("Rssi_Past_Date", currentByte, 813, 6),
                Rssi_Reg_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_PackedData", currentByte, 819, 6),

                Rssi_Late_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_PackedData", currentByte, 825, 6),
                Rssi_Billing_Opt = PackedTypeCheckAndUnPackData("Rssi_Billing_Opt", currentByte, 921, 1),

                Rssi_Alt_Ov_Un_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Ov_Un_PackedData", currentByte, 922, 4),
                Rssi_Indx_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Indx_Dt_PackedData", currentByte, 926, 4),

                Rssi_Curr_Indx_PackedData = PackedTypeCheckAndUnPackData("Rssi_Curr_Indx_PackedData", currentByte, 930, 4),
                Rssi_Mkt_Ov_Un_PackedData = PackedTypeCheckAndUnPackData("Rssi_Mkt_Ov_Un_PackedData", currentByte, 934, 4),

                Rssi_Int_Pmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Int_Pmt_PackedData", currentByte, 938, 6),
                Rssi_Amort_Pmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Amort_Pmt_PackedData", currentByte, 944, 6),

                Rssi_Bill_Method_PackedData = PackedTypeCheckAndUnPackData("Rssi_Bill_Method_PackedData", currentByte, 950, 1),
                Rssi_Ach_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Ach_Acct_No", currentByte, 951, 20),

                Rssi_Anl_Indx_Rte_PackedData = PackedTypeCheckAndUnPackData("Rssi_Anl_Indx_Rte_PackedData", currentByte, 971, 4),
                Rssi_Int_Meth_PackedData = PackedTypeCheckAndUnPackData("Rssi_Int_Meth_PackedData", currentByte, 975, 2),

                Rssi_Cross_Sell_Flag = PackedTypeCheckAndUnPackData("Rssi_Cross_Sell_Flag", currentByte, 977, 1),
                Rssi_Mult_Loan_Flag = PackedTypeCheckAndUnPackData("Rssi_Mult_Loan_Flag", currentByte, 978, 1),

                Rssi_Primary_Social_Fill = PackedTypeCheckAndUnPackData("Rssi_Primary_Social_Fill", currentByte, 979, 1),
                Rssi_Primary_Social_Sec = PackedTypeCheckAndUnPackData("Rssi_Primary_Social_Sec", currentByte, 980, 4),

                Rssi_Repy_Plan_Due_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Repy_Plan_Due_Date_PackedData", currentByte, 984, 6),
                Rssi_Amort_Fee_Pymt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Amort_Fee_Pymt_PackedData", currentByte, 990, 5),

                Rssi_Repay_Amt_Due_PackedData = PackedTypeCheckAndUnPackData("Rssi_Repay_Amt_Due_PackedData", currentByte, 995, 4),
                Rssi_Repy_Remain_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Repy_Remain_Bal_PackedData", currentByte, 999, 6),

                Rssi_Email_Bill_Ind = PackedTypeCheckAndUnPackData("Rssi_Email_Bill_Ind", currentByte, 1005, 1),
                Rssi_Primary_Email_Adr = PackedTypeCheckAndUnPackData("Rssi_Primary_Email_Adr", currentByte, 1006, 40),

                Rssi_Primary_Fax_Phone_PackedData = PackedTypeCheckAndUnPackData("Rssi_Primary_Fax_Phone_PackedData", currentByte, 1046, 6),
                Rssi_Primary_Cell_Ph_PackedData = PackedTypeCheckAndUnPackData("Rssi_Primary_Cell_Ph_PackedData", currentByte, 1052, 6),

                Rssi_Direct_Mail = PackedTypeCheckAndUnPackData("Rssi_Direct_Mail", currentByte, 1058, 2),
                Rssi_Telemarket = PackedTypeCheckAndUnPackData("Rssi_Telemarket", currentByte, 1060, 2),

                Rssi_Fees_New_PackedData = PackedTypeCheckAndUnPackData("Rssi_Fees_New_PackedData", currentByte, 1062, 5),
                Rssi_Serv_Date = PackedTypeCheckAndUnPackData("Rssi_Serv_Date", currentByte, 1067, 8),

                Rssi_First_Stmt_Ind = PackedTypeCheckAndUnPackData("Rssi_First_Stmt_Ind", currentByte, 1075, 1),
                Rssi_Mail_Cd = PackedTypeCheckAndUnPackData("Rssi_Mail_Cd", currentByte, 1076, 1),

                Rssi_Spec_Stmt_Req = PackedTypeCheckAndUnPackData("Rssi_Spec_Stmt_Req", currentByte, 1077, 1),
                Rssi_Stop_1 = PackedTypeCheckAndUnPackData("Rssi_Stop_1", currentByte, 1078, 1),

                Rssi_Opt_In_Flag = PackedTypeCheckAndUnPackData("Rssi_Opt_In_Flag", currentByte, 1079, 1),
                Rssi_Opt_Out_Flag = PackedTypeCheckAndUnPackData("Rssi_Opt_Out_Flag", currentByte, 1080, 1),

                Rssi_Ml_Scnd_Email_Bill_Ind = PackedTypeCheckAndUnPackData("Rssi_Ml_Scnd_Email_Bill_Ind", currentByte, 1081, 1),
                Rssi_First_Due_Dt = PackedTypeCheckAndUnPackData("Rssi_First_Due_Dt", currentByte, 1082, 8),

                Rssi_Mort_Ln_Flg = PackedTypeCheckAndUnPackData("Rssi_Mort_Ln_Flg", currentByte, 1090, 1),
                Rssi_Purch_From_Name = PackedTypeCheckAndUnPackData("Rssi_Purch_From_Name", currentByte, 1091, 34),

                Rssi_Uncoll_Nsf_Fees = PackedTypeCheckAndUnPackData("Rssi_Uncoll_Nsf_Fees", currentByte, 1125, 7),
                Rssi_Uncoll_Ext_Fees = PackedTypeCheckAndUnPackData("Rssi_Uncoll_Ext_Fees", currentByte, 1132, 7),

                Rssi_Prim_Home_Ph = PackedTypeCheckAndUnPackData("Rssi_Prim_Home_Ph", currentByte, 1139, 11),
                Rssi_V_Tax_Id = PackedTypeCheckAndUnPackData("Rssi_V_Tax_Id", currentByte, 1150, 11),

                Rssi_F_O_Flag_1 = PackedTypeCheckAndUnPackData("Rssi_F_O_Flag_1", currentByte, 1161, 1),
                Rssi_F_O_Flag_2 = PackedTypeCheckAndUnPackData("Rssi_F_O_Flag_2", currentByte, 1162, 1),

                Rssi_F_O_Flag_3 = PackedTypeCheckAndUnPackData("Rssi_F_O_Flag_3", currentByte, 1163, 1),
                Rssi_F_O_Flag_4 = PackedTypeCheckAndUnPackData("Rssi_F_O_Flag_4", currentByte, 1164, 1),

                Rssi_F_O_Flag_5 = PackedTypeCheckAndUnPackData("Rssi_F_O_Flag_5", currentByte, 1165, 1),
                FillerPart3 = PackedTypeCheckAndUnPackData("FillerPart3", currentByte, 1166, 5),

                Rssi_Scnd_Social_Sec = PackedTypeCheckAndUnPackData("Rssi_Scnd_Social_Sec", currentByte, 1171, 4),
                Rssi_Origin_Date = PackedTypeCheckAndUnPackData("Rssi_Origin_Date", currentByte, 1175, 8),

                Rssi_Int_Start_Dt = PackedTypeCheckAndUnPackData("Rssi_Int_Start_Dt", currentByte, 1183, 8),
                Rssi_Term_Clos = PackedTypeCheckAndUnPackData("Rssi_Term_Clos", currentByte, 1191, 3),

                Rssi_Couns_Cd = PackedTypeCheckAndUnPackData("Rssi_Couns_Cd", currentByte, 1194, 5),
                Rssi_Updated_Term = PackedTypeCheckAndUnPackData("Rssi_Updated_Term", currentByte, 1199, 3),

                Rssi_Modify_Date = PackedTypeCheckAndUnPackData("Rssi_Modify_Date", currentByte, 1202, 8),
                Rssi_Var_Rate = PackedTypeCheckAndUnPackData("Rssi_Var_Rate", currentByte, 1210, 1),

                Rssi_Name_Chg_Ind = PackedTypeCheckAndUnPackData("Rssi_Name_Chg_Ind", currentByte, 1211, 1),
                Rssi_Addr_Chg_Ind = PackedTypeCheckAndUnPackData("Rssi_Addr_Chg_Ind", currentByte, 1212, 1),

                Rssi_Balloon_Date = PackedTypeCheckAndUnPackData("Rssi_Balloon_Date", currentByte, 1213, 8),
                Rssi_Times_Delq_30 = PackedTypeCheckAndUnPackData("Rssi_Times_Delq_30", currentByte, 1221, 3),

                Rssi_Times_Delq_60 = PackedTypeCheckAndUnPackData("Rssi_Times_Delq_60", currentByte, 1224, 3),
                Rssi_Times_Delq_90 = PackedTypeCheckAndUnPackData("Rssi_Times_Delq_90", currentByte, 1227, 3),

                Rssi_Nsf_Tl_Ctr = PackedTypeCheckAndUnPackData("Rssi_Nsf_Tl_Ctr", currentByte, 1230, 3),
                Rssi_Dem1_Prim_Birthdt = PackedTypeCheckAndUnPackData("Rssi_Dem1_Prim_Birthdt", currentByte, 1233, 8),

                Rssi_Dem1_Cb_Score_1 = PackedTypeCheckAndUnPackData("Rssi_Dem1_Cb_Score_1", currentByte, 1241, 15),
                Rssi_Dem1_Cb_Score_2 = PackedTypeCheckAndUnPackData("Rssi_Dem1_Cb_Score_2", currentByte, 1256, 15),

                Rssi_Dem1_Cb_Score_3 = PackedTypeCheckAndUnPackData("Rssi_Dem1_Cb_Score_3", currentByte, 1271, 15),
                Rssi_Ext_Latest_Post_Dt = PackedTypeCheckAndUnPackData("Rssi_Ext_Latest_Post_Dt", currentByte, 1286, 8),

                Rssi_Ext_Tot_Act_Ext = PackedTypeCheckAndUnPackData("Rssi_Ext_Tot_Act_Ext", currentByte, 1294, 3),
                Rssi_Pre_Note = PackedTypeCheckAndUnPackData("Rssi_Pre_Note", currentByte, 1297, 1),

                Rssi_Prim_Work_Ph = PackedTypeCheckAndUnPackData("Rssi_Prim_Work_Ph", currentByte, 1298, 11),
                Rssi_Eoyh_Int_Gross = PackedTypeCheckAndUnPackData("Rssi_Eoyh_Int_Gross", currentByte, 1309, 11),

                Rssi_Foreclosure_Adv = PackedTypeCheckAndUnPackData("Rssi_Foreclosure_Adv", currentByte, 1320, 7),
                Rssi_Net_Investment = PackedTypeCheckAndUnPackData("Rssi_Net_Investment", currentByte, 1327, 11),

                Rssi_Orig_Dcnt_Amount = PackedTypeCheckAndUnPackData("Rssi_Orig_Dcnt_Amount", currentByte, 1338, 9),
                Rssi_Tot_Pymts_Lol = PackedTypeCheckAndUnPackData("Rssi_Tot_Pymts_Lol", currentByte, 1347, 13),

                Rssi_Monthly_Int_Rate = PackedTypeCheckAndUnPackData("Rssi_Monthly_Int_Rate", currentByte, 1360, 7),
                Rssi_Num_Days_Delq = PackedTypeCheckAndUnPackData("Rssi_Num_Days_Delq", currentByte, 1367, 5),

                Rssi_Optn_Maint_Dt = PackedTypeCheckAndUnPackData("Rssi_Optn_Maint_Dt", currentByte, 1372, 8),
                Rssi_Prior_Acnt_Nbr = PackedTypeCheckAndUnPackData("Rssi_Prior_Acnt_Nbr", currentByte, 1380, 20),

                Rssi_Last_Pymt_Dt = PackedTypeCheckAndUnPackData("Rssi_Last_Pymt_Dt", currentByte, 1400, 8),
                Rssi_Prim_Marital_Stat = PackedTypeCheckAndUnPackData("Rssi_Prim_Marital_Stat", currentByte, 1408, 1),

                Rssi_Cls_Cd = PackedTypeCheckAndUnPackData("Rssi_Cls_Cd", currentByte, 1409, 1),
                Rssi_Reo_Ind = PackedTypeCheckAndUnPackData("Rssi_Reo_Ind", currentByte, 1410, 1),

                Rssi_Mat_Date = PackedTypeCheckAndUnPackData("Rssi_Mat_Date", currentByte, 1411, 8),

                Rssi_Lien_3_Pymt_Amt = PackedTypeCheckAndUnPackData("Rssi_Lien_3_Pymt_Amt", currentByte, 1419, 11),

                Rssi_L_Flag = PackedTypeCheckAndUnPackData("Rssi_L_Flag", currentByte, 1430, 1),
                Rssi_Stop_Code_2 = PackedTypeCheckAndUnPackData("Rssi_Stop_Code_2", currentByte, 1431, 1),

                Rssi_Stop_Code_3 = PackedTypeCheckAndUnPackData("Rssi_Stop_Code_3", currentByte, 1432, 1),
                Rssi_Fico_Score = PackedTypeCheckAndUnPackData("Rssi_Fico_Score", currentByte, 1433, 5),

                Rssi_Nsf_Indicator = PackedTypeCheckAndUnPackData("Rssi_Nsf_Indicator", currentByte, 1438, 1),
                Rssi_Empl_Code = PackedTypeCheckAndUnPackData("Rssi_Empl_Code", currentByte, 1439, 1),

                Rssi_Audit_Date = PackedTypeCheckAndUnPackData("Rssi_Audit_Date", currentByte, 1440, 8),
                Rssi_Prim_Age = PackedTypeCheckAndUnPackData("Rssi_Prim_Age", currentByte, 1448, 3),

                Rssi_Scnd_Age = PackedTypeCheckAndUnPackData("Rssi_Scnd_Age", currentByte, 1451, 3),
                Rssi_Realtr_Bldr = PackedTypeCheckAndUnPackData("Rssi_Realtr_Bldr", currentByte, 1454, 5),

                Rssi_Usr_01_PackedData = PackedTypeCheckAndUnPackData("Rssi_Usr_01_PackedData", currentByte, 1459, 4),
                Rssi_Tot_Fees_Due_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tot_Fees_Due_PackedData", currentByte, 1463, 5),

                Rssi_Rd_Status = PackedTypeCheckAndUnPackData("Rssi_Rd_Status", currentByte, 1468, 1),
                Rssi_Int_Refi_Code = PackedTypeCheckAndUnPackData("Rssi_Int_Refi_Code", currentByte, 1469, 1),

                Rssi_Usr_07 = PackedTypeCheckAndUnPackData("Rssi_Usr_07", currentByte, 1470, 2),
                Rssi_Usr_36 = PackedTypeCheckAndUnPackData("Rssi_Usr_36", currentByte, 1472, 1),

                Rssi_Ln_Ext_Extend_Int_PackedData = PackedTypeCheckAndUnPackData("Rssi_Ln_Ext_Extend_Int_PackedData", currentByte, 1473, 6),
                Rssi_Stmnt_Freq_Type = PackedTypeCheckAndUnPackData("Rssi_Stmnt_Freq_Type", currentByte, 1479, 2),

                Rssi_Stmnt_Chg_Dt = PackedTypeCheckAndUnPackData("Rssi_Stmnt_Chg_Dt", currentByte, 1481, 8),
                Rssi_Accel_Apds_Part = PackedTypeCheckAndUnPackData("Rssi_Accel_Apds_Part", currentByte, 1489, 1),

                Rssi_Accel_Prog_Ind = PackedTypeCheckAndUnPackData("Rssi_Accel_Prog_Ind", currentByte, 1490, 2),
                Rssi_Org_Code = PackedTypeCheckAndUnPackData("Rssi_Org_Code", currentByte, 1492, 5),

                Rssi_Nimx_Plss_Entity = PackedTypeCheckAndUnPackData("Rssi_Nimx_Plss_Entity", currentByte, 1497, 3),
                Rssi_Rate_Chg_Date = PackedTypeCheckAndUnPackData("Rssi_Rate_Chg_Date", currentByte, 1500, 8),

                Rssi_Prepay_Pen_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Prepay_Pen_Amt_PackedData", currentByte, 1508, 6),
                Rssi_Prin_Paid_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Prin_Paid_Ytd_PackedData", currentByte, 1514, 6),

                Rssi_Esc_Paid_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Esc_Paid_Ytd_PackedData", currentByte, 1520, 6),
                Rssi_Fees_Paid_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Fees_Paid_Ytd_PackedData", currentByte, 1526, 5),

                Rssi_Late_Chg_Paid_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Late_Chg_Paid_Ytd_PackedData", currentByte, 1531, 5),
                Rssi_Pmt_Due_Date_1 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_1", currentByte, 1536, 6),

                Rssi_Pmt_Paid_Date_1 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_1", currentByte, 1542, 6),
                Rssi_Pmt_Due_Date_2 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_2", currentByte, 1548, 6),

                Rssi_Pmt_Paid_Date_2 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_2", currentByte, 1554, 6),
                Rssi_Pmt_Due_Date_3 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_3", currentByte, 1560, 6),

                Rssi_Pmt_Paid_Date_3 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_3", currentByte, 1566, 6),
                Rssi_Pmt_Due_Date_4 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_4", currentByte, 1572, 6),

                Rssi_Pmt_Paid_Date_4 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_4", currentByte, 1578, 6),
                Rssi_Pmt_Due_Date_5 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_5", currentByte, 1584, 6),

                Rssi_Pmt_Paid_Date_5 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_5", currentByte, 1590, 6),
                Rssi_Pmt_Due_Date_6 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_6", currentByte, 1596, 6),

                Rssi_Pmt_Paid_Date_6 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_6", currentByte, 1602, 6),
                Rssi_Prin_Pd_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Prin_Pd_Since_Lst_Stmt_PackedData", currentByte, 1608, 7),

                Rssi_Int_Pd_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Int_Pd_Since_Lst_Stmt_PackedData", currentByte, 1615, 7),
                Rssi_Esc_Pd_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Esc_Pd_Since_Lst_Stmt_PackedData", currentByte, 1622, 7),

                Rssi_Lc_Pd_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lc_Pd_Since_Lst_Stmt_PackedData", currentByte, 1629, 6),
                Rssi_Fees_Pd_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Fees_Pd_Since_Lst_Stmt_PackedData", currentByte, 1635, 7),

                Rssi_Amt_To_Uaf_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Amt_To_Uaf_Since_Lst_Stmt_PackedData", currentByte, 1642, 6),
                Rssi_Tot_Pd_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tot_Pd_Since_Lst_Stmt_PackedData", currentByte, 1648, 8),

                Rssi_Fees_Assd_Since_Lst_Stmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Fees_Assd_Since_Lst_Stmt_PackedData", currentByte, 1656, 6),
                Rssi_Accr_Lc_PackedData = PackedTypeCheckAndUnPackData("Rssi_Accr_Lc_PackedData", currentByte, 1662, 6),

                Rssi_Loss_Mit_Ind = PackedTypeCheckAndUnPackData("Rssi_Loss_Mit_Ind", currentByte, 1668, 1),
                Rssi_1St_Contact_Name = PackedTypeCheckAndUnPackData("Rssi_1St_Contact_Name", currentByte, 1669, 20),

                Rssi_1St_Contact_Adrs_1 = PackedTypeCheckAndUnPackData("Rssi_1St_Contact_Adrs_1", currentByte, 1689, 50),
                Rssi_1St_Contact_City = PackedTypeCheckAndUnPackData("Rssi_1St_Contact_City", currentByte, 1739, 20),

                Rssi_1St_Contact_St = PackedTypeCheckAndUnPackData("Rssi_1St_Contact_St", currentByte, 1759, 2),
                Rssi_1St_Contact_Zip = PackedTypeCheckAndUnPackData("Rssi_1St_Contact_Zip", currentByte, 1761, 10),

                Rssi_1St_Contact_Phone = PackedTypeCheckAndUnPackData("Rssi_1St_Contact_Phone", currentByte, 1771, 15),
                Rssi_1St_Contact_Ph_Ext = PackedTypeCheckAndUnPackData("Rssi_1St_Contact_Ph_Ext", currentByte, 1786, 5),

                Rssi_Past_Date_R = PackedTypeCheckAndUnPackData("Rssi_Past_Date_R", currentByte, 1791, 6),
                Rssi_Reg_Amt_R_PackedData = PackedTypeCheckAndUnPackData("Rssi_Reg_Amt_R_PackedData", currentByte, 1797, 6),
                Rssi_Late_Amt_R_PackedData = PackedTypeCheckAndUnPackData("Rssi_Late_Amt_R_PackedData", currentByte, 1803, 6),

                Rssi_Pmt_Due_Date_7 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_7", currentByte, 2187, 6),
                Rssi_Pmt_Paid_Date_7 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_7", currentByte, 2193, 6),

                Rssi_Pmt_Due_Date_8 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_8", currentByte, 2199, 6),
                Rssi_Pmt_Paid_Date_8 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_8", currentByte, 2205, 6),

                Rssi_Pmt_Due_Date_9 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_9", currentByte, 2211, 6),
                Rssi_Pmt_Paid_Date_9 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_9", currentByte, 2217, 6),

                Rssi_Pmt_Due_Date_10 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_10", currentByte, 2223, 6),
                Rssi_Pmt_Paid_Date_10 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_10", currentByte, 2229, 6),

                Rssi_Pmt_Due_Date_11 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_11", currentByte, 2235, 6),
                Rssi_Pmt_Paid_Date_11 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_11", currentByte, 2241, 6),

                Rssi_Pmt_Due_Date_12 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_12", currentByte, 2247, 6),
                Rssi_Pmt_Paid_Date_12 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_12", currentByte, 2253, 6),

                Rssi_Pmt_Due_Date_13 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_13", currentByte, 2259, 6),
                Rssi_Pmt_Paid_Date_13 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_13", currentByte, 2265, 6),

                Rssi_Pmt_Due_Date_14 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_14", currentByte, 2271, 6),
                Rssi_Pmt_Paid_Date_14 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_14", currentByte, 2277, 6),

                Rssi_Pmt_Due_Date_15 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_15", currentByte, 2283, 6),
                Rssi_Pmt_Paid_Date_15 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_15", currentByte, 2289, 6),

                Rssi_Pmt_Due_Date_16 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_16", currentByte, 2295, 6),
                Rssi_Pmt_Paid_Date_16 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_16", currentByte, 2301, 6),

                Rssi_Pmt_Due_Date_17 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_17", currentByte, 2307, 6),
                Rssi_Pmt_Paid_Date_17 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_17", currentByte, 2313, 6),

                Rssi_Pmt_Due_Date_18 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_18", currentByte, 2319, 6),
                Rssi_Pmt_Paid_Date_18 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_18", currentByte, 2325, 6),

                Rssi_Pmt_Due_Date_19 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_19", currentByte, 2331, 6),
                Rssi_Pmt_Paid_Date_19 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_19", currentByte, 2337, 6),

                Rssi_Pmt_Due_Date_20 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_20", currentByte, 2343, 6),
                Rssi_Pmt_Paid_Date_20 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_20", currentByte, 2349, 6),

                Rssi_Pmt_Due_Date_21 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_21", currentByte, 2355, 6),
                Rssi_Pmt_Paid_Date_21 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_21", currentByte, 2361, 6),

                Rssi_Pmt_Due_Date_22 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_22", currentByte, 2367, 6),
                Rssi_Pmt_Paid_Date_22 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_22", currentByte, 2373, 6),


                Rssi_Pmt_Due_Date_23 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_23", currentByte, 2379, 6),
                Rssi_Pmt_Paid_Date_23 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_23", currentByte, 2385, 6),

                Rssi_Pmt_Due_Date_24 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_24", currentByte, 2391, 6),
                Rssi_Pmt_Paid_Date_24 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_24", currentByte, 2397, 6),

                Rssi_Pmt_Due_Date_25 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_25", currentByte, 2403, 6),
                Rssi_Pmt_Paid_Date_25 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_25", currentByte, 2409, 6),

                Rssi_Pmt_Due_Date_26 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_26", currentByte, 2415, 6),
                Rssi_Pmt_Paid_Date_26 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_26", currentByte, 2421, 6),

                Rssi_Pmt_Due_Date_27 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_27", currentByte, 2427, 6),
                Rssi_Pmt_Paid_Date_27 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_27", currentByte, 2433, 6),

                Rssi_Pmt_Due_Date_28 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Due_Date_28", currentByte, 2439, 6),
                Rssi_Pmt_Paid_Date_28 = PackedTypeCheckAndUnPackData("Rssi_Pmt_Paid_Date_28", currentByte, 2445, 6),

                Rssi_Cash_Tran_Opt_Out = PackedTypeCheckAndUnPackData("Rssi_Cash_Tran_Opt_Out", currentByte, 2451, 1),
                Rssi_Mult_Loan_Ind = PackedTypeCheckAndUnPackData("Rssi_Mult_Loan_Ind", currentByte, 2452, 1),

                Rssi_Last_Ann_Stmt_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Last_Ann_Stmt_Dt_PackedData", currentByte, 2453, 4),
                Rssi_Last_Ann_Stmt_Meth = PackedTypeCheckAndUnPackData("Rssi_Last_Ann_Stmt_Meth", currentByte, 2457, 2),

                Rssi_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Opt_Out_Type", currentByte, 2459, 1),
                Rssi_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Opt_Out_Date_PackedData", currentByte, 2460, 4),

                Rssi_Special_Contact_Code = PackedTypeCheckAndUnPackData("Rssi_Special_Contact_Code", currentByte, 2464, 5),
                Rssi_Last_Dscl_Notice_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Last_Dscl_Notice_Dt_PackedData", currentByte, 2469, 4),

                Rssi_Last_Dscl_Notice_Meth = PackedTypeCheckAndUnPackData("Rssi_Last_Dscl_Notice_Meth", currentByte, 2473, 2),
                Rssi_Prim_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Prim_Opt_Out_Type", currentByte, 2475, 1),

                Rssi_Prim_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Prim_Opt_Out_Date_PackedData", currentByte, 2476, 4),
                Rssi_Scnd_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Scnd_Opt_Out_Type", currentByte, 2480, 1),
                Rssi_Scnd_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Scnd_Opt_Out_Date_PackedData", currentByte, 2481, 4),

                Rssi_Cbwr1_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr1_Opt_Out_Type", currentByte, 2485, 1),
                Rssi_Cbwr1_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr1_Opt_Out_Date_PackedData", currentByte, 2486, 4),

                Rssi_Cbwr2_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr2_Opt_Out_Type", currentByte, 2490, 1),
                Rssi_Cbwr2_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr2_Opt_Out_Date_PackedData", currentByte, 2491, 4),

                Rssi_Cbwr3_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr3_Opt_Out_Type", currentByte, 2495, 1),
                Rssi_Cbwr3_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr3_Opt_Out_Date_PackedData", currentByte, 2496, 4),

                Rssi_Cbwr4_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr4_Opt_Out_Type", currentByte, 2500, 1),
                Rssi_Cbwr4_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr4_Opt_Out_Date_PackedData", currentByte, 2501, 4),

                Rssi_Cbwr5_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr5_Opt_Out_Type", currentByte, 2505, 1),
                Rssi_Cbwr5_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr5_Opt_Out_Date_PackedData", currentByte, 2506, 4),

                Rssi_Cbwr6_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr6_Opt_Out_Type", currentByte, 2510, 1),
                Rssi_Cbwr6_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 2511, 4),

                Rssi_Cbwr7_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr7_Opt_Out_Type", currentByte, 2515, 1),
                Rssi_Cbwr7_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr7_Opt_Out_Date_PackedData", currentByte, 2516, 4),

                Rssi_Cbwr8_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr8_Opt_Out_Type", currentByte, 2520, 1),
                Rssi_Cbwr8_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr8_Opt_Out_Date_PackedData", currentByte, 2521, 4),

                Rssi_Cbwr9_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr9_Opt_Out_Type", currentByte, 2525, 1),
                Rssi_Cbwr9_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr9_Opt_Out_Date_PackedData", currentByte, 2526, 4),

                Rssi_Cbwr10_Opt_Out_Type = PackedTypeCheckAndUnPackData("Rssi_Cbwr10_Opt_Out_Type", currentByte, 2530, 1),
                Rssi_Cbwr10_Opt_Out_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Cbwr10_Opt_Out_Date_PackedData", currentByte, 2531, 4),

                Rssi_Accelerated_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Accelerated_Dt_PackedData", currentByte, 2535, 4),
                Rssi_Accelerated_Interest_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Accelerated_Interest_Amt_PackedData", currentByte, 2539, 6),

                Rssi_Print_Stmt = PackedTypeCheckAndUnPackData("Rssi_Print_Stmt", currentByte, 2545, 1),
                Rssi_Part_Pymts_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Part_Pymts_Ytd_PackedData", currentByte, 2546, 5),

                Rssi_Closing_Int_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Closing_Int_Ytd_PackedData", currentByte, 2551, 6),
                Rssi_Payoff_Amount = PackedTypeCheckAndUnPackData("Rssi_Payoff_Amount", currentByte, 2557, 6),

                Rssi_Prim_Attention = PackedTypeCheckAndUnPackData("Rssi_Prim_Attention", currentByte, 2563, 35),
                Rssi_Dsi_Accr_Int = PackedTypeCheckAndUnPackData("Rssi_Dsi_Accr_Int", currentByte, 2598, 6),

                Rssi_Accelerated_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Accelerated_Amt_PackedData", currentByte, 2604, 7),
                Rssi_Reinstatement_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Reinstatement_Dt_PackedData", currentByte, 2611, 4),

                Rssi_Reinstatement_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Reinstatement_Amt_PackedData", currentByte, 2615, 7),
                Rssi_Task605_Comp_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Task605_Comp_Dt_PackedData", currentByte, 2622, 4),

                Rssi_Next_Draft_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Next_Draft_Dt_PackedData", currentByte, 2626, 4),
                Rssi_Breach_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Breach_Date_PackedData", currentByte, 2630, 4),

                Rssi_Chrg_Off_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Chrg_Off_Dt_PackedData", currentByte, 2634, 4),
                Rssi_Promise_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Promise_Date_PackedData", currentByte, 2638, 4),

                Rssi_Promise_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Promise_Amt_PackedData", currentByte, 2642, 5),
                Rssi_Promise_Broken_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Promise_Broken_Dt_PackedData", currentByte, 2647, 4),

                Rssi_Promise_Kept_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Promise_Kept_Date_PackedData", currentByte, 2651, 4),
                FillerPart4 = PackedTypeCheckAndUnPackData("FillerPart4", currentByte, 2655, 1356),

            };
        }

        // 2 Master File Data Part 2 Record.One record per loan.
        public void GetMasterFileDataPart_2(byte[] currentByte, ref AccountsModel acc)
        {

            acc.MasterFileDataPart2Model = new MasterFileDataPart2Model()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("", currentByte, 2, 3),
                Rssi_Acct_No = PackedTypeCheckAndUnPackData("", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("", currentByte, 15, 5),

                Rssi_Unap_Bal_2_PackedData = PackedTypeCheckAndUnPackData("Rssi_Unap_Bal_2_PackedData", currentByte, 20, 5),
                Rssi_Unap_Cd_2 = PackedTypeCheckAndUnPackData("", currentByte, 25, 1),

                Rssi_Unap_Bal_3_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 26, 5),
                Rssi_Unap_Cd_3 = PackedTypeCheckAndUnPackData("", currentByte, 31, 1),

                Rssi_Unap_Bal_4_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 32, 5),
                Rssi_Unap_Cd_4 = PackedTypeCheckAndUnPackData("", currentByte, 37, 1),

                Rssi_Unap_Bal_5_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 38, 5),
                Rssi_Unap_Cd_5 = PackedTypeCheckAndUnPackData("", currentByte, 43, 1),

                Rssi_Unap_Bal_Tot_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 44, 6),
                Rssi_Tot_Draft_Amt_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 50, 6),

                Rssi_Rd_Bk_Draft_Amt_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 56, 6),
                Filler = PackedTypeCheckAndUnPackData("", currentByte, 62, 26),

                Rssi_Uncoll_Pi_Adv_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 88, 6),
                Rssi_Orig_Mat_Date = PackedTypeCheckAndUnPackData("", currentByte, 94, 5),

                Rssi_Delq_Couns = PackedTypeCheckAndUnPackData("", currentByte, 99, 3),
                Rssi_Bmsg_Code_01 = PackedTypeCheckAndUnPackData("", currentByte, 102, 6),

                Rssi_Bmsg_Code_02 = PackedTypeCheckAndUnPackData("", currentByte, 108, 6),
                Rssi_Bmsg_Code_03 = PackedTypeCheckAndUnPackData("", currentByte, 114, 6),

                Rssi_Bmsg_Code_04 = PackedTypeCheckAndUnPackData("", currentByte, 120, 6),
                Rssi_Bmsg_Code_05 = PackedTypeCheckAndUnPackData("", currentByte, 126, 6),

                Rssi_Bmsg_Code_06 = PackedTypeCheckAndUnPackData("", currentByte, 132, 6),
                Rssi_Bmsg_Code_07 = PackedTypeCheckAndUnPackData("", currentByte, 138, 6),

                Rssi_Bmsg_Code_08 = PackedTypeCheckAndUnPackData("", currentByte, 144, 6),
                Rssi_Bmsg_Code_09 = PackedTypeCheckAndUnPackData("", currentByte, 150, 6),

                Rssi_Bmsg_Code_10 = PackedTypeCheckAndUnPackData("", currentByte, 156, 6),
                Rssi_Bmsg_Code_11 = PackedTypeCheckAndUnPackData("", currentByte, 162, 6),

                Rssi_Bmsg_Code_12 = PackedTypeCheckAndUnPackData("", currentByte, 168, 6),
                Rssi_Bmsg_Code_13 = PackedTypeCheckAndUnPackData("", currentByte, 174, 6),

                Rssi_Bmsg_Code_14 = PackedTypeCheckAndUnPackData("", currentByte, 180, 6),
                Rssi_Bmsg_Code_15 = PackedTypeCheckAndUnPackData("", currentByte, 186, 6),

                Rssi_Bmsg_Code_16 = PackedTypeCheckAndUnPackData("", currentByte, 192, 6),
                Rssi_Bmsg_Code_17 = PackedTypeCheckAndUnPackData("", currentByte, 198, 6),

                Rssi_Bmsg_Code_18 = PackedTypeCheckAndUnPackData("", currentByte, 204, 6),
                Rssi_Bmsg_Code_19 = PackedTypeCheckAndUnPackData("", currentByte, 210, 6),
                Rssi_Bmsg_Code_20 = PackedTypeCheckAndUnPackData("", currentByte, 216, 6),

                Rssi_Prim_Forgn_Flag = PackedTypeCheckAndUnPackData("", currentByte, 222, 1),
                Rssi_Altr_Forgn_Flag = PackedTypeCheckAndUnPackData("", currentByte, 223, 1),

                Rssi_Appl_Foreign_Flag = PackedTypeCheckAndUnPackData("", currentByte, 224, 1),
                Rssi_Def_Tot_Bal = PackedTypeCheckAndUnPackData("", currentByte, 225, 7),

                Rssi_Def_Int_Bal_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 232, 6),
                Rssi_Def_Late_Chrg_Bal_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 238, 4),

                Rssi_Def_Escrow_Adv_Bal_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 242, 6),
                Rssi_Def_Paid_Exp_Adv_Bal_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 248, 6),

                Rssi_Def_Unpd_Exp_Adv_Bal_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 254, 6),
                Rssi_Def_Admn_Fees_Bal = PackedTypeCheckAndUnPackData("", currentByte, 260, 6),

                Rssi_Borr_Lnge = PackedTypeCheckAndUnPackData("", currentByte, 266, 1),
                Rssi_Uncoll_Esc_Short = PackedTypeCheckAndUnPackData("", currentByte, 267, 6),

                Rssi_Def_Opt_Ins_Bal_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 273, 5),
                Rssi_Clo_Agent_Cd = PackedTypeCheckAndUnPackData("", currentByte, 278, 5),

                FillerPart2 = PackedTypeCheckAndUnPackData("", currentByte, 283, 13),
                Rssi_Def_Prin_Bal_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 296, 6),

                Rssi_Comb_Prin_Bal_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 302, 6),
                Rssi_Pra_Original_Amount_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 308, 6),

                Rssi_Pra_Remain_Amt_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 314, 6),
                Rssi_Pra_Taken_Amt_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 320, 6),

                Rssi_Lmt_Program = PackedTypeCheckAndUnPackData("", currentByte, 326, 3),
                Rssi_Fcl_Start_Date = PackedTypeCheckAndUnPackData("", currentByte, 329, 6),

                Rssi_Breach_Ltr_Dt = PackedTypeCheckAndUnPackData("", currentByte, 335, 6),
                Rssi_Higher_Priced_Flag = PackedTypeCheckAndUnPackData("", currentByte, 341, 1),

                Rssi_Hpml_Escrow_Reqd_Thru_Dt = PackedTypeCheckAndUnPackData("", currentByte, 342, 8),
                Filler_350_536 = PackedTypeCheckAndUnPackData("", currentByte, 350, 187),

                Rssi_Ml_Curr_Occ_Code = PackedTypeCheckAndUnPackData("", currentByte, 537, 1),
                Filler_538_1500 = PackedTypeCheckAndUnPackData("", currentByte, 538, 965),

            };
        }

        // U User Field Record. One record per loan if applicable.
        public void GetUserFieldRecord(byte[] currentByte, ref AccountsModel acc)
        {
            acc.UserFieldRecordModel = new UserFieldRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("", currentByte, 2, 3),
                Rssi_Acct_No = PackedTypeCheckAndUnPackData("", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("", currentByte, 15, 5),
                Rssi_Usr_02_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 20, 4),
                Rssi_Usr_03 = PackedTypeCheckAndUnPackData("", currentByte, 24, 1),
                Rssi_Usr_04 = PackedTypeCheckAndUnPackData("", currentByte, 25, 1),
                Rssi_Usr_05 = PackedTypeCheckAndUnPackData("", currentByte, 26, 1),
                Rssi_Usr_06 = PackedTypeCheckAndUnPackData("", currentByte, 27, 1),
                Rssi_Usr_08 = PackedTypeCheckAndUnPackData("", currentByte, 28, 2),
                Rssi_Usr_09 = PackedTypeCheckAndUnPackData("", currentByte, 30, 2),
                Rssi_Usr_10 = PackedTypeCheckAndUnPackData("", currentByte, 32, 2),
                Rssi_Usr_11 = PackedTypeCheckAndUnPackData("", currentByte, 34, 3),
                Rssi_Usr_12 = PackedTypeCheckAndUnPackData("", currentByte, 37, 3),
                Rssi_Usr_13 = PackedTypeCheckAndUnPackData("", currentByte, 40, 3),
                Rssi_Usr_14 = PackedTypeCheckAndUnPackData("", currentByte, 43, 6),
                Rssi_Usr_15_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 49, 4),
                Rssi_Usr_16_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 53, 4),
                Rssi_Usr_17_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 57, 5),
                Rssi_Usr_18 = PackedTypeCheckAndUnPackData("", currentByte, 62, 15),
                Rssi_Usr_19 = PackedTypeCheckAndUnPackData("", currentByte, 77, 5),
                Rssi_Usr_20_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 82, 2),
                Rssi_Usr_21 = PackedTypeCheckAndUnPackData("", currentByte, 84, 10),
                Rssi_Usr_22 = PackedTypeCheckAndUnPackData("", currentByte, 94, 10),
                Rssi_Usr_23 = PackedTypeCheckAndUnPackData("", currentByte, 104, 6),
                Rssi_Usr_24 = PackedTypeCheckAndUnPackData("", currentByte, 110, 6),
                Rssi_Usr_25_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 116, 4),
                Rssi_Usr_26_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 120, 4),
                Rssi_Usr_27_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 124, 4),
                Rssi_Usr_28_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 128, 4),
                Rssi_Usr_29_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 132, 4),
                Rssi_Usr_30_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 136, 4),
                Rssi_Usr_31_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 140, 6),
                Rssi_Usr_32_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 146, 6),
                Rssi_Usr_33_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 152, 6),
                Rssi_Usr_34_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 158, 6),
                Rssi_Usr_35 = PackedTypeCheckAndUnPackData("", currentByte, 164, 1),
                Rssi_Usr_37 = PackedTypeCheckAndUnPackData("", currentByte, 165, 1),
                Rssi_Usr_38 = PackedTypeCheckAndUnPackData("", currentByte, 166, 1),
                Rssi_Usr_39 = PackedTypeCheckAndUnPackData("", currentByte, 167, 2),
                Rssi_Usr_40 = PackedTypeCheckAndUnPackData("", currentByte, 169, 2),
                Rssi_Usr_41 = PackedTypeCheckAndUnPackData("", currentByte, 171, 2),
                Rssi_Usr_42 = PackedTypeCheckAndUnPackData("", currentByte, 173, 2),
                Rssi_Usr_43 = PackedTypeCheckAndUnPackData("", currentByte, 175, 3),
                Rssi_Usr_44 = PackedTypeCheckAndUnPackData("", currentByte, 178, 6),
                Rssi_Usr_45 = PackedTypeCheckAndUnPackData("", currentByte, 184, 6),
                Rssi_Usr_46 = PackedTypeCheckAndUnPackData("", currentByte, 190, 15),
                Rssi_Usr_47 = PackedTypeCheckAndUnPackData("", currentByte, 205, 15),
                Rssi_Usr_48 = PackedTypeCheckAndUnPackData("", currentByte, 220, 15),
                Rssi_Usr_49 = PackedTypeCheckAndUnPackData("", currentByte, 235, 15),
                Rssi_Usr_50 = PackedTypeCheckAndUnPackData("", currentByte, 250, 15),
                Rssi_Usr_51 = PackedTypeCheckAndUnPackData("", currentByte, 265, 35),
                Rssi_Usr_52 = PackedTypeCheckAndUnPackData("", currentByte, 300, 35),
                Rssi_Usr_53 = PackedTypeCheckAndUnPackData("", currentByte, 335, 35),
                Rssi_Usr_54 = PackedTypeCheckAndUnPackData("", currentByte, 370, 1),
                Rssi_Usr_55 = PackedTypeCheckAndUnPackData("", currentByte, 371, 1),
                Rssi_Usr_56 = PackedTypeCheckAndUnPackData("", currentByte, 372, 1),
                Rssi_Usr_57 = PackedTypeCheckAndUnPackData("", currentByte, 373, 1),
                Rssi_Usr_58 = PackedTypeCheckAndUnPackData("", currentByte, 374, 1),
                Rssi_Usr_59 = PackedTypeCheckAndUnPackData("", currentByte, 375, 1),
                Rssi_Usr_60 = PackedTypeCheckAndUnPackData("", currentByte, 376, 1),
                Rssi_Usr_61 = PackedTypeCheckAndUnPackData("", currentByte, 377, 1),
                Rssi_Usr_62 = PackedTypeCheckAndUnPackData("", currentByte, 378, 1),
                Rssi_Usr_63 = PackedTypeCheckAndUnPackData("", currentByte, 379, 1),
                Rssi_Usr_64 = PackedTypeCheckAndUnPackData("", currentByte, 380, 1),
                Rssi_Usr_65 = PackedTypeCheckAndUnPackData("", currentByte, 381, 1),
                Rssi_Usr_66 = PackedTypeCheckAndUnPackData("", currentByte, 382, 1),
                Rssi_Usr_67 = PackedTypeCheckAndUnPackData("", currentByte, 383, 1),
                Rssi_Usr_68 = PackedTypeCheckAndUnPackData("", currentByte, 384, 1),
                Rssi_Usr_69 = PackedTypeCheckAndUnPackData("", currentByte, 385, 1),
                Rssi_Usr_70 = PackedTypeCheckAndUnPackData("", currentByte, 386, 1),
                Rssi_Usr_71 = PackedTypeCheckAndUnPackData("", currentByte, 387, 1),
                Rssi_Usr_72 = PackedTypeCheckAndUnPackData("", currentByte, 388, 1),
                Rssi_Usr_73 = PackedTypeCheckAndUnPackData("", currentByte, 389, 1),
                Rssi_Usr_74 = PackedTypeCheckAndUnPackData("", currentByte, 390, 2),
                Rssi_Usr_75 = PackedTypeCheckAndUnPackData("", currentByte, 392, 2),
                Rssi_Usr_76 = PackedTypeCheckAndUnPackData("", currentByte, 394, 2),
                Rssi_Usr_77 = PackedTypeCheckAndUnPackData("", currentByte, 396, 2),
                Rssi_Usr_78 = PackedTypeCheckAndUnPackData("", currentByte, 398, 2),
                Rssi_Usr_79 = PackedTypeCheckAndUnPackData("", currentByte, 400, 2),
                Rssi_Usr_80 = PackedTypeCheckAndUnPackData("", currentByte, 402, 2),
                Rssi_Usr_81 = PackedTypeCheckAndUnPackData("", currentByte, 404, 2),
                Rssi_Usr_82 = PackedTypeCheckAndUnPackData("", currentByte, 406, 2),
                Rssi_Usr_83 = PackedTypeCheckAndUnPackData("", currentByte, 408, 2),
                Rssi_Usr_84 = PackedTypeCheckAndUnPackData("", currentByte, 410, 2),
                Rssi_Usr_85 = PackedTypeCheckAndUnPackData("", currentByte, 412, 2),
                Rssi_Usr_86 = PackedTypeCheckAndUnPackData("", currentByte, 414, 2),
                Rssi_Usr_87 = PackedTypeCheckAndUnPackData("", currentByte, 416, 2),
                Rssi_Usr_88 = PackedTypeCheckAndUnPackData("", currentByte, 418, 2),
                Rssi_Usr_89 = PackedTypeCheckAndUnPackData("", currentByte, 420, 2),
                Rssi_Usr_90 = PackedTypeCheckAndUnPackData("", currentByte, 422, 2),
                Rssi_Usr_91 = PackedTypeCheckAndUnPackData("", currentByte, 424, 2),
                Rssi_Usr_92 = PackedTypeCheckAndUnPackData("", currentByte, 426, 2),
                Rssi_Usr_93 = PackedTypeCheckAndUnPackData("", currentByte, 428, 2),
                Rssi_Usr_94 = PackedTypeCheckAndUnPackData("", currentByte, 430, 6),
                Rssi_Usr_95 = PackedTypeCheckAndUnPackData("", currentByte, 436, 6),
                Rssi_Usr_96 = PackedTypeCheckAndUnPackData("", currentByte, 442, 6),
                Rssi_Usr_97 = PackedTypeCheckAndUnPackData("", currentByte, 448, 6),
                Rssi_Usr_98 = PackedTypeCheckAndUnPackData("", currentByte, 454, 6),
                Rssi_Usr_99 = PackedTypeCheckAndUnPackData("", currentByte, 460, 6),
                Rssi_Usr_100 = PackedTypeCheckAndUnPackData("", currentByte, 466, 6),
                Rssi_Usr_101 = PackedTypeCheckAndUnPackData("", currentByte, 472, 6),
                Rssi_Usr_102 = PackedTypeCheckAndUnPackData("", currentByte, 478, 6),
                Rssi_Usr_103 = PackedTypeCheckAndUnPackData("", currentByte, 484, 6),
                Rssi_Usr_104 = PackedTypeCheckAndUnPackData("", currentByte, 490, 6),
                Rssi_Usr_105 = PackedTypeCheckAndUnPackData("", currentByte, 496, 6),
                Rssi_Usr_106 = PackedTypeCheckAndUnPackData("", currentByte, 502, 6),
                Rssi_Usr_107 = PackedTypeCheckAndUnPackData("", currentByte, 508, 6),
                Rssi_Usr_108 = PackedTypeCheckAndUnPackData("", currentByte, 514, 6),
                Rssi_Usr_109 = PackedTypeCheckAndUnPackData("", currentByte, 520, 6),
                Rssi_Usr_110 = PackedTypeCheckAndUnPackData("", currentByte, 526, 6),
                Rssi_Usr_111 = PackedTypeCheckAndUnPackData("", currentByte, 532, 6),
                Rssi_Usr_112 = PackedTypeCheckAndUnPackData("", currentByte, 538, 6),
                Rssi_Usr_113 = PackedTypeCheckAndUnPackData("", currentByte, 544, 10),
                Rssi_Usr_114 = PackedTypeCheckAndUnPackData("", currentByte, 554, 10),
                Rssi_Usr_115 = PackedTypeCheckAndUnPackData("", currentByte, 564, 10),
                Rssi_Usr_116 = PackedTypeCheckAndUnPackData("", currentByte, 574, 10),
                Rssi_Usr_117 = PackedTypeCheckAndUnPackData("", currentByte, 584, 10),
                Rssi_Usr_118 = PackedTypeCheckAndUnPackData("", currentByte, 594, 10),
                Rssi_Usr_119 = PackedTypeCheckAndUnPackData("", currentByte, 604, 10),
                Rssi_Usr_120 = PackedTypeCheckAndUnPackData("", currentByte, 614, 10),
                Rssi_Usr_121 = PackedTypeCheckAndUnPackData("", currentByte, 624, 10),
                Rssi_Usr_122 = PackedTypeCheckAndUnPackData("", currentByte, 634, 10),
                Rssi_Usr_123 = PackedTypeCheckAndUnPackData("", currentByte, 644, 10),
                Rssi_Usr_124 = PackedTypeCheckAndUnPackData("", currentByte, 654, 10),
                Rssi_Usr_125 = PackedTypeCheckAndUnPackData("", currentByte, 664, 10),
                Rssi_Usr_126 = PackedTypeCheckAndUnPackData("", currentByte, 674, 10),
                Rssi_Usr_127 = PackedTypeCheckAndUnPackData("", currentByte, 684, 10),
                Rssi_Usr_128 = PackedTypeCheckAndUnPackData("", currentByte, 694, 10),
                Rssi_Usr_129 = PackedTypeCheckAndUnPackData("", currentByte, 704, 10),
                Rssi_Usr_130 = PackedTypeCheckAndUnPackData("", currentByte, 714, 10),
                Rssi_Usr_131 = PackedTypeCheckAndUnPackData("", currentByte, 724, 10),
                Rssi_Usr_132 = PackedTypeCheckAndUnPackData("", currentByte, 734, 10),
                Rssi_Usr_133 = PackedTypeCheckAndUnPackData("", currentByte, 744, 15),
                Rssi_Usr_134 = PackedTypeCheckAndUnPackData("", currentByte, 759, 15),
                Rssi_Usr_135 = PackedTypeCheckAndUnPackData("", currentByte, 774, 15),
                Rssi_Usr_136 = PackedTypeCheckAndUnPackData("", currentByte, 789, 15),
                Rssi_Usr_137 = PackedTypeCheckAndUnPackData("", currentByte, 804, 15),
                Rssi_Usr_138 = PackedTypeCheckAndUnPackData("", currentByte, 819, 15),
                Rssi_Usr_139 = PackedTypeCheckAndUnPackData("", currentByte, 834, 15),
                Rssi_Usr_140 = PackedTypeCheckAndUnPackData("", currentByte, 849, 15),
                Rssi_Usr_141 = PackedTypeCheckAndUnPackData("", currentByte, 864, 15),
                Rssi_Usr_142 = PackedTypeCheckAndUnPackData("", currentByte, 879, 15),
                Rssi_Usr_143 = PackedTypeCheckAndUnPackData("", currentByte, 894, 15),
                Rssi_Usr_144 = PackedTypeCheckAndUnPackData("", currentByte, 909, 15),
                Rssi_Usr_145 = PackedTypeCheckAndUnPackData("", currentByte, 924, 15),
                Rssi_Usr_146 = PackedTypeCheckAndUnPackData("", currentByte, 939, 0),
                Rssi_Usr_147 = PackedTypeCheckAndUnPackData("", currentByte, 954, 15),
                Rssi_Usr_148 = PackedTypeCheckAndUnPackData("", currentByte, 969, 15),
                Rssi_Usr_149 = PackedTypeCheckAndUnPackData("", currentByte, 984, 15),
                Rssi_Usr_150 = PackedTypeCheckAndUnPackData("", currentByte, 999, 15),
                Rssi_Usr_151 = PackedTypeCheckAndUnPackData("", currentByte, 1014, 15),
                Rssi_Usr_152 = PackedTypeCheckAndUnPackData("", currentByte, 1029, 15),
                Rssi_Usr_153 = PackedTypeCheckAndUnPackData("", currentByte, 1044, 35),
                Rssi_Usr_154 = PackedTypeCheckAndUnPackData("", currentByte, 1079, 35),
                Rssi_Usr_155 = PackedTypeCheckAndUnPackData("", currentByte, 1114, 35),
                Rssi_Usr_156 = PackedTypeCheckAndUnPackData("", currentByte, 1149, 35),
                Rssi_Usr_157 = PackedTypeCheckAndUnPackData("", currentByte, 1184, 35),
                Rssi_Usr_158 = PackedTypeCheckAndUnPackData("", currentByte, 1219, 35),
                Rssi_Usr_159 = PackedTypeCheckAndUnPackData("", currentByte, 1254, 35),
                Rssi_Usr_160 = PackedTypeCheckAndUnPackData("", currentByte, 1289, 35),
                Rssi_Usr_161 = PackedTypeCheckAndUnPackData("", currentByte, 1324, 35),
                Rssi_Usr_162 = PackedTypeCheckAndUnPackData("", currentByte, 1359, 35),
                Rssi_Usr_163 = PackedTypeCheckAndUnPackData("", currentByte, 1394, 35),
                Rssi_Usr_164 = PackedTypeCheckAndUnPackData("", currentByte, 1429, 35),
                Rssi_Usr_165 = PackedTypeCheckAndUnPackData("", currentByte, 1464, 35),
                Rssi_Usr_166 = PackedTypeCheckAndUnPackData("", currentByte, 1499, 35),
                Rssi_Usr_167 = PackedTypeCheckAndUnPackData("", currentByte, 1534, 35),
                Rssi_Usr_168 = PackedTypeCheckAndUnPackData("", currentByte, 1569, 35),
                Rssi_Usr_169 = PackedTypeCheckAndUnPackData("", currentByte, 1604, 35),
                Rssi_Usr_170 = PackedTypeCheckAndUnPackData("", currentByte, 1639, 35),
                Rssi_Usr_171 = PackedTypeCheckAndUnPackData("", currentByte, 1674, 35),
                Rssi_Usr_172 = PackedTypeCheckAndUnPackData("", currentByte, 1709, 35),
                Rssi_Usr_173 = PackedTypeCheckAndUnPackData("", currentByte, 1744, 60),
                Rssi_Usr_174 = PackedTypeCheckAndUnPackData("", currentByte, 1804, 60),
                Rssi_Usr_175 = PackedTypeCheckAndUnPackData("", currentByte, 1864, 60),
                Rssi_Usr_176 = PackedTypeCheckAndUnPackData("", currentByte, 1924, 60),
                Rssi_Usr_177 = PackedTypeCheckAndUnPackData("", currentByte, 1984, 60),
                Rssi_Usr_178 = PackedTypeCheckAndUnPackData("", currentByte, 2044, 60),
                Rssi_Usr_179 = PackedTypeCheckAndUnPackData("", currentByte, 2104, 60),
                Rssi_Usr_180 = PackedTypeCheckAndUnPackData("", currentByte, 2164, 60),
                Rssi_Usr_181 = PackedTypeCheckAndUnPackData("", currentByte, 2224, 60),
                Rssi_Usr_182 = PackedTypeCheckAndUnPackData("", currentByte, 2284, 60),
                Rssi_Usr_183 = PackedTypeCheckAndUnPackData("", currentByte, 2344, 60),
                Rssi_Usr_184 = PackedTypeCheckAndUnPackData("", currentByte, 2404, 60),
                Rssi_Usr_185 = PackedTypeCheckAndUnPackData("", currentByte, 2464, 60),
                Rssi_Usr_186 = PackedTypeCheckAndUnPackData("", currentByte, 2524, 60),
                Rssi_Usr_187 = PackedTypeCheckAndUnPackData("", currentByte, 2584, 60),
                Rssi_Usr_188 = PackedTypeCheckAndUnPackData("", currentByte, 2644, 60),
                Rssi_Usr_189 = PackedTypeCheckAndUnPackData("", currentByte, 2704, 60),
                Rssi_Usr_190 = PackedTypeCheckAndUnPackData("", currentByte, 2764, 60),
                Rssi_Usr_191 = PackedTypeCheckAndUnPackData("", currentByte, 2824, 60),
                Rssi_Usr_192 = PackedTypeCheckAndUnPackData("", currentByte, 2884, 60),
                Rssi_Usr_193 = PackedTypeCheckAndUnPackData("", currentByte, 2944, 75),
                Rssi_Usr_194 = PackedTypeCheckAndUnPackData("", currentByte, 3019, 75),
                Rssi_Usr_195 = PackedTypeCheckAndUnPackData("", currentByte, 3094, 1),
                Rssi_Usr_196 = PackedTypeCheckAndUnPackData("", currentByte, 3095, 1),
                Rssi_Usr_197 = PackedTypeCheckAndUnPackData("", currentByte, 3096, 1),
                Rssi_Usr_198 = PackedTypeCheckAndUnPackData("", currentByte, 3097, 1),
                Rssi_Usr_199 = PackedTypeCheckAndUnPackData("", currentByte, 3098, 1),
                Rssi_Usr_200 = PackedTypeCheckAndUnPackData("", currentByte, 3099, 1),
                Rssi_Usr_201 = PackedTypeCheckAndUnPackData("", currentByte, 3100, 1),
                Rssi_Usr_202 = PackedTypeCheckAndUnPackData("", currentByte, 3101, 1),
                Rssi_Usr_203 = PackedTypeCheckAndUnPackData("", currentByte, 3102, 1),
                Rssi_Usr_204 = PackedTypeCheckAndUnPackData("", currentByte, 3103, 1),
                Rssi_Usr_205 = PackedTypeCheckAndUnPackData("", currentByte, 3104, 1),
                Rssi_Usr_206 = PackedTypeCheckAndUnPackData("", currentByte, 3105, 1),
                Rssi_Usr_207 = PackedTypeCheckAndUnPackData("", currentByte, 3106, 1),
                Rssi_Usr_208 = PackedTypeCheckAndUnPackData("", currentByte, 3107, 1),
                Rssi_Usr_209 = PackedTypeCheckAndUnPackData("", currentByte, 3108, 1),
                Rssi_Usr_210 = PackedTypeCheckAndUnPackData("", currentByte, 3109, 1),
                Rssi_Usr_211 = PackedTypeCheckAndUnPackData("", currentByte, 3110, 1),
                Rssi_Usr_212 = PackedTypeCheckAndUnPackData("", currentByte, 3111, 1),
                Rssi_Usr_213 = PackedTypeCheckAndUnPackData("", currentByte, 3112, 1),
                Rssi_Usr_214 = PackedTypeCheckAndUnPackData("", currentByte, 3113, 1),
                Rssi_Usr_215_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3114, 2),
                Rssi_Usr_216_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3116, 2),
                Rssi_Usr_217_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3118, 2),
                Rssi_Usr_218_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3120, 2),
                Rssi_Usr_219_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3122, 2),
                Rssi_Usr_220_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3124, 2),
                Rssi_Usr_221_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3126, 2),
                Rssi_Usr_222_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3128, 2),
                Rssi_Usr_223_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3130, 2),
                Rssi_Usr_224_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3132, 2),
                Rssi_Usr_225_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3134, 2),
                Rssi_Usr_226_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3136, 2),
                Rssi_Usr_227_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3138, 2),
                Rssi_Usr_228_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3140, 2),
                Rssi_Usr_229_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3142, 2),
                Rssi_Usr_230_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3144, 2),
                Rssi_Usr_231_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3146, 2),
                Rssi_Usr_232_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3148, 2),
                Rssi_Usr_233_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3150, 2),
                Rssi_Usr_234_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3152, 2),
                Rssi_Usr_235_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3154, 4),
                Rssi_Usr_236_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3158, 4),
                Rssi_Usr_237_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3162, 4),
                Rssi_Usr_238_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3166, 4),
                Rssi_Usr_239_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3170, 4),
                Rssi_Usr_240_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3174, 4),
                Rssi_Usr_241_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3178, 4),
                Rssi_Usr_242_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3182, 4),
                Rssi_Usr_243_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3186, 4),
                Rssi_Usr_244_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3190, 4),
                Rssi_Usr_245_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3194, 4),
                Rssi_Usr_246_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3198, 4),
                Rssi_Usr_247_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3202, 4),
                Rssi_Usr_248_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3206, 4),
                Rssi_Usr_249_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3210, 4),
                Rssi_Usr_250_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3214, 4),
                Rssi_Usr_251_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3218, 4),
                Rssi_Usr_252_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3222, 4),
                Rssi_Usr_253_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3226, 4),
                Rssi_Usr_254_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3230, 4),
                Rssi_Usr_255_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3234, 6),
                Rssi_Usr_256_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3240, 6),
                Rssi_Usr_257_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3246, 6),
                Rssi_Usr_258_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3252, 6),
                Rssi_Usr_259_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3258, 6),
                Rssi_Usr_260_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3264, 6),
                Rssi_Usr_261_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3270, 6),
                Rssi_Usr_262_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3276, 6),
                Rssi_Usr_263_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3282, 6),
                Rssi_Usr_264_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3288, 6),
                Rssi_Usr_265_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3294, 6),
                Rssi_Usr_266_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3300, 6),
                Rssi_Usr_267_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3306, 6),
                Rssi_Usr_268_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3312, 6),
                Rssi_Usr_269_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3318, 6),
                Rssi_Usr_270_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3324, 6),
                Rssi_Usr_271_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3330, 6),
                Rssi_Usr_272_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3336, 6),
                Rssi_Usr_273_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3342, 6),
                Rssi_Usr_274_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3348, 6),
                Rssi_Usr_275_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3354, 4),
                Rssi_Usr_276_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3358, 4),
                Rssi_Usr_277_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3362, 4),
                Rssi_Usr_278_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3366, 4),
                Rssi_Usr_279_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3370, 4),
                Rssi_Usr_280_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3374, 4),
                Rssi_Usr_281_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3378, 4),
                Rssi_Usr_282_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3382, 4),
                Rssi_Usr_283_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3386, 4),
                Rssi_Usr_284_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3390, 4),
                Rssi_Usr_285_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3394, 4),
                Rssi_Usr_286_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3398, 4),
                Rssi_Usr_287_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3402, 4),
                Rssi_Usr_288_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3406, 4),
                Rssi_Usr_289_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3410, 4),
                Rssi_Usr_290_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3414, 4),
                Rssi_Usr_291_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3418, 4),
                Rssi_Usr_292_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3422, 4),
                Rssi_Usr_293_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3426, 4),
                Rssi_Usr_294_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3430, 4),
                Rssi_Usr_295_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3434, 5),
                Rssi_Usr_296_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3439, 5),
                Rssi_Usr_297_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3444, 5),
                Rssi_Usr_298_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3449, 5),
                Rssi_Usr_299_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3454, 5),
                Rssi_Usr_300_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3459, 5),
                Rssi_Usr_301_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3464, 5),
                Rssi_Usr_302_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3469, 5),
                Rssi_Usr_303_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3474, 5),
                Rssi_Usr_304_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3479, 5),
                Rssi_Usr_305_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3484, 5),
                Rssi_Usr_306_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3489, 5),
                Rssi_Usr_307_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3494, 5),
                Rssi_Usr_308_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3499, 5),
                Rssi_Usr_309_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3504, 5),
                Rssi_Usr_310_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3509, 5),
                Rssi_Usr_311_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3514, 5),
                Rssi_Usr_312_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3519, 5),
                Rssi_Usr_313_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3524, 5),
                Rssi_Usr_314_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3529, 5),
                Rssi_Usr_315_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3534, 6),
                Rssi_Usr_316_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3540, 6),
                Rssi_Usr_317_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3546, 6),
                Rssi_Usr_318_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3552, 6),
                Rssi_Usr_319_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3558, 6),
                Rssi_Usr_320_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3564, 6),
                Rssi_Usr_321_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3570, 6),
                Rssi_Usr_322_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3576, 6),
                Rssi_Usr_323_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3582, 6),
                Rssi_Usr_324_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3588, 6),
                Rssi_Usr_325_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3594, 6),
                Rssi_Usr_326_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3600, 6),
                Rssi_Usr_327_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3606, 6),
                Rssi_Usr_328_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3612, 6),
                Rssi_Usr_329_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3618, 6),
                Rssi_Usr_330_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3624, 6),
                Rssi_Usr_331_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3630, 6),
                Rssi_Usr_332_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3636, 6),
                Rssi_Usr_333_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3642, 6),
                Rssi_Usr_334_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3648, 6),
                Rssi_Usr_335_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3654, 7),
                Rssi_Usr_336_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3661, 7),
                Rssi_Usr_337_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3668, 7),
                Rssi_Usr_338_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3675, 7),
                Rssi_Usr_339_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3682, 7),
                Rssi_Usr_340_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3689, 7),
                Rssi_Usr_341_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3696, 7),
                Rssi_Usr_342_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3703, 7),
                Rssi_Usr_343_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3710, 7),
                Rssi_Usr_344_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3717, 7),
                Rssi_Usr_345_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 2724, 7),
                Rssi_Usr_346_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3731, 7),
                Rssi_Usr_347_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3738, 7),
                Rssi_Usr_348_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3745, 7),
                Rssi_Usr_349_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3752, 7),
                Rssi_Usr_350_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3759, 7),
                Rssi_Usr_351_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3766, 7),
                Rssi_Usr_352_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3773, 7),
                Rssi_Usr_353_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3780, 7),
                Rssi_Usr_354_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3787, 4),
                Rssi_Usr_355_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3791, 4),
                Rssi_Usr_356_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3795, 4),
                Rssi_Usr_357_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3799, 4),
                Rssi_Usr_358_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3803, 4),
                Rssi_Usr_359_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3807, 4),
                Rssi_Usr_360_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3811, 4),
                Rssi_Usr_361_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3815, 4),
                Rssi_Usr_362_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3819, 4),
                Rssi_Usr_363_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3823, 4),
                Rssi_Usr_364_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3827, 4),
                Rssi_Usr_365_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3831, 4),
                Rssi_Usr_366_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3835, 4),
                Rssi_Usr_367_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3839, 4),
                Rssi_Usr_368_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3843, 4),
                Rssi_Usr_369_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3847, 4),
                Rssi_Usr_370_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3851, 4),
                Rssi_Usr_371_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3855, 4),
                Rssi_Usr_372_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3859, 4),
                Rssi_Usr_373_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 3863, 4),
                FillerPart3 = PackedTypeCheckAndUnPackData("", currentByte, 3867, 144),

            };
        }

        // L Multiple Lockbox Record. One record per loan if applicable.
        public void GetMultiLockboxRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.MultiLockboxRecordModel = new MultiLockboxRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("", currentByte, 2, 3),
                Rssi_Acct_No = PackedTypeCheckAndUnPackData("", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("", currentByte, 15, 5),
                Rssi_Il_Lkbx_Id_Data = PackedTypeCheckAndUnPackData("", currentByte, 20, 1),
                Rssi_Il_Lkbx_Addr_1 = PackedTypeCheckAndUnPackData("", currentByte, 21, 35),
                Rssi_Il_Lkbx_Addr_2 = PackedTypeCheckAndUnPackData("", currentByte, 56, 35),
                Rssi_Il_Lkbx_City = PackedTypeCheckAndUnPackData("", currentByte, 91, 20),
                Rssi_Il_Lkbx_State = PackedTypeCheckAndUnPackData("", currentByte, 111, 2),
                Rssi_Il_Lkbx_Zip = PackedTypeCheckAndUnPackData("", currentByte, 113, 10),

            };
        }

        // R Rate Reduction Record. One record per loan if applicable.
        public void GetRateReductionRecord(byte[] currentByte, ref AccountsModel acc)
        {
            acc.RateReductionRecordModel = new RateReductionRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("", currentByte, 2, 3),
                Rssi_Acct_No = PackedTypeCheckAndUnPackData("", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("", currentByte, 15, 5),
                Rssi_Loan_Plan_Nbr = PackedTypeCheckAndUnPackData("", currentByte, 20, 6),
                Rssi_Loan_Status = PackedTypeCheckAndUnPackData("", currentByte, 26, 1),
                Rssi_Tot_Red_To_Date = PackedTypeCheckAndUnPackData("", currentByte, 27, 7),
                Rssi_Tot_Tiers_Comp = PackedTypeCheckAndUnPackData("", currentByte, 34, 2),
                Rssi_Tier_Status = PackedTypeCheckAndUnPackData("", currentByte, 36, 1),
                Rssi_Disql_Dt = PackedTypeCheckAndUnPackData("", currentByte, 37, 8),
                Rssi_Disql_Due_Dt = PackedTypeCheckAndUnPackData("", currentByte, 45, 8),
                Rssi_Cpltn_Date = PackedTypeCheckAndUnPackData("", currentByte, 53, 8),
                Rssi_Cpltn_Due_Dt = PackedTypeCheckAndUnPackData("", currentByte, 61, 8),
                Rssi_Reql_Dt = PackedTypeCheckAndUnPackData("", currentByte, 69, 8),
                Rssi_Reql_Due_Dt = PackedTypeCheckAndUnPackData("", currentByte, 77, 8),
                Rssi_Total_Rq = PackedTypeCheckAndUnPackData("", currentByte, 85, 3),
                Rssi_Ot_Pmts_Ctr = PackedTypeCheckAndUnPackData("", currentByte, 88, 2),
                Rssi_Rem_Pmts_Ctr = PackedTypeCheckAndUnPackData("", currentByte, 90, 2),
                Rssi_New_Rate = PackedTypeCheckAndUnPackData("", currentByte, 92, 7),
                Rssi_New_Pmt = PackedTypeCheckAndUnPackData("", currentByte, 99, 7),
                Rssi_New_Eff_Dt = PackedTypeCheckAndUnPackData("", currentByte, 106, 8),
                Rssi_Pmt_Diff = PackedTypeCheckAndUnPackData("", currentByte, 114, 9),
                Rssi_Reset_Date = PackedTypeCheckAndUnPackData("", currentByte, 123, 8),
                Rssi_Reset_Due_Dt = PackedTypeCheckAndUnPackData("", currentByte, 131, 8),
                Rssi_Beg_Due_Dt = PackedTypeCheckAndUnPackData("", currentByte, 139, 8),
                Rssi_Reduct_Amt = PackedTypeCheckAndUnPackData("", currentByte, 147, 7),


            };
        }

        // E Escrow Payee Data Record. Multiple records per loan if applicable.
        public void GetEscrowRecordModel(byte[] currentByte, ref AccountsModel acc)
        {

            acc.EscrowRecordModel = new EscrowRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("", currentByte, 2, 3),
                Rssi_Acnt_Rem = PackedTypeCheckAndUnPackData("", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("", currentByte, 15, 5),
                Rssi_Esc_Type = PackedTypeCheckAndUnPackData("", currentByte, 20, 2),
                Rssi_Ins_Co = PackedTypeCheckAndUnPackData("", currentByte, 22, 4),
                Rssi_Ins_Ag = PackedTypeCheckAndUnPackData("", currentByte, 26, 5),
                Rssi_Payee_Name = PackedTypeCheckAndUnPackData("", currentByte, 31, 35),
                Rssi_Payee_Phone = PackedTypeCheckAndUnPackData("", currentByte, 66, 11),
                Rssi_Prod_Name = PackedTypeCheckAndUnPackData("", currentByte, 77, 35),
                Rssi_Pymt_Due = PackedTypeCheckAndUnPackData("", currentByte, 112, 11),
                Rssi_Num_Due = PackedTypeCheckAndUnPackData("", currentByte, 123, 2),
                Rssi_Esc_Expir_Dt = PackedTypeCheckAndUnPackData("", currentByte, 125, 6),

            };
        }

        // O Optional Items/Escrow Record. Multiple records per loan if applicable.
        public void GetOptionalItemEscrowRecordModel(byte[] currentByte, ref AccountsModel acc)
        {

            acc.OptionalItemEscrowRecordModel = new OptionalItemEscrowRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("", currentByte, 2, 3),
                Rssi_Acnt_Rem = PackedTypeCheckAndUnPackData("", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("", currentByte, 15, 5),
                Rssi_Oed_Prod_Name = PackedTypeCheckAndUnPackData("", currentByte, 20, 35),
                Rssi_Oed_Cur_Amt = PackedTypeCheckAndUnPackData("", currentByte, 55, 11),
                Rssi_Oed_Pend_Amt = PackedTypeCheckAndUnPackData("", currentByte, 66, 11),
                Rssi_Oed_Pend_Date = PackedTypeCheckAndUnPackData("", currentByte, 77, 4),
                Rssi_Oed_Prod_Type = PackedTypeCheckAndUnPackData("", currentByte, 81, 2),
                Rssi_Oed_Tot_Prem_Due = PackedTypeCheckAndUnPackData("", currentByte, 83, 7),
                Rssi_Oed_Filler = PackedTypeCheckAndUnPackData("", currentByte, 90, 11),

            };
        }

        // F Fee Record. Multiple records per loan if applicable.
        public void GetFeeRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.FeeRecordModel = new FeeRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("", currentByte, 2, 3),
                Rssi_Acnt_Rem = PackedTypeCheckAndUnPackData("", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("", currentByte, 15, 5),
                Rssi_Fd_Fee_Type = PackedTypeCheckAndUnPackData("", currentByte, 20, 3),
                Rssi_Fd_Fee_Desc = PackedTypeCheckAndUnPackData("", currentByte, 23, 23),
                Rssi_Fd_Fee_Amort_Pymt = PackedTypeCheckAndUnPackData("", currentByte, 46, 7),
                Rssi_Fd_Prev_Fee_Bal = PackedTypeCheckAndUnPackData("", currentByte, 53, 7),
                Rssi_Fd_Assess_Amt = PackedTypeCheckAndUnPackData("", currentByte, 60, 7),
                Rssi_Fd_Assess_Date = PackedTypeCheckAndUnPackData("", currentByte, 67, 7),
                Rssi_Fd_Coll_Assess = PackedTypeCheckAndUnPackData("", currentByte, 74, 9),
                Rssi_Fd_Coll_Non_Assess = PackedTypeCheckAndUnPackData("", currentByte, 83, 7),
                Rssi_Fd_Waived = PackedTypeCheckAndUnPackData("", currentByte, 90, 7),
                Rssi_Fd_Curr_Fee_Bal = PackedTypeCheckAndUnPackData("", currentByte, 97, 7),
                Rssi_Fd_Coll_Date = PackedTypeCheckAndUnPackData("", currentByte, 104, 7),
                Rssi_Fd_Waived_Date = PackedTypeCheckAndUnPackData("", currentByte, 111, 7),
                Rssi_Fd_Recur_Total_Due = PackedTypeCheckAndUnPackData("", currentByte, 118, 9),
                Rssi_Fd_Recur_Pmts_Past_Due = PackedTypeCheckAndUnPackData("", currentByte, 127, 2),
                Rssi_Fd_Filler2 = PackedTypeCheckAndUnPackData("", currentByte, 129, 4),
                Rssi_Expi_Type = PackedTypeCheckAndUnPackData("", currentByte, 133, 1),
                Rssi_Expi_Po_No = PackedTypeCheckAndUnPackData("", currentByte, 134, 12),
                Rssi_Expi_Amt_Billed_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 146, 4),
                Rssi_Expi_Amt_Paid_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 150, 4),
                Rssi_Expi_Rec_Or_Nonrec = PackedTypeCheckAndUnPackData("", currentByte, 154, 1),
                Rssi_Expi_Invoice_Date_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 155, 4),
                Rssi_Fee2_Inv_Paid_Date_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 159, 4),
                Rssi_Expi_Vend = PackedTypeCheckAndUnPackData("", currentByte, 163, 7),
                Rssi_Expi_Vend_Resp_Cd = PackedTypeCheckAndUnPackData("", currentByte, 170, 2),
                Rssi_Cinv_Exp_Code_PackedData = PackedTypeCheckAndUnPackData("", currentByte, 172, 2),
                Rssi_Cinv_Inv_No = PackedTypeCheckAndUnPackData("", currentByte, 174, 15),
                Rssi_Cinv_Area = PackedTypeCheckAndUnPackData("", currentByte, 189, 5),
                Rssi_Fd_Filler = PackedTypeCheckAndUnPackData("", currentByte, 194, 207),

            };
        }

        // S Solicitation Record. One record per loan if applicable.
        public void GetSolicitationRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.SolicitationRecordModel = new SolicitationRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("", currentByte, 2, 3),
                Rssi_Acct_No = PackedTypeCheckAndUnPackData("", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("", currentByte, 15, 5),
                Rssi_Campgn_Id = PackedTypeCheckAndUnPackData("", currentByte, 20, 5),
                Rssi_Campgncntl = PackedTypeCheckAndUnPackData("", currentByte, 25, 3),
                Rssi_Campgnmeth = PackedTypeCheckAndUnPackData("", currentByte, 28, 3),

            };
        }

        // T Transaction Record. Multiple records per loan if applicable.
        public void GetTransactionRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.TransactionRecordModel = new TransactionRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

                Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

                Rssi_Log_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Log_Date_PackedData", currentByte, 20, 4),
                Rssi_Log_Time = PackedTypeCheckAndUnPackData("Rssi_Log_Time", currentByte, 24, 4),

                Rssi_Tr_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Date_PackedData", currentByte, 28, 4),
                Rssi_Log_Ptrn = PackedTypeCheckAndUnPackData("Rssi_Log_Ptrn", currentByte, 32, 8),

                Rssi_Tr_Fill_01 = PackedTypeCheckAndUnPackData("Rssi_Tr_Fill_01", currentByte, 40, 1),
                Rssi_Log_Tran = PackedTypeCheckAndUnPackData("Rssi_Log_Tran", currentByte, 41, 4),

                Rssi_Tr_Fill_02 = PackedTypeCheckAndUnPackData("Rssi_Tr_Fill_02", currentByte, 45, 1),
                Rssi_Tr_Store_Ovride = PackedTypeCheckAndUnPackData("Rssi_Tr_Store_Ovride", currentByte, 46, 1),

                Rssi_Tr_Fill_03 = PackedTypeCheckAndUnPackData("Rssi_Tr_Fill_03", currentByte, 47, 1),
                Rssi_Tr_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_PackedData", currentByte, 48, 8,2),

                Rssi_Tr_Cash_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Cash_Amt_PackedData", currentByte, 56, 8,2),
                Rssi_Tr_Teller_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Teller_PackedData", currentByte, 64, 3),

                Rssi_Tr_Unap_Cd_Before = PackedTypeCheckAndUnPackData("Rssi_Tr_Unap_Cd_Before", currentByte, 67, 5),
                Rssi_Tr_Unap_Cd_After = PackedTypeCheckAndUnPackData("Rssi_Tr_Unap_Cd_After", currentByte, 72, 5),

                Rssi_Tr_Amt_To_Prin_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Prin_PackedData", currentByte, 77, 6,2),
                Rssi_Tr_Amt_To_Int_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Int_PackedData", currentByte, 83, 6,2),

                Rssi_Tr_Amt_To_Esc_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Esc_PackedData", currentByte, 89, 5,2),
                Rssi_Tr_Amt_To_Lc_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Lc_PackedData", currentByte, 94, 5,2),

                Rssi_Tr_Amt_To_Pvar_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Pvar_PackedData", currentByte, 99, 5,2),
                Rssi_Tr_Amt_To_Ivar_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Ivar_PackedData", currentByte, 104, 4,2),

                Rssi_Tr_Amt_To_Evar_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Evar_PackedData", currentByte, 109, 5,2),
                Rssi_Tr_Amt_To_Lvar_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Lvar_PackedData", currentByte, 114, 5,2),

                Rssi_Tr_Amt_To_Lip_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Lip_PackedData", currentByte, 119, 5,2),
                Rssi_Tr_Pymt_Ctr_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Pymt_Ctr_PackedData", currentByte, 124, 2),

                Rssi_Tr_Amt_To_Cr_Ins_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Cr_Ins_PackedData", currentByte, 126, 5),
                Rssi_Tr_Prin_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Prin_Bal_PackedData", currentByte, 131, 6),

                Rssi_Tr_Esc_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Esc_Bal_PackedData", currentByte, 137, 6),
                Rssi_Tr_Pd_To_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Pd_To_Date_PackedData", currentByte, 143, 4),

                Rssi_Tr_Esc_Pymt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Esc_Pymt_PackedData", currentByte, 147, 5),
                Rssi_Tr_Prn_Var_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Prn_Var_PackedData", currentByte, 152, 5),

                Rssi_Tr_Uncoll_Int_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Uncoll_Int_PackedData", currentByte, 157, 6),
                Rssi_Tr_Esc_Var_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Esc_Var_PackedData", currentByte, 163, 5),

                Rssi_Tr_Uncoll_Lc_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Uncoll_Lc_PackedData", currentByte, 168, 5),
                Rssi_Tr_Dla_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Dla_PackedData", currentByte, 173, 4),

                Rssi_Tr_Lip_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Lip_Bal_PackedData", currentByte, 177, 5),
                Rssi_Tr_Lip_La_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Lip_La_Date_PackedData", currentByte, 182, 4),

                Rssi_Tr_Pre_Int_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Pre_Int_Amt_PackedData", currentByte, 186, 6),
                Rssi_Tr_Pre_Int_Date = PackedTypeCheckAndUnPackData("Rssi_Tr_Pre_Int_Date", currentByte, 192, 4),

                Rssi_Tr_Amt_To_Fees_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Fees_PackedData", currentByte, 196, 6),
                Rssi_Tr_Fee_Code = PackedTypeCheckAndUnPackData("Rssi_Tr_Fee_Code", currentByte, 202, 3),

                Rssi_Tr_Fee_Desc = PackedTypeCheckAndUnPackData("Rssi_Tr_Fee_Desc", currentByte, 205, 23),
                Rssi_Tr_Amt_Negam_Tak_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_Negam_Tak_PackedData", currentByte, 228, 6),

                Rssi_Tr_Amt_Negam_Pd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_Negam_Pd_PackedData", currentByte, 234, 6),
                Rssi_Tr_Esc_Pay_Id = PackedTypeCheckAndUnPackData("Rssi_Tr_Esc_Pay_Id", currentByte, 240, 2),

                Rssi_Tr_Amort_Fee_Pymt = PackedTypeCheckAndUnPackData("Rssi_Tr_Amort_Fee_Pymt", currentByte, 242, 7),
                Rssi_Tr_Amt_To_Evar_2 = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Evar_2", currentByte, 249, 9),

                Rssi_Tr_Amt_To_Evar_3 = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Evar_3", currentByte, 258, 9),
                Rssi_Tr_Amt_To_Evar_04 = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Evar_04", currentByte, 267, 9),

                Rssi_Tr_Amt_To_Evar_05 = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Evar_05", currentByte, 276, 9),
                Rssi_Tr_Exp_Fee_Code = PackedTypeCheckAndUnPackData("Rssi_Tr_Exp_Fee_Code", currentByte, 285, 3),

                Rssi_Tr_Exp_Fee_Desc = PackedTypeCheckAndUnPackData("Rssi_Tr_Exp_Fee_Desc", currentByte, 288, 30),
                Rssi_Tr_Exp_Fee_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Exp_Fee_Amt_PackedData", currentByte, 318, 6),

                Rssi_Tr_Amt_To_Pi_Shrtg = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Pi_Shrtg", currentByte, 324, 9),
                Rssi_Tr_Amt_To_Esc_Short = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Esc_Short", currentByte, 333, 9),

                Rssi_Tr_Amt_To_Acrd_Inctv = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Acrd_Inctv", currentByte, 342, 7),
                Rssi_Tr_Amt_To_Pra_Remain = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Pra_Remain", currentByte, 349, 11),

                Rssi_Tr_Amt_To_Def_Prin_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Prin_PackedData", currentByte, 360, 6),
                Rssi_Tr_Def_Prin_Bal_After_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Prin_Bal_After_PackedData", currentByte, 366, 6),

                Rssi_Tr_Amt_To_Def_Int_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Int_PackedData", currentByte, 372, 6),
                Rssi_Tr_Def_Int_Bal_Aft_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Int_Bal_Aft_PackedData", currentByte, 378, 6),

                Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData", currentByte, 384, 5),
                Rssi_Tr_Def_Lt_Chg_Bal_Aft_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Lt_Chg_Bal_Aft_PackedData", currentByte, 389, 6),

                Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData", currentByte, 395, 5),
                Rssi_Tr_Def_Esc_Adv_Bal_Aft_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Esc_Adv_Bal_Aft_PackedData", currentByte, 400, 6),

                Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData", currentByte, 406, 6),
                Rssi_Tr_Def_Pd_Exp_Adv_Bal_Aft_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Pd_Exp_Adv_Bal_Aft_PackedData", currentByte, 412, 6),

                Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData", currentByte, 418, 6),
                Rssi_Tr_Def_Unpexp_Bal_Aft_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Unpexp_Bal_Aft_PackedData", currentByte, 424, 6),

                Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData", currentByte, 430, 6),
                Rssi_Tr_Def_Admin_Fees_Bal_Aft_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Admin_Fees_Bal_Aft_PackedData", currentByte, 436, 6),

                Rssi_Tr_Amt_To_Def_Optins_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Def_Optins_PackedData", currentByte, 442, 5),
                Rssi_Tr_Def_Optins_Bal_Aft_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Def_Optins_Bal_Aft_PackedData", currentByte, 447, 6),

                Rssi_Tr_Amt_To_Esc_Nt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Tr_Amt_To_Esc_Nt_PackedData", currentByte, 453, 6),
                Filler_459_1500 = PackedTypeCheckAndUnPackData("Filler_459_1500", currentByte, 459, 1042),

            };
        }

        // C Foreign Information Record. One record per loan if applicable.
        public void GetForeignInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.ForeignInformationRecordModel = new ForeignInformationRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

                Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

                Rssi_Prim_Id_Number = PackedTypeCheckAndUnPackData("Rssi_Prim_Id_Number", currentByte, 20, 15),
                Rssi_Primary_Borr_Prefix = PackedTypeCheckAndUnPackData("Rssi_Primary_Borr_Prefix", currentByte, 35, 6),

                Rssi_Primary_Borr_Suffix = PackedTypeCheckAndUnPackData("Rssi_Primary_Borr_Suffix", currentByte, 41, 6),
                Rssi_Attention = PackedTypeCheckAndUnPackData("Rssi_Attention", currentByte, 47, 35),

                Rssi_Prim_Mail_Country = PackedTypeCheckAndUnPackData("Rssi_Prim_Mail_Country", currentByte, 82, 35),
                Rssi_Prim_Zip_Code = PackedTypeCheckAndUnPackData("Rssi_Prim_Zip_Code", currentByte, 117, 10),

                Rssi_Prim_Home_Ph_Co = PackedTypeCheckAndUnPackData("Rssi_Prim_Home_Ph_Co", currentByte, 127, 3),
                Rssi_Prim_Home_Ph1 = PackedTypeCheckAndUnPackData("Rssi_Prim_Home_Ph1", currentByte, 130, 15),

                Rssi_Prim_Work_Ph_Co = PackedTypeCheckAndUnPackData("Rssi_Prim_Work_Ph_Co", currentByte, 145, 3),
                Rssi_Prim_Work_Ph1 = PackedTypeCheckAndUnPackData("Rssi_Prim_Work_Ph1", currentByte, 148, 15),

                Rssi_Prim_Fax_Ph_Co = PackedTypeCheckAndUnPackData("Rssi_Prim_Fax_Ph_Co", currentByte, 163, 3),
                Rssi_Prim_Fax_Phone = PackedTypeCheckAndUnPackData("Rssi_Prim_Fax_Phone", currentByte, 166, 15),

                Rssi_Prim_Cell_Ph_Co = PackedTypeCheckAndUnPackData("Rssi_Prim_Cell_Ph_Co", currentByte, 181, 3),
                Rssi_Prim_Cell_Ph = PackedTypeCheckAndUnPackData("Rssi_Prim_Cell_Ph", currentByte, 184, 15),

                Rssi_Appl_Country = PackedTypeCheckAndUnPackData("Rssi_Appl_Country", currentByte, 199, 35),
                Rssi_Appl_Zip_Cd = PackedTypeCheckAndUnPackData("Rssi_Appl_Zip_Cd", currentByte, 234, 10),

                Rssi_Altr_Cntry = PackedTypeCheckAndUnPackData("Rssi_Altr_Cntry", currentByte, 244, 35),
                Rssi_Altr_Zip_Cd = PackedTypeCheckAndUnPackData("Rssi_Altr_Zip_Cd", currentByte, 279, 10),
                Filler_289_500 = PackedTypeCheckAndUnPackData("Filler_289_500", currentByte, 289, 212),

            };
        }

        // D Blended Rate Information Record. One record per loan if applicable.
        public void GetBlendedRateInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.BlendedRateInformationRecordModel = new BlendedRateInformationRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

                Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

                Rssi_C_Alt_Type_Id = PackedTypeCheckAndUnPackData("Rssi_C_Alt_Type_Id", currentByte, 20, 1),
                Rssi_Ml_Alt_Typ_Id_PackedData = PackedTypeCheckAndUnPackData("Rssi_Ml_Alt_Typ_Id_PackedData", currentByte, 21, 1),

                Rssi_Alt_Chg_Amt1_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Chg_Amt1_PackedData", currentByte, 22, 6,2),
                Rssi_Alt_Chg_Amt2_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Chg_Amt2_PackedData", currentByte, 28, 6,2),

                Rssi_Alt_Chg_Amt3_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Chg_Amt3_PackedData", currentByte, 34, 6,2),
                Rssi_Alt_Chg_Amt4_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Chg_Amt4_PackedData", currentByte, 40, 6,2),

                Rssi_Alt_Pymt1_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Pymt1_PackedData", currentByte, 46, 6,2),
                Rssi_Alt_Pymt2_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Pymt2_PackedData", currentByte, 52, 6,2),

                Rssi_Alt_Pymt3_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Pymt3_PackedData", currentByte, 58, 6,2),
                Rssi_Alt_Pymt4_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Pymt4_PackedData", currentByte, 64, 6,2),

                Rssi_Alt_B_A_Rt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_B_A_Rt_PackedData", currentByte, 70, 4,5),
                Rssi_Alt_B_F_Rate_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_B_F_Rate_PackedData", currentByte, 74, 4,5),

                Rssi_Alt_Ar_Rate_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Ar_Rate_PackedData", currentByte, 78, 4,5),
                Rssi_Alt_Fr_Rate = PackedTypeCheckAndUnPackData("Rssi_Alt_Fr_Rate", currentByte, 82, 4,5),

                Rssi_Alt_B_Rate_Flag_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_B_Rate_Flag_PackedData", currentByte, 86, 1),
                Rssi_Alt_B_Rt_Mgn_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_B_Rt_Mgn_PackedData", currentByte, 87, 4,5),

                Rssi_Alt_B_Rt_Term_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_B_Rt_Term_PackedData", currentByte, 91, 2),
                Rssi_Alt_Adj_Pct_PackedData = PackedTypeCheckAndUnPackData("Rssi_Alt_Adj_Pct_PackedData", currentByte, 93, 4,5),

                Rssi_Alt_Fix_Pct = PackedTypeCheckAndUnPackData("Rssi_Alt_Fix_Pct", currentByte, 97, 4,5),
                Rssi_Alt_B_Opt_Flag = PackedTypeCheckAndUnPackData("Rssi_Alt_B_Opt_Flag", currentByte, 101, 1),

                Rssi_Alt_B_Opt_Curr_Fix = PackedTypeCheckAndUnPackData("Rssi_Alt_B_Opt_Curr_Fix", currentByte, 102, 11,2),
                Rssi_Alt_B_Curr_Adj = PackedTypeCheckAndUnPackData("Rssi_Alt_B_Curr_Adj", currentByte, 113, 11,2),
                FILLER_124_400 = PackedTypeCheckAndUnPackData("FILLER_124_400", currentByte, 124, 277),
            };
        }


        //  I Co-borrower Record. One record per loan if applicable.
        public void GetCoBorrowerRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.CoBorrowerRecordModel = new CoBorrowerRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3), 

                Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

                Rssi_Cb_Cbwr1_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_F", currentByte, 20, 35),
                Rssi_Cb_Cbwr1_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_Adrs1", currentByte, 55, 35),

                Rssi_Cb_Cbwr1_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_Adrs2", currentByte, 90, 35),
                Rssi_Cb_Cbwr1_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_City", currentByte, 125, 21),

                Rssi_Cb_Cbwr1_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_State", currentByte, 146, 2),
                Rssi_Cb_Cbwr1_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_Zip", currentByte, 148, 10),

                Rssi_Cb_Cbwr1_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_Bill_Stmnt", currentByte, 158, 1),
                Rssi_Cb_Cbwr2_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_F", currentByte, 159, 35),

                Rssi_Cb_Cbwr2_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_Adrs1", currentByte, 194, 35),
                Rssi_Cb_Cbwr2_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_Adrs2", currentByte, 229, 35),

                Rssi_Cb_Cbwr2_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_City", currentByte, 264, 21),
                Rssi_Cb_Cbwr2_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_State", currentByte, 285, 2),

                Rssi_Cb_Cbwr2_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_Zip", currentByte, 287, 10),
                Rssi_Cb_Cbwr2_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_Bill_Stmnt", currentByte, 297, 1),

                Rssi_Cb_Cbwr3_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_F", currentByte, 298, 35),
                Rssi_Cb_Cbwr3_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_Adrs1", currentByte, 333, 35),

                Rssi_Cb_Cbwr3_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_Adrs2", currentByte, 368, 35),
                Rssi_Cb_Cbwr3_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_City", currentByte, 403, 21),

                Rssi_Cb_Cbwr3_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_State", currentByte, 424, 2),
                Rssi_Cb_Cbwr3_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_Zip", currentByte, 426, 10),

                Rssi_Cb_Cbwr3_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_Bill_Stmnt", currentByte, 436, 1),
                Rssi_Cb_Cbwr4_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_F", currentByte, 437, 35),

                Rssi_Cb_Cbwr4_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_Adrs1", currentByte, 472, 35),
                Rssi_Cb_Cbwr4_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_Adrs2", currentByte, 507, 35),

                Rssi_Cb_Cbwr4_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_City", currentByte, 542, 21),
                Rssi_Cb_Cbwr4_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_State", currentByte, 563, 2),

                Rssi_Cb_Cbwr4_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_Zip", currentByte, 565, 10),
                Rssi_Cb_Cbwr4_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_Bill_Stmnt", currentByte, 575, 1),

                Rssi_Cb_Cbwr5_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_F", currentByte, 576, 35),
                Rssi_Cb_Cbwr5_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_Adrs1", currentByte, 611, 35),

                Rssi_Cb_Cbwr5_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_Adrs2", currentByte, 646, 35),
                Rssi_Cb_Cbwr5_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_City", currentByte, 681, 21),

                Rssi_Cb_Cbwr5_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_State", currentByte, 702, 2),
                Rssi_Cb_Cbwr5_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_Zip", currentByte, 704, 10),

                Rssi_Cb_Cbwr5_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_Bill_Stmnt", currentByte, 714, 1),
                Rssi_Cb_Cbwr6_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_F", currentByte, 715, 35),

                Rssi_Cb_Cbwr6_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_Adrs1", currentByte, 750, 35),
                Rssi_Cb_Cbwr6_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_Adrs2", currentByte, 785, -65),

                Rssi_Cb_Cbwr6_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_City", currentByte, 820, 21),
                Rssi_Cb_Cbwr6_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_State", currentByte, 841, 2),

                Rssi_Cb_Cbwr6_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_Zip", currentByte, 843, 10),
                Rssi_Cb_Cbwr6_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_Bill_Stmnt", currentByte, 853, 1),

                Rssi_Cb_Cbwr7_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_F", currentByte, 854, 35),
                Rssi_Cb_Cbwr7_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_Adrs1", currentByte, 889, 35),

                Rssi_Cb_Cbwr7_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_Adrs2", currentByte, 924, 35),
                Rssi_Cb_Cbwr7_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_City", currentByte, 959, 21),

                Rssi_Cb_Cbwr7_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_State", currentByte, 980, 2),
                Rssi_Cb_Cbwr7_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_Zip", currentByte, 982, 10),

                Rssi_Cb_Cbwr7_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_Bill_Stmnt", currentByte, 992, 1),
                Rssi_Cb_Cbwr8_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_F", currentByte, 993, 35),

                Rssi_Cb_Cbwr8_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_Adrs1", currentByte, 1028, 35),
                Rssi_Cb_Cbwr8_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_Adrs2", currentByte, 1063, 35),

                Rssi_Cb_Cbwr8_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_City", currentByte, 1098, 21),
                Rssi_Cb_Cbwr8_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_State", currentByte, 1119, 2),

                Rssi_Cb_Cbwr8_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_Zip", currentByte, 1121, 10),
                Rssi_Cb_Cbwr8_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_Bill_Stmnt", currentByte, 1131, 1),

                Rssi_Cb_Cbwr9_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_F", currentByte, 1132, 35),
                Rssi_Cb_Cbwr9_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_Adrs1", currentByte, 1167, 35),

                Rssi_Cb_Cbwr9_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_Adrs2", currentByte, 1202, 35),
                Rssi_Cb_Cbwr9_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_City", currentByte, 1237, 21),

                Rssi_Cb_Cbwr9_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_State", currentByte, 1258, 2),
                Rssi_Cb_Cbwr9_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_Zip", currentByte, 1260, 10),

                Rssi_Cb_Cbwr9_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_Bill_Stmnt", currentByte, 1270, 1),
                Rssi_Cb_Cbwr10_F = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_F", currentByte, 1271, 35),

                Rssi_Cb_Cbwr10_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_Adrs1", currentByte, 1306, 35),
                Rssi_Cb_Cbwr10_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_Adrs2", currentByte, 1341, 35),

                Rssi_Cb_Cbwr10_City = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_City", currentByte, 1376, 21),
                Rssi_Cb_Cbwr10_State = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_State", currentByte, 1397, 2),

                Rssi_Cb_Cbwr10_Zip = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_Zip", currentByte, 1399, 10),
                Rssi_Cb_Cbwr10_Bill_Stmnt = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_Bill_Stmnt", currentByte, 1409, 1),

                Rssi_Cb_Cbwr1_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_Corr_Flag", currentByte, 1410, 1),
                Rssi_Cb_Cbwr2_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_Corr_Flag", currentByte, 1411, 1),

                Rssi_Cb_Cbwr3_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_Corr_Flag", currentByte, 1412, 1),
                Rssi_Cb_Cbwr4_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_Corr_Flag", currentByte, 1413, 1),

                Rssi_Cb_Cbwr5_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_Corr_Flag", currentByte, 1414, 1),
                Rssi_Cb_Cbwr6_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_Corr_Flag", currentByte, 1415, 1),

                Rssi_Cb_Cbwr7_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_Corr_Flag", currentByte, 1416, 1),
                Rssi_Cb_Cbwr8_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_Corr_Flag", currentByte, 1417, 1),

                Rssi_Cb_Cbwr9_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_Corr_Flag", currentByte, 1418, 1),
                Rssi_Cb_Cbwr10_Corr_Flag = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_Corr_Flag", currentByte, 1419, 1),

                Rssi_Cb_Cbwr1_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr1_Typ", currentByte, 1420, 1),
                Rssi_Csii_Cbwr1_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr1_Verified", currentByte, 1421, 1),

                Rssi_Cb_Cbwr2_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr2_Typ", currentByte, 1422, 1),
                Rssi_Csii_Cbwr2_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr2_Verified", currentByte, 1423, 1),

                Rssi_Cb_Cbwr3_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr3_Typ", currentByte, 1424, 1),
                Rssi_Csii_Cbwr3_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr3_Verified", currentByte, 1425, 1),

                Rssi_Cb_Cbwr4_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr4_Typ", currentByte, 1426, 1),
                Rssi_Csii_Cbwr4_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr4_Verified", currentByte, 1427, 1),

                Rssi_Cb_Cbwr5_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr5_Typ", currentByte, 1428, 1),
                Rssi_Csii_Cbwr5_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr5_Verified", currentByte, 1429, 1),

                Rssi_Cb_Cbwr6_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr6_Typ", currentByte, 1430, 1),
                Rssi_Csii_Cbwr6_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr6_Verified", currentByte, 1431, 1),

                Rssi_Cb_Cbwr7_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr7_Typ", currentByte, 1432, 1),
                Rssi_Csii_Cbwr7_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr7_Verified", currentByte, 1433, 1),

                Rssi_Cb_Cbwr8_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr8_Typ", currentByte, 1434, 1),
                Rssi_Csii_Cbwr8_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr8_Verified", currentByte, 1435, 1),

                Rssi_Cb_Cbwr9_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr9_Typ", currentByte, 1436, 1),
                Rssi_Csii_Cbwr9_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr9_Verified", currentByte, 1437, 1),

                Rssi_Cb_Cbwr10_Typ = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr10_Typ", currentByte, 1438, 1),
                Rssi_Csii_Cbwr10_Verified = PackedTypeCheckAndUnPackData("Rssi_Csii_Cbwr10_Verified", currentByte, 1439, 1),

                Rssi_Cb_Cbwr_Email_Bill_Ind_1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_1", currentByte, 1440, 1),
                Rssi_Cb_Cbwr_Email_Bill_Ind_2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_2", currentByte, 1441, 1),

                Rssi_Cb_Cbwr_Email_Bill_Ind_3 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_3", currentByte, 1442, 1),
                Rssi_Cb_Cbwr_Email_Bill_Ind_4 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_4", currentByte, 1443, 1),

                Rssi_Cb_Cbwr_Email_Bill_Ind_5 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_5", currentByte, 1444, 1),
                Rssi_Cb_Cbwr_Email_Bill_Ind_6 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_6", currentByte, 1445, 1),

                Rssi_Cb_Cbwr_Email_Bill_Ind_7 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_7", currentByte, 1446, 1),
                Rssi_Cb_Cbwr_Email_Bill_Ind_8 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_8", currentByte, 1447, 1),

                Rssi_Cb_Cbwr_Email_Bill_Ind_9 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_9", currentByte, 1448, 1),
                Rssi_Cb_Cbwr_Email_Bill_Ind_10 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Bill_Ind_10", currentByte, 1449, 1),
                Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 1450, 2561),

            };
        }

        // < Late Charge Information Record. One record per loan if applicable.
        public void GetLateChargeInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.LateChargeInformationRecordModel = new LateChargeInformationRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),
                Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),
                Rssi_Lci_Pymt_Due_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Pymt_Due_Dt_PackedData", currentByte, 20, 4),
                Rssi_Lci_Code = PackedTypeCheckAndUnPackData("Rssi_Lci_Code", currentByte, 24, 1),
                Rssi_Lci_Ind = PackedTypeCheckAndUnPackData("Rssi_Lci_Ind", currentByte, 25, 1),
                Rssi_Lci_Ptd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Ptd_PackedData", currentByte, 26, 4),
                Rssi_Lci_Coll_Meth = PackedTypeCheckAndUnPackData("Rssi_Lci_Coll_Meth", currentByte, 30, 1),
                Rssi_Lci_Factor_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Factor_PackedData", currentByte, 31, 3,2),
                Rssi_Lci_Assess_Meth = PackedTypeCheckAndUnPackData("Rssi_Lci_Assess_Meth", currentByte, 34, 1),
                Rssi_Lci_Max_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Max_PackedData", currentByte, 35, 4, 2),
                Rssi_Lci_Min_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Min_PackedData", currentByte, 39, 4, 2),
                Rssi_Lci_Max_Annual_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Max_Annual_PackedData", currentByte, 43, 5, 2),
                Rssi_Lci_Max_Life_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Max_Life_PackedData", currentByte, 48, 5, 2),
                Rssi_Lci_Counter_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Counter_PackedData", currentByte, 53, 2),
                Rssi_Lci_Freeze_To_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Freeze_To_Dt_PackedData", currentByte, 55, 4),
                Rssi_Lci_Freeze_From_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Freeze_From_Dt_PackedData", currentByte, 59, 4),
                Rssi_Lci_Freeze_Dt_Type = PackedTypeCheckAndUnPackData("Rssi_Lci_Freeze_Dt_Type", currentByte, 63, 1),
                Rssi_Lci_Year_Type_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Year_Type_PackedData", currentByte, 64, 2),
                Rssi_Lci_Assesed_Lfe_To_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Assesed_Lfe_To_Dt_PackedData", currentByte, 66, 5, 2),
                Rssi_Lci_Assessed_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lci_Assessed_Ytd_PackedData", currentByte, 71, 5, 2),
                Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 76, 130),

            };
        }

        // - Late Charge Detail Record.One record per loan if applicable.
        public void GetLateChargeDetailRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.LateChargeDetailRecordModel = new LateChargeDetailRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

                Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

                Rssi_Lcd_Pymt_Due_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Pymt_Due_Dt_PackedData", currentByte, 20, 4),
                Rssi_Lcd_Due_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Due_Dt_PackedData", currentByte, 24, 4),

                Rssi_Lcd_Calc_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Calc_Dt_PackedData", currentByte, 28, 4),
                Rssi_Lcd_Amt_For_Lc_Due_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Amt_For_Lc_Due_Dt_PackedData", currentByte, 32, 5, 2),

                Rssi_Lcd_Pd_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Pd_Dt_PackedData", currentByte, 37, 4),
                Rssi_Lcd_Factor_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Factor_PackedData", currentByte, 41, 3, 3),

                Rssi_Lcd_Calc_Meth = PackedTypeCheckAndUnPackData("Rssi_Lcd_Calc_Meth", currentByte, 44, 1),
                Rssi_Lcd_Waiver_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Waiver_Dt_PackedData", currentByte, 45, 4),

                Rssi_Lcd_Waiver_Cd = PackedTypeCheckAndUnPackData("Rssi_Lcd_Waiver_Cd", currentByte, 49, 1),
                Rssi_Lcd_Rev_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Rev_Dt_PackedData", currentByte, 50, 4),

                Rssi_Lcd_Paid_Amt = PackedTypeCheckAndUnPackData("Rssi_Lcd_Paid_Amt", currentByte, 54, 5, 2),
                Rssi_Lcd_Waive_Amt = PackedTypeCheckAndUnPackData("Rssi_Lcd_Waive_Amt", currentByte, 59, 5, 2),

                Rssi_Lcd_Rev_Amt = PackedTypeCheckAndUnPackData("Rssi_Lcd_Rev_Amt", currentByte, 64, 5,2),
                Rssi_Lcd_Lc_Adj_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Lc_Adj_Dt_PackedData", currentByte, 69, 4),
                Rssi_Lcd_Lc_Adj_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Lc_Adj_Amt_PackedData", currentByte, 73, 5, 2),

                Rssi_Lcd_Rem_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Lcd_Rem_Bal_PackedData", currentByte, 78, 5,2),
                Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 83, 123),

            };
        }

        // J Active Bankruptcy Information Record. One record per loan if applicable.
        public void GetActiveBankruptcyInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.ActiveBankruptcyInformationRecordModel = new ActiveBankruptcyInformationRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),

                Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),

                Rssi_B_Type = PackedTypeCheckAndUnPackData("Rssi_B_Type", currentByte, 20, 1),
                Rssi_B_Chap = PackedTypeCheckAndUnPackData("Rssi_B_Chap", currentByte, 21, 2),

                Rssi_B_Case_No = PackedTypeCheckAndUnPackData("Rssi_B_Case_No", currentByte, 23, 12),
                Rssi_B_Filed_By = PackedTypeCheckAndUnPackData("Rssi_B_Filed_By", currentByte, 35, 1),

                Rssi_B_Debtor = PackedTypeCheckAndUnPackData("Rssi_B_Debtor", currentByte, 36, 35),
                Rssi_B_Co_Debtor = PackedTypeCheckAndUnPackData("Rssi_B_Co_Debtor", currentByte, 71, 35),

                Rssi_B_Filed_Cbwr1_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr1_Id", currentByte, 106, 1),
                Rssi_B_Filed_Cbwr2_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr2_Id", currentByte, 107, 1),

                Rssi_B_Filed_Cbwr3_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr3_Id", currentByte, 108, 1),
                Rssi_B_Filed_Cbwr4_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr4_Id", currentByte, 109, 1),

                Rssi_B_Filed_Cbwr5_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr5_Id", currentByte, 110, 1),
                Rssi_B_Filed_Cbwr6_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr6_Id", currentByte, 111, 1),

                Rssi_B_Filed_Cbwr7_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr7_Id", currentByte, 112, 1),
                Rssi_B_Filed_Cbwr8_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr8_Id", currentByte, 113, 1),

                Rssi_B_Filed_Cbwr9_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr9_Id", currentByte, 114, 1),
                Rssi_B_Filed_Cbwr10_Id = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Cbwr10_Id", currentByte, 115, 1),

                Rssi_B_Filed_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_Filed_Dt_PackedData", currentByte, 116, 4),
                Rssi_B_Conv_1_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_Conv_1_Date_PackedData", currentByte, 120, 4),

                Rssi_B_Reaffirm_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_Reaffirm_Dt_PackedData", currentByte, 124, 4),
                Rssi_B_Dschg_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_Dschg_Dt_PackedData", currentByte, 128, 4),

                Rssi_B_Dsmsd_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_Dsmsd_Dt_PackedData", currentByte, 132, 4),
                Rssi_B_Relief_1_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_Relief_1_Dt_PackedData", currentByte, 136, 4),

                Rssi_B_C_Type = PackedTypeCheckAndUnPackData("Rssi_B_C_Type", currentByte, 140, 1),
                Rssi_B_C_Chap = PackedTypeCheckAndUnPackData("Rssi_B_C_Chap", currentByte, 141, 2),

                Rssi_B_C_Case_No = PackedTypeCheckAndUnPackData("Rssi_B_C_Case_No", currentByte, 143, 12),
                Rssi_B_C_Filed_By = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_By", currentByte, 155, 1),

                Rssi_B_C_Debtor = PackedTypeCheckAndUnPackData("Rssi_B_C_Debtor", currentByte, 156, 25),
                Rssi_B_C_Co_Debtor = PackedTypeCheckAndUnPackData("Rssi_B_C_Co_Debtor", currentByte, 181, 25),

                Rssi_B_C_Filed_Cbwr1_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr1_Id", currentByte, 206, 1),
                Rssi_B_C_Filed_Cbwr2_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr2_Id", currentByte, 207, 1),

                Rssi_B_C_Filed_Cbwr3_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr3_Id", currentByte, 208, 1),
                Rssi_B_C_Filed_Cbwr4_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr4_Id", currentByte, 209, 1),

                Rssi_B_C_Filed_Cbwr5_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr5_Id", currentByte, 210, 1),
                Rssi_B_C_Filed_Cbwr6_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr6_Id", currentByte, 211, 1),

                Rssi_B_C_Filed_Cbwr7_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr7_Id", currentByte, 212, 1),
                Rssi_B_C_Filed_Cbwr8_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr8_Id", currentByte, 213, 1),

                Rssi_B_C_Filed_Cbwr9_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr9_Id", currentByte, 214, 1),
                Rssi_B_C_Filed_Cbwr10_Id = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Cbwr10_Id", currentByte, 215, 1),

                Rssi_B_C_Filed_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_C_Filed_Dt_PackedData", currentByte, 216, 4),
                Rssi_B_C_Conv_1_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_C_Conv_1_Date_PackedData", currentByte, 220, 4),

                Rssi_B_C_Reaffirm_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_C_Reaffirm_Dt_PackedData", currentByte, 224, 4),
                Rssi_B_C_Dschg_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_C_Dschg_Dt_PackedData", currentByte, 228, 4),

                Rssi_B_C_Dsmsd_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_C_Dsmsd_Dt_PackedData", currentByte, 232, 4),
                Rssi_B_C_Relf_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_B_C_Relf_Dt_PackedData", currentByte, 236, 4),

                Rssi_Poc_Post_Amt_Due_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Amt_Due_PackedData", currentByte, 240, 6, 2),
                Rssi_Poc_Post_Lc_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Lc_PackedData", currentByte, 246, 5, 2),

                Rssi_Poc_Total_Rec_Bkr_Pre_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Total_Rec_Bkr_Pre_PackedData", currentByte, 251, 5, 2),
                Rssi_Poc_Post_Pet_Fees_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Pet_Fees_PackedData", currentByte, 256, 5, 2),

                Rssi_Poc_Amt_Paid_By_Pet_Last_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Amt_Paid_By_Pet_Last_PackedData", currentByte, 261, 5, 2),
                Rssi_Poc_Pre_Pet_Arrearage_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Pre_Pet_Arrearage_PackedData", currentByte, 266, 5, 2),

                Rssi_Poc_Statement_Flag = PackedTypeCheckAndUnPackData("Rssi_Poc_Statement_Flag", currentByte, 271, 1),
                Rssi_Vend_Name1 = PackedTypeCheckAndUnPackData("Rssi_Vend_Name1", currentByte, 272, 35),

                Rssi_Vend_Adrs1 = PackedTypeCheckAndUnPackData("Rssi_Vend_Adrs1", currentByte, 307, 35),
                Rssi_Vend_Adrs2 = PackedTypeCheckAndUnPackData("Rssi_Vend_Adrs2", currentByte, 342, 35),

                Rssi_Vend_City = PackedTypeCheckAndUnPackData("Rssi_Vend_City", currentByte, 377, 21),
                Rssi_Vend_State = PackedTypeCheckAndUnPackData("Rssi_Vend_State", currentByte, 398, 2),

                Rssi_Vend_Zip = PackedTypeCheckAndUnPackData("Rssi_Vend_Zip", currentByte, 400, 10),
                Rssi_Poc_Pre_Suspense_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Pre_Suspense_PackedData", currentByte, 410, 6, 2),

                Rssi_Poc_Post_Suspense_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Suspense_PackedData", currentByte, 416, 6, 2),
                Rssi_Brpy_Unapp_Paid_PackedData = PackedTypeCheckAndUnPackData("Rssi_Brpy_Unapp_Paid_PackedData", currentByte, 422, 6, 2),

                Rssi_Brpy_Plan_Next_Pmt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Brpy_Plan_Next_Pmt_PackedData", currentByte, 428, 5, 2),
                Rssi_Brpy_Plan_Due_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Brpy_Plan_Due_Date_PackedData", currentByte, 433, 4),

                Rssi_Fbr_B_Cramdown_Flag = PackedTypeCheckAndUnPackData("Rssi_Fbr_B_Cramdown_Flag", currentByte, 437, 1),
                Rssi_Poc_Post_Pet_Unpaid_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Pet_Unpaid_PackedData", currentByte, 438, 5),

                Rssi_Poc_Bk_Discharged = PackedTypeCheckAndUnPackData("Rssi_Poc_Bk_Discharged", currentByte, 443, 1),
                Rssi_Poc_Post_Shortfall_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Shortfall_PackedData", currentByte, 444, 6, 2),

                Rssi_Brpy_Short_Bal_PackedData = PackedTypeCheckAndUnPackData("Rssi_Brpy_Short_Bal_PackedData", currentByte, 450, 6),
                Rssi_Poc_Pre_Due_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Pre_Due_Date_PackedData", currentByte, 456, 4),

                Rssi_Poc_Pre_Payment_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Pre_Payment_PackedData", currentByte, 460, 6, 2),
                Rssi_Poc_Plan_Shortfall_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Plan_Shortfall_PackedData", currentByte, 466, 6, 2),

                Rssi_Poc_Post_Due_Date = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Due_Date", currentByte, 472, 8),
                Rssi_Poc_Post_Payment_PackedData = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Payment_PackedData", currentByte, 480, 6, 2),

                Rssi_Post_Lc_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Post_Lc_Amt_PackedData", currentByte, 486, 4, 2),
                Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 490, 511),

            };
        }

        // K Archived Bankruptcy Information Record. Multiple records per loan if applicable.
        public void GetArchivedBankruptcyDetailRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.ArchivedBankruptcyDetailRecordModel = new ArchivedBankruptcyDetailRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),
                Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),
                Rssi_K_B_Type = PackedTypeCheckAndUnPackData("Rssi_K_B_Type", currentByte, 20, 1),
                Rssi_K_B_Chap = PackedTypeCheckAndUnPackData("Rssi_K_B_Chap", currentByte, 21, 2),
                Rssi_K_B_Case_No = PackedTypeCheckAndUnPackData("Rssi_K_B_Case_No", currentByte, 23, 12),
                Rssi_K_B_Filed_By = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_By", currentByte, 35, 1),
                Rssi_K_B_Debtor = PackedTypeCheckAndUnPackData("Rssi_K_B_Debtor", currentByte, 36, 35),
                Rssi_K_B_Co_Debtor = PackedTypeCheckAndUnPackData("Rssi_K_B_Co_Debtor", currentByte, 71, 35),
                Rssi_K_B_Filed_Cbwr1_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr1_Id", currentByte, 106, 1),
                Rssi_K_B_Filed_Cbwr2_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr2_Id", currentByte, 107, 1),
                Rssi_K_B_Filed_Cbwr3_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr3_Id", currentByte, 108, 1),
                Rssi_K_B_Filed_Cbwr4_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr4_Id", currentByte, 109, 1),
                Rssi_K_B_Filed_Cbwr5_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr5_Id", currentByte, 110, 1),
                Rssi_K_B_Filed_Cbwr6_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr6_Id", currentByte, 111, 1),
                Rssi_K_B_Filed_Cbwr7_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr7_Id", currentByte, 112, 1),
                Rssi_K_B_Filed_Cbwr8_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr8_Id", currentByte, 113, 1),
                Rssi_K_B_Filed_Cbwr9_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr9_Id", currentByte, 114, 1),
                Rssi_K_B_Filed_Cbwr10_Id = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Cbwr10_Id", currentByte, 115, 1),
                Rssi_K_B_Filed_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_K_B_Filed_Dt_PackedData", currentByte, 116, 4),
                Rssi_K_B_Conv_1_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_K_B_Conv_1_Date_PackedData", currentByte, 120, 4),
                Rssi_K_B_Reaffirm_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_K_B_Reaffirm_Dt_PackedData", currentByte, 124, 4),
                Rssi_K_B_Dschg_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_K_B_Dschg_Dt_PackedData", currentByte, 128, 4),
                Rssi_K_B_Dsmsd_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_K_B_Dsmsd_Dt_PackedData", currentByte, 132, 4),
                Rssi_K_B_Relief_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_K_B_Relief_Dt_PackedData", currentByte, 136, 4),
                Rssi_K_Poc_Statement_Flag = PackedTypeCheckAndUnPackData("Rssi_K_Poc_Statement_Flag", currentByte, 140, 1),
                Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 141, 160),

            };
        }

        // X Email Addresses Record
        public void GetEmailAddressRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.EmailAddressRecordModel = new EmailAddressRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),
                Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),
                Rssi_Info_Primary_Email_Adr = PackedTypeCheckAndUnPackData("Rssi_Info_Primary_Email_Adr", currentByte, 20, 60),
                Rssi_Info_Scnd_Email_Adr = PackedTypeCheckAndUnPackData("Rssi_Info_Scnd_Email_Adr", currentByte, 80, 60),
                Rssi_Info_E_Stmt_Email_Adr_1 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_1", currentByte, 140, 60),
                Rssi_Info_E_Stmt_Email_Adr_2 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_2", currentByte, 200, 60),
                Rssi_Info_E_Stmt_Email_Adr_3 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_3", currentByte, 260, 60),
                Rssi_Info_E_Stmt_Email_Adr_4 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_4", currentByte, 320, 60),
                Rssi_Info_E_Stmt_Email_Adr_5 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_5", currentByte, 380, 60),
                Rssi_Info_E_Stmt_Email_Adr_6 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_6", currentByte, 440, 60),
                Rssi_Info_E_Stmt_Email_Adr_7 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_7", currentByte, 500, 60),
                Rssi_Info_E_Stmt_Email_Adr_8 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_8", currentByte, 560, 60),
                Rssi_Info_E_Stmt_Email_Adr_9 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_9", currentByte, 620, 60),
                Rssi_Info_E_Stmt_Email_Adr_10 = PackedTypeCheckAndUnPackData("Rssi_Info_E_Stmt_Email_Adr_10", currentByte, 680, 60),
                Rssi_Cb_Cbwr_Email_Adr_1 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_1", currentByte, 740, 60),
                Rssi_Cb_Cbwr_Email_Adr_2 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_2", currentByte, 800, 60),
                Rssi_Cb_Cbwr_Email_Adr_3 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_3", currentByte, 860, 60),
                Rssi_Cb_Cbwr_Email_Adr_4 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_4", currentByte, 920, 60),
                Rssi_Cb_Cbwr_Email_Adr_5 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_5", currentByte, 980, 60),
                Rssi_Cb_Cbwr_Email_Adr_6 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_6", currentByte, 1040, 60),
                Rssi_Cb_Cbwr_Email_Adr_7 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_7", currentByte, 1100, 60),
                Rssi_Cb_Cbwr_Email_Adr_8 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_8", currentByte, 1160, 60),
                Rssi_Cb_Cbwr_Email_Adr_9 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_9", currentByte, 1220, 60),
                Rssi_Cb_Cbwr_Email_Adr_10 = PackedTypeCheckAndUnPackData("Rssi_Cb_Cbwr_Email_Adr_10", currentByte, 1280, 60),
                Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 1340, 2671),

            };
        }

        // 3 Disaster Tracking Record
        public void GetDisasterTrackingRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.DisasterTrackingRecordModel = new DisasterTrackingRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),
                Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),
                Rssi_Dstr_Occ_Num = PackedTypeCheckAndUnPackData("Rssi_Dstr_Occ_Num", currentByte, 20, 3),
                Rssi_Dstr_Status = PackedTypeCheckAndUnPackData("Rssi_Dstr_Status", currentByte, 23, 1),
                Rssi_Dstr_Disaster_Name = PackedTypeCheckAndUnPackData("Rssi_Dstr_Disaster_Name", currentByte, 24, 35),
                Rssi_Dstr_Type = PackedTypeCheckAndUnPackData("Rssi_Dstr_Type", currentByte, 59, 2),
                Rssi_Dstr_Desig_Dt = PackedTypeCheckAndUnPackData("Rssi_Dstr_Desig_Dt", currentByte, 61, 4),
                Rssi_Dstr_End_Dt = PackedTypeCheckAndUnPackData("Rssi_Dstr_End_Dt", currentByte, 65, 4),
                Rssi_Dstr_Extended_Dt = PackedTypeCheckAndUnPackData("Rssi_Dstr_Extended_Dt", currentByte, 69, 4),
                Rssi_Dstr_Ddn = PackedTypeCheckAndUnPackData("Rssi_Dstr_Ddn", currentByte, 73, 10),
                Rssi_Dstr_Aplcnt_Nbr = PackedTypeCheckAndUnPackData("Rssi_Dstr_Aplcnt_Nbr", currentByte, 83, 10),
                Rssi_Dstr_Prop_Impact_Determine = PackedTypeCheckAndUnPackData("Rssi_Dstr_Prop_Impact_Determine", currentByte, 93, 1),
                Rssi_Dstr_Prop_Determine_Dt = PackedTypeCheckAndUnPackData("Rssi_Dstr_Prop_Determine_Dt", currentByte, 94, 4),
                Rssi_Dstr_Prop_Resolution_Dt = PackedTypeCheckAndUnPackData("Rssi_Dstr_Prop_Resolution_Dt", currentByte, 98, 4),
                Rssi_Dstr_Prop_Impact_Severity = PackedTypeCheckAndUnPackData("Rssi_Dstr_Prop_Impact_Severity", currentByte, 102, 1),
                Rssi_Dstr_Wrkp_Impact_Determine = PackedTypeCheckAndUnPackData("Rssi_Dstr_Wrkp_Impact_Determine", currentByte, 103, 1),
                Rssi_Dstr_Wrkp_Determine_Dt = PackedTypeCheckAndUnPackData("Rssi_Dstr_Wrkp_Determine_Dt", currentByte, 104, 4),
                Rssi_Dstr_Wrkp_Resolution_Dt = PackedTypeCheckAndUnPackData("Rssi_Dstr_Wrkp_Resolution_Dt", currentByte, 108, 4),
                Rssi_Dstr_Wrkp_Impact_Severity = PackedTypeCheckAndUnPackData("Rssi_Dstr_Wrkp_Impact_Severity", currentByte, 112, 1),
                Rssi_Dstr_Attempt_Contact = PackedTypeCheckAndUnPackData("Rssi_Dstr_Attempt_Contact", currentByte, 113, 1),
                Rssi_Dstr_Attempt_Contact_Dt = PackedTypeCheckAndUnPackData("Rssi_Dstr_Attempt_Contact_Dt", currentByte, 114, 4),
                Rssi_Dstr_Contact_Made = PackedTypeCheckAndUnPackData("Rssi_Dstr_Contact_Made", currentByte, 118, 1),
                Rssi_Dstr_Contact_Made_Dt = PackedTypeCheckAndUnPackData("Rssi_Dstr_Contact_Made_Dt", currentByte, 119, 4),
                Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 123, 78),
            };
        }

        // 4 RHCDS Only Record(Only created if RHCDS Option (DB-2: I-RHCDS-OPT) =‘Y’)
        public void GetRHCDRecords(byte[] currentByte, ref AccountsModel acc)
        {
            acc.RHCDSOnlyRecordModel = new RHCDSOnlyRecordModel()
            {
                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),
                Rssi_Acct_No = PackedTypeCheckAndUnPackData("Rssi_Acct_No", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),
                Rssi_Rhcds_Aa_Expir_Date_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rhcds_Aa_Expir_Date_PackedData", currentByte, 20, 4),
                Rssi_Subsidy_Paid_Ytd_PackedData = PackedTypeCheckAndUnPackData("Rssi_Subsidy_Paid_Ytd_PackedData", currentByte, 24, 5, 2),
                Rssi_Rhcds_Morat_Eff_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rhcds_Morat_Eff_Dt_PackedData", currentByte, 29, 4),
                Rssi_Rhcds_Morat_Flag = PackedTypeCheckAndUnPackData("Rssi_Rhcds_Morat_Flag", currentByte, 33, 1),
                Rssi_Rhcds_Morat_Expir_St_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rhcds_Morat_Expir_St_PackedData", currentByte, 34, 4),
                Rssi_Ml_Notice_Ctl = PackedTypeCheckAndUnPackData("Rssi_Ml_Notice_Ctl", currentByte, 38, 1),
                Rssi_Ml_Pend_Start_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Ml_Pend_Start_Dt_PackedData", currentByte, 39, 4),
                Rssi_Ml_Bnkrpt_Flg = PackedTypeCheckAndUnPackData("Rssi_Ml_Bnkrpt_Flg", currentByte, 43, 1),
                Rssi_Ml_Bankrupt_Code = PackedTypeCheckAndUnPackData("Rssi_Ml_Bankrupt_Code", currentByte, 44, 1),
                Rssi_Ml_Repay_Status_Flg = PackedTypeCheckAndUnPackData("Rssi_Ml_Repay_Status_Flg", currentByte, 45, 1),
                Rssi_Ml_Repay_Cancel_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Ml_Repay_Cancel_Dt_PackedData", currentByte, 46, 4),
                Rssi_Rpmt_Add_Pmt_Amt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rpmt_Add_Pmt_Amt_PackedData", currentByte, 50, 5, 2),
                Rssi_Rpmt_Plan_Term_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rpmt_Plan_Term_PackedData", currentByte, 55, 2),
                Rssi_Rpmt_Creation_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rpmt_Creation_Dt_PackedData", currentByte, 57, 4),
                Rssi_Rpmt_Rhcds_Down_Pymt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rpmt_Rhcds_Down_Pymt_PackedData", currentByte, 61, 5, 2),
                Rssi_Rpmt_Start_Dt_PackedData = PackedTypeCheckAndUnPackData("Rssi_Rpmt_Start_Dt_PackedData", currentByte, 66, 4),
                Rssi_Ffssd119_Dwa_Delq_PackedData = PackedTypeCheckAndUnPackData("Rssi_Ffssd119_Dwa_Delq_PackedData", currentByte, 70, 4, 2),
                Rssi_Poc_Post_Plan_Source = PackedTypeCheckAndUnPackData("Rssi_Poc_Post_Plan_Source", currentByte, 74, 1),
                Filler = PackedTypeCheckAndUnPackData("Filler", currentByte, 75, 126),

            };
        }

        // Z Trailer. One record per file.
        public void GetTrailerRecords(byte[] currentByte, ref AccountsModel acc)
        {
            acc.TrailerRecordModel = new TrailerRecordModel()
            {

                Rssi_Rcd_Id = PackedTypeCheckAndUnPackData("Rssi_Rcd_Id", currentByte, 1, 1),
                Rssi_Inst = PackedTypeCheckAndUnPackData("Rssi_Inst", currentByte, 2, 3),
                Rssi_Acct_Np = PackedTypeCheckAndUnPackData("Rssi_Acct_Np", currentByte, 5, 10),
                Rssi_Seq_No = PackedTypeCheckAndUnPackData("Rssi_Seq_No", currentByte, 15, 5),
                Rssi_Total_B_Records = PackedTypeCheckAndUnPackData("Rssi_Total_B_Records", currentByte, 20, 1),
                Rssi_Total_A_Records = PackedTypeCheckAndUnPackData("Rssi_Total_A_Records", currentByte, 21, 9),
                Rssi_Total_R_Records = PackedTypeCheckAndUnPackData("Rssi_Total_R_Records", currentByte, 30, 9),
                Rssi_Total_E_Records = PackedTypeCheckAndUnPackData("Rssi_Total_E_Records", currentByte, 39, 15),
                Rssi_Total_T_Records = PackedTypeCheckAndUnPackData("Rssi_Total_T_Records", currentByte, 54, 15),
                Rssi_Total_O_Records = PackedTypeCheckAndUnPackData("Rssi_Total_O_Records", currentByte, 69, 9),
                Rssi_Total_F_Records = PackedTypeCheckAndUnPackData("Rssi_Total_F_Records", currentByte, 78, 9),
                Rssi_Total_U_Records = PackedTypeCheckAndUnPackData("Rssi_Total_U_Records", currentByte, 87, 9),
                Rssi_Total_2_Records = PackedTypeCheckAndUnPackData("Rssi_Total_2_Records", currentByte, 96, 9),
                Rssi_Total_P_Records = PackedTypeCheckAndUnPackData("Rssi_Total_P_Records", currentByte, 105, 9),
                Rssi_Total_L_Records = PackedTypeCheckAndUnPackData("Rssi_Total_L_Records", currentByte, 114, 9),
                Rssi_Total_S_Records = PackedTypeCheckAndUnPackData("Rssi_Total_S_Records", currentByte, 123, 9),
                Rssi_Total_Fr_Records = PackedTypeCheckAndUnPackData("Rssi_Total_Fr_Records", currentByte, 132, 9),
                Rssi_Total_Records = PackedTypeCheckAndUnPackData("Rssi_Total_Records", currentByte, 141, 15),
                Rssi_Total_Loans = PackedTypeCheckAndUnPackData("Rssi_Total_Loans", currentByte, 156, 9),

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
        public void GenerateCRL30File()
        {
            //List<AccountsModel> account = new List<AccountsModel>();
            //Logger.Trace("Creating NCP Header records...");


            //Logger.Trace("Creating NCP Institution records...");
            //Logger.Trace("Starting Account records process...");
            // var line = new StringBuilder();


            //foreach (var account in account)
            //{
            //    Logger.Trace("Creating NCP10 records for Account" + account.MasterFileDataPart_1Model.AccountNumber);
            //    //account.MasterFileDataPart_1Model.AccountNumber;
            //    line.Append(Delimiter).Append(extractAccount.MailReturnAddress.Address.CityName);

            //}
        }

        public string PackedTypeCheckAndUnPackData(string propertyName, byte[] data, int start, int length, int decimalPlaces = 0, bool hasSign = true)
        {
            if (propertyName.Contains("PackedData") && propertyName != null)
            {
                var buffer = new byte[length];
                Array.Copy(data, start - 1, buffer, 0, length);
                string output = string.Empty;
                string sign = string.Empty;
                int upperBound = length - 1;

                for (int i = 0; i < length; i++)
                {
                    var left = (buffer[i] & 0xF0) >> 4;
                    var right = buffer[i] & 0x0F;

                    output += left.ToString(CultureInfo.InvariantCulture);

                    if (i == upperBound && hasSign)
                    {
                        sign = right == 0x0D ? "-" : string.Empty;
                    }
                    else
                    {
                        output += right.ToString(CultureInfo.InvariantCulture);
                    }
                }

                if (decimalPlaces > 0)
                {
                    int index = output.Length - decimalPlaces;
                    output = output.Insert(index, ".");
                }

                if (hasSign)
                {
                    output = output.Insert(0, sign);
                }

                return output;
            }
            else
            {
                return GetPositionData(data, start, length);
            }


        }
        #endregion


    }
}
