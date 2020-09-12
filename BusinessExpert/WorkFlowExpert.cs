﻿using Carrington_Service.Helpers;
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
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_File_Id = GetPositionData(currentByte, 20, 24)
            };

        }

        // B Institution Record.One record per institution.
        public void GetInstitutionRecord(byte[] currentByte)
        {
            MortgageLoanBillingFile.InstitutionRecords = new InstitutionRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Institution_Name = GetPositionData(currentByte, 20, 35),
                Rssi_Inst_Adrs_1 = GetPositionData(currentByte, 55, 35),
                Rssi_Inst_Adrs_2 = GetPositionData(currentByte, 90, 35),
                Rssi_Inst_City = GetPositionData(currentByte, 125, 21),
                Rssi_Inst_State = GetPositionData(currentByte, 146, 2),
                Rssi_Inst_Zip = GetPositionData(currentByte, 148, 10),
                Rssi_Inst_Phone = GetPositionData(currentByte, 158, 10),
                Rssi_Alt_Coup_Adrs_1 = GetPositionData(currentByte, 168, 35),
                Rssi_Alt_Coup_Adrs_2 = GetPositionData(currentByte, 203, 35),
                Rssi_Alt_Coup_City = GetPositionData(currentByte, 238, 21),
                Rssi_Alt_Coup_State = GetPositionData(currentByte, 259, 2),
                Rssi_Alt_Coup_Zip = GetPositionData(currentByte, 261, 10),
                Rssi_Alt_Coup_Ph_Desc_1 = GetPositionData(currentByte, 271, 20),
                Rssi_Alt_Coup_Ph_No_1 = GetPositionData(currentByte, 291, 10),
                Rssi_Alt_Coup_Ph_Desc_2 = GetPositionData(currentByte, 301, 20),
                Rssi_Alt_Coup_Ph_No_2 = GetPositionData(currentByte, 321, 10),
                Rssi_Alt_Coup_Ph_Desc_3 = GetPositionData(currentByte, 331, 20),
                Rssi_Alt_Coup_Ph_No_3 = GetPositionData(currentByte, 351, 10),
                Rssi_Alt_Coup_Ph_Desc_4 = GetPositionData(currentByte, 361, 20),
                Rssi_Alt_Coup_Ph_No_4 = GetPositionData(currentByte, 381, 10),
                Rssi_Alt_Coup_Ph_Desc_5 = GetPositionData(currentByte, 391, 20),
                Rssi_Alt_Coup_Ph_No_5 = GetPositionData(currentByte, 411, 10),
                Rssi_Lock_Adrs_1 = GetPositionData(currentByte, 421, 35),
                Rssi_Lock_Adrs_2 = GetPositionData(currentByte, 456, 35),
                Rssi_Lock_City = GetPositionData(currentByte, 491, 21),
                Rssi_Lock_State = GetPositionData(currentByte, 512, 2),
                Rssi_Lock_Zip = GetPositionData(currentByte, 514, 10)
            };
        }

        // P PL$$ Entity Record.One record per Entity within Institution if applicable.
        public void GetPL_Record(byte[] currentByte, ref AccountsModel acc)
        {
            acc.PL_RecordModel = new PL_RecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),

                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),

                Rssi_N1Mx_Plss_Entity = GetPositionData(currentByte, 20, 3),
                Rssi_Enty_Plss_Group = GetPositionData(currentByte, 23, 8),

                Rssi_Enty_Status = GetPositionData(currentByte, 31, 1),
                Rssi_Enty_Name = GetPositionData(currentByte, 32, 35),

                Rssi_Enty_Adrs_1 = GetPositionData(currentByte, 67, 35),
                Rssi_Enty_Adrs_2 = GetPositionData(currentByte, 102, 35),

                Rssi_Enty_City = GetPositionData(currentByte, 137, 21),
                Rssi_Enty_State = GetPositionData(currentByte, 158, 35),

                Rssi_Enty_Zip = GetPositionData(currentByte, 193, 10),
                Rssi_Enty_Phone = GetPositionData(currentByte, 203, 10),

                Rssi_Enty_Tax_Id_Number = GetPositionData(currentByte, 213, 09),
                Rssi_I_Mers_Org_Id = GetPositionData(currentByte, 222, 07),

                Rssi_I_Hud_Id = GetPositionData(currentByte, 229, 12),
                Rssi_I_Va_Set264_Id = GetPositionData(currentByte, 241, 06),

                Rssi_Enty_Rhs_Lender_Number = GetPositionData(currentByte, 247, 03),
                Rssi_Enty_Hud_Cont_Name_First = GetPositionData(currentByte, 250, 10),

                Rssi_Enty_Hud_Cont_Name_Last = GetPositionData(currentByte, 260, 20),
                Rssi_Enty_Cont_Phn = GetPositionData(currentByte, 280, 10),

                Rssi_Enty_Hud_Office_City = GetPositionData(currentByte, 290, 21),
                Rssi_Enty_Hud_Office_State = GetPositionData(currentByte, 311, 2),

                Rssi_Enty_Hud_Office_Zip = GetPositionData(currentByte, 313, 09),
                Rssi_Enty_Company_Head_St_Cd = GetPositionData(currentByte, 322, 03),

                Rssi_Enty_Lock_Adrs_1 = GetPositionData(currentByte, 325, 35),
                Rssi_Enty_Lock_Adrs_2 = GetPositionData(currentByte, 360, 35),

                Rssi_Enty_Lock_City = GetPositionData(currentByte, 395, 21),
                Rssi_Enty_Lock_State = GetPositionData(currentByte, 416, 2),

                Rssi_Enty_Lock_Zip = GetPositionData(currentByte, 418, 10),
                Rssi_Enty_Alt_Coup_Adrs_1 = GetPositionData(currentByte, 428, 35),

                Rssi_Enty_Alt_Coup_Adrs_2 = GetPositionData(currentByte, 463, 35),
                Rssi_Enty_Alt_Coup_City = GetPositionData(currentByte, 498, 21),

                Rssi_Enty_Alt_Coup_State = GetPositionData(currentByte, 519, 2),
                Rssi_Enty_Alt_Coup_Zip = GetPositionData(currentByte, 521, 10),

                Rssi_Enty_Alt_Coup_Ph_Desc_1 = GetPositionData(currentByte, 531, 20),
                Rssi_Enty_Alt_Coup_Ph_No_1 = GetPositionData(currentByte, 551, 10),

                Rssi_Enty_Alt_Coup_Ph_Desc_2 = GetPositionData(currentByte, 561, 20),
                Rssi_Enty_Alt_Coup_Ph_No_2 = GetPositionData(currentByte, 581, 10),

                Rssi_Enty_Alt_Coup_Ph_Desc_3 = GetPositionData(currentByte, 591, 20),
                Rssi_Enty_Alt_Coup_Ph_No_3 = GetPositionData(currentByte, 611, 10),

                Rssi_Enty_Alt_Coup_Ph_Desc_4 = GetPositionData(currentByte, 621, 20),
                Rssi_Enty_Alt_Coup_Ph_No_4 = GetPositionData(currentByte, 641, 10),

                Rssi_Enty_Alt_Coup_Ph_Desc_5 = GetPositionData(currentByte, 651, 20),
                Rssi_Enty_Alt_Coup_Ph_No_5 = GetPositionData(currentByte, 671, 10),
            };
        }

        // A Master File Data Part 1 Record.One record per loan.
        public void GetMasterFileDataPart_1(byte[] currentByte, ref AccountsModel acc)
        {

            acc.MasterFileDataPart_1Model = new MasterFileDataPart_1Model()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),

                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),

                Rssi_Cr_Ins_Pymt_PackedData = UnpackComp3(currentByte, 20, 4, 0, true),
                Rssi_Prin_Bal_PackedData = UnpackComp3(currentByte, 24, 6, 0, true),

                Rssi_Esc_Bal_PackedData = UnpackComp3(currentByte, 30, 6,0,true),
                Rssi_Ln_Type_PackedData = UnpackComp3(currentByte, 36, 1,0,true),

                Rssi_Sub_Type_PackedData = UnpackComp3(currentByte, 37, 1,0, true),
                Rssi_P_I_Pymt_PackedData = UnpackComp3(currentByte, 38, 6,0, true),

                Rssi_Esc_Pymt_PackedData = UnpackComp3(currentByte, 44, 5, 0, true),
                Rssi_Inv_Own_Cd_PackedData = UnpackComp3(currentByte, 49, 1, 0, true),

                Rssi_Inv_All = GetPositionData(currentByte, 50, 280),
                Rssi_Inv_Code_PackedData = UnpackComp3(currentByte, 50, 3, 0, true),

                Rssi_Inv_Name = GetPositionData(currentByte, 53, 35),
                Rssi_Inv_Block_PackedData = UnpackComp3(currentByte, 88, 3, 0, true),

                Rssi_Inv_Pc_Owned_PackedData = UnpackComp3(currentByte, 91, 4, 0, true),
                Rssi_Inv_Rate_PackedData = UnpackComp3(currentByte, 95, 4, 0, true),

                Rssi_Inv_Sv_Code_PackedData = UnpackComp3(currentByte, 99, 1, 0, true),
                Rssi_Inv_Sv_Fee_PackedData = UnpackComp3(currentByte, 100, 4, 0, true),

                Rssi_Inv_Sv_Acct = GetPositionData(currentByte, 104, 15),
                Rssi_Inv_Fill = GetPositionData(currentByte, 119, 1),

                Rssi_Lip_La_Date = GetPositionData(currentByte, 330, 6),
                Rssi_Pre_Int_Amt_PackedData = UnpackComp3(currentByte, 336, 6, 0, true),

                Rssi_Esc_Var_PackedData = UnpackComp3(currentByte, 342, 6, 0, true),
                Rssi_Prop_Cd_PackedData = UnpackComp3(currentByte, 348, 2, 0, true),

                Rssi_Int_Pd_Ytd_PackedData = UnpackComp3(currentByte, 350, 6, 0, true),
                Rssi_Pur_Code_PackedData = UnpackComp3(currentByte, 356, 2, 0, true),

                Rssi_Unap_Fund_Cd = GetPositionData(currentByte, 358, 1),
                Rssi_State_PackedData = UnpackComp3(currentByte, 359, 2, 0, true),

                Rssi_Due_Date = GetPositionData(currentByte, 361, 6),
                Rssi_Pymts_Due_Amt_PackedData = UnpackComp3(currentByte, 367, 7, 0, true),

                Rssi_Pymts_Due_Ctr_PackedData = UnpackComp3(currentByte, 374, 2, 0, true),
                Rssi_Late_Chg_Amt_PackedData = UnpackComp3(currentByte, 376, 4, 0, true),

                Rssi_Late_Chg_Due_PackedData = UnpackComp3(currentByte, 380, 4, 0, true),
                Rssi_Prepaid_Flag = GetPositionData(currentByte, 384, 1),

                Rssi_Esc_Int_Ytd_PackedData = UnpackComp3(currentByte, 385, 4, 0, true),
                Rssi_Run_Date = GetPositionData(currentByte, 389, 6),

                Rssi_Primary_Name = GetPositionData(currentByte, 395, 35),
                Rssi_Secondary_Name = GetPositionData(currentByte, 430, 35),

                Rssi_Mail_Adrs_1 = GetPositionData(currentByte, 465, 35),
                Rssi_Appl_Adrs_1 = GetPositionData(currentByte, 570, 35),

                Rssi_Bill_Pmt_Dte = GetPositionData(currentByte, 675, 6),
                Rssi_Bill_Pmt_Amt_PackedData = UnpackComp3(currentByte, 681, 6),

                Rssi_Branch_PackedData = GetPositionData(currentByte, 687, 3),
                Rssi_Bill_Total_Due_PackedData = UnpackComp3(currentByte, 690, 7),

                Rssi_Bill_Lc_PackedData = UnpackComp3(currentByte, 697, 5),
                Rssi_Pymt_Cyc_PackedData = UnpackComp3(currentByte, 702, 1),

                Rssi_W_Flag_PackedData = UnpackComp3(currentByte, 703, 1),
                Rssi_Dist_Mail_Cd = GetPositionData(currentByte, 704, 1),

                Rssi_Last_Actvty_Dt_PackedData = UnpackComp3(currentByte, 705, 4),
                Rssi_Apr_Rate_PackedData = UnpackComp3(currentByte, 709, 3),

                Rssi_Neg_Amort_Taken_PackedData = UnpackComp3(currentByte, 712, 6),
                Rssi_Grace_Days_PackedData = UnpackComp3(currentByte, 718, 2),

                Rssi_Taxpd_Ytd_PackedData = UnpackComp3(currentByte, 720, 5),
                Rssi_Pd_To_Date = GetPositionData(currentByte, 725, 6),

                Rssi_Cur_Due_Dte = GetPositionData(currentByte, 731, 6),
                Rssi_Prn_Var_PackedData = UnpackComp3(currentByte, 737, 6),

                Rssi_Uncol_Int_PackedData = UnpackComp3(currentByte, 743, 6),
                Rssi_Note_Rate_PackedData = UnpackComp3(currentByte, 749, 4),

                Rssi_Neg_Am_Ass_Ytd_PackedData = UnpackComp3(currentByte, 753, 5),
                Rssi_Neg_Am_Paid_Ytd_PackedData = UnpackComp3(currentByte, 758, 5),

                Rssi_Rate_Ov_PackedData = UnpackComp3(currentByte, 763, 4),
                Rssi_Org_Rate_Ov_PackedData = UnpackComp3(currentByte, 767, 4),

                Rssi_Bill_Number_PackedData = UnpackComp3(currentByte, 771, 9),
                Rssi_Bank_Trans_PackedData = UnpackComp3(currentByte, 780, 5),

                Rssi_Withhold_Ytd_PackedData = UnpackComp3(currentByte, 785, 4),
                Rssi_Neg_Amort_Flag_PackedData = UnpackComp3(currentByte, 789, 1),

                Rssi_Int_Due_PackedData = UnpackComp3(currentByte, 790, 6),
                Rssi_Sec_Mort_Cd_PackedData = UnpackComp3(currentByte, 796, 1),

                Rssi_2Nd_Acct_No_PackedData = UnpackComp3(currentByte, 797, 6),
                Rssi_2Nd_Bill_Amt_PackedData = UnpackComp3(currentByte, 803, 6),

                Rssi_Fees_PackedData = UnpackComp3(currentByte, 809, 4),
                Rssi_Past_Payments = GetPositionData(currentByte, 813, 108),

                Rssi_Past_Date = GetPositionData(currentByte, 813, 6),
                Rssi_Reg_Amt_PackedData = UnpackComp3(currentByte, 819, 6),

                Rssi_Late_Amt_PackedData = UnpackComp3(currentByte, 825, 6),
                Rssi_Billing_Opt = GetPositionData(currentByte, 921, 1),

                Rssi_Alt_Ov_Un_PackedData = GetPositionData(currentByte, 922, 4),
                Rssi_Indx_Dt_PackedData = GetPositionData(currentByte, 926, 4),

                Rssi_Curr_Indx_PackedData = GetPositionData(currentByte, 930, 4),
                Rssi_Mkt_Ov_Un_PackedData = GetPositionData(currentByte, 934, 4),

                Rssi_Int_Pmt_PackedData = GetPositionData(currentByte, 938, 6),
                Rssi_Amort_Pmt_PackedData = GetPositionData(currentByte, 944, 6),

                Rssi_Bill_Method_PackedData = GetPositionData(currentByte, 950, 1),
                Rssi_Ach_Acct_No = GetPositionData(currentByte, 951, 20),

                Rssi_Anl_Indx_Rte_PackedData = GetPositionData(currentByte, 971, 4),
                Rssi_Int_Meth_PackedData = GetPositionData(currentByte, 975, 2),

                Rssi_Cross_Sell_Flag = GetPositionData(currentByte, 977, 1),
                Rssi_Mult_Loan_Flag = GetPositionData(currentByte, 978, 1),

                Rssi_Primary_Social_Fill = GetPositionData(currentByte, 979, 1),
                Rssi_Primary_Social_Sec = GetPositionData(currentByte, 980, 4),

                Rssi_Repy_Plan_Due_Date_PackedData = GetPositionData(currentByte, 984, 6),
                Rssi_Amort_Fee_Pymt_PackedData = GetPositionData(currentByte, 990, 5),

                Rssi_Repay_Amt_Due_PackedData = GetPositionData(currentByte, 995, 4),
                Rssi_Repy_Remain_Bal_PackedData = GetPositionData(currentByte, 999, 6),

                Rssi_Email_Bill_Ind = GetPositionData(currentByte, 1005, 1),
                Rssi_Primary_Email_Adr = GetPositionData(currentByte, 1006, 40),

                Rssi_Primary_Fax_Phone_PackedData = GetPositionData(currentByte, 1046, 6),
                Rssi_Primary_Cell_Ph_PackedData = GetPositionData(currentByte, 1052, 6),

                Rssi_Direct_Mail = GetPositionData(currentByte, 1058, 2),
                Rssi_Telemarket = GetPositionData(currentByte, 1060, 2),

                Rssi_Fees_New_PackedData = GetPositionData(currentByte, 1062, 5),
                Rssi_Serv_Date = GetPositionData(currentByte, 1067, 8),

                Rssi_First_Stmt_Ind = GetPositionData(currentByte, 1075, 1),
                Rssi_Mail_Cd = GetPositionData(currentByte, 1076, 1),

                Rssi_Spec_Stmt_Req = GetPositionData(currentByte, 1077, 1),
                Rssi_Stop_1 = GetPositionData(currentByte, 1078, 1),

                Rssi_Opt_In_Flag = GetPositionData(currentByte, 1079, 1),
                Rssi_Opt_Out_Flag = GetPositionData(currentByte, 1080, 1),

                Rssi_Ml_Scnd_Email_Bill_Ind = GetPositionData(currentByte, 1081, 1),
                Rssi_First_Due_Dt = GetPositionData(currentByte, 1082, 8),

                Rssi_Mort_Ln_Flg = GetPositionData(currentByte, 1090, 1),
                Rssi_Purch_From_Name = GetPositionData(currentByte, 1091, 34),

                Rssi_Uncoll_Nsf_Fees = GetPositionData(currentByte, 1125, 7),
                Rssi_Uncoll_Ext_Fees = GetPositionData(currentByte, 1132, 7),

                Rssi_Prim_Home_Ph = GetPositionData(currentByte, 1139, 11),
                Rssi_V_Tax_Id = GetPositionData(currentByte, 1150, 11),

                Rssi_F_O_Flag_1 = GetPositionData(currentByte, 1161, 1),
                Rssi_F_O_Flag_2 = GetPositionData(currentByte, 1162, 1),

                Rssi_F_O_Flag_3 = GetPositionData(currentByte, 1163, 1),
                Rssi_F_O_Flag_4 = GetPositionData(currentByte, 1164, 1),

                Rssi_F_O_Flag_5 = GetPositionData(currentByte, 1165, 1),
                FillerPart3 = GetPositionData(currentByte, 1166, 5),

                Rssi_Scnd_Social_Sec = GetPositionData(currentByte, 1171, 4),
                Rssi_Origin_Date = GetPositionData(currentByte, 1175, 8),

                Rssi_Int_Start_Dt = GetPositionData(currentByte, 1183, 8),
                Rssi_Term_Clos = GetPositionData(currentByte, 1191, 3),

                Rssi_Couns_Cd = GetPositionData(currentByte, 1194, 5),
                Rssi_Updated_Term = GetPositionData(currentByte, 1199, 3),

                Rssi_Modify_Date = GetPositionData(currentByte, 1202, 8),
                Rssi_Var_Rate = GetPositionData(currentByte, 1210, 1),

                Rssi_Name_Chg_Ind = GetPositionData(currentByte, 1211, 1),
                Rssi_Addr_Chg_Ind = GetPositionData(currentByte, 1212, 1),

                Rssi_Balloon_Date = GetPositionData(currentByte, 1213, 8),
                Rssi_Times_Delq_30 = GetPositionData(currentByte, 1221, 3),

                Rssi_Times_Delq_60 = GetPositionData(currentByte, 1224, 3),
                Rssi_Times_Delq_90 = GetPositionData(currentByte, 1227, 3),

                Rssi_Nsf_Tl_Ctr = GetPositionData(currentByte, 1230, 3),
                Rssi_Dem1_Prim_Birthdt = GetPositionData(currentByte, 1233, 8),

                Rssi_Dem1_Cb_Score_1 = GetPositionData(currentByte, 1241, 15),
                Rssi_Dem1_Cb_Score_2 = GetPositionData(currentByte, 1256, 15),

                Rssi_Dem1_Cb_Score_3 = GetPositionData(currentByte, 1271, 15),
                Rssi_Ext_Latest_Post_Dt = GetPositionData(currentByte, 1286, 8),

                Rssi_Ext_Tot_Act_Ext = GetPositionData(currentByte, 1294, 3),
                Rssi_Pre_Note = GetPositionData(currentByte, 1297, 1),

                Rssi_Prim_Work_Ph = GetPositionData(currentByte, 1298, 11),
                Rssi_Eoyh_Int_Gross = GetPositionData(currentByte, 1309, 11),

                Rssi_Foreclosure_Adv = GetPositionData(currentByte, 1320, 7),
                Rssi_Net_Investment = GetPositionData(currentByte, 1327, 11),

                Rssi_Orig_Dcnt_Amount = GetPositionData(currentByte, 1338, 9),
                Rssi_Tot_Pymts_Lol = GetPositionData(currentByte, 1347, 13),

                Rssi_Monthly_Int_Rate = GetPositionData(currentByte, 1360, 7),
                Rssi_Num_Days_Delq = GetPositionData(currentByte, 1367, 5),

                Rssi_Optn_Maint_Dt = GetPositionData(currentByte, 1372, 8),
                Rssi_Prior_Acnt_Nbr = GetPositionData(currentByte, 1380, 20),

                Rssi_Last_Pymt_Dt = GetPositionData(currentByte, 1400, 8),
                Rssi_Prim_Marital_Stat = GetPositionData(currentByte, 1408, 1),

                Rssi_Cls_Cd = GetPositionData(currentByte, 1409, 1),
                Rssi_Reo_Ind = GetPositionData(currentByte, 1410, 1),

                Rssi_Mat_Date = GetPositionData(currentByte, 1411, 8),

                Rssi_Lien_3_Pymt_Amt = GetPositionData(currentByte, 1419, 11),

                Rssi_L_Flag = GetPositionData(currentByte, 1430, 1),
                Rssi_Stop_Code_2 = GetPositionData(currentByte, 1431, 1),

                Rssi_Stop_Code_3 = GetPositionData(currentByte, 1432, 1),
                Rssi_Fico_Score = GetPositionData(currentByte, 1433, 5),

                Rssi_Nsf_Indicator = GetPositionData(currentByte, 1438, 1),
                Rssi_Empl_Code = GetPositionData(currentByte, 1439, 1),

                Rssi_Audit_Date = GetPositionData(currentByte, 1440, 8),
                Rssi_Prim_Age = GetPositionData(currentByte, 1448, 3),

                Rssi_Scnd_Age = GetPositionData(currentByte, 1451, 3),
                Rssi_Realtr_Bldr = GetPositionData(currentByte, 1454, 5),

                Rssi_Usr_01_PackedData = GetPositionData(currentByte, 1459, 4),
                Rssi_Tot_Fees_Due_PackedData = GetPositionData(currentByte, 1463, 5),

                Rssi_Rd_Status = GetPositionData(currentByte, 1468, 1),
                Rssi_Int_Refi_Code = GetPositionData(currentByte, 1469, 1),

                Rssi_Usr_07 = GetPositionData(currentByte, 1470, 2),
                Rssi_Usr_36 = GetPositionData(currentByte, 1472, 1),

                Rssi_Ln_Ext_Extend_Int_PackedData = GetPositionData(currentByte, 1473, 6),
                Rssi_Stmnt_Freq_Type = GetPositionData(currentByte, 1479, 2),

                Rssi_Stmnt_Chg_Dt = GetPositionData(currentByte, 1481, 8),
                Rssi_Accel_Apds_Part = GetPositionData(currentByte, 1489, 1),

                Rssi_Accel_Prog_Ind = GetPositionData(currentByte, 1490, 2),
                Rssi_Org_Code = GetPositionData(currentByte, 1492, 5),

                Rssi_Nimx_Plss_Entity = GetPositionData(currentByte, 1497, 3),
                Rssi_Rate_Chg_Date = GetPositionData(currentByte, 1500, 8),

                Rssi_Prepay_Pen_Amt_PackedData = GetPositionData(currentByte, 1508, 6),
                Rssi_Prin_Paid_Ytd_PackedData = GetPositionData(currentByte, 1514, 6),

                Rssi_Esc_Paid_Ytd_PackedData = GetPositionData(currentByte, 1520, 6),
                Rssi_Fees_Paid_Ytd_PackedData = GetPositionData(currentByte, 1526, 5),

                Rssi_Late_Chg_Paid_Ytd_PackedData = GetPositionData(currentByte, 1531, 5),
                Rssi_Pmt_Due_Date_1 = GetPositionData(currentByte, 1536, 6),

                Rssi_Pmt_Paid_Date_1 = GetPositionData(currentByte, 1542, 6),
                Rssi_Pmt_Due_Date_2 = GetPositionData(currentByte, 1548, 6),

                Rssi_Pmt_Paid_Date_2 = GetPositionData(currentByte, 1554, 6),
                Rssi_Pmt_Due_Date_3 = GetPositionData(currentByte, 1560, 6),

                Rssi_Pmt_Paid_Date_3 = GetPositionData(currentByte, 1566, 6),
                Rssi_Pmt_Due_Date_4 = GetPositionData(currentByte, 1572, 6),

                Rssi_Pmt_Paid_Date_4 = GetPositionData(currentByte, 1578, 6),
                Rssi_Pmt_Due_Date_5 = GetPositionData(currentByte, 1584, 6),

                Rssi_Pmt_Paid_Date_5 = GetPositionData(currentByte, 1590, 6),
                Rssi_Pmt_Due_Date_6 = GetPositionData(currentByte, 1596, 6),

                Rssi_Pmt_Paid_Date_6 = GetPositionData(currentByte, 1602, 6),
                Rssi_Prin_Pd_Since_Lst_Stmt_PackedData = GetPositionData(currentByte, 1608, 7),

                Rssi_Int_Pd_Since_Lst_Stmt_PackedData = GetPositionData(currentByte, 1615, 7),
                Rssi_Esc_Pd_Since_Lst_Stmt_PackedData = GetPositionData(currentByte, 1622, 7),

                Rssi_Lc_Pd_Since_Lst_Stmt_PackedData = GetPositionData(currentByte, 1629, 6),
                Rssi_Fees_Pd_Since_Lst_Stmt_PackedData = GetPositionData(currentByte, 1635, 7),

                Rssi_Amt_To_Uaf_Since_Lst_Stmt_PackedData = GetPositionData(currentByte, 1642, 6),
                Rssi_Tot_Pd_Since_Lst_Stmt_PackedData = GetPositionData(currentByte, 1648, 8),

                Rssi_Fees_Assd_Since_Lst_Stmt_PackedData = GetPositionData(currentByte, 1656, 6),
                Rssi_Accr_Lc_PackedData = GetPositionData(currentByte, 1662, 6),

                Rssi_Loss_Mit_Ind = GetPositionData(currentByte, 1668, 1),
                Rssi_1St_Contact_Name = GetPositionData(currentByte, 1669, 20),

                Rssi_1St_Contact_Adrs_1 = GetPositionData(currentByte, 1689, 50),
                Rssi_1St_Contact_City = GetPositionData(currentByte, 1739, 20),

                Rssi_1St_Contact_St = GetPositionData(currentByte, 1759, 2),
                Rssi_1St_Contact_Zip = GetPositionData(currentByte, 1761, 10),

                Rssi_1St_Contact_Phone = GetPositionData(currentByte, 1771, 15),
                Rssi_1St_Contact_Ph_Ext = GetPositionData(currentByte, 1786, 5),

                Rssi_Past_Date_R = GetPositionData(currentByte, 1791, 6),
                Rssi_Reg_Amt_R_PackedData = GetPositionData(currentByte, 1797, 6),
                Rssi_Late_Amt_R_PackedData = GetPositionData(currentByte, 1803, 6),

                Rssi_Pmt_Due_Date_7 = GetPositionData(currentByte, 2187, 6),
                Rssi_Pmt_Paid_Date_7 = GetPositionData(currentByte, 2193, 6),

                Rssi_Pmt_Due_Date_8 = GetPositionData(currentByte, 2199, 6),
                Rssi_Pmt_Paid_Date_8 = GetPositionData(currentByte, 2205, 6),

                Rssi_Pmt_Due_Date_9 = GetPositionData(currentByte, 2211, 6),
                Rssi_Pmt_Paid_Date_9 = GetPositionData(currentByte, 2217, 6),

                Rssi_Pmt_Due_Date_10 = GetPositionData(currentByte, 2223, 6),
                Rssi_Pmt_Paid_Date_10 = GetPositionData(currentByte, 2229, 6),

                Rssi_Pmt_Due_Date_11 = GetPositionData(currentByte, 2235, 6),
                Rssi_Pmt_Paid_Date_11 = GetPositionData(currentByte, 2241, 6),

                Rssi_Pmt_Due_Date_12 = GetPositionData(currentByte, 2247, 6),
                Rssi_Pmt_Paid_Date_12 = GetPositionData(currentByte, 2253, 6),

                Rssi_Pmt_Due_Date_13 = GetPositionData(currentByte, 2259, 6),
                Rssi_Pmt_Paid_Date_13 = GetPositionData(currentByte, 2265, 6),

                Rssi_Pmt_Due_Date_14 = GetPositionData(currentByte, 2271, 6),
                Rssi_Pmt_Paid_Date_14 = GetPositionData(currentByte, 2277, 6),

                Rssi_Pmt_Due_Date_15 = GetPositionData(currentByte, 2283, 6),
                Rssi_Pmt_Paid_Date_15 = GetPositionData(currentByte, 2289, 6),

                Rssi_Pmt_Due_Date_16 = GetPositionData(currentByte, 2295, 6),
                Rssi_Pmt_Paid_Date_16 = GetPositionData(currentByte, 2301, 6),

                Rssi_Pmt_Due_Date_17 = GetPositionData(currentByte, 2307, 6),
                Rssi_Pmt_Paid_Date_17 = GetPositionData(currentByte, 2313, 6),

                Rssi_Pmt_Due_Date_18 = GetPositionData(currentByte, 2319, 6),
                Rssi_Pmt_Paid_Date_18 = GetPositionData(currentByte, 2325, 6),

                Rssi_Pmt_Due_Date_19 = GetPositionData(currentByte, 2331, 6),
                Rssi_Pmt_Paid_Date_19 = GetPositionData(currentByte, 2337, 6),

                Rssi_Pmt_Due_Date_20 = GetPositionData(currentByte, 2343, 6),
                Rssi_Pmt_Paid_Date_20 = GetPositionData(currentByte, 2349, 6),

                Rssi_Pmt_Due_Date_21 = GetPositionData(currentByte, 2355, 6),
                Rssi_Pmt_Paid_Date_21 = GetPositionData(currentByte, 2361, 6),

                Rssi_Pmt_Due_Date_22 = GetPositionData(currentByte, 2367, 6),
                Rssi_Pmt_Paid_Date_22 = GetPositionData(currentByte, 2373, 6),


                Rssi_Pmt_Due_Date_23 = GetPositionData(currentByte, 2379, 6),
                Rssi_Pmt_Paid_Date_23 = GetPositionData(currentByte, 2385, 6),

                Rssi_Pmt_Due_Date_24 = GetPositionData(currentByte, 2391, 6),
                Rssi_Pmt_Paid_Date_24 = GetPositionData(currentByte, 2397, 6),

                Rssi_Pmt_Due_Date_25 = GetPositionData(currentByte, 2403, 6),
                Rssi_Pmt_Paid_Date_25 = GetPositionData(currentByte, 2409, 6),

                Rssi_Pmt_Due_Date_26 = GetPositionData(currentByte, 2415, 6),
                Rssi_Pmt_Paid_Date_26 = GetPositionData(currentByte, 2421, 6),

                Rssi_Pmt_Due_Date_27 = GetPositionData(currentByte, 2427, 6),
                Rssi_Pmt_Paid_Date_27 = GetPositionData(currentByte, 2433, 6),

                Rssi_Pmt_Due_Date_28 = GetPositionData(currentByte, 2439, 6),
                Rssi_Pmt_Paid_Date_28 = GetPositionData(currentByte, 2445, 6),

                Rssi_Cash_Tran_Opt_Out = GetPositionData(currentByte, 2451, 1),
                Rssi_Mult_Loan_Ind = GetPositionData(currentByte, 2452, 1),

                Rssi_Last_Ann_Stmt_Dt_PackedData = GetPositionData(currentByte, 2453, 4),
                Rssi_Last_Ann_Stmt_Meth = GetPositionData(currentByte, 2457, 2),

                Rssi_Opt_Out_Type = GetPositionData(currentByte, 2459, 1),
                Rssi_Opt_Out_Date_PackedData = GetPositionData(currentByte, 2460, 4),

                Rssi_Special_Contact_Code = GetPositionData(currentByte, 2464, 5),
                Rssi_Last_Dscl_Notice_Dt_PackedData = GetPositionData(currentByte, 2469, 4),

                Rssi_Last_Dscl_Notice_Meth = GetPositionData(currentByte, 2473, 2),
                Rssi_Prim_Opt_Out_Type = GetPositionData(currentByte, 2475, 1),

                Rssi_Prim_Opt_Out_Date_PackedData = GetPositionData(currentByte, 2476, 4),
                Rssi_Scnd_Opt_Out_Type = GetPositionData(currentByte, 2480, 1),
                Rssi_Scnd_Opt_Out_Date_PackedData = GetPositionData(currentByte, 2481, 4),

                Rssi_Cbwr1_Opt_Out_Type = GetPositionData(currentByte, 2485, 1),
                Rssi_Cbwr1_Opt_Out_Date_PackedData = GetPositionData(currentByte, 2486, 4),

                Rssi_Cbwr2_Opt_Out_Type = GetPositionData(currentByte, 2490, 1),
                Rssi_Cbwr2_Opt_Out_Date_PackedData = GetPositionData(currentByte, 2491, 4),

                Rssi_Cbwr3_Opt_Out_Type = GetPositionData(currentByte, 2495, 1),
                Rssi_Cbwr3_Opt_Out_Date_PackedData = GetPositionData(currentByte, 2496, 4),

                Rssi_Cbwr4_Opt_Out_Type = GetPositionData(currentByte, 2500, 1),
                Rssi_Cbwr4_Opt_Out_Date_PackedData = GetPositionData(currentByte, 2501, 4),

                Rssi_Cbwr5_Opt_Out_Type = GetPositionData(currentByte, 2505, 1),
                Rssi_Cbwr5_Opt_Out_Date_PackedData = GetPositionData(currentByte, 2506, 4),

                Rssi_Cbwr6_Opt_Out_Type = GetPositionData(currentByte, 2510, 1),
                Rssi_Cbwr6_Opt_Out_Date_PackedData = GetPositionData(currentByte, 2511, 4),

                Rssi_Cbwr7_Opt_Out_Type = GetPositionData(currentByte, 2515, 1),
                Rssi_Cbwr7_Opt_Out_Date_PackedData = GetPositionData(currentByte, 2516, 4),

                Rssi_Cbwr8_Opt_Out_Type = GetPositionData(currentByte, 2520, 1),
                Rssi_Cbwr8_Opt_Out_Date_PackedData = GetPositionData(currentByte, 2521, 4),

                Rssi_Cbwr9_Opt_Out_Type = GetPositionData(currentByte, 2525, 1),
                Rssi_Cbwr9_Opt_Out_Date_PackedData = GetPositionData(currentByte, 2526, 4),

                Rssi_Cbwr10_Opt_Out_Type = GetPositionData(currentByte, 2530, 1),
                Rssi_Cbwr10_Opt_Out_Date_PackedData = GetPositionData(currentByte, 2531, 4),

                Rssi_Accelerated_Dt_PackedData = GetPositionData(currentByte, 2535, 4),
                Rssi_Accelerated_Interest_Amt_PackedData = GetPositionData(currentByte, 2539, 6),

                Rssi_Print_Stmt = GetPositionData(currentByte, 2545, 1),
                Rssi_Part_Pymts_Ytd_PackedData = GetPositionData(currentByte, 2546, 5),

                Rssi_Closing_Int_Ytd_PackedData = GetPositionData(currentByte, 2551, 6),
                Rssi_Payoff_Amount = GetPositionData(currentByte, 2557, 6),

                Rssi_Prim_Attention = GetPositionData(currentByte, 2563, 35),
                Rssi_Dsi_Accr_Int = GetPositionData(currentByte, 2598, 6),

                Rssi_Accelerated_Amt_PackedData = GetPositionData(currentByte, 2604, 7),
                Rssi_Reinstatement_Dt_PackedData = GetPositionData(currentByte, 2611, 4),

                Rssi_Reinstatement_Amt_PackedData = GetPositionData(currentByte, 2615, 7),
                Rssi_Task605_Comp_Dt_PackedData = GetPositionData(currentByte, 2622, 4),

                Rssi_Next_Draft_Dt_PackedData = GetPositionData(currentByte, 2626, 4),
                Rssi_Breach_Date_PackedData = GetPositionData(currentByte, 2630, 4),

                Rssi_Chrg_Off_Dt_PackedData = GetPositionData(currentByte, 2634, 4),
                Rssi_Promise_Date_PackedData = GetPositionData(currentByte, 2638, 4),

                Rssi_Promise_Amt_PackedData = GetPositionData(currentByte, 2642, 5),
                Rssi_Promise_Broken_Dt_PackedData = GetPositionData(currentByte, 2647, 4),

                Rssi_Promise_Kept_Date_PackedData = GetPositionData(currentByte, 2651, 4),
                FillerPart4 = GetPositionData(currentByte, 2655, 1356),

            };
        }

        // 2 Master File Data Part 2 Record.One record per loan.
        public void GetMasterFileDataPart_2(byte[] currentByte, ref AccountsModel acc)
        {

            acc.MasterFileDataPart2Model = new MasterFileDataPart2Model()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),

                Rssi_Unap_Bal_2_PackedData = GetPositionData(currentByte, 20, 5),
                Rssi_Unap_Cd_2 = GetPositionData(currentByte, 25, 1),

                Rssi_Unap_Bal_3_PackedData = GetPositionData(currentByte, 26, 5),
                Rssi_Unap_Cd_3 = GetPositionData(currentByte, 31, 1),

                Rssi_Unap_Bal_4_PackedData = GetPositionData(currentByte, 32, 5),
                Rssi_Unap_Cd_4 = GetPositionData(currentByte, 37, 1),

                Rssi_Unap_Bal_5_PackedData = GetPositionData(currentByte, 38, 5),
                Rssi_Unap_Cd_5 = GetPositionData(currentByte, 43, 1),

                Rssi_Unap_Bal_Tot_PackedData = GetPositionData(currentByte, 44, 6),
                Rssi_Tot_Draft_Amt_PackedData = GetPositionData(currentByte, 50, 6),

                Rssi_Rd_Bk_Draft_Amt_PackedData = GetPositionData(currentByte, 56, 6),
                Filler = GetPositionData(currentByte, 62, 26),

                Rssi_Uncoll_Pi_Adv_PackedData = GetPositionData(currentByte, 88, 6),
                Rssi_Orig_Mat_Date = GetPositionData(currentByte, 94, 5),

                Rssi_Delq_Couns = GetPositionData(currentByte, 99, 3),
                Rssi_Bmsg_Code_01 = GetPositionData(currentByte, 102, 6),

                Rssi_Bmsg_Code_02 = GetPositionData(currentByte, 108, 6),
                Rssi_Bmsg_Code_03 = GetPositionData(currentByte, 114, 6),

                Rssi_Bmsg_Code_04 = GetPositionData(currentByte, 120, 6),
                Rssi_Bmsg_Code_05 = GetPositionData(currentByte, 126, 6),

                Rssi_Bmsg_Code_06 = GetPositionData(currentByte, 132, 6),
                Rssi_Bmsg_Code_07 = GetPositionData(currentByte, 138, 6),

                Rssi_Bmsg_Code_08 = GetPositionData(currentByte, 144, 6),
                Rssi_Bmsg_Code_09 = GetPositionData(currentByte, 150, 6),

                Rssi_Bmsg_Code_10 = GetPositionData(currentByte, 156, 6),
                Rssi_Bmsg_Code_11 = GetPositionData(currentByte, 162, 6),

                Rssi_Bmsg_Code_12 = GetPositionData(currentByte, 168, 6),
                Rssi_Bmsg_Code_13 = GetPositionData(currentByte, 174, 6),

                Rssi_Bmsg_Code_14 = GetPositionData(currentByte, 180, 6),
                Rssi_Bmsg_Code_15 = GetPositionData(currentByte, 186, 6),

                Rssi_Bmsg_Code_16 = GetPositionData(currentByte, 192, 6),
                Rssi_Bmsg_Code_17 = GetPositionData(currentByte, 198, 6),

                Rssi_Bmsg_Code_18 = GetPositionData(currentByte, 204, 6),
                Rssi_Bmsg_Code_19 = GetPositionData(currentByte, 210, 6),
                Rssi_Bmsg_Code_20 = GetPositionData(currentByte, 216, 6),

                Rssi_Prim_Forgn_Flag = GetPositionData(currentByte, 222, 1),
                Rssi_Altr_Forgn_Flag = GetPositionData(currentByte, 223, 1),

                Rssi_Appl_Foreign_Flag = GetPositionData(currentByte, 224, 1),
                Rssi_Def_Tot_Bal = GetPositionData(currentByte, 225, 7),

                Rssi_Def_Int_Bal_PackedData = GetPositionData(currentByte, 232, 6),
                Rssi_Def_Late_Chrg_Bal_PackedData = GetPositionData(currentByte, 238, 4),

                Rssi_Def_Escrow_Adv_Bal_PackedData = GetPositionData(currentByte, 242, 6),
                Rssi_Def_Paid_Exp_Adv_Bal_PackedData = GetPositionData(currentByte, 248, 6),

                Rssi_Def_Unpd_Exp_Adv_Bal_PackedData = GetPositionData(currentByte, 254, 6),
                Rssi_Def_Admn_Fees_Bal = GetPositionData(currentByte, 260, 6),

                Rssi_Borr_Lnge = GetPositionData(currentByte, 266, 1),
                Rssi_Uncoll_Esc_Short = GetPositionData(currentByte, 267, 6),

                Rssi_Def_Opt_Ins_Bal_PackedData = GetPositionData(currentByte, 273, 5),
                Rssi_Clo_Agent_Cd = GetPositionData(currentByte, 278, 5),

                FillerPart2 = GetPositionData(currentByte, 283, 13),
                Rssi_Def_Prin_Bal_PackedData = GetPositionData(currentByte, 296, 6),

                Rssi_Comb_Prin_Bal_PackedData = GetPositionData(currentByte, 302, 6),
                Rssi_Pra_Original_Amount_PackedData = GetPositionData(currentByte, 308, 6),

                Rssi_Pra_Remain_Amt_PackedData = GetPositionData(currentByte, 314, 6),
                Rssi_Pra_Taken_Amt_PackedData = GetPositionData(currentByte, 320, 6),

                Rssi_Lmt_Program = GetPositionData(currentByte, 326, 3),
                Rssi_Fcl_Start_Date = GetPositionData(currentByte, 329, 6),

                Rssi_Breach_Ltr_Dt = GetPositionData(currentByte, 335, 6),
                Rssi_Higher_Priced_Flag = GetPositionData(currentByte, 341, 1),

                Rssi_Hpml_Escrow_Reqd_Thru_Dt = GetPositionData(currentByte, 342, 8),
                Filler_350_536 = GetPositionData(currentByte, 350, 187),

                Rssi_Ml_Curr_Occ_Code = GetPositionData(currentByte, 537, 1),
                Filler_538_1500 = GetPositionData(currentByte, 538, 965),

            };
        }

        // U User Field Record. One record per loan if applicable.
        public void GetUserFieldRecord(byte[] currentByte, ref AccountsModel acc)
        {
            acc.UserFieldRecordModel = new UserFieldRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Usr_02_PackedData = GetPositionData(currentByte, 20, 4),
                Rssi_Usr_03 = GetPositionData(currentByte, 24, 1),
                Rssi_Usr_04 = GetPositionData(currentByte, 25, 1),
                Rssi_Usr_05 = GetPositionData(currentByte, 26, 1),
                Rssi_Usr_06 = GetPositionData(currentByte, 27, 1),
                Rssi_Usr_08 = GetPositionData(currentByte, 28, 2),
                Rssi_Usr_09 = GetPositionData(currentByte, 30, 2),
                Rssi_Usr_10 = GetPositionData(currentByte, 32, 2),
                Rssi_Usr_11 = GetPositionData(currentByte, 34, 3),
                Rssi_Usr_12 = GetPositionData(currentByte, 37, 3),
                Rssi_Usr_13 = GetPositionData(currentByte, 40, 3),
                Rssi_Usr_14 = GetPositionData(currentByte, 43, 6),
                Rssi_Usr_15_PackedData = GetPositionData(currentByte, 49, 4),
                Rssi_Usr_16_PackedData = GetPositionData(currentByte, 53, 4),
                Rssi_Usr_17_PackedData = GetPositionData(currentByte, 57, 5),
                Rssi_Usr_18 = GetPositionData(currentByte, 62, 15),
                Rssi_Usr_19 = GetPositionData(currentByte, 77, 5),
                Rssi_Usr_20_PackedData = GetPositionData(currentByte, 82, 2),
                Rssi_Usr_21 = GetPositionData(currentByte, 84, 10),
                Rssi_Usr_22 = GetPositionData(currentByte, 94, 10),
                Rssi_Usr_23 = GetPositionData(currentByte, 104, 6),
                Rssi_Usr_24 = GetPositionData(currentByte, 110, 6),
                Rssi_Usr_25_PackedData = GetPositionData(currentByte, 116, 4),
                Rssi_Usr_26_PackedData = GetPositionData(currentByte, 120, 4),
                Rssi_Usr_27_PackedData = GetPositionData(currentByte, 124, 4),
                Rssi_Usr_28_PackedData = GetPositionData(currentByte, 128, 4),
                Rssi_Usr_29_PackedData = GetPositionData(currentByte, 132, 4),
                Rssi_Usr_30_PackedData = GetPositionData(currentByte, 136, 4),
                Rssi_Usr_31_PackedData = GetPositionData(currentByte, 140, 6),
                Rssi_Usr_32_PackedData = GetPositionData(currentByte, 146, 6),
                Rssi_Usr_33_PackedData = GetPositionData(currentByte, 152, 6),
                Rssi_Usr_34_PackedData = GetPositionData(currentByte, 158, 6),
                Rssi_Usr_35 = GetPositionData(currentByte, 164, 1),
                Rssi_Usr_37 = GetPositionData(currentByte, 165, 1),
                Rssi_Usr_38 = GetPositionData(currentByte, 166, 1),
                Rssi_Usr_39 = GetPositionData(currentByte, 167, 2),
                Rssi_Usr_40 = GetPositionData(currentByte, 169, 2),
                Rssi_Usr_41 = GetPositionData(currentByte, 171, 2),
                Rssi_Usr_42 = GetPositionData(currentByte, 173, 2),
                Rssi_Usr_43 = GetPositionData(currentByte, 175, 3),
                Rssi_Usr_44 = GetPositionData(currentByte, 178, 6),
                Rssi_Usr_45 = GetPositionData(currentByte, 184, 6),
                Rssi_Usr_46 = GetPositionData(currentByte, 190, 15),
                Rssi_Usr_47 = GetPositionData(currentByte, 205, 15),
                Rssi_Usr_48 = GetPositionData(currentByte, 220, 15),
                Rssi_Usr_49 = GetPositionData(currentByte, 235, 15),
                Rssi_Usr_50 = GetPositionData(currentByte, 250, 15),
                Rssi_Usr_51 = GetPositionData(currentByte, 265, 35),
                Rssi_Usr_52 = GetPositionData(currentByte, 300, 35),
                Rssi_Usr_53 = GetPositionData(currentByte, 335, 35),
                Rssi_Usr_54 = GetPositionData(currentByte, 370, 1),
                Rssi_Usr_55 = GetPositionData(currentByte, 371, 1),
                Rssi_Usr_56 = GetPositionData(currentByte, 372, 1),
                Rssi_Usr_57 = GetPositionData(currentByte, 373, 1),
                Rssi_Usr_58 = GetPositionData(currentByte, 374, 1),
                Rssi_Usr_59 = GetPositionData(currentByte, 375, 1),
                Rssi_Usr_60 = GetPositionData(currentByte, 376, 1),
                Rssi_Usr_61 = GetPositionData(currentByte, 377, 1),
                Rssi_Usr_62 = GetPositionData(currentByte, 378, 1),
                Rssi_Usr_63 = GetPositionData(currentByte, 379, 1),
                Rssi_Usr_64 = GetPositionData(currentByte, 380, 1),
                Rssi_Usr_65 = GetPositionData(currentByte, 381, 1),
                Rssi_Usr_66 = GetPositionData(currentByte, 382, 1),
                Rssi_Usr_67 = GetPositionData(currentByte, 383, 1),
                Rssi_Usr_68 = GetPositionData(currentByte, 384, 1),
                Rssi_Usr_69 = GetPositionData(currentByte, 385, 1),
                Rssi_Usr_70 = GetPositionData(currentByte, 386, 1),
                Rssi_Usr_71 = GetPositionData(currentByte, 387, 1),
                Rssi_Usr_72 = GetPositionData(currentByte, 388, 1),
                Rssi_Usr_73 = GetPositionData(currentByte, 389, 1),
                Rssi_Usr_74 = GetPositionData(currentByte, 390, 2),
                Rssi_Usr_75 = GetPositionData(currentByte, 392, 2),
                Rssi_Usr_76 = GetPositionData(currentByte, 394, 2),
                Rssi_Usr_77 = GetPositionData(currentByte, 396, 2),
                Rssi_Usr_78 = GetPositionData(currentByte, 398, 2),
                Rssi_Usr_79 = GetPositionData(currentByte, 400, 2),
                Rssi_Usr_80 = GetPositionData(currentByte, 402, 2),
                Rssi_Usr_81 = GetPositionData(currentByte, 404, 2),
                Rssi_Usr_82 = GetPositionData(currentByte, 406, 2),
                Rssi_Usr_83 = GetPositionData(currentByte, 408, 2),
                Rssi_Usr_84 = GetPositionData(currentByte, 410, 2),
                Rssi_Usr_85 = GetPositionData(currentByte, 412, 2),
                Rssi_Usr_86 = GetPositionData(currentByte, 414, 2),
                Rssi_Usr_87 = GetPositionData(currentByte, 416, 2),
                Rssi_Usr_88 = GetPositionData(currentByte, 418, 2),
                Rssi_Usr_89 = GetPositionData(currentByte, 420, 2),
                Rssi_Usr_90 = GetPositionData(currentByte, 422, 2),
                Rssi_Usr_91 = GetPositionData(currentByte, 424, 2),
                Rssi_Usr_92 = GetPositionData(currentByte, 426, 2),
                Rssi_Usr_93 = GetPositionData(currentByte, 428, 2),
                Rssi_Usr_94 = GetPositionData(currentByte, 430, 6),
                Rssi_Usr_95 = GetPositionData(currentByte, 436, 6),
                Rssi_Usr_96 = GetPositionData(currentByte, 442, 6),
                Rssi_Usr_97 = GetPositionData(currentByte, 448, 6),
                Rssi_Usr_98 = GetPositionData(currentByte, 454, 6),
                Rssi_Usr_99 = GetPositionData(currentByte, 460, 6),
                Rssi_Usr_100 = GetPositionData(currentByte, 466, 6),
                Rssi_Usr_101 = GetPositionData(currentByte, 472, 6),
                Rssi_Usr_102 = GetPositionData(currentByte, 478, 6),
                Rssi_Usr_103 = GetPositionData(currentByte, 484, 6),
                Rssi_Usr_104 = GetPositionData(currentByte, 490, 6),
                Rssi_Usr_105 = GetPositionData(currentByte, 496, 6),
                Rssi_Usr_106 = GetPositionData(currentByte, 502, 6),
                Rssi_Usr_107 = GetPositionData(currentByte, 508, 6),
                Rssi_Usr_108 = GetPositionData(currentByte, 514, 6),
                Rssi_Usr_109 = GetPositionData(currentByte, 520, 6),
                Rssi_Usr_110 = GetPositionData(currentByte, 526, 6),
                Rssi_Usr_111 = GetPositionData(currentByte, 532, 6),
                Rssi_Usr_112 = GetPositionData(currentByte, 538, 6),
                Rssi_Usr_113 = GetPositionData(currentByte, 544, 10),
                Rssi_Usr_114 = GetPositionData(currentByte, 554, 10),
                Rssi_Usr_115 = GetPositionData(currentByte, 564, 10),
                Rssi_Usr_116 = GetPositionData(currentByte, 574, 10),
                Rssi_Usr_117 = GetPositionData(currentByte, 584, 10),
                Rssi_Usr_118 = GetPositionData(currentByte, 594, 10),
                Rssi_Usr_119 = GetPositionData(currentByte, 604, 10),
                Rssi_Usr_120 = GetPositionData(currentByte, 614, 10),
                Rssi_Usr_121 = GetPositionData(currentByte, 624, 10),
                Rssi_Usr_122 = GetPositionData(currentByte, 634, 10),
                Rssi_Usr_123 = GetPositionData(currentByte, 644, 10),
                Rssi_Usr_124 = GetPositionData(currentByte, 654, 10),
                Rssi_Usr_125 = GetPositionData(currentByte, 664, 10),
                Rssi_Usr_126 = GetPositionData(currentByte, 674, 10),
                Rssi_Usr_127 = GetPositionData(currentByte, 684, 10),
                Rssi_Usr_128 = GetPositionData(currentByte, 694, 10),
                Rssi_Usr_129 = GetPositionData(currentByte, 704, 10),
                Rssi_Usr_130 = GetPositionData(currentByte, 714, 10),
                Rssi_Usr_131 = GetPositionData(currentByte, 724, 10),
                Rssi_Usr_132 = GetPositionData(currentByte, 734, 10),
                Rssi_Usr_133 = GetPositionData(currentByte, 744, 15),
                Rssi_Usr_134 = GetPositionData(currentByte, 759, 15),
                Rssi_Usr_135 = GetPositionData(currentByte, 774, 15),
                Rssi_Usr_136 = GetPositionData(currentByte, 789, 15),
                Rssi_Usr_137 = GetPositionData(currentByte, 804, 15),
                Rssi_Usr_138 = GetPositionData(currentByte, 819, 15),
                Rssi_Usr_139 = GetPositionData(currentByte, 834, 15),
                Rssi_Usr_140 = GetPositionData(currentByte, 849, 15),
                Rssi_Usr_141 = GetPositionData(currentByte, 864, 15),
                Rssi_Usr_142 = GetPositionData(currentByte, 879, 15),
                Rssi_Usr_143 = GetPositionData(currentByte, 894, 15),
                Rssi_Usr_144 = GetPositionData(currentByte, 909, 15),
                Rssi_Usr_145 = GetPositionData(currentByte, 924, 15),
                Rssi_Usr_146 = GetPositionData(currentByte, 939, 0),
                Rssi_Usr_147 = GetPositionData(currentByte, 954, 15),
                Rssi_Usr_148 = GetPositionData(currentByte, 969, 15),
                Rssi_Usr_149 = GetPositionData(currentByte, 984, 15),
                Rssi_Usr_150 = GetPositionData(currentByte, 999, 15),
                Rssi_Usr_151 = GetPositionData(currentByte, 1014, 15),
                Rssi_Usr_152 = GetPositionData(currentByte, 1029, 15),
                Rssi_Usr_153 = GetPositionData(currentByte, 1044, 35),
                Rssi_Usr_154 = GetPositionData(currentByte, 1079, 35),
                Rssi_Usr_155 = GetPositionData(currentByte, 1114, 35),
                Rssi_Usr_156 = GetPositionData(currentByte, 1149, 35),
                Rssi_Usr_157 = GetPositionData(currentByte, 1184, 35),
                Rssi_Usr_158 = GetPositionData(currentByte, 1219, 35),
                Rssi_Usr_159 = GetPositionData(currentByte, 1254, 35),
                Rssi_Usr_160 = GetPositionData(currentByte, 1289, 35),
                Rssi_Usr_161 = GetPositionData(currentByte, 1324, 35),
                Rssi_Usr_162 = GetPositionData(currentByte, 1359, 35),
                Rssi_Usr_163 = GetPositionData(currentByte, 1394, 35),
                Rssi_Usr_164 = GetPositionData(currentByte, 1429, 35),
                Rssi_Usr_165 = GetPositionData(currentByte, 1464, 35),
                Rssi_Usr_166 = GetPositionData(currentByte, 1499, 35),
                Rssi_Usr_167 = GetPositionData(currentByte, 1534, 35),
                Rssi_Usr_168 = GetPositionData(currentByte, 1569, 35),
                Rssi_Usr_169 = GetPositionData(currentByte, 1604, 35),
                Rssi_Usr_170 = GetPositionData(currentByte, 1639, 35),
                Rssi_Usr_171 = GetPositionData(currentByte, 1674, 35),
                Rssi_Usr_172 = GetPositionData(currentByte, 1709, 35),
                Rssi_Usr_173 = GetPositionData(currentByte, 1744, 60),
                Rssi_Usr_174 = GetPositionData(currentByte, 1804, 60),
                Rssi_Usr_175 = GetPositionData(currentByte, 1864, 60),
                Rssi_Usr_176 = GetPositionData(currentByte, 1924, 60),
                Rssi_Usr_177 = GetPositionData(currentByte, 1984, 60),
                Rssi_Usr_178 = GetPositionData(currentByte, 2044, 60),
                Rssi_Usr_179 = GetPositionData(currentByte, 2104, 60),
                Rssi_Usr_180 = GetPositionData(currentByte, 2164, 60),
                Rssi_Usr_181 = GetPositionData(currentByte, 2224, 60),
                Rssi_Usr_182 = GetPositionData(currentByte, 2284, 60),
                Rssi_Usr_183 = GetPositionData(currentByte, 2344, 60),
                Rssi_Usr_184 = GetPositionData(currentByte, 2404, 60),
                Rssi_Usr_185 = GetPositionData(currentByte, 2464, 60),
                Rssi_Usr_186 = GetPositionData(currentByte, 2524, 60),
                Rssi_Usr_187 = GetPositionData(currentByte, 2584, 60),
                Rssi_Usr_188 = GetPositionData(currentByte, 2644, 60),
                Rssi_Usr_189 = GetPositionData(currentByte, 2704, 60),
                Rssi_Usr_190 = GetPositionData(currentByte, 2764, 60),
                Rssi_Usr_191 = GetPositionData(currentByte, 2824, 60),
                Rssi_Usr_192 = GetPositionData(currentByte, 2884, 60),
                Rssi_Usr_193 = GetPositionData(currentByte, 2944, 75),
                Rssi_Usr_194 = GetPositionData(currentByte, 3019, 75),
                Rssi_Usr_195 = GetPositionData(currentByte, 3094, 1),
                Rssi_Usr_196 = GetPositionData(currentByte, 3095, 1),
                Rssi_Usr_197 = GetPositionData(currentByte, 3096, 1),
                Rssi_Usr_198 = GetPositionData(currentByte, 3097, 1),
                Rssi_Usr_199 = GetPositionData(currentByte, 3098, 1),
                Rssi_Usr_200 = GetPositionData(currentByte, 3099, 1),
                Rssi_Usr_201 = GetPositionData(currentByte, 3100, 1),
                Rssi_Usr_202 = GetPositionData(currentByte, 3101, 1),
                Rssi_Usr_203 = GetPositionData(currentByte, 3102, 1),
                Rssi_Usr_204 = GetPositionData(currentByte, 3103, 1),
                Rssi_Usr_205 = GetPositionData(currentByte, 3104, 1),
                Rssi_Usr_206 = GetPositionData(currentByte, 3105, 1),
                Rssi_Usr_207 = GetPositionData(currentByte, 3106, 1),
                Rssi_Usr_208 = GetPositionData(currentByte, 3107, 1),
                Rssi_Usr_209 = GetPositionData(currentByte, 3108, 1),
                Rssi_Usr_210 = GetPositionData(currentByte, 3109, 1),
                Rssi_Usr_211 = GetPositionData(currentByte, 3110, 1),
                Rssi_Usr_212 = GetPositionData(currentByte, 3111, 1),
                Rssi_Usr_213 = GetPositionData(currentByte, 3112, 1),
                Rssi_Usr_214 = GetPositionData(currentByte, 3113, 1),
                Rssi_Usr_215_PackedData = GetPositionData(currentByte, 3114, 2),
                Rssi_Usr_216_PackedData = GetPositionData(currentByte, 3116, 2),
                Rssi_Usr_217_PackedData = GetPositionData(currentByte, 3118, 2),
                Rssi_Usr_218_PackedData = GetPositionData(currentByte, 3120, 2),
                Rssi_Usr_219_PackedData = GetPositionData(currentByte, 3122, 2),
                Rssi_Usr_220_PackedData = GetPositionData(currentByte, 3124, 2),
                Rssi_Usr_221_PackedData = GetPositionData(currentByte, 3126, 2),
                Rssi_Usr_222_PackedData = GetPositionData(currentByte, 3128, 2),
                Rssi_Usr_223_PackedData = GetPositionData(currentByte, 3130, 2),
                Rssi_Usr_224_PackedData = GetPositionData(currentByte, 3132, 2),
                Rssi_Usr_225_PackedData = GetPositionData(currentByte, 3134, 2),
                Rssi_Usr_226_PackedData = GetPositionData(currentByte, 3136, 2),
                Rssi_Usr_227_PackedData = GetPositionData(currentByte, 3138, 2),
                Rssi_Usr_228_PackedData = GetPositionData(currentByte, 3140, 2),
                Rssi_Usr_229_PackedData = GetPositionData(currentByte, 3142, 2),
                Rssi_Usr_230_PackedData = GetPositionData(currentByte, 3144, 2),
                Rssi_Usr_231_PackedData = GetPositionData(currentByte, 3146, 2),
                Rssi_Usr_232_PackedData = GetPositionData(currentByte, 3148, 2),
                Rssi_Usr_233_PackedData = GetPositionData(currentByte, 3150, 2),
                Rssi_Usr_234_PackedData = GetPositionData(currentByte, 3152, 2),
                Rssi_Usr_235_PackedData = GetPositionData(currentByte, 3154, 4),
                Rssi_Usr_236_PackedData = GetPositionData(currentByte, 3158, 4),
                Rssi_Usr_237_PackedData = GetPositionData(currentByte, 3162, 4),
                Rssi_Usr_238_PackedData = GetPositionData(currentByte, 3166, 4),
                Rssi_Usr_239_PackedData = GetPositionData(currentByte, 3170, 4),
                Rssi_Usr_240_PackedData = GetPositionData(currentByte, 3174, 4),
                Rssi_Usr_241_PackedData = GetPositionData(currentByte, 3178, 4),
                Rssi_Usr_242_PackedData = GetPositionData(currentByte, 3182, 4),
                Rssi_Usr_243_PackedData = GetPositionData(currentByte, 3186, 4),
                Rssi_Usr_244_PackedData = GetPositionData(currentByte, 3190, 4),
                Rssi_Usr_245_PackedData = GetPositionData(currentByte, 3194, 4),
                Rssi_Usr_246_PackedData = GetPositionData(currentByte, 3198, 4),
                Rssi_Usr_247_PackedData = GetPositionData(currentByte, 3202, 4),
                Rssi_Usr_248_PackedData = GetPositionData(currentByte, 3206, 4),
                Rssi_Usr_249_PackedData = GetPositionData(currentByte, 3210, 4),
                Rssi_Usr_250_PackedData = GetPositionData(currentByte, 3214, 4),
                Rssi_Usr_251_PackedData = GetPositionData(currentByte, 3218, 4),
                Rssi_Usr_252_PackedData = GetPositionData(currentByte, 3222, 4),
                Rssi_Usr_253_PackedData = GetPositionData(currentByte, 3226, 4),
                Rssi_Usr_254_PackedData = GetPositionData(currentByte, 3230, 4),
                Rssi_Usr_255_PackedData = GetPositionData(currentByte, 3234, 6),
                Rssi_Usr_256_PackedData = GetPositionData(currentByte, 3240, 6),
                Rssi_Usr_257_PackedData = GetPositionData(currentByte, 3246, 6),
                Rssi_Usr_258_PackedData = GetPositionData(currentByte, 3252, 6),
                Rssi_Usr_259_PackedData = GetPositionData(currentByte, 3258, 6),
                Rssi_Usr_260_PackedData = GetPositionData(currentByte, 3264, 6),
                Rssi_Usr_261_PackedData = GetPositionData(currentByte, 3270, 6),
                Rssi_Usr_262_PackedData = GetPositionData(currentByte, 3276, 6),
                Rssi_Usr_263_PackedData = GetPositionData(currentByte, 3282, 6),
                Rssi_Usr_264_PackedData = GetPositionData(currentByte, 3288, 6),
                Rssi_Usr_265_PackedData = GetPositionData(currentByte, 3294, 6),
                Rssi_Usr_266_PackedData = GetPositionData(currentByte, 3300, 6),
                Rssi_Usr_267_PackedData = GetPositionData(currentByte, 3306, 6),
                Rssi_Usr_268_PackedData = GetPositionData(currentByte, 3312, 6),
                Rssi_Usr_269_PackedData = GetPositionData(currentByte, 3318, 6),
                Rssi_Usr_270_PackedData = GetPositionData(currentByte, 3324, 6),
                Rssi_Usr_271_PackedData = GetPositionData(currentByte, 3330, 6),
                Rssi_Usr_272_PackedData = GetPositionData(currentByte, 3336, 6),
                Rssi_Usr_273_PackedData = GetPositionData(currentByte, 3342, 6),
                Rssi_Usr_274_PackedData = GetPositionData(currentByte, 3348, 6),
                Rssi_Usr_275_PackedData = GetPositionData(currentByte, 3354, 4),
                Rssi_Usr_276_PackedData = GetPositionData(currentByte, 3358, 4),
                Rssi_Usr_277_PackedData = GetPositionData(currentByte, 3362, 4),
                Rssi_Usr_278_PackedData = GetPositionData(currentByte, 3366, 4),
                Rssi_Usr_279_PackedData = GetPositionData(currentByte, 3370, 4),
                Rssi_Usr_280_PackedData = GetPositionData(currentByte, 3374, 4),
                Rssi_Usr_281_PackedData = GetPositionData(currentByte, 3378, 4),
                Rssi_Usr_282_PackedData = GetPositionData(currentByte, 3382, 4),
                Rssi_Usr_283_PackedData = GetPositionData(currentByte, 3386, 4),
                Rssi_Usr_284_PackedData = GetPositionData(currentByte, 3390, 4),
                Rssi_Usr_285_PackedData = GetPositionData(currentByte, 3394, 4),
                Rssi_Usr_286_PackedData = GetPositionData(currentByte, 3398, 4),
                Rssi_Usr_287_PackedData = GetPositionData(currentByte, 3402, 4),
                Rssi_Usr_288_PackedData = GetPositionData(currentByte, 3406, 4),
                Rssi_Usr_289_PackedData = GetPositionData(currentByte, 3410, 4),
                Rssi_Usr_290_PackedData = GetPositionData(currentByte, 3414, 4),
                Rssi_Usr_291_PackedData = GetPositionData(currentByte, 3418, 4),
                Rssi_Usr_292_PackedData = GetPositionData(currentByte, 3422, 4),
                Rssi_Usr_293_PackedData = GetPositionData(currentByte, 3426, 4),
                Rssi_Usr_294_PackedData = GetPositionData(currentByte, 3430, 4),
                Rssi_Usr_295_PackedData = GetPositionData(currentByte, 3434, 5),
                Rssi_Usr_296_PackedData = GetPositionData(currentByte, 3439, 5),
                Rssi_Usr_297_PackedData = GetPositionData(currentByte, 3444, 5),
                Rssi_Usr_298_PackedData = GetPositionData(currentByte, 3449, 5),
                Rssi_Usr_299_PackedData = GetPositionData(currentByte, 3454, 5),
                Rssi_Usr_300_PackedData = GetPositionData(currentByte, 3459, 5),
                Rssi_Usr_301_PackedData = GetPositionData(currentByte, 3464, 5),
                Rssi_Usr_302_PackedData = GetPositionData(currentByte, 3469, 5),
                Rssi_Usr_303_PackedData = GetPositionData(currentByte, 3474, 5),
                Rssi_Usr_304_PackedData = GetPositionData(currentByte, 3479, 5),
                Rssi_Usr_305_PackedData = GetPositionData(currentByte, 3484, 5),
                Rssi_Usr_306_PackedData = GetPositionData(currentByte, 3489, 5),
                Rssi_Usr_307_PackedData = GetPositionData(currentByte, 3494, 5),
                Rssi_Usr_308_PackedData = GetPositionData(currentByte, 3499, 5),
                Rssi_Usr_309_PackedData = GetPositionData(currentByte, 3504, 5),
                Rssi_Usr_310_PackedData = GetPositionData(currentByte, 3509, 5),
                Rssi_Usr_311_PackedData = GetPositionData(currentByte, 3514, 5),
                Rssi_Usr_312_PackedData = GetPositionData(currentByte, 3519, 5),
                Rssi_Usr_313_PackedData = GetPositionData(currentByte, 3524, 5),
                Rssi_Usr_314_PackedData = GetPositionData(currentByte, 3529, 5),
                Rssi_Usr_315_PackedData = GetPositionData(currentByte, 3534, 6),
                Rssi_Usr_316_PackedData = GetPositionData(currentByte, 3540, 6),
                Rssi_Usr_317_PackedData = GetPositionData(currentByte, 3546, 6),
                Rssi_Usr_318_PackedData = GetPositionData(currentByte, 3552, 6),
                Rssi_Usr_319_PackedData = GetPositionData(currentByte, 3558, 6),
                Rssi_Usr_320_PackedData = GetPositionData(currentByte, 3564, 6),
                Rssi_Usr_321_PackedData = GetPositionData(currentByte, 3570, 6),
                Rssi_Usr_322_PackedData = GetPositionData(currentByte, 3576, 6),
                Rssi_Usr_323_PackedData = GetPositionData(currentByte, 3582, 6),
                Rssi_Usr_324_PackedData = GetPositionData(currentByte, 3588, 6),
                Rssi_Usr_325_PackedData = GetPositionData(currentByte, 3594, 6),
                Rssi_Usr_326_PackedData = GetPositionData(currentByte, 3600, 6),
                Rssi_Usr_327_PackedData = GetPositionData(currentByte, 3606, 6),
                Rssi_Usr_328_PackedData = GetPositionData(currentByte, 3612, 6),
                Rssi_Usr_329_PackedData = GetPositionData(currentByte, 3618, 6),
                Rssi_Usr_330_PackedData = GetPositionData(currentByte, 3624, 6),
                Rssi_Usr_331_PackedData = GetPositionData(currentByte, 3630, 6),
                Rssi_Usr_332_PackedData = GetPositionData(currentByte, 3636, 6),
                Rssi_Usr_333_PackedData = GetPositionData(currentByte, 3642, 6),
                Rssi_Usr_334_PackedData = GetPositionData(currentByte, 3648, 6),
                Rssi_Usr_335_PackedData = GetPositionData(currentByte, 3654, 7),
                Rssi_Usr_336_PackedData = GetPositionData(currentByte, 3661, 7),
                Rssi_Usr_337_PackedData = GetPositionData(currentByte, 3668, 7),
                Rssi_Usr_338_PackedData = GetPositionData(currentByte, 3675, 7),
                Rssi_Usr_339_PackedData = GetPositionData(currentByte, 3682, 7),
                Rssi_Usr_340_PackedData = GetPositionData(currentByte, 3689, 7),
                Rssi_Usr_341_PackedData = GetPositionData(currentByte, 3696, 7),
                Rssi_Usr_342_PackedData = GetPositionData(currentByte, 3703, 7),
                Rssi_Usr_343_PackedData = GetPositionData(currentByte, 3710, 7),
                Rssi_Usr_344_PackedData = GetPositionData(currentByte, 3717, 7),
                Rssi_Usr_345_PackedData = GetPositionData(currentByte, 2724, 7),
                Rssi_Usr_346_PackedData = GetPositionData(currentByte, 3731, 7),
                Rssi_Usr_347_PackedData = GetPositionData(currentByte, 3738, 7),
                Rssi_Usr_348_PackedData = GetPositionData(currentByte, 3745, 7),
                Rssi_Usr_349_PackedData = GetPositionData(currentByte, 3752, 7),
                Rssi_Usr_350_PackedData = GetPositionData(currentByte, 3759, 7),
                Rssi_Usr_351_PackedData = GetPositionData(currentByte, 3766, 7),
                Rssi_Usr_352_PackedData = GetPositionData(currentByte, 3773, 7),
                Rssi_Usr_353_PackedData = GetPositionData(currentByte, 3780, 7),
                Rssi_Usr_354_PackedData = GetPositionData(currentByte, 3787, 4),
                Rssi_Usr_355_PackedData = GetPositionData(currentByte, 3791, 4),
                Rssi_Usr_356_PackedData = GetPositionData(currentByte, 3795, 4),
                Rssi_Usr_357_PackedData = GetPositionData(currentByte, 3799, 4),
                Rssi_Usr_358_PackedData = GetPositionData(currentByte, 3803, 4),
                Rssi_Usr_359_PackedData = GetPositionData(currentByte, 3807, 4),
                Rssi_Usr_360_PackedData = GetPositionData(currentByte, 3811, 4),
                Rssi_Usr_361_PackedData = GetPositionData(currentByte, 3815, 4),
                Rssi_Usr_362_PackedData = GetPositionData(currentByte, 3819, 4),
                Rssi_Usr_363_PackedData = GetPositionData(currentByte, 3823, 4),
                Rssi_Usr_364_PackedData = GetPositionData(currentByte, 3827, 4),
                Rssi_Usr_365_PackedData = GetPositionData(currentByte, 3831, 4),
                Rssi_Usr_366_PackedData = GetPositionData(currentByte, 3835, 4),
                Rssi_Usr_367_PackedData = GetPositionData(currentByte, 3839, 4),
                Rssi_Usr_368_PackedData = GetPositionData(currentByte, 3843, 4),
                Rssi_Usr_369_PackedData = GetPositionData(currentByte, 3847, 4),
                Rssi_Usr_370_PackedData = GetPositionData(currentByte, 3851, 4),
                Rssi_Usr_371_PackedData = GetPositionData(currentByte, 3855, 4),
                Rssi_Usr_372_PackedData = GetPositionData(currentByte, 3859, 4),
                Rssi_Usr_373_PackedData = GetPositionData(currentByte, 3863, 4),
                FillerPart3 = GetPositionData(currentByte, 3867, 144),

            };
        }

        // L Multiple Lockbox Record. One record per loan if applicable.
        public void GetMultiLockboxRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.MultiLockboxRecordModel = new MultiLockboxRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Il_Lkbx_Id_Data = GetPositionData(currentByte, 20, 1),
                Rssi_Il_Lkbx_Addr_1 = GetPositionData(currentByte, 21, 35),
                Rssi_Il_Lkbx_Addr_2 = GetPositionData(currentByte, 56, 35),
                Rssi_Il_Lkbx_City = GetPositionData(currentByte, 91, 20),
                Rssi_Il_Lkbx_State = GetPositionData(currentByte, 111, 2),
                Rssi_Il_Lkbx_Zip = GetPositionData(currentByte, 113, 10),

            };
        }

        // R Rate Reduction Record. One record per loan if applicable.
        public void GetRateReductionRecord(byte[] currentByte, ref AccountsModel acc)
        {
            acc.RateReductionRecordModel = new RateReductionRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Loan_Plan_Nbr = GetPositionData(currentByte, 20, 6),
                Rssi_Loan_Status = GetPositionData(currentByte, 26, 1),
                Rssi_Tot_Red_To_Date = GetPositionData(currentByte, 27, 7),
                Rssi_Tot_Tiers_Comp = GetPositionData(currentByte, 34, 2),
                Rssi_Tier_Status = GetPositionData(currentByte, 36, 1),
                Rssi_Disql_Dt = GetPositionData(currentByte, 37, 8),
                Rssi_Disql_Due_Dt = GetPositionData(currentByte, 45, 8),
                Rssi_Cpltn_Date = GetPositionData(currentByte, 53, 8),
                Rssi_Cpltn_Due_Dt = GetPositionData(currentByte, 61, 8),
                Rssi_Reql_Dt = GetPositionData(currentByte, 69, 8),
                Rssi_Reql_Due_Dt = GetPositionData(currentByte, 77, 8),
                Rssi_Total_Rq = GetPositionData(currentByte, 85, 3),
                Rssi_Ot_Pmts_Ctr = GetPositionData(currentByte, 88, 2),
                Rssi_Rem_Pmts_Ctr = GetPositionData(currentByte, 90, 2),
                Rssi_New_Rate = GetPositionData(currentByte, 92, 7),
                Rssi_New_Pmt = GetPositionData(currentByte, 99, 7),
                Rssi_New_Eff_Dt = GetPositionData(currentByte, 106, 8),
                Rssi_Pmt_Diff = GetPositionData(currentByte, 114, 9),
                Rssi_Reset_Date = GetPositionData(currentByte, 123, 8),
                Rssi_Reset_Due_Dt = GetPositionData(currentByte, 131, 8),
                Rssi_Beg_Due_Dt = GetPositionData(currentByte, 139, 8),
                Rssi_Reduct_Amt = GetPositionData(currentByte, 147, 7),


            };
        }

        // E Escrow Payee Data Record. Multiple records per loan if applicable.
        public void GetEscrowRecordModel(byte[] currentByte, ref AccountsModel acc)
        {

            acc.EscrowRecordModel = new EscrowRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acnt_Rem = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Esc_Type = GetPositionData(currentByte, 20, 2),
                Rssi_Ins_Co = GetPositionData(currentByte, 22, 4),
                Rssi_Ins_Ag = GetPositionData(currentByte, 26, 5),
                Rssi_Payee_Name = GetPositionData(currentByte, 31, 35),
                Rssi_Payee_Phone = GetPositionData(currentByte, 66, 11),
                Rssi_Prod_Name = GetPositionData(currentByte, 77, 35),
                Rssi_Pymt_Due = GetPositionData(currentByte, 112, 11),
                Rssi_Num_Due = GetPositionData(currentByte, 123, 2),
                Rssi_Esc_Expir_Dt = GetPositionData(currentByte, 125, 6),

            };
        }

        // O Optional Items/Escrow Record. Multiple records per loan if applicable.
        public void GetOptionalItemEscrowRecordModel(byte[] currentByte, ref AccountsModel acc)
        {

            acc.OptionalItemEscrowRecordModel = new OptionalItemEscrowRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acnt_Rem = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Oed_Prod_Name = GetPositionData(currentByte, 20, 35),
                Rssi_Oed_Cur_Amt = GetPositionData(currentByte, 55, 11),
                Rssi_Oed_Pend_Amt = GetPositionData(currentByte, 66, 11),
                Rssi_Oed_Pend_Date = GetPositionData(currentByte, 77, 4),
                Rssi_Oed_Prod_Type = GetPositionData(currentByte, 81, 2),
                Rssi_Oed_Tot_Prem_Due = GetPositionData(currentByte, 83, 7),
                Rssi_Oed_Filler = GetPositionData(currentByte, 90, 11),

            };
        }

        // F Fee Record. Multiple records per loan if applicable.
        public void GetFeeRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.FeeRecordModel = new FeeRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acnt_Rem = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Fd_Fee_Type = GetPositionData(currentByte, 20, 3),
                Rssi_Fd_Fee_Desc = GetPositionData(currentByte, 23, 23),
                Rssi_Fd_Fee_Amort_Pymt = GetPositionData(currentByte, 46, 7),
                Rssi_Fd_Prev_Fee_Bal = GetPositionData(currentByte, 53, 7),
                Rssi_Fd_Assess_Amt = GetPositionData(currentByte, 60, 7),
                Rssi_Fd_Assess_Date = GetPositionData(currentByte, 67, 7),
                Rssi_Fd_Coll_Assess = GetPositionData(currentByte, 74, 9),
                Rssi_Fd_Coll_Non_Assess = GetPositionData(currentByte, 83, 7),
                Rssi_Fd_Waived = GetPositionData(currentByte, 90, 7),
                Rssi_Fd_Curr_Fee_Bal = GetPositionData(currentByte, 97, 7),
                Rssi_Fd_Coll_Date = GetPositionData(currentByte, 104, 7),
                Rssi_Fd_Waived_Date = GetPositionData(currentByte, 111, 7),
                Rssi_Fd_Recur_Total_Due = GetPositionData(currentByte, 118, 9),
                Rssi_Fd_Recur_Pmts_Past_Due = GetPositionData(currentByte, 127, 2),
                Rssi_Fd_Filler2 = GetPositionData(currentByte, 129, 4),
                Rssi_Expi_Type = GetPositionData(currentByte, 133, 1),
                Rssi_Expi_Po_No = GetPositionData(currentByte, 134, 12),
                Rssi_Expi_Amt_Billed_PackedData = GetPositionData(currentByte, 146, 4),
                Rssi_Expi_Amt_Paid_PackedData = GetPositionData(currentByte, 150, 4),
                Rssi_Expi_Rec_Or_Nonrec = GetPositionData(currentByte, 154, 1),
                Rssi_Expi_Invoice_Date_PackedData = GetPositionData(currentByte, 155, 4),
                Rssi_Fee2_Inv_Paid_Date_PackedData = GetPositionData(currentByte, 159, 4),
                Rssi_Expi_Vend = GetPositionData(currentByte, 163, 7),
                Rssi_Expi_Vend_Resp_Cd = GetPositionData(currentByte, 170, 2),
                Rssi_Cinv_Exp_Code_PackedData = GetPositionData(currentByte, 172, 2),
                Rssi_Cinv_Inv_No = GetPositionData(currentByte, 174, 15),
                Rssi_Cinv_Area = GetPositionData(currentByte, 189, 5),
                Rssi_Fd_Filler = GetPositionData(currentByte, 194, 207),

            };
        }

        // S Solicitation Record. One record per loan if applicable.
        public void GetSolicitationRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.SolicitationRecordModel = new SolicitationRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Campgn_Id = GetPositionData(currentByte, 20, 5),
                Rssi_Campgncntl = GetPositionData(currentByte, 25, 3),
                Rssi_Campgnmeth = GetPositionData(currentByte, 28, 3),

            };
        }

        // T Transaction Record. Multiple records per loan if applicable.
        public void GetTransactionRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.TransactionRecordModel = new TransactionRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Log_Date_PackedData = GetPositionData(currentByte, 20, 4),
                Rssi_Log_Time = GetPositionData(currentByte, 24, 4),
                Rssi_Tr_Date_PackedData = GetPositionData(currentByte, 28, 4),
                Rssi_Log_Ptrn = GetPositionData(currentByte, 32, 8),
                Rssi_Tr_Fill_01 = GetPositionData(currentByte, 40, 1),
                Rssi_Log_Tran = GetPositionData(currentByte, 41, 4),
                Rssi_Tr_Fill_02 = GetPositionData(currentByte, 45, 1),
                Rssi_Tr_Store_Ovride = GetPositionData(currentByte, 46, 1),
                Rssi_Tr_Fill_03 = GetPositionData(currentByte, 47, 1),
                Rssi_Tr_Amt_PackedData = GetPositionData(currentByte, 48, 8),
                Rssi_Tr_Cash_Amt_PackedData = GetPositionData(currentByte, 56, 8),
                Rssi_Tr_Teller_PackedData = GetPositionData(currentByte, 64, 3),
                Rssi_Tr_Unap_Cd_Before = GetPositionData(currentByte, 67, 5),
                Rssi_Tr_Unap_Cd_After = GetPositionData(currentByte, 72, 5),
                Rssi_Tr_Amt_To_Prin_PackedData = GetPositionData(currentByte, 77, 6),
                Rssi_Tr_Amt_To_Int_PackedData = GetPositionData(currentByte, 83, 6),
                Rssi_Tr_Amt_To_Esc_PackedData = GetPositionData(currentByte, 89, 5),
                Rssi_Tr_Amt_To_Lc_PackedData = GetPositionData(currentByte, 94, 5),
                Rssi_Tr_Amt_To_Pvar_PackedData = GetPositionData(currentByte, 99, 5),
                Rssi_Tr_Amt_To_Ivar_PackedData = GetPositionData(currentByte, 104, 4),
                Rssi_Tr_Amt_To_Evar_PackedData = GetPositionData(currentByte, 109, 5),
                Rssi_Tr_Amt_To_Lvar_PackedData = GetPositionData(currentByte, 114, 5),
                Rssi_Tr_Amt_To_Lip_PackedData = GetPositionData(currentByte, 119, 5),
                Rssi_Tr_Pymt_Ctr_PackedData = GetPositionData(currentByte, 124, 2),
                Rssi_Tr_Amt_To_Cr_Ins_PackedData = GetPositionData(currentByte, 126, 5),
                Rssi_Tr_Prin_Bal_PackedData = GetPositionData(currentByte, 131, 6),
                Rssi_Tr_Esc_Bal_PackedData = GetPositionData(currentByte, 137, 6),
                Rssi_Tr_Pd_To_Date_PackedData = GetPositionData(currentByte, 143, 4),
                Rssi_Tr_Esc_Pymt_PackedData = GetPositionData(currentByte, 147, 5),
                Rssi_Tr_Prn_Var_PackedData = GetPositionData(currentByte, 152, 5),
                Rssi_Tr_Uncoll_Int_PackedData = GetPositionData(currentByte, 157, 6),
                Rssi_Tr_Esc_Var_PackedData = GetPositionData(currentByte, 163, 5),
                Rssi_Tr_Uncoll_Lc_PackedData = GetPositionData(currentByte, 168, 5),
                Rssi_Tr_Dla_PackedData = GetPositionData(currentByte, 173, 4),
                Rssi_Tr_Lip_Bal_PackedData = GetPositionData(currentByte, 177, 5),
                Rssi_Tr_Lip_La_Date_PackedData = GetPositionData(currentByte, 182, 4),
                Rssi_Tr_Pre_Int_Amt_PackedData = GetPositionData(currentByte, 186, 6),
                Rssi_Tr_Pre_Int_Date = GetPositionData(currentByte, 192, 4),
                Rssi_Tr_Amt_To_Fees_PackedData = GetPositionData(currentByte, 196, 6),
                Rssi_Tr_Fee_Code = GetPositionData(currentByte, 202, 3),
                Rssi_Tr_Fee_Desc = GetPositionData(currentByte, 205, 23),
                Rssi_Tr_Amt_Negam_Tak_PackedData = GetPositionData(currentByte, 228, 6),
                Rssi_Tr_Amt_Negam_Pd_PackedData = GetPositionData(currentByte, 234, 6),
                Rssi_Tr_Esc_Pay_Id = GetPositionData(currentByte, 240, 2),
                Rssi_Tr_Amort_Fee_Pymt = GetPositionData(currentByte, 242, 7),
                Rssi_Tr_Amt_To_Evar_2 = GetPositionData(currentByte, 249, 9),
                Rssi_Tr_Amt_To_Evar_3 = GetPositionData(currentByte, 258, 9),
                Rssi_Tr_Amt_To_Evar_04 = GetPositionData(currentByte, 267, 9),
                Rssi_Tr_Amt_To_Evar_05 = GetPositionData(currentByte, 276, 9),
                Rssi_Tr_Exp_Fee_Code = GetPositionData(currentByte, 285, 3),
                Rssi_Tr_Exp_Fee_Desc = GetPositionData(currentByte, 288, 30),
                Rssi_Tr_Exp_Fee_Amt_PackedData = GetPositionData(currentByte, 318, 6),
                Rssi_Tr_Amt_To_Pi_Shrtg = GetPositionData(currentByte, 324, 9),
                Rssi_Tr_Amt_To_Esc_Short = GetPositionData(currentByte, 333, 9),
                Rssi_Tr_Amt_To_Acrd_Inctv = GetPositionData(currentByte, 342, 7),
                Rssi_Tr_Amt_To_Pra_Remain = GetPositionData(currentByte, 349, 11),
                Rssi_Tr_Amt_To_Def_Prin_PackedData = GetPositionData(currentByte, 360, 6),
                Rssi_Tr_Def_Prin_Bal_After_PackedData = GetPositionData(currentByte, 366, 6),
                Rssi_Tr_Amt_To_Def_Int_PackedData = GetPositionData(currentByte, 372, 6),
                Rssi_Tr_Def_Int_Bal_Aft_PackedData = GetPositionData(currentByte, 378, 6),
                Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData = GetPositionData(currentByte, 384, 5),
                Rssi_Tr_Def_Lt_Chg_Bal_Aft_PackedData = GetPositionData(currentByte, 389, 6),
                Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData = GetPositionData(currentByte, 395, 5),
                Rssi_Tr_Def_Esc_Adv_Bal_Aft_PackedData = GetPositionData(currentByte, 400, 6),
                Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData = GetPositionData(currentByte, 406, 6),
                Rssi_Tr_Def_Pd_Exp_Adv_Bal_Aft_PackedData = GetPositionData(currentByte, 412, 6),
                Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData = GetPositionData(currentByte, 418, 6),
                Rssi_Tr_Def_Unpexp_Bal_Aft_PackedData = GetPositionData(currentByte, 424, 6),
                Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData = GetPositionData(currentByte, 430, 6),
                Rssi_Tr_Def_Admin_Fees_Bal_Aft_PackedData = GetPositionData(currentByte, 436, 6),
                Rssi_Tr_Amt_To_Def_Optins_PackedData = GetPositionData(currentByte, 442, 5),
                Rssi_Tr_Def_Optins_Bal_Aft_PackedData = GetPositionData(currentByte, 447, 6),
                Rssi_Tr_Amt_To_Esc_Nt_PackedData = GetPositionData(currentByte, 453, 6),
                Filler_459_1500 = GetPositionData(currentByte, 459, 1042),

            };
        }

        // C Foreign Information Record. One record per loan if applicable.
        public void GetForeignInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.ForeignInformationRecordModel = new ForeignInformationRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Prim_Id_Number = GetPositionData(currentByte, 20, 15),
                Rssi_Primary_Borr_Prefix = GetPositionData(currentByte, 35, 6),
                Rssi_Primary_Borr_Suffix = GetPositionData(currentByte, 41, 6),
                Rssi_Attention = GetPositionData(currentByte, 47, 35),
                Rssi_Prim_Mail_Country = GetPositionData(currentByte, 82, 35),
                Rssi_Prim_Zip_Code = GetPositionData(currentByte, 117, 10),
                Rssi_Prim_Home_Ph_Co = GetPositionData(currentByte, 127, 3),
                Rssi_Prim_Home_Ph1 = GetPositionData(currentByte, 130, 15),
                Rssi_Prim_Work_Ph_Co = GetPositionData(currentByte, 145, 3),
                Rssi_Prim_Work_Ph1 = GetPositionData(currentByte, 148, 15),
                Rssi_Prim_Fax_Ph_Co = GetPositionData(currentByte, 163, 3),
                Rssi_Prim_Fax_Phone = GetPositionData(currentByte, 166, 15),
                Rssi_Prim_Cell_Ph_Co = GetPositionData(currentByte, 181, 3),
                Rssi_Prim_Cell_Ph = GetPositionData(currentByte, 184, 15),
                Rssi_Appl_Country = GetPositionData(currentByte, 199, 35),
                Rssi_Appl_Zip_Cd = GetPositionData(currentByte, 234, 10),
                Rssi_Altr_Cntry = GetPositionData(currentByte, 244, 35),
                Rssi_Altr_Zip_Cd = GetPositionData(currentByte, 279, 10),
                Filler_289_500 = GetPositionData(currentByte, 289, 212),

            };
        }

        // D Blended Rate Information Record. One record per loan if applicable.
        public void GetBlendedRateInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.BlendedRateInformationRecordModel = new BlendedRateInformationRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_C_Alt_Type_Id = GetPositionData(currentByte, 20, 1),
                Rssi_Ml_Alt_Typ_Id_PackedData = GetPositionData(currentByte, 21, 1),
                Rssi_Alt_Chg_Amt1_PackedData = GetPositionData(currentByte, 22, 6),
                Rssi_Alt_Chg_Amt2_PackedData = GetPositionData(currentByte, 28, 6),
                Rssi_Alt_Chg_Amt3_PackedData = GetPositionData(currentByte, 34, 6),
                Rssi_Alt_Chg_Amt4_PackedData = GetPositionData(currentByte, 40, 6),
                Rssi_Alt_Pymt1_PackedData = GetPositionData(currentByte, 46, 6),
                Rssi_Alt_Pymt2_PackedData = GetPositionData(currentByte, 52, 6),
                Rssi_Alt_Pymt3_PackedData = GetPositionData(currentByte, 58, 6),
                Rssi_Alt_Pymt4_PackedData = GetPositionData(currentByte, 64, 6),
                Rssi_Alt_B_A_Rt_PackedData = GetPositionData(currentByte, 70, 4),
                Rssi_Alt_B_F_Rate_PackedData = GetPositionData(currentByte, 74, 4),
                Rssi_Alt_Ar_Rate_PackedData = GetPositionData(currentByte, 78, 4),
                Rssi_Alt_Fr_Rate = GetPositionData(currentByte, 82, 4),
                Rssi_Alt_B_Rate_Flag_PackedData = GetPositionData(currentByte, 86, 1),
                Rssi_Alt_B_Rt_Mgn_PackedData = GetPositionData(currentByte, 87, 4),
                Rssi_Alt_B_Rt_Term_PackedData = GetPositionData(currentByte, 91, 2),
                Rssi_Alt_Adj_Pct_PackedData = GetPositionData(currentByte, 93, 4),
                Rssi_Alt_Fix_Pct = GetPositionData(currentByte, 97, 4),
                Rssi_Alt_B_Opt_Flag = GetPositionData(currentByte, 101, 1),
                Rssi_Alt_B_Opt_Curr_Fix = GetPositionData(currentByte, 102, 11),
                Rssi_Alt_B_Curr_Adj = GetPositionData(currentByte, 113, 11),
                FILLER_124_400 = GetPositionData(currentByte, 124, 277),
            };
        }


        //  I Co-borrower Record. One record per loan if applicable.
        public void GetCoBorrowerRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.CoBorrowerRecordModel = new CoBorrowerRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Cb_Cbwr1_F = GetPositionData(currentByte, 20, 35),
                Rssi_Cb_Cbwr1_Adrs1 = GetPositionData(currentByte, 55, 35),
                Rssi_Cb_Cbwr1_Adrs2 = GetPositionData(currentByte, 90, 35),
                Rssi_Cb_Cbwr1_City = GetPositionData(currentByte, 125, 21),
                Rssi_Cb_Cbwr1_State = GetPositionData(currentByte, 146, 2),
                Rssi_Cb_Cbwr1_Zip = GetPositionData(currentByte, 148, 10),
                Rssi_Cb_Cbwr1_Bill_Stmnt = GetPositionData(currentByte, 158, 1),
                Rssi_Cb_Cbwr2_F = GetPositionData(currentByte, 159, 35),
                Rssi_Cb_Cbwr2_Adrs1 = GetPositionData(currentByte, 194, 35),
                Rssi_Cb_Cbwr2_Adrs2 = GetPositionData(currentByte, 229, 35),
                Rssi_Cb_Cbwr2_City = GetPositionData(currentByte, 264, 21),
                Rssi_Cb_Cbwr2_State = GetPositionData(currentByte, 285, 2),
                Rssi_Cb_Cbwr2_Zip = GetPositionData(currentByte, 287, 10),
                Rssi_Cb_Cbwr2_Bill_Stmnt = GetPositionData(currentByte, 297, 1),
                Rssi_Cb_Cbwr3_F = GetPositionData(currentByte, 298, 35),
                Rssi_Cb_Cbwr3_Adrs1 = GetPositionData(currentByte, 333, 35),
                Rssi_Cb_Cbwr3_Adrs2 = GetPositionData(currentByte, 368, 35),
                Rssi_Cb_Cbwr3_City = GetPositionData(currentByte, 403, 21),
                Rssi_Cb_Cbwr3_State = GetPositionData(currentByte, 424, 2),
                Rssi_Cb_Cbwr3_Zip = GetPositionData(currentByte, 426, 10),
                Rssi_Cb_Cbwr3_Bill_Stmnt = GetPositionData(currentByte, 436, 1),
                Rssi_Cb_Cbwr4_F = GetPositionData(currentByte, 437, 35),
                Rssi_Cb_Cbwr4_Adrs1 = GetPositionData(currentByte, 472, 35),
                Rssi_Cb_Cbwr4_Adrs2 = GetPositionData(currentByte, 507, 35),
                Rssi_Cb_Cbwr4_City = GetPositionData(currentByte, 542, 21),
                Rssi_Cb_Cbwr4_State = GetPositionData(currentByte, 563, 2),
                Rssi_Cb_Cbwr4_Zip = GetPositionData(currentByte, 565, 10),
                Rssi_Cb_Cbwr4_Bill_Stmnt = GetPositionData(currentByte, 575, 1),
                Rssi_Cb_Cbwr5_F = GetPositionData(currentByte, 576, 35),
                Rssi_Cb_Cbwr5_Adrs1 = GetPositionData(currentByte, 611, 35),
                Rssi_Cb_Cbwr5_Adrs2 = GetPositionData(currentByte, 646, 35),
                Rssi_Cb_Cbwr5_City = GetPositionData(currentByte, 681, 21),
                Rssi_Cb_Cbwr5_State = GetPositionData(currentByte, 702, 2),
                Rssi_Cb_Cbwr5_Zip = GetPositionData(currentByte, 704, 10),
                Rssi_Cb_Cbwr5_Bill_Stmnt = GetPositionData(currentByte, 714, 1),
                Rssi_Cb_Cbwr6_F = GetPositionData(currentByte, 715, 35),
                Rssi_Cb_Cbwr6_Adrs1 = GetPositionData(currentByte, 750, 35),
                Rssi_Cb_Cbwr6_Adrs2 = GetPositionData(currentByte, 785, -65),
                Rssi_Cb_Cbwr6_City = GetPositionData(currentByte, 820, 21),
                Rssi_Cb_Cbwr6_State = GetPositionData(currentByte, 841, 2),
                Rssi_Cb_Cbwr6_Zip = GetPositionData(currentByte, 843, 10),
                Rssi_Cb_Cbwr6_Bill_Stmnt = GetPositionData(currentByte, 853, 1),
                Rssi_Cb_Cbwr7_F = GetPositionData(currentByte, 854, 35),
                Rssi_Cb_Cbwr7_Adrs1 = GetPositionData(currentByte, 889, 35),
                Rssi_Cb_Cbwr7_Adrs2 = GetPositionData(currentByte, 924, 35),
                Rssi_Cb_Cbwr7_City = GetPositionData(currentByte, 959, 21),
                Rssi_Cb_Cbwr7_State = GetPositionData(currentByte, 980, 2),
                Rssi_Cb_Cbwr7_Zip = GetPositionData(currentByte, 982, 10),
                Rssi_Cb_Cbwr7_Bill_Stmnt = GetPositionData(currentByte, 992, 1),
                Rssi_Cb_Cbwr8_F = GetPositionData(currentByte, 993, 35),
                Rssi_Cb_Cbwr8_Adrs1 = GetPositionData(currentByte, 1028, 35),
                Rssi_Cb_Cbwr8_Adrs2 = GetPositionData(currentByte, 1063, 35),
                Rssi_Cb_Cbwr8_City = GetPositionData(currentByte, 1098, 21),
                Rssi_Cb_Cbwr8_State = GetPositionData(currentByte, 1119, 2),
                Rssi_Cb_Cbwr8_Zip = GetPositionData(currentByte, 1121, 10),
                Rssi_Cb_Cbwr8_Bill_Stmnt = GetPositionData(currentByte, 1131, 1),
                Rssi_Cb_Cbwr9_F = GetPositionData(currentByte, 1132, 35),
                Rssi_Cb_Cbwr9_Adrs1 = GetPositionData(currentByte, 1167, 35),
                Rssi_Cb_Cbwr9_Adrs2 = GetPositionData(currentByte, 1202, 35),
                Rssi_Cb_Cbwr9_City = GetPositionData(currentByte, 1237, 21),
                Rssi_Cb_Cbwr9_State = GetPositionData(currentByte, 1258, 2),
                Rssi_Cb_Cbwr9_Zip = GetPositionData(currentByte, 1260, 10),
                Rssi_Cb_Cbwr9_Bill_Stmnt = GetPositionData(currentByte, 1270, 1),
                Rssi_Cb_Cbwr10_F = GetPositionData(currentByte, 1271, 35),
                Rssi_Cb_Cbwr10_Adrs1 = GetPositionData(currentByte, 1306, 35),
                Rssi_Cb_Cbwr10_Adrs2 = GetPositionData(currentByte, 1341, 35),
                Rssi_Cb_Cbwr10_City = GetPositionData(currentByte, 1376, 21),
                Rssi_Cb_Cbwr10_State = GetPositionData(currentByte, 1397, 2),
                Rssi_Cb_Cbwr10_Zip = GetPositionData(currentByte, 1399, 10),
                Rssi_Cb_Cbwr10_Bill_Stmnt = GetPositionData(currentByte, 1409, 1),
                Rssi_Cb_Cbwr1_Corr_Flag = GetPositionData(currentByte, 1410, 1),
                Rssi_Cb_Cbwr2_Corr_Flag = GetPositionData(currentByte, 1411, 1),
                Rssi_Cb_Cbwr3_Corr_Flag = GetPositionData(currentByte, 1412, 1),
                Rssi_Cb_Cbwr4_Corr_Flag = GetPositionData(currentByte, 1413, 1),
                Rssi_Cb_Cbwr5_Corr_Flag = GetPositionData(currentByte, 1414, 1),
                Rssi_Cb_Cbwr6_Corr_Flag = GetPositionData(currentByte, 1415, 1),
                Rssi_Cb_Cbwr7_Corr_Flag = GetPositionData(currentByte, 1416, 1),
                Rssi_Cb_Cbwr8_Corr_Flag = GetPositionData(currentByte, 1417, 1),
                Rssi_Cb_Cbwr9_Corr_Flag = GetPositionData(currentByte, 1418, 1),
                Rssi_Cb_Cbwr10_Corr_Flag = GetPositionData(currentByte, 1419, 1),
                Rssi_Cb_Cbwr1_Typ = GetPositionData(currentByte, 1420, 1),
                Rssi_Csii_Cbwr1_Verified = GetPositionData(currentByte, 1421, 1),
                Rssi_Cb_Cbwr2_Typ = GetPositionData(currentByte, 1422, 1),
                Rssi_Csii_Cbwr2_Verified = GetPositionData(currentByte, 1423, 1),
                Rssi_Cb_Cbwr3_Typ = GetPositionData(currentByte, 1424, 1),
                Rssi_Csii_Cbwr3_Verified = GetPositionData(currentByte, 1425, 1),
                Rssi_Cb_Cbwr4_Typ = GetPositionData(currentByte, 1426, 1),
                Rssi_Csii_Cbwr4_Verified = GetPositionData(currentByte, 1427, 1),
                Rssi_Cb_Cbwr5_Typ = GetPositionData(currentByte, 1428, 1),
                Rssi_Csii_Cbwr5_Verified = GetPositionData(currentByte, 1429, 1),
                Rssi_Cb_Cbwr6_Typ = GetPositionData(currentByte, 1430, 1),
                Rssi_Csii_Cbwr6_Verified = GetPositionData(currentByte, 1431, 1),
                Rssi_Cb_Cbwr7_Typ = GetPositionData(currentByte, 1432, 1),
                Rssi_Csii_Cbwr7_Verified = GetPositionData(currentByte, 1433, 1),
                Rssi_Cb_Cbwr8_Typ = GetPositionData(currentByte, 1434, 1),
                Rssi_Csii_Cbwr8_Verified = GetPositionData(currentByte, 1435, 1),
                Rssi_Cb_Cbwr9_Typ = GetPositionData(currentByte, 1436, 1),
                Rssi_Csii_Cbwr9_Verified = GetPositionData(currentByte, 1437, 1),
                Rssi_Cb_Cbwr10_Typ = GetPositionData(currentByte, 1438, 1),
                Rssi_Csii_Cbwr10_Verified = GetPositionData(currentByte, 1439, 1),
                Rssi_Cb_Cbwr_Email_Bill_Ind_1 = GetPositionData(currentByte, 1440, 1),
                Rssi_Cb_Cbwr_Email_Bill_Ind_2 = GetPositionData(currentByte, 1441, 1),
                Rssi_Cb_Cbwr_Email_Bill_Ind_3 = GetPositionData(currentByte, 1442, 1),
                Rssi_Cb_Cbwr_Email_Bill_Ind_4 = GetPositionData(currentByte, 1443, 1),
                Rssi_Cb_Cbwr_Email_Bill_Ind_5 = GetPositionData(currentByte, 1444, 1),
                Rssi_Cb_Cbwr_Email_Bill_Ind_6 = GetPositionData(currentByte, 1445, 1),
                Rssi_Cb_Cbwr_Email_Bill_Ind_7 = GetPositionData(currentByte, 1446, 1),
                Rssi_Cb_Cbwr_Email_Bill_Ind_8 = GetPositionData(currentByte, 1447, 1),
                Rssi_Cb_Cbwr_Email_Bill_Ind_9 = GetPositionData(currentByte, 1448, 1),
                Rssi_Cb_Cbwr_Email_Bill_Ind_10 = GetPositionData(currentByte, 1449, 1),
                Filler = GetPositionData(currentByte, 1450, 2561),

            };
        }

        // < Late Charge Information Record. One record per loan if applicable.
        public void GetLateChargeInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.LateChargeInformationRecordModel = new LateChargeInformationRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Lci_Pymt_Due_Dt_PackedData = GetPositionData(currentByte, 20, 4),
                Rssi_Lci_Code = GetPositionData(currentByte, 24, 1),
                Rssi_Lci_Ind = GetPositionData(currentByte, 25, 1),
                Rssi_Lci_Ptd_PackedData = GetPositionData(currentByte, 26, 4),
                Rssi_Lci_Coll_Meth = GetPositionData(currentByte, 30, 1),
                Rssi_Lci_Factor_PackedData = GetPositionData(currentByte, 31, 3),
                Rssi_Lci_Assess_Meth = GetPositionData(currentByte, 34, 1),
                Rssi_Lci_Max_PackedData = GetPositionData(currentByte, 35, 4),
                Rssi_Lci_Min_PackedData = GetPositionData(currentByte, 39, 4),
                Rssi_Lci_Max_Annual_PackedData = GetPositionData(currentByte, 43, 5),
                Rssi_Lci_Max_Life_PackedData = GetPositionData(currentByte, 48, 5),
                Rssi_Lci_Counter_PackedData = GetPositionData(currentByte, 53, 2),
                Rssi_Lci_Freeze_To_Dt_PackedData = GetPositionData(currentByte, 55, 4),
                Rssi_Lci_Freeze_From_Dt_PackedData = GetPositionData(currentByte, 59, 4),
                Rssi_Lci_Freeze_Dt_Type = GetPositionData(currentByte, 63, 1),
                Rssi_Lci_Year_Type_PackedData = GetPositionData(currentByte, 64, 2),
                Rssi_Lci_Assesed_Lfe_To_Dt_PackedData = GetPositionData(currentByte, 66, 5),
                Rssi_Lci_Assessed_Ytd_PackedData = GetPositionData(currentByte, 71, 5),
                Filler = GetPositionData(currentByte, 76, 130),

            };
        }

        // - Late Charge Detail Record.One record per loan if applicable.
        public void GetLateChargeDetailRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.LateChargeDetailRecordModel = new LateChargeDetailRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Lcd_Pymt_Due_Dt_PackedData = GetPositionData(currentByte, 20, 4),
                Rssi_Lcd_Due_Dt_PackedData = GetPositionData(currentByte, 24, 4),
                Rssi_Lcd_Calc_Dt_PackedData = GetPositionData(currentByte, 28, 4),
                Rssi_Lcd_Amt_For_Lc_Due_Dt_PackedData = GetPositionData(currentByte, 32, 5),
                Rssi_Lcd_Pd_Dt_PackedData = GetPositionData(currentByte, 37, 4),
                Rssi_Lcd_Factor_PackedData = GetPositionData(currentByte, 41, 3),
                Rssi_Lcd_Calc_Meth = GetPositionData(currentByte, 44, 1),
                Rssi_Lcd_Waiver_Dt_PackedData = GetPositionData(currentByte, 45, 4),
                Rssi_Lcd_Waiver_Cd = GetPositionData(currentByte, 49, 1),
                Rssi_Lcd_Rev_Dt_PackedData = GetPositionData(currentByte, 50, 4),
                Rssi_Lcd_Paid_Amt = GetPositionData(currentByte, 54, 5),
                Rssi_Lcd_Waive_Amt = GetPositionData(currentByte, 59, 5),
                Rssi_Lcd_Rev_Amt = GetPositionData(currentByte, 64, 5),
                Rssi_Lcd_Lc_Adj_Dt_PackedData = GetPositionData(currentByte, 69, 4),
                Rssi_Lcd_Lc_Adj_Amt_PackedData = GetPositionData(currentByte, 73, 5),
                Rssi_Lcd_Rem_Bal_PackedData = GetPositionData(currentByte, 78, 5),
                Filler = GetPositionData(currentByte, 83, 123),

            };
        }

        // J Active Bankruptcy Information Record. One record per loan if applicable.
        public void GetActiveBankruptcyInformationRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.ActiveBankruptcyInformationRecordModel = new ActiveBankruptcyInformationRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_B_Type = GetPositionData(currentByte, 20, 1),
                Rssi_B_Chap = GetPositionData(currentByte, 21, 2),
                Rssi_B_Case_No = GetPositionData(currentByte, 23, 12),
                Rssi_B_Filed_By = GetPositionData(currentByte, 35, 1),
                Rssi_B_Debtor = GetPositionData(currentByte, 36, 35),
                Rssi_B_Co_Debtor = GetPositionData(currentByte, 71, 35),
                Rssi_B_Filed_Cbwr1_Id = GetPositionData(currentByte, 106, 1),
                Rssi_B_Filed_Cbwr2_Id = GetPositionData(currentByte, 107, 1),
                Rssi_B_Filed_Cbwr3_Id = GetPositionData(currentByte, 108, 1),
                Rssi_B_Filed_Cbwr4_Id = GetPositionData(currentByte, 109, 1),
                Rssi_B_Filed_Cbwr5_Id = GetPositionData(currentByte, 110, 1),
                Rssi_B_Filed_Cbwr6_Id = GetPositionData(currentByte, 111, 1),
                Rssi_B_Filed_Cbwr7_Id = GetPositionData(currentByte, 112, 1),
                Rssi_B_Filed_Cbwr8_Id = GetPositionData(currentByte, 113, 1),
                Rssi_B_Filed_Cbwr9_Id = GetPositionData(currentByte, 114, 1),
                Rssi_B_Filed_Cbwr10_Id = GetPositionData(currentByte, 115, 1),
                Rssi_B_Filed_Dt_PackedData = GetPositionData(currentByte, 116, 4),
                Rssi_B_Conv_1_Date_PackedData = GetPositionData(currentByte, 120, 4),
                Rssi_B_Reaffirm_Dt_PackedData = GetPositionData(currentByte, 124, 4),
                Rssi_B_Dschg_Dt_PackedData = GetPositionData(currentByte, 128, 4),
                Rssi_B_Dsmsd_Dt_PackedData = GetPositionData(currentByte, 132, 4),
                Rssi_B_Relief_1_Dt_PackedData = GetPositionData(currentByte, 136, 4),
                Rssi_B_C_Type = GetPositionData(currentByte, 140, 1),
                Rssi_B_C_Chap = GetPositionData(currentByte, 141, 2),
                Rssi_B_C_Case_No = GetPositionData(currentByte, 143, 12),
                Rssi_B_C_Filed_By = GetPositionData(currentByte, 155, 1),
                Rssi_B_C_Debtor = GetPositionData(currentByte, 156, 25),
                Rssi_B_C_Co_Debtor = GetPositionData(currentByte, 181, 25),
                Rssi_B_C_Filed_Cbwr1_Id = GetPositionData(currentByte, 206, 1),
                Rssi_B_C_Filed_Cbwr2_Id = GetPositionData(currentByte, 207, 1),
                Rssi_B_C_Filed_Cbwr3_Id = GetPositionData(currentByte, 208, 1),
                Rssi_B_C_Filed_Cbwr4_Id = GetPositionData(currentByte, 209, 1),
                Rssi_B_C_Filed_Cbwr5_Id = GetPositionData(currentByte, 210, 1),
                Rssi_B_C_Filed_Cbwr6_Id = GetPositionData(currentByte, 211, 1),
                Rssi_B_C_Filed_Cbwr7_Id = GetPositionData(currentByte, 212, 1),
                Rssi_B_C_Filed_Cbwr8_Id = GetPositionData(currentByte, 213, 1),
                Rssi_B_C_Filed_Cbwr9_Id = GetPositionData(currentByte, 214, 1),
                Rssi_B_C_Filed_Cbwr10_Id = GetPositionData(currentByte, 215, 1),
                Rssi_B_C_Filed_Dt_PackedData = GetPositionData(currentByte, 216, 4),
                Rssi_B_C_Conv_1_Date_PackedData = GetPositionData(currentByte, 220, 4),
                Rssi_B_C_Reaffirm_Dt_PackedData = GetPositionData(currentByte, 224, 4),
                Rssi_B_C_Dschg_Dt_PackedData = GetPositionData(currentByte, 228, 4),
                Rssi_B_C_Dsmsd_Dt_PackedData = GetPositionData(currentByte, 232, 4),
                Rssi_B_C_Relf_Dt_PackedData = GetPositionData(currentByte, 236, 4),
                Rssi_Poc_Post_Amt_Due_PackedData = GetPositionData(currentByte, 240, 6),
                Rssi_Poc_Post_Lc_PackedData = GetPositionData(currentByte, 246, 5),
                Rssi_Poc_Total_Rec_Bkr_Pre_PackedData = GetPositionData(currentByte, 251, 5),
                Rssi_Poc_Post_Pet_Fees_PackedData = GetPositionData(currentByte, 256, 5),
                Rssi_Poc_Amt_Paid_By_Pet_Last_PackedData = GetPositionData(currentByte, 261, 5),
                Rssi_Poc_Pre_Pet_Arrearage_PackedData = GetPositionData(currentByte, 266, 5),
                Rssi_Poc_Statement_Flag = GetPositionData(currentByte, 271, 1),
                Rssi_Vend_Name1 = GetPositionData(currentByte, 272, 35),
                Rssi_Vend_Adrs1 = GetPositionData(currentByte, 307, 35),
                Rssi_Vend_Adrs2 = GetPositionData(currentByte, 342, 35),
                Rssi_Vend_City = GetPositionData(currentByte, 377, 21),
                Rssi_Vend_State = GetPositionData(currentByte, 398, 2),
                Rssi_Vend_Zip = GetPositionData(currentByte, 400, 10),
                Rssi_Poc_Pre_Suspense_PackedData = GetPositionData(currentByte, 410, 6),
                Rssi_Poc_Post_Suspense_PackedData = GetPositionData(currentByte, 416, 6),
                Rssi_Brpy_Unapp_Paid_PackedData = GetPositionData(currentByte, 422, 6),
                Rssi_Brpy_Plan_Next_Pmt_PackedData = GetPositionData(currentByte, 428, 5),
                Rssi_Brpy_Plan_Due_Date_PackedData = GetPositionData(currentByte, 433, 4),
                Rssi_Fbr_B_Cramdown_Flag = GetPositionData(currentByte, 437, 1),
                Rssi_Poc_Post_Pet_Unpaid_PackedData = GetPositionData(currentByte, 438, 5),
                Rssi_Poc_Bk_Discharged = GetPositionData(currentByte, 443, 1),
                Rssi_Poc_Post_Shortfall_PackedData = GetPositionData(currentByte, 444, 6),
                Rssi_Brpy_Short_Bal_PackedData = GetPositionData(currentByte, 450, 6),
                Rssi_Poc_Pre_Due_Date_PackedData = GetPositionData(currentByte, 456, 4),
                Rssi_Poc_Pre_Payment_PackedData = GetPositionData(currentByte, 460, 6),
                Rssi_Poc_Plan_Shortfall_PackedData = GetPositionData(currentByte, 466, 6),
                Rssi_Poc_Post_Due_Date = GetPositionData(currentByte, 472, 8),
                Rssi_Poc_Post_Payment_PackedData = GetPositionData(currentByte, 480, 6),
                Rssi_Post_Lc_Amt_PackedData = GetPositionData(currentByte, 486, 4),
                Filler = GetPositionData(currentByte, 490, 511),

            };
        }

        // K Archived Bankruptcy Information Record. Multiple records per loan if applicable.
        public void GetArchivedBankruptcyDetailRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.ArchivedBankruptcyDetailRecordModel = new ArchivedBankruptcyDetailRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_K_B_Type = GetPositionData(currentByte, 20, 1),
                Rssi_K_B_Chap = GetPositionData(currentByte, 21, 2),
                Rssi_K_B_Case_No = GetPositionData(currentByte, 23, 12),
                Rssi_K_B_Filed_By = GetPositionData(currentByte, 35, 1),
                Rssi_K_B_Debtor = GetPositionData(currentByte, 36, 35),
                Rssi_K_B_Co_Debtor = GetPositionData(currentByte, 71, 35),
                Rssi_K_B_Filed_Cbwr1_Id = GetPositionData(currentByte, 106, 1),
                Rssi_K_B_Filed_Cbwr2_Id = GetPositionData(currentByte, 107, 1),
                Rssi_K_B_Filed_Cbwr3_Id = GetPositionData(currentByte, 108, 1),
                Rssi_K_B_Filed_Cbwr4_Id = GetPositionData(currentByte, 109, 1),
                Rssi_K_B_Filed_Cbwr5_Id = GetPositionData(currentByte, 110, 1),
                Rssi_K_B_Filed_Cbwr6_Id = GetPositionData(currentByte, 111, 1),
                Rssi_K_B_Filed_Cbwr7_Id = GetPositionData(currentByte, 112, 1),
                Rssi_K_B_Filed_Cbwr8_Id = GetPositionData(currentByte, 113, 1),
                Rssi_K_B_Filed_Cbwr9_Id = GetPositionData(currentByte, 114, 1),
                Rssi_K_B_Filed_Cbwr10_Id = GetPositionData(currentByte, 115, 1),
                Rssi_K_B_Filed_Dt_PackedData = GetPositionData(currentByte, 116, 4),
                Rssi_K_B_Conv_1_Date_PackedData = GetPositionData(currentByte, 120, 4),
                Rssi_K_B_Reaffirm_Dt_PackedData = GetPositionData(currentByte, 124, 4),
                Rssi_K_B_Dschg_Dt_PackedData = GetPositionData(currentByte, 128, 4),
                Rssi_K_B_Dsmsd_Dt_PackedData = GetPositionData(currentByte, 132, 4),
                Rssi_K_B_Relief_Dt_PackedData = GetPositionData(currentByte, 136, 4),
                Rssi_K_Poc_Statement_Flag = GetPositionData(currentByte, 140, 1),
                Filler = GetPositionData(currentByte, 141, 160),

            };
        }

        // X Email Addresses Record
        public void GetEmailAddressRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.EmailAddressRecordModel = new EmailAddressRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Info_Primary_Email_Adr = GetPositionData(currentByte, 20, 60),
                Rssi_Info_Scnd_Email_Adr = GetPositionData(currentByte, 80, 60),
                Rssi_Info_E_Stmt_Email_Adr_1 = GetPositionData(currentByte, 140, 60),
                Rssi_Info_E_Stmt_Email_Adr_2 = GetPositionData(currentByte, 200, 60),
                Rssi_Info_E_Stmt_Email_Adr_3 = GetPositionData(currentByte, 260, 60),
                Rssi_Info_E_Stmt_Email_Adr_4 = GetPositionData(currentByte, 320, 60),
                Rssi_Info_E_Stmt_Email_Adr_5 = GetPositionData(currentByte, 380, 60),
                Rssi_Info_E_Stmt_Email_Adr_6 = GetPositionData(currentByte, 440, 60),
                Rssi_Info_E_Stmt_Email_Adr_7 = GetPositionData(currentByte, 500, 60),
                Rssi_Info_E_Stmt_Email_Adr_8 = GetPositionData(currentByte, 560, 60),
                Rssi_Info_E_Stmt_Email_Adr_9 = GetPositionData(currentByte, 620, 60),
                Rssi_Info_E_Stmt_Email_Adr_10 = GetPositionData(currentByte, 680, 60),
                Rssi_Cb_Cbwr_Email_Adr_1 = GetPositionData(currentByte, 740, 60),
                Rssi_Cb_Cbwr_Email_Adr_2 = GetPositionData(currentByte, 800, 60),
                Rssi_Cb_Cbwr_Email_Adr_3 = GetPositionData(currentByte, 860, 60),
                Rssi_Cb_Cbwr_Email_Adr_4 = GetPositionData(currentByte, 920, 60),
                Rssi_Cb_Cbwr_Email_Adr_5 = GetPositionData(currentByte, 980, 60),
                Rssi_Cb_Cbwr_Email_Adr_6 = GetPositionData(currentByte, 1040, 60),
                Rssi_Cb_Cbwr_Email_Adr_7 = GetPositionData(currentByte, 1100, 60),
                Rssi_Cb_Cbwr_Email_Adr_8 = GetPositionData(currentByte, 1160, 60),
                Rssi_Cb_Cbwr_Email_Adr_9 = GetPositionData(currentByte, 1220, 60),
                Rssi_Cb_Cbwr_Email_Adr_10 = GetPositionData(currentByte, 1280, 60),
                Filler = GetPositionData(currentByte, 1340, 2671),

            };
        }

        // 3 Disaster Tracking Record
        public void GetDisasterTrackingRecordModel(byte[] currentByte, ref AccountsModel acc)
        {
            acc.DisasterTrackingRecordModel = new DisasterTrackingRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Dstr_Occ_Num = GetPositionData(currentByte, 20, 3),
                Rssi_Dstr_Status = GetPositionData(currentByte, 23, 1),
                Rssi_Dstr_Disaster_Name = GetPositionData(currentByte, 24, 35),
                Rssi_Dstr_Type = GetPositionData(currentByte, 59, 2),
                Rssi_Dstr_Desig_Dt = GetPositionData(currentByte, 61, 4),
                Rssi_Dstr_End_Dt = GetPositionData(currentByte, 65, 4),
                Rssi_Dstr_Extended_Dt = GetPositionData(currentByte, 69, 4),
                Rssi_Dstr_Ddn = GetPositionData(currentByte, 73, 10),
                Rssi_Dstr_Aplcnt_Nbr = GetPositionData(currentByte, 83, 10),
                Rssi_Dstr_Prop_Impact_Determine = GetPositionData(currentByte, 93, 1),
                Rssi_Dstr_Prop_Determine_Dt = GetPositionData(currentByte, 94, 4),
                Rssi_Dstr_Prop_Resolution_Dt = GetPositionData(currentByte, 98, 4),
                Rssi_Dstr_Prop_Impact_Severity = GetPositionData(currentByte, 102, 1),
                Rssi_Dstr_Wrkp_Impact_Determine = GetPositionData(currentByte, 103, 1),
                Rssi_Dstr_Wrkp_Determine_Dt = GetPositionData(currentByte, 104, 4),
                Rssi_Dstr_Wrkp_Resolution_Dt = GetPositionData(currentByte, 108, 4),
                Rssi_Dstr_Wrkp_Impact_Severity = GetPositionData(currentByte, 112, 1),
                Rssi_Dstr_Attempt_Contact = GetPositionData(currentByte, 113, 1),
                Rssi_Dstr_Attempt_Contact_Dt = GetPositionData(currentByte, 114, 4),
                Rssi_Dstr_Contact_Made = GetPositionData(currentByte, 118, 1),
                Rssi_Dstr_Contact_Made_Dt = GetPositionData(currentByte, 119, 4),
                Filler = GetPositionData(currentByte, 123, 78),
            };
        }

        // 4 RHCDS Only Record(Only created if RHCDS Option (DB-2: I-RHCDS-OPT) =‘Y’)
        public void GetRHCDRecords(byte[] currentByte, ref AccountsModel acc)
        {
            acc.RHCDSOnlyRecordModel = new RHCDSOnlyRecordModel()
            {
                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_No = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Rhcds_Aa_Expir_Date_PackedData = GetPositionData(currentByte, 20, 4),
                Rssi_Subsidy_Paid_Ytd_PackedData = GetPositionData(currentByte, 24, 5),
                Rssi_Rhcds_Morat_Eff_Dt_PackedData = GetPositionData(currentByte, 29, 4),
                Rssi_Rhcds_Morat_Flag = GetPositionData(currentByte, 33, 1),
                Rssi_Rhcds_Morat_Expir_St_PackedData = GetPositionData(currentByte, 34, 4),
                Rssi_Ml_Notice_Ctl = GetPositionData(currentByte, 38, 1),
                Rssi_Ml_Pend_Start_Dt_PackedData = GetPositionData(currentByte, 39, 4),
                Rssi_Ml_Bnkrpt_Flg = GetPositionData(currentByte, 43, 1),
                Rssi_Ml_Bankrupt_Code = GetPositionData(currentByte, 44, 1),
                Rssi_Ml_Repay_Status_Flg = GetPositionData(currentByte, 45, 1),
                Rssi_Ml_Repay_Cancel_Dt_PackedData = GetPositionData(currentByte, 46, 4),
                Rssi_Rpmt_Add_Pmt_Amt_PackedData = GetPositionData(currentByte, 50, 5),
                Rssi_Rpmt_Plan_Term_PackedData = GetPositionData(currentByte, 55, 2),
                Rssi_Rpmt_Creation_Dt_PackedData = GetPositionData(currentByte, 57, 4),
                Rssi_Rpmt_Rhcds_Down_Pymt_PackedData = GetPositionData(currentByte, 61, 5),
                Rssi_Rpmt_Start_Dt_PackedData = GetPositionData(currentByte, 66, 4),
                Rssi_Ffssd119_Dwa_Delq_PackedData = GetPositionData(currentByte, 70, 4),
                Rssi_Poc_Post_Plan_Source = GetPositionData(currentByte, 74, 1),
                Filler = GetPositionData(currentByte, 75, 126),

            };
        }

        // Z Trailer. One record per file.
        public void GetTrailerRecords(byte[] currentByte, ref AccountsModel acc)
        {
            acc.TrailerRecordModel = new TrailerRecordModel()
            {

                Rssi_Rcd_Id = GetPositionData(currentByte, 1, 1),
                Rssi_Inst = GetPositionData(currentByte, 2, 3),
                Rssi_Acct_Np = GetPositionData(currentByte, 5, 10),
                Rssi_Seq_No = GetPositionData(currentByte, 15, 5),
                Rssi_Total_B_Records = GetPositionData(currentByte, 20, 1),
                Rssi_Total_A_Records = GetPositionData(currentByte, 21, 9),
                Rssi_Total_R_Records = GetPositionData(currentByte, 30, 9),
                Rssi_Total_E_Records = GetPositionData(currentByte, 39, 15),
                Rssi_Total_T_Records = GetPositionData(currentByte, 54, 15),
                Rssi_Total_O_Records = GetPositionData(currentByte, 69, 9),
                Rssi_Total_F_Records = GetPositionData(currentByte, 78, 9),
                Rssi_Total_U_Records = GetPositionData(currentByte, 87, 9),
                Rssi_Total_2_Records = GetPositionData(currentByte, 96, 9),
                Rssi_Total_P_Records = GetPositionData(currentByte, 105, 9),
                Rssi_Total_L_Records = GetPositionData(currentByte, 114, 9),
                Rssi_Total_S_Records = GetPositionData(currentByte, 123, 9),
                Rssi_Total_Fr_Records = GetPositionData(currentByte, 132, 9),
                Rssi_Total_Records = GetPositionData(currentByte, 141, 15),
                Rssi_Total_Loans = GetPositionData(currentByte, 156, 9),

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

        public string UnpackComp3(byte[] data, int start, int length, int decimalPlaces = 0, bool hasSign = true)
        {
            var buffer = new byte[length];
            Array.Copy(data, start, buffer, 0, length);
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
        #endregion


    }
}
