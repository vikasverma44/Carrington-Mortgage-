using Carrington_Service.Infrastructure;
using CarringtonMortgage.Models.InputCopyBookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarringtonMortgage.FlexFields_Calculation
{
    public class StatementType
    {
        #region Object Declaration ==>
        public ILogger Logger;
        public AccountsModel accountModel;
        #endregion
        public StatementType(ILogger logger)
        {
            Logger = logger;

            var accMod = new List<AccountsModel> { };

            var accountModelList = accMod.Where(x =>
                x.EConsentModel.LoanNumber == x.CmsBillInput.DetRecord.LoanNumber
                && x.EConsentModel.LoanNumber == x.CmsBillInput.TransRecord.LoanNumber);

            accountModel = accountModelList.FirstOrDefault();

        }
        public bool ClearedPrivousPrimaryStandardStatementCondition = false;



        public List<Borrower> GetPrimaryStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get primary standard statement.");
                //If RSSI-B-CHAP =7,11 and (FBR-B-REAFFIRM-DT<> 00/00/00) and RSSI-ML-ALT-TYP-ID <>‘O’ or RSSI-B-CHAP <>7,11,12, or 13 and RSSI-ML-ALT-TYP-ID <> ‘O’
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
                if (ClearedPrivousPrimaryStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")))
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousPrimaryStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")))
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousPrimaryStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")))
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousPrimaryStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")))
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousPrimaryStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")))
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
    || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")))
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousPrimaryStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
   || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")))
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
   || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")))
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousPrimaryStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
   || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")))
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousPrimaryStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
|| ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")))
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    return lstBrw;
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


        public List<Borrower> GetPrimaryForeignStandardStatement(AccountsModel accountModel)
        {
            bool ClearedPrivousPrimaryForeignStandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get primary foreign standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = false;
                    lstBrw = GetEDeliveryArchiveStandardStatement(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryForeignStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryForeignStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousPrimaryForeignStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryForeignStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryForeignStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
           || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryForeignStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryForeignStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryForeignStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryForeignStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryForeignStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                Logger.Trace("ENDED:get primary foreign standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }


        public List<Borrower> GetEDeliveryArchiveStandardStatement(AccountsModel accountModel)
        {
            // and condition missing eConsent file has Document type = Bill and eConsent Flag = Y

            // co brwr econsent conditions missing
            bool ClearedPrivousEDeliveryArchiveStandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get edelivery archive standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")) && ((accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = false;
                    lstBrw = GetArchiveOnlyStandardStatement(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousEDeliveryArchiveStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")) && ((accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousEDeliveryArchiveStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")) && ((accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousEDeliveryArchiveStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")) && ((accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousEDeliveryArchiveStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")) && ((accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousEDeliveryArchiveStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
           || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")) && ((accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousEDeliveryArchiveStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")) && ((accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousEDeliveryArchiveStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")) && ((accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousEDeliveryArchiveStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")) && ((accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousEDeliveryArchiveStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")) && ((accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousEDeliveryArchiveStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")) && ((accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousEDeliveryArchiveStandardStatementCondition = false;
                    return lstBrw;
                }
                Logger.Trace("ENDED:get edelivery archive standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        public List<Borrower> GetArchiveOnlyStandardStatement(AccountsModel accountModel)
        {
            bool ClearedPrivousArchiveOnlyStandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = false;
                    lstBrw = GetArchiveOnlyNyHelloStandardStatement(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")))
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousArchiveOnlyStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")))
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousArchiveOnlyStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")))
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousArchiveOnlyStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")))
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousArchiveOnlyStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")))
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
    || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")))
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousArchiveOnlyStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
   || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")))
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
   || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")))
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousArchiveOnlyStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
   || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")))
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }

                if (ClearedPrivousArchiveOnlyStandardStatementCondition && ((((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
|| ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")))
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }
                Logger.Trace("STARTED:  Execute to get archive Only standard statement.");

                Logger.Trace("ENDED:get archive Only standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }



        public List<Borrower> GetArchiveOnlyNyHelloStandardStatement(AccountsModel accountModel)
        {
            bool ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //need to check
                Logger.Trace("STARTED:  Execute to get archive Only ny Hello standard statement.");
                //{ If RSSI-B - CHAP = 7,11 and(FBR - B - REAFFIRM - DT <> 00 / 00 / 00) and RSSI-ML - ALT - TYP - ID <>‘O’ or RSSI-B - CHAP <> 7,11,12, or 13 and RSSI-ML - ALT - TYP - ID <> ‘O’}
                //and If  RSSI - PRINT - STMT = H and RSSI-STATE = 33 and RSSI-LIP - LA - DATE = 0 and RSSI-FIRST - STMT - IND = Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO.

                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                   || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                   && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = false;
                    lstBrw = GetArchiveOnlyNyHelloDvlStandardStatement(accountModel);
                    return lstBrw;
                }
                //{ If RSSI-B - CHAP = 7,11 and(FBR - B - REAFFIRM - DT <> 00 / 00 / 00) and RSSI-ML - ALT - TYP - ID <>‘O’ or RSSI-B - CHAP <> 7,11,12, or 13 and RSSI-ML - ALT - TYP - ID <> ‘O’}
                //and If RSSI - PRINT - STMT = H and RSSI-STATE = 33 and RSSI-LIP - LA - DATE = 0 and RSSI-FIRST - STMT - IND = Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO and If RSSI - CB - CBWR1 - BILL - STMNT = A
                if (ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                           || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                                 && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO") && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                          || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                                && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                Logger.Trace("ENDED:get archive Only ny Hello standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        public List<Borrower> GetArchiveOnlyNyHelloDvlStandardStatement(AccountsModel accountModel)
        {

            //need to check condition statement 
            bool ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get archive Only ny Hello Dvl standard statement.");
                //{ If RSSI-B - CHAP = 7,11 and(FBR - B - REAFFIRM - DT <> 00 / 00 / 00) and RSSI-ML - ALT - TYP - ID <>‘O’ or RSSI-B - CHAP <> 7,11,12, or 13 and RSSI-ML - ALT - TYP - ID <> ‘O’}
                //and If RSSI - PRINT - STMT = H and RSSI-STATE = 33 and RSSI-LIP - LA - DATE = 0 and RSSI-FIRST - STMT - IND = Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO_DVL

                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                   || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                   && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = false;
                    lstBrw = GetArchiveOnlyNyDvlStandardStatement(accountModel);
                    return lstBrw;
                }
                //{ If RSSI-B - CHAP = 7,11 and(FBR - B - REAFFIRM - DT <> 00 / 00 / 00) and RSSI-ML - ALT - TYP - ID <>‘O’ or RSSI-B - CHAP <> 7,11,12, or 13 and RSSI-ML - ALT - TYP - ID <> ‘O’}
                //and If RSSI - PRINT - STMT = H and RSSI-STATE = 33 and RSSI-LIP - LA - DATE = 0 and RSSI-FIRST - STMT - IND = Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO and If RSSI - CB - CBWR1 - BILL - STMNT = A
                if (ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                           || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                                 && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                          || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                                && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyHelloDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                Logger.Trace("ENDED:get archive Only ny Hello Dvl standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }


        public List<Borrower> GetArchiveOnlyNyDvlStandardStatement(AccountsModel accountModel)
        {

            //need to check condition once for field 8
            bool ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get archive Only ny Dvl standard statement.");
                //{ If RSSI-B - CHAP = 7,11 and(FBR - B - REAFFIRM - DT <> 00 / 00 / 00) and RSSI-ML - ALT - TYP - ID <>‘O’ or RSSI-B - CHAP <> 7,11,12, or 13 and RSSI-ML - ALT - TYP - ID <> ‘O’}
                //and If RSSI - PRINT - STMT = H and RSSI-STATE = 33 and RSSI-LIP - LA - DATE = 0 and RSSI-FIRST - STMT - IND = Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = DVL

                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                  || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                  && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = false;
                    lstBrw = GetNyAndHelloLetterStandardStatement(accountModel);
                    return lstBrw;
                }

                if (ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                          || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                                && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                          || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                                && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                        || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                              && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousArchiveOnlyNyDvlStandardStatementCondition = false;
                    return lstBrw;
                }
                Logger.Trace("ENDED:get archive Only ny  Dvl standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        public List<Borrower> GetNyAndHelloLetterStandardStatement(AccountsModel accountModel)
        {
            //check field 8 condition
            bool ClearedPrivousNyAndHelloLetterStandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get ny and hello letter standard statement.");

                //{ If RSSI-B - CHAP = 7,11 and(FBR - B - REAFFIRM - DT <> 00 / 00 / 00) and RSSI-ML - ALT - TYP - ID <>‘O’ or RSSI-B - CHAP <> 7,11,12, or 13 and RSSI-ML - ALT - TYP - ID <> ‘O’}
                //and RSSI-STATE = 33 and RSSI-LIP - LA - DATE = 0 and RSSI-FIRST - STMT - IND = Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO.
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                    || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                    && ((accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = false;
                    lstBrw = GetNyAndHelloDvlLetterStandardStatement(accountModel);
                    return lstBrw;
                }
                //{ If RSSI-B - CHAP = 7,11 and(FBR - B - REAFFIRM - DT <> 00 / 00 / 00) and RSSI-ML - ALT - TYP - ID <>‘O’ or RSSI-B - CHAP <> 7,11,12, or 13 and RSSI-ML - ALT - TYP - ID <> ‘O’}
                //and If RSSI - CB - CBWR1 - BILL - STMNT = A, and RSSI-STATE = 33 and RSSI-LIP - LA - DATE = 0 and RSSI-FIRST - STMT - IND = Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO.
                if (ClearedPrivousNyAndHelloLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                          || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                                && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                           || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                                 && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                Logger.Trace("ENDED:get ny and hello letter standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        public List<Borrower> GetNyAndHelloDvlLetterStandardStatement(AccountsModel accountModel)
        {
            bool ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get ny and hello dvl letter standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                   || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                   && ((accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = false;
                    lstBrw = GetNyAndDvlLetterStandardStatement(accountModel);
                    return lstBrw;
                }
                //{ If RSSI-B - CHAP = 7,11 and(FBR - B - REAFFIRM - DT <> 00 / 00 / 00) and RSSI-ML - ALT - TYP - ID <>‘O’ or RSSI-B - CHAP <> 7,11,12, or 13 and RSSI-ML - ALT - TYP - ID <> ‘O’}
                //and If RSSI - CB - CBWR1 - BILL - STMNT = A, and RSSI-STATE = 33 and RSSI-LIP - LA - DATE = 0 and RSSI-FIRST - STMT - IND = Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO.
                if (ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                          || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                                && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                           || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                                 && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndHelloDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                Logger.Trace("ENDED:get ny and hello dvl letter standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        public List<Borrower> GetNyAndDvlLetterStandardStatement(AccountsModel accountModel)
        {
            bool ClearedPrivousNyAndDvlLetterStandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get ny and dvl letter standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                 || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                 && ((accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = false;
                    lstBrw = GetBkChpt7PrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                //{ If RSSI-B - CHAP = 7,11 and(FBR - B - REAFFIRM - DT <> 00 / 00 / 00) and RSSI-ML - ALT - TYP - ID <>‘O’ or RSSI-B - CHAP <> 7,11,12, or 13 and RSSI-ML - ALT - TYP - ID <> ‘O’}
                //and If RSSI - CB - CBWR1 - BILL - STMNT = A, and RSSI-STATE = 33 and RSSI-LIP - LA - DATE = 0 and RSSI-FIRST - STMT - IND = Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO.
                if (ClearedPrivousNyAndDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                          || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                                && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                           || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                                 && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousNyAndDvlLetterStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                         || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                               && ((accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousNyAndDvlLetterStandardStatementCondition = false;
                    return lstBrw;
                }
                Logger.Trace("ENDED:get ny and  dvl letter standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }


        public List<Borrower> GetBkChpt7PrimaryStandardStatement(AccountsModel accountModel)
        {
            //bool ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 primary standard statement.");
                //{ If RSSI-B - CHAP = 7 or 11 and RSSI-ML - ALT - TYP - ID <> ‘O’ and(FBR - B - REAFFIRM - DT = 00 / 00 / 00) or RSSI-USR - 93 = 7 or 11 and RSSI-ML - ALT - TYP - ID <> ‘O’}
                //and If RSSI - POC - STATEMENT - FLAG = B

                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
  || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7VendStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 primary standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        public List<Borrower> GetBkChpt7VendStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 Vend standard statement.");

                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
  || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7Copy1PrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 Vend standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        public List<Borrower> GetBkChpt7Copy1PrimaryStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 copy 1 primary standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7Copy2VendStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 copy 1 primary standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        public List<Borrower> GetBkChpt7Copy2VendStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 copy 2 vend standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7PrimaryForeignStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 copy 2 vend standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        public List<Borrower> GetBkChpt7PrimaryForeignStandardStatement(AccountsModel accountModel)
        {
            //RSSI-ALTR-FORGN-FLAG = Y need to check this field
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 primary foreign standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7VendForeignStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 primary foreign standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }


        public List<Borrower> GetBkChpt7VendForeignStandardStatement(AccountsModel accountModel)
        {
            //RSSI-ALTR-FORGN-FLAG = Y need to check this field
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 Vend foreign standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7COPY1PrimaryForeignStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 Vend foreign standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        public List<Borrower> GetBkChpt7COPY1PrimaryForeignStandardStatement(AccountsModel accountModel)
        {
            //RSSI-ALTR-FORGN-FLAG = Y need to check this field
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 COPY 1 primary foreign standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7COPY2VENDForeignStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 COPY 1 primary foreign standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        public List<Borrower> GetBkChpt7COPY2VENDForeignStandardStatement(AccountsModel accountModel)
        {
            //RSSI-ALTR-FORGN-FLAG = Y need to check this field
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 COPY 2 vend foreign standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7ArchiveOnlyPrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 COPY 2 vend foreign standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }


        public List<Borrower> GetBkChpt7ArchiveOnlyPrimaryStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only primary standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7ArchiveOnlyVendStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only primary standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }



        public List<Borrower> GetBkChpt7ArchiveOnlyVendStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only Vend standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7ArchiveOnlyCopy1PrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only Vend standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        public List<Borrower> GetBkChpt7ArchiveOnlyCopy1PrimaryStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only copy 1 primary standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy1primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7ArchiveOnlyCopy2VendStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only copy 1 primary standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        public List<Borrower> GetBkChpt7ArchiveOnlyCopy2VendStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only copy 2 vend standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7ArchiveOnlyNyPrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only copy 2 vend standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }



        public List<Borrower> GetBkChpt7ArchiveOnlyNyPrimaryStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny primary standard statement.");

                //{ If RSSI-B - CHAP = 7 or 11 and RSSI-ML - ALT - TYP - ID <> ‘O’ and(FBR - B - REAFFIRM - DT = 00 / 00 / 00) or RSSI-USR - 93 = 7 or 11 and RSSI-ML - ALT - TYP - ID <> ‘O’}
                //and If RSSI - POC - STATEMENT - FLAG = B  and If RSSI - PRINT - STMT = H and RSSI-STATE = 33 and RSSI-LIP - LA - DATE = 0 and RSSI-FIRST - STMT - IND = Y


                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7ArchiveOnlyNyVendStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny primary standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }


        public List<Borrower> GetBkChpt7ArchiveOnlyNyVendStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny vend standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7ArchiveOnlyNyCopy1PrimaryVendStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny vend standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        public List<Borrower> GetBkChpt7ArchiveOnlyNyCopy1PrimaryVendStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny copy 1 primary vend standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy1primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7ArchiveOnlyNyCopy2VendStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny copy 1 primary vend standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        public List<Borrower> GetBkChpt7ArchiveOnlyNyCopy2VendStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny copy 2 Vend standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7ArchiveOnlyNyHelloPrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny ny copy 2 Vend standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }
        public List<Borrower> GetBkChpt7ArchiveOnlyNyHelloPrimaryStandardStatement(AccountsModel accountModel)
        {
            //need to check condition and when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO.

            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello primary standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7ArchiveOnlyNyHelloVENDStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello primary standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }
        public List<Borrower> GetBkChpt7ArchiveOnlyNyHelloVENDStandardStatement(AccountsModel accountModel)
        {

            //need to check condition and when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO.
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt7ArchiveOnlyNyCopy1HelloPrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }
        //sanjay work till here

// for Bhawna
        //For Vikas work
        //STD BK CHPT 13 Stmt - ARCHIVE ONLY - NY - DVL Primary

        public List<Borrower> GetBkChpt13ArchiveOnlyNyDvlPrimaryStandardStatement(AccountsModel accountModel)
        {
           List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                     lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    lstBrw = GetBkChpt13ArchiveOnlyNyDvlVendPrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }
        //STD BK CHPT 13 Stmt - ARCHIVE ONLY - NY  DVL VEND
        public List<Borrower> GetBkChpt13ArchiveOnlyNyDvlVendPrimaryStandardStatement(AccountsModel accountModel)
        {
           List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    lstBrw = GetBkChpt13ArchiveOnlyNyCopy1DvlPrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        //STD BK CHPT 13 Stmt - ARCHIVE ONLY - NY Copy 1 DVL Primary
        public List<Borrower> GetBkChpt13ArchiveOnlyNyCopy1DvlPrimaryStandardStatement(AccountsModel accountModel)
        {
           List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
               if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                   lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1primary", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    lstBrw = GetBkChpt13ArchiveOnlyNyCopy2DvlVendStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        //STD BK CHPT 13 Stmt - ARCHIVE ONLY - NY Copy 2  DVL Vend
        public List<Borrower> GetBkChpt13ArchiveOnlyNyCopy2DvlVendStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                //{If RSSI-B-CHAP =12 or 13 and RSSI-ML-ALT-TYP-ID <> ‘O’}  and If RSSI-POC-STATEMENT-FLAG = B and  If RSSI-PRINT-STMT = H and RSSI-STATE = 33 and RSSI-LIP-LA-DATE = 0 and RSSI-FIRST-STMT-IND=Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = DVL.
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt13NyAndHelloLetterPrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        //STD BK CHPT 13 Stmt NY and Hello Letter Primary
        public List<Borrower> GetBkChpt13NyAndHelloLetterPrimaryStandardStatement(AccountsModel accountModel)
        {
         
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                //{If RSSI-B-CHAP =12 or 13 and RSSI-ML-ALT-TYP-ID <> ‘O’}  and If RSSI-POC-STATEMENT-FLAG = B and  If RSSI-PRINT-STMT = H and RSSI-STATE = 33 and RSSI-LIP-LA-DATE = 0 and RSSI-FIRST-STMT-IND=Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = DVL.
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt13NyHelloLetterVendStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }
        //STD BK CHPT 13 Stmt -NY Hello Letter VEND
        public List<Borrower> GetBkChpt13NyHelloLetterVendStandardStatement(AccountsModel accountModel)
        {

            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                //{If RSSI-B-CHAP =12 or 13 and RSSI-ML-ALT-TYP-ID <> ‘O’}  and If RSSI-POC-STATEMENT-FLAG = B and  If RSSI-PRINT-STMT = H and RSSI-STATE = 33 and RSSI-LIP-LA-DATE = 0 and RSSI-FIRST-STMT-IND=Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = DVL.
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))
                {
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    
                    lstBrw = GetBkChpt13NyHelloLetterCopy1PrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        //STD BK CHPT 13 Stmt -  NY Hello Letter Copy 1 Primary
        public List<Borrower> GetBkChpt13NyHelloLetterCopy1PrimaryStandardStatement(AccountsModel accountModel)
        {

            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))
                {
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                   
                    lstBrw = GetBkChpt13NyHelloLetterCopy2VendStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        //STD BK CHPT 13 Stmt - NY Hello Letter Copy 2 Vend
        public List<Borrower> GetBkChpt13NyHelloLetterCopy2VendStandardStatement(AccountsModel accountModel)
        {

            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                //{If RSSI-B-CHAP =12 or 13 and RSSI-ML-ALT-TYP-ID <> ‘O’}  and If RSSI-POC-STATEMENT-FLAG = B and  If RSSI-PRINT-STMT = H and RSSI-STATE = 33 and RSSI-LIP-LA-DATE = 0 and RSSI-FIRST-STMT-IND=Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = DVL.
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt13NyAndHelloDvlLetterPrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        //STD BK CHPT 13 Stmt NY and Hello DVL Letter Primary
        public List<Borrower> GetBkChpt13NyAndHelloDvlLetterPrimaryStandardStatement(AccountsModel accountModel)
        {

            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                //{If RSSI-B-CHAP =12 or 13 and RSSI-ML-ALT-TYP-ID <> ‘O’}  and If RSSI-POC-STATEMENT-FLAG = B and  If RSSI-PRINT-STMT = H and RSSI-STATE = 33 and RSSI-LIP-LA-DATE = 0 and RSSI-FIRST-STMT-IND=Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = DVL.
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt13NyAndHelloDvlLetterVendStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }
        //STD BK CHPT 13 Stmt  NY and Hello DVL Letter VEND
        public List<Borrower> GetBkChpt13NyAndHelloDvlLetterVendStandardStatement(AccountsModel accountModel)
        {

            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                //{If RSSI-B-CHAP =12 or 13 and RSSI-ML-ALT-TYP-ID <> ‘O’}  and If RSSI-POC-STATEMENT-FLAG = B and  If RSSI-PRINT-STMT = H and RSSI-STATE = 33 and RSSI-LIP-LA-DATE = 0 and RSSI-FIRST-STMT-IND=Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = DVL.
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt13NyHelloDvlLetterCopy1PrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        //STD BK CHPT 13 Stmt - NY Hello DVL Letter Copy 1 Primary
        public List<Borrower> GetBkChpt13NyHelloDvlLetterCopy1PrimaryStandardStatement(AccountsModel accountModel)
        {

            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                //{If RSSI-B-CHAP =12 or 13 and RSSI-ML-ALT-TYP-ID <> ‘O’}  and If RSSI-POC-STATEMENT-FLAG = B and  If RSSI-PRINT-STMT = H and RSSI-STATE = 33 and RSSI-LIP-LA-DATE = 0 and RSSI-FIRST-STMT-IND=Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = DVL.
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt13NyAndHelloDvlLetterCopy2VendStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        //STD BK CHPT 13 Stmt - NY and Hello DVL LetterCopy 2 Vend
        public List<Borrower> GetBkChpt13NyAndHelloDvlLetterCopy2VendStandardStatement(AccountsModel accountModel)
        {

            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                //{If RSSI-B-CHAP =12 or 13 and RSSI-ML-ALT-TYP-ID <> ‘O’}  and If RSSI-POC-STATEMENT-FLAG = B and  If RSSI-PRINT-STMT = H and RSSI-STATE = 33 and RSSI-LIP-LA-DATE = 0 and RSSI-FIRST-STMT-IND=Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = DVL.
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt13NyAndDvlLetterPrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        //STD BK CHPT 13 Stmt NY and DVL Letter Primary
        public List<Borrower> GetBkChpt13NyAndDvlLetterPrimaryStandardStatement(AccountsModel accountModel)
        {

            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                //{If RSSI-B-CHAP =12 or 13 and RSSI-ML-ALT-TYP-ID <> ‘O’}  and If RSSI-POC-STATEMENT-FLAG = B and  If RSSI-PRINT-STMT = H and RSSI-STATE = 33 and RSSI-LIP-LA-DATE = 0 and RSSI-FIRST-STMT-IND=Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = DVL.
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetBkChpt13NyAndDvlLetterVendStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }

        //STD BK CHPT 13 Stmt -  NY and DVL Letter VEND
        public List<Borrower> GetBkChpt13NyAndDvlLetterVendStandardStatement(AccountsModel accountModel)
        {

            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                 if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                   lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    lstBrw = GetBkChpt13NyAndDvlLetterCopy1PrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        //STD BK CHPT 13 Stmt - NY and DVL Letter Copy 1 Primary

        public List<Borrower> GetBkChpt13NyAndDvlLetterCopy1PrimaryStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                   lstBrw = GetBkChpt13NyAndDvlLetterCopy2VendStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }

        //STD BK CHPT 13 Stmt - NY and DVL Letter Copy 2 Vend
        public List<Borrower> GetBkChpt13NyAndDvlLetterCopy2VendStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")) && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                   lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    lstBrw = GetBkChpt13EDeliveryArchivePrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }

        //STD BK CHPT 13 E-Delivery (Archive) Primary
        public List<Borrower> GetBkChpt13EDeliveryArchivePrimaryStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
               if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B") && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                   lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    lstBrw = GetBkChpt13EDeliveryArchiveVendStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        //STD BK CHPT 13 E-Delivery  (Archive) Vend
        public List<Borrower> GetBkChpt13EDeliveryArchiveVendStandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L") && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                   lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    lstBrw = GetBkChpt13EDeliveryArchiveCopy1StandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }

        // STD BK CHPT 13 E-Delivery(Archive) Copy 1
        public List<Borrower> GetBkChpt13EDeliveryArchiveCopy1StandardStatement(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                  lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy1primary", FlexField2 = "S13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    lstBrw = GetBkChpt13EDeliveryMailCopy2StandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }

        //STD BK CHPT 13 E-Delivery Mail Copy 2
        public List<Borrower> GetBkChpt13EDeliveryMailCopy2StandardStatement(AccountsModel accountModel)
        {
           List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny hello Vends standard statement.");
               if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                   lstBrw = GetOptionArmPrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny hello Vends standard statement.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmPrimaryStandardStatement(AccountsModel accountModel)
        {
            bool ClearedPrivousOptionArmPrimaryStandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get Option Arm Primary standard statement.");
                 if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                 || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))))
                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmPrimaryForeignStandardStatement(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A"))

                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                  || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A"))

                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A"))

                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A"))

                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A"))

                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A"))

                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A"))

                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A"))

                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A"))

                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A"))

                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryStandardStatementCondition = false;
                    return lstBrw;
                }
                Logger.Trace("ENDED:get Option Arm  primary standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        //Option ARM STMT - Primary - Foreign
        public List<Borrower> GetOptionArmPrimaryForeignStandardStatement(AccountsModel accountModel)
        {
            bool ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get Option Arm Primary standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                 || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"))
                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = false;
                    lstBrw = GetOptionArmPEDeliveryArchiveCopy1StandardStatement(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"))

                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                  || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"))

                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"))

                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"))

                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"))

                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"))

                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"))

                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"))

                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"))

                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"))

                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPrimaryForeignStandardStatementCondition = false;
                    return lstBrw;
                }
                Logger.Trace("ENDED:get Option Arm  primary standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        //Option ARM  STMT - E-Delivery Archive (Copy 1)
        public List<Borrower> GetOptionArmPEDeliveryArchiveCopy1StandardStatement(AccountsModel accountModel)
        {
            bool ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get Option Arm Primary standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                 || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y"))
                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = false;
                    lstBrw = GetOptionArmArchiveOnlyStandardStatement(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y"))

                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                  || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y"))

                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y"))

                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y"))

                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y"))

                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y"))

                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y"))

                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y"))

                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y"))

                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y"))

                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmPEDeliveryArchiveCopy1StandardStatementCondition = false;
                    return lstBrw;
                }
                Logger.Trace("ENDED:get Option Arm  primary standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }

        //Option ARM  STMT - ARCHIVE ONLY 
        public List<Borrower> GetOptionArmArchiveOnlyStandardStatement(AccountsModel accountModel)
        {
            bool ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get Option Arm Primary standard statement.");
                //  { If RSSI-B - CHAP = 7,11 and(FBR - B - REAFFIRM - DT <> 00 / 00 / 00) and RSSI-ML - ALT - TYP - ID = ‘O’ or RSSI-B - CHAP <> 7, 11, 12 or 13 and RSSI-ML - ALT - TYPE - ID = 'O' or RSSI-USR - 93 <> 7 or 11 and RSSI-ML - ALT - TYP - ID = ‘O’}
                // and RSSI-PRINT - STMT = H
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                 || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = false;
                    lstBrw = GetOptionArmArchiveOnlyNyStandardStatement(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                  || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyStandardStatementCondition = false;
                    return lstBrw;
                }
                Logger.Trace("ENDED:get Option Arm  primary standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        //Option ARM STMT - ARCHIVE ONLY - NY 
        //doubtful function  not implementing
        public List<Borrower> GetOptionArmArchiveOnlyNyStandardStatement(AccountsModel accountModel)
        {
            bool ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get Option Arm Primary standard statement.");
                //{ If RSSI-B - CHAP = 7,11 and(FBR - B - REAFFIRM - DT <> 00 / 00 / 00) and RSSI-ML - ALT - TYP - ID = ‘O’ or RSSI-B - CHAP <> 7, 11, 12 or 13 and RSSI-ML - ALT - TYPE - ID = 'O' or RSSI-USR - 93 <> 7 or 11 and RSSI-ML - ALT - TYP - ID = ‘O’}
                //and the "LoanNumber" is not on PM - 400 - 661 file or the “Proposed Supplemental CCF Layout_050820” and If RSSI - PRINT - STMT = H and RSSI-STATE = 33 and RSSI-LIP - LA - DATE = 0 and RSSI-FIRST - STMT - IND = Y
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                 || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = false;
                    lstBrw = GetOptionArmArchiveOnlyNyHelloStandardStatement(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                  || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyStandardStatementCondition = false;
                    return lstBrw;
                }
                Logger.Trace("ENDED:get Option Arm  primary standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }

        //Option ARM  STMT - ARCHIVE ONLY - NY - Hello
        public List<Borrower> GetOptionArmArchiveOnlyNyHelloStandardStatement(AccountsModel accountModel)
        {
            bool ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {/// RSSI_PRINT_STMT not found
                Logger.Trace("STARTED:  Execute to get Option Arm Primary standard statement.");
                // { If RSSI-B - CHAP = 7,11 and(FBR - B - REAFFIRM - DT <> 00 / 00 / 00) and RSSI-ML - ALT - TYP - ID = ‘O’ or RSSI-B - CHAP <> 7, 11, 12 or 13 and RSSI-ML - ALT - TYPE - ID = 'O' or RSSI-USR - 93 <> 7 or 11 and RSSI-ML - ALT - TYP - ID = ‘O’}
                // and If RSSI - PRINT - STMT = H and RSSI-STATE = 33 and RSSI-LIP - LA - DATE = 0 and RSSI-FIRST - STMT - IND = Y and when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO.
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                 || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))
                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = false;
                    lstBrw = GetBkChpt7ArchiveOnlyNyCopy1HelloPrimaryStandardStatement(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                  || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
              || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                if (ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
               || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))
             || ((accountModel.UserFieldRecordModel.Rssi_Usr_93 != "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 != "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "0"))) && ((accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))

                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousOptionArmArchiveOnlyNyHelloStandardStatementCondition = false;
                    return lstBrw;
                }
                Logger.Trace("ENDED:get Option Arm  primary standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        //till here

        public List<Borrower> GetBkChpt7ArchiveOnlyNyCopy1HelloPrimaryStandardStatement(AccountsModel accountModel)
        {

            //need to check condition and when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO.
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get bk chpt 7 archive only ny copy 1 hello primary standard statement.");
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11") && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0") && (accountModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != "00/00/00"))
|| ((accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7" || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11" && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData != "0"))) && ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") && (accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33") && (accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0") && (accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy1primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    // ClearedPrivousBkChpt7PrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNyHelloDvl(accountModel);
                    return lstBrw;
                }
                Logger.Trace("ENDED:get bk chpt 7 archive only ny copy 1 hello primary standard statement.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }

            return lstBrw;
        }


        public List<Borrower> GetOptionArmStmtArchiveOnlyNyHelloDvl(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get Option ARM STMT ARCHIVE ONLY NY Hello DVL");

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
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                    )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNyDvl(accountModel);
                    return lstBrw;
                }

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
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNyDvl(accountModel);
                    return lstBrw;
                }


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
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNyDvl(accountModel);
                    return lstBrw;
                }

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
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNyDvl(accountModel);
                    return lstBrw;
                }

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
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNyDvl(accountModel);
                    return lstBrw;
                }

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
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNyDvl(accountModel);
                    return lstBrw;
                }

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
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNyDvl(accountModel);
                    return lstBrw;
                }

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
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNyDvl(accountModel);
                    return lstBrw;
                }

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
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNyDvl(accountModel);
                    return lstBrw;
                }
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
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNyDvl(accountModel);
                    return lstBrw;
                }
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
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNyDvl(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To get Option ARM STMT ARCHIVE ONLY NY Hello DVL");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmStmtArchiveOnlyNyDvl(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Option ARM STMT ARCHIVE ONLY NY DVL");

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
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL"// need to check
                    )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloLetter(accountModel);
                    return lstBrw;
                }
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
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y"
                    )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloLetter(accountModel);
                    return lstBrw;
                }

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
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y"
                    )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloLetter(accountModel);
                    return lstBrw;
                }

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
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y"
                    )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloLetter(accountModel);
                    return lstBrw;
                }
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
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y"
                    )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloLetter(accountModel);
                    return lstBrw;
                }
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
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y"
                    )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloLetter(accountModel);
                    return lstBrw;
                }
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
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y"
                    )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloLetter(accountModel);
                    return lstBrw;
                }
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
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y"
                    )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloLetter(accountModel);
                    return lstBrw;
                }
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
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y"
                    )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloLetter(accountModel);
                    return lstBrw;
                }
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
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y"
                    )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloLetter(accountModel);
                    return lstBrw;
                }
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
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y"
                    )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloLetter(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To get Option ARM STMT ARCHIVE ONLY NY DVL");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name); throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmStmtNyandHelloLetter(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to get Option ARM STMT NY and Hello Letter");
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
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloDVLLetter(accountModel);
                    return lstBrw;
                }

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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloDVLLetter(accountModel);
                    return lstBrw;
                }

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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandHelloDVLLetter(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To get Option ARM STMT NY and Hello Letter");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmStmtNyandHelloDVLLetter(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option ARM STMT NY and Hello DVL Letter");
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
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandDVLLetter(accountModel);
                    return lstBrw;
                }

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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandDVLLetter(accountModel);
                    return lstBrw;
                }

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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandDVLLetter(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmStmtNyandDVLLetter(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option ARM STMT NY and Hello DVL Letter");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmStmtNyandDVLLetter(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option ARM STMT NY and DVL Letter");
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
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtPrimary(accountModel);
                    return lstBrw;
                }

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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtPrimary(accountModel);
                    return lstBrw;
                }

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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtPrimary(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtPrimary(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtPrimary(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtPrimary(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtPrimary(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtPrimary(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtPrimary(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtPrimary(accountModel);
                    return lstBrw;
                }
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
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option ARM STMT NY and DVL Letter");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }

        public List<Borrower> GetOptionArmBkChpt7StmtPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtVend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Vend");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtCopy1Primary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Vend");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtCopy1Primary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Copy1 Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1primary", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtCopy2Vend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Copy1 Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtCopy2Vend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Copy2 Vend");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtPrimaryForeign(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Copy2 Vend");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }

        public List<Borrower> GetOptionArmBkChpt7StmtPrimaryForeign(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Primary Foreign");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtVendForeign(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Primary Foreign");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtVendForeign(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Vend Foreign");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtCopy1VendForeign(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Vend Foreign");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtCopy1VendForeign(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Copy1 Vend Foreign");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1primary", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtCopy2VendForeign(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Copy1 Vend Foreign");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtCopy2VendForeign(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Copy2 Vend Foreign");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Copy2 Vend Foreign");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }

        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyVend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Vend");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyCopy1Primary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Vend");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyCopy1Primary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Copy1 Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyCopy2Vend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Copy1 Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyCopy2Vend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Copy2 Vend");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Copy2 Vend");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }


        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind =="Y"
                     && "The Loannumber Is Not On PM-400 - 661 File Or The Proposed Supplemental CCF Layout_050820" == "")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyVend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>(); try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "The Loannumber Is Not On PM-400 - 661 File Or The Proposed Supplemental CCF Layout_050820" == "")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyCopy1Primary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyCopy1Primary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>(); try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "The Loannumber Is Not On PM-400 - 661 File Or The Proposed Supplemental CCF Layout_050820" == "")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyCopy2Vend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyCopy2Vend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "The Loannumber Is Not On PM-400 - 661 File Or The Proposed Supplemental CCF Layout_050820" == "")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyHelloPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }

        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyHelloPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyHelloVend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyHelloVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>(); try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyCopy1HelloPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyCopy1HelloPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>(); try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyCopy2HelloVend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyCopy2HelloVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyHelloDvlPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }

        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyHelloDvlPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyHelloDvlVend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyHelloDvlVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>(); try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyCopy1HelloDvlPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyCopy1HelloDvlPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>(); try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyCopy2HelloDvlVend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyCopy2HelloDvlVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyDvlPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }

        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyDvlPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyDvlVend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyDvlVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>(); try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyCopy1DvlPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyCopy1DvlPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>(); try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyCopy2DvlVend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyCopy2DvlVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtNyAndHelloLetterPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }

        public List<Borrower> GetOptionArmBkChpt7StmtNyAndHelloLetterPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtNyHelloLetterVend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtNyHelloLetterVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>(); try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtNyHelloLetterCopy1Primary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtNyHelloLetterCopy1Primary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>(); try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtNyHelloLetterCopy2Vend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtNyHelloLetterCopy2Vend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtNyAndHelloDvlLetterPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }

        public List<Borrower> GetOptionArmBkChpt7StmtNyAndHelloDvlLetterPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtNyAndHelloDvlLetterVend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtNyAndHelloDvlLetterVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>(); try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtNyHelloDvlLetterCopy1Primary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtNyHelloDvlLetterCopy1Primary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>(); try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtNyAndHelloDvlLettercopy2Vend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtNyAndHelloDvlLettercopy2Vend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "HELLO_DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtNyAndDvlLetterPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }

        public List<Borrower> GetOptionArmBkChpt7StmtNyAndDvlLetterPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtNyAndDvlLetterVend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtNyAndDvlLetterVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>(); try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtNyAndDvlLetterCopy1Primary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtNyAndDvlLetterCopy1Primary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>(); try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7StmtNyAndDvlLetterCopy2Vend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtNyAndDvlLetterCopy2Vend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && "when field 8 on the “Proposed Supplemental CCF Layout_050820”" == "DVL")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7EDeliveryArchivePrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }

        public List<Borrower> GetOptionArmBkChpt7EDeliveryArchivePrimary(AccountsModel accountModel) {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && "DocumentType" == "Bill"
                     && "eConset Flag" == "Y")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7EDeliveryArchiveVend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw; 
        }
        public List<Borrower> GetOptionArmBkChpt7EDeliveryArchiveVend(AccountsModel accountModel) {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && "DocumentType" == "Bill"
                     && "eConset Flag" == "Y")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7EDeliveryArchiveCopy1(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7EDeliveryArchiveCopy1(AccountsModel accountModel) {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && "DocumentType" == "Bill"
                     && "eConset Flag" == "Y")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt7EDeliveryMailCopy2Vend(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: ");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7EDeliveryMailCopy2Vend(AccountsModel accountModel) {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 E Delivery Mail Copy2 Vend");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData != "00/00/00"

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && "DocumentType" == "Bill"
                     && "eConset Flag" == "Y")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPrivousPrimaryStandardStatementCondition)
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                }
                Logger.Trace("ENDED: To Get Option Arm Bk Chpt 7 E Delivery Mail Copy2 Vend");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }

        public List<Borrower> GetOptionArmBkChpt13StmtPrimary(AccountsModel accountModel) {
            List<Borrower> lstBrw = new List<Borrower>(); 
            try { 
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtVend(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtVend(AccountsModel accountModel) {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtCopy1Primary(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtCopy1Primary(AccountsModel accountModel) {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtCopy2Vend(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtCopy2Vend(AccountsModel accountModel) {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtPrimaryForeign(accountModel);
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

        public List<Borrower> GetOptionArmBkChpt13StmtPrimaryForeign(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtVendForeign(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtVendForeign(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtCopy1PrimaryForeign(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtCopy1PrimaryForeign(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtCopy2VendForeign(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtCopy2VendForeign(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyPrimary(accountModel);
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

        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyVend(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyCopy1Primary(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyCopy1Primary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyCopy2Vend(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyCopy2Vend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyPrimary(accountModel);
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

        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y") 
                     //&& '"LoanNumber" is not on PM-400-661 file or the “Proposed Supplemental CCF Layout_050820”')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyVend(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")
                //&& '"LoanNumber" is not on PM-400-661 file or the “Proposed Supplemental CCF Layout_050820”')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyCopy1Primary(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyCopy1Primary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")
                    //&& '"LoanNumber" is not on PM-400-661 file or the “Proposed Supplemental CCF Layout_050820”')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmbkChpt13StmtArchiveOnlyNyCopy2Vend(accountModel);
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
        public List<Borrower> GetOptionArmbkChpt13StmtArchiveOnlyNyCopy2Vend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")
                    //&& '"LoanNumber" is not on PM-400-661 file or the “Proposed Supplemental CCF Layout_050820”')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyHelloPrimary(accountModel);
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

        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyHelloPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")
                //&& 'when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyHelloVend(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyHelloVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")
                //&& 'when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyCopy1HelloPrimary(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyCopy1HelloPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")
                //&& 'when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyCopy2HelloVend(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyCopy2HelloVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")
                //&& 'when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyHelloDvlPrimary(accountModel);
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

        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyHelloDvlPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")
                //&& 'when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO_DVL')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyHelloDvlVend(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyHelloDvlVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")
                //&& 'when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO_DVL')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyCopy1HelloDvlPrimary(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyCopy1HelloDvlPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")
                //&& 'when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyCopy2HelloDvlVend(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyCopy2HelloDvlVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")
                //&& 'when field 8 on the “Proposed Supplemental CCF Layout_050820” = HELLO_DVL')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyDvlPrimary(accountModel);
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

        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyDvlPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")
                //&& 'when field 8 on the “Proposed Supplemental CCF Layout_050820” = DVL')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyDvlVend(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyDvlVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")
                //&& 'when field 8 on the “Proposed Supplemental CCF Layout_050820” = DVL')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyCopy1DvlPrimary(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyCopy1DvlPrimary(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")
                //&& 'when field 8 on the “Proposed Supplemental CCF Layout_050820” = DVL')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyCopy2DvlVend(accountModel);
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
        public List<Borrower> GetOptionArmBkChpt13StmtArchiveOnlyNyCopy2DvlVend(AccountsModel accountModel)
        {
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id_PackedData == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")
                //&& 'when field 8 on the “Proposed Supplemental CCF Layout_050820” = DVL')
                {
                    ClearedPrivousPrimaryStandardStatementCondition = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPrivousPrimaryStandardStatementCondition = false;
                    lstBrw = GetOptionArmBkChpt13StmtNyAndHelloLetterPrimary(accountModel);
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

        public List<Borrower> GetOptionArmBkChpt13StmtNyAndHelloLetterPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionArmBkChpt13StmtNyHelloLetterVend(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionArmBkChpt13StmtNyHelloLetterCopy1Primary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionArmBkChpt13StmtNyHelloLetterCopy2Vend(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionArmBkChpt13StmtNyAndHelloDvlLetterPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionArmbkChpt13StmtNyAndHelloDvlLetterVend(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionArmBkChpt13StmtNyHelloDvlLetterCopy1Primary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionArmBkChpt13StmtNyAndHelloDvlLettercopy2Vend(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionArmBkChpt13StmtNyAndDvlLetterPrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionArmbkChpt13StmtNyAndDvlLetterVend(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionArmBkChpt13StmtNyAndDvlLetterCopy1Primary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionArmbkChpt13StmtNyAndDvlLetterCopy2Vend(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        
        public List<Borrower> GetOptionArmBkChpt13EDeliveryArchivePrimary(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionArmBkChpt13EDeliveryArchiveVend(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionArmBkChpt13EDeliveryArchiveCopy1(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
        public List<Borrower> GetOptionArmBkChpt13EDeliveryMailCopy2Vend(AccountsModel accountModel) { List<Borrower> lstBrw = new List<Borrower>(); try { Logger.Trace("STARTED:  Execute"); Logger.Trace("ENDED: "); } catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; } return lstBrw; }
    }
}
