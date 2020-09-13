using Carrington_Service.Infrastructure;
using ODHS_EDelivery.Models.InputCopyBookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.FlexFields_Calculation
{
    public class StatementType
    {
        #region Object Declaration ==>
        public ILogger Logger;
        #endregion
        public StatementType(ILogger logger)
        {
            Logger = logger;
        }
        public bool ClearedPrivousPrimaryStandardStatementCondition = false;
        public List<Borrower> GetPrimaryStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get primary standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0")))
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetPrimaryForeignStandardStatement(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:get primary standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }


            return lstBrw;

        }


        public static List<Borrower> GetPrimaryForeignStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            return lstBrw;
        }

        public List<Borrower> GetOptionARMSTMTARCHIVEONLYNYHelloDVL(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");

                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date) == 0
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                    )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionARMSTMTARCHIVEONLYNYDVL(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionARMSTMTARCHIVEONLYNYDVL(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");

                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date) == 0
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL"// need to check
                    )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionARMSTMTNYandHelloLetter(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name); throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionARMSTMTNYandHelloLetter(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date) == 0
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionARMSTMTNYandHelloDVLLetter(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionARMSTMTNYandHelloDVLLetter(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date) == 0
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionARMSTMTNYandDVLLetter(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionARMSTMTNYandDVLLetter(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date) == 0
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionARMBKCHPT7STMTPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionARMBKCHPT7STMTPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date) == 0
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionARMBKCHPT7STMTCOPY1Primary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionARMBKCHPT7STMTCOPY1Primary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                   && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"
                   || (Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) == 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) == 11))
                   && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                   )
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionARMBKCHPT7STMTPrimaryForeign(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionARMBKCHPT7STMTPrimaryForeign(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                   && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"
                   || (Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) == 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) == 11))
                   && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                   )
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionARMBKCHPT7STMTCOPY1PrimaryForeign(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionARMBKCHPT7STMTCOPY1PrimaryForeign(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                   && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"
                   || (Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) == 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) == 11))
                   && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                   && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                   )
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionARMBKCHPT7STMTArchiveONLYPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionARMBKCHPT7STMTArchiveONLYPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                   && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"
                   || (Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) == 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) == 11))
                   && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                   && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                   )
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionARMBKCHPT7STMTArchiveONLYCopy1Primary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionARMBKCHPT7STMTArchiveONLYCopy1Primary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7STMTArchiveONLYNY(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7StmtARCHIVEONLYNYPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7StmtARCHIVEONLYNYCopy1Primary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7StmtARCHIVEONLYNYHelloPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7StmtARCHIVEONLYNYCopy1HelloPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7StmtARCHIVEONLYNYHelloDVLPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7StmtARCHIVEONLYNYCopy1HelloDVLPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7StmtARCHIVEONLYNYDVLPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7StmtARCHIVEONLYNYCopy1DVLPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7StmtNYandHelloLetterPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7StmtNYHelloLetterCopy1Primary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7StmtNYandHelloDVLLetterPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7StmtNYHelloDVLLetterCopy1Primary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7StmtNYandDVLLetterPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7StmtNYandDVLLetterCopy1Primary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7EDeliveryArchivePrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT7EDeliveryArchiveCopy1(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13STMTPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13STMTCOPY1Primary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13STMTPrimaryForeign(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13STMTCOPY1PrimaryForeign(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13STMTArchiveONLYPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13STMTArchiveONLYCopy1Primary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        //public List<Borrower> GetOptionARMBKCHPT7STMTArchiveONLYNY(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        //public List<Borrower> GetOptionARMBKCHPT13StmtARCHIVEONLYNYPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13StmtARCHIVEONLYNYCopy1Primary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13StmtARCHIVEONLYNYHelloPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13StmtARCHIVEONLYNYCopy1HelloPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13StmtARCHIVEONLYNYHelloDVLPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13StmtARCHIVEONLYNYCopy1HelloDVLPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13StmtARCHIVEONLYNYDVLPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13StmtARCHIVEONLYNYCopy1DVLPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13StmtNYandHelloLetterPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13StmtNYHelloLetterCopy1Primary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13StmtNYandHelloDVLLetterPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13StmtNYHelloDVLLetterCopy1Primary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13StmtNYandDVLLetterPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13StmtNYandDVLLetterCopy1Primary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13EDeliveryArchivePrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionARMBKCHPT13EDeliveryArchiveCopy1(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }

    }
}
