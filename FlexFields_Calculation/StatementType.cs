using Carrington_Service.Infrastructure;
using CarringtonMortgage.Helpers;
using CarringtonMortgage.Models.InputCopyBookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarringtonMortgage.FlexFields_Calculation
{
    public class StatementType : IStatementType
    {
        public ILogger Logger;
        public AccountsModel accountModel;
        public StatementType(ILogger logger)
        {
            Logger = logger;
        }
        public List<Borrower> GetPrimaryStandardStatement(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdStmtPrimaryForeign(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdStmtPrimaryForeign(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdStmtEDeliveryArchiveCopy1(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdStmtEDeliveryArchiveCopy1(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdStmtArchiveOnly(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdStmtArchiveOnly(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdStmtArchiveOnlyNy(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdStmtArchiveOnlyNy(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && ((!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No))
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdStmtArchiveOnlyNyHello(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                && ((!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No))
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                && ((!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No))
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                && ((!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No))
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                && ((!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No))
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                && ((!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No))
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                && ((!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No))
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                && ((!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No))
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                && ((!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No))
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                && ((!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No))
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                && ((!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No))
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdStmtArchiveOnlyNyHello(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdStmtArchiveOnlyNyHelloDvl(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdStmtArchiveOnlyNyHelloDvl(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdStmtArchiveOnlyNyDvl(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdStmtArchiveOnlyNyDvl(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdStmtNyAndHelloLetter(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdStmtNyAndHelloLetter(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdStmtNyAndHelloDvlLetter(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdStmtNyAndHelloDvlLetter(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdStmtNyAndDvlLetter(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdStmtNyAndDvlLetter(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt7StmtPrimary(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "7" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap == "11")
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00"))
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                || ((accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "7"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "11"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "12"
                || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap != "13")
                && (accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"))
                && (accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                && ((accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                   && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt7StmtPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                 || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                 || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                 && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt7StmtPrimaryForeign(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                  || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                  || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                  && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                  || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                  || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                  && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                   && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                   || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                   || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                   && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt7StmtPrimaryForeign(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                 || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                 || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt7StmtArchiveOnlyPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                  || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                  || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                  && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                  && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                  || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                  || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                  && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                  && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                   && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                   || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                   || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                   && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                   && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt7StmtArchiveOnlyPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                 || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                 || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt7StmtArchiveOnlyNy(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                  || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                  || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                  && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                  || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                  || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                  && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                   && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                   || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                   || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                   && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt7StmtArchiveOnlyNy(AccountsModel accountModel) //TOD0:Revisit Again
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                 || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                 || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                 && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                 && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt7StmtArchiveOnlyNyPrimary(accountModel);
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt7StmtArchiveOnlyNyPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                 || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                 || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt7StmtArchiveOnlyNyHelloPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                  || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                  || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                  && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                  || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                  || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                  && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt7StmtArchiveOnlyNyHelloPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                 || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                 || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt7StmtArchiveOnlyNyHelloDvlPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                  || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                  || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                  && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt7StmtArchiveOnlyNyHelloDvlPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                 || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                 || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt7StmtArchiveOnlyNyDvlPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                  || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                  || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                  && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt7StmtArchiveOnlyNyDvlPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                 || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                 || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt7StmtNyAndHelloLetterPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                  || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                  || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                  && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt7StmtNyAndHelloLetterPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                 || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                 || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt7StmtNyAndHelloDvlLetterPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                  || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                  || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                  && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt7StmtNyAndHelloDvlLetterPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                 || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                 || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt7StmtNyAndDvlLetterPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                  || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                  || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                  && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt7StmtNyAndDvlLetterPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                 || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                 || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt7EDeliveryArchivePrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                  || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                  || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                  && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S07", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt7EDeliveryArchivePrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                 || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                 || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.EConsentModel.DocumentType == "Bill"
                 && accountModel.EConsentModel.EConsentFlag == "Y"))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S07", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt13StmtPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                 && accountModel.EConsentModel.DocumentType == "Bill"
                 && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S07", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                  && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                  || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                  || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                  && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
              && accountModel.EConsentModel.DocumentType == "Bill"
                 && accountModel.EConsentModel.EConsentFlag == "Y")))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S07", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                || (accountModel.UserFieldRecordModel.Rssi_Usr_93 == "7"
                || accountModel.UserFieldRecordModel.Rssi_Usr_93 == "11"
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O")
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                 && accountModel.EConsentModel.DocumentType == "Bill"
                 && accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S07", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt13StmtPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt13StmtPrimaryForeign(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt13StmtPrimaryForeign(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt13StmtArchiveOnlyPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                 && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt13StmtArchiveOnlyPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt13StmtArchiveOnlyNy(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt13StmtArchiveOnlyNy(AccountsModel accountModel) //TOD0:Revisit Again
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"

                 && (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "33"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                 && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "", FlexField2 = "S07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt13StmtArchiveOnlyNyPrimary(accountModel);
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt13StmtArchiveOnlyNyPrimary(AccountsModel accountModel) {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "B"
                 && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No))))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt13StmtArchiveOnlyNyHelloPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "L"
                 && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)))))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)))))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)))))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt13StmtArchiveOnlyNyHelloPrimary(AccountsModel accountModel) 
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "B"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt13StmtArchiveOnlyNyHelloDvlPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "L"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt13StmtArchiveOnlyNyHelloDvlPrimary(AccountsModel accountModel) 
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "B"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt13StmtArchiveOnlyNyDvlPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "L"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt13StmtArchiveOnlyNyDvlPrimary(AccountsModel accountModel) {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "B"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt13StmtNyAndHelloLetterPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "L"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt13StmtNyAndHelloLetterPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "B"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt13StmtNyAndHelloDvlLetterPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "L"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt13StmtNyAndHelloDvlLetterPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "B"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt13StmtNyAndDvlLetterPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "L"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt13StmtNyAndDvlLetterPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "B"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt13EDeliveryArchivePrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                 && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                 && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "L"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt13EDeliveryArchivePrimary(AccountsModel accountModel) {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                 && (accountModel.EConsentModel.DocumentType == "Bill")
                 && (accountModel.EConsentModel.EConsentFlag == "Y")))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "S13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmStmtPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                 && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                 && (accountModel.EConsentModel.DocumentType == "Bill")
                 && (accountModel.EConsentModel.EConsentFlag == "Y"))))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "S13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && (accountModel.EConsentModel.DocumentType == "Bill")
                && (accountModel.EConsentModel.EConsentFlag == "Y"))))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "S13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id != "O"
                && (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && (accountModel.EConsentModel.DocumentType == "Bill") 
                && (accountModel.EConsentModel.EConsentFlag == "Y"))))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "S13", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmStmtPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to get Option ARM Stmt Archive Only Ny");

                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")

                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmStmtPrimaryForeign(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")

                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }


                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")

                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")

                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")

                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")

                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")

                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")

                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")

                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")

                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")

                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED:    To get Option ARM Stmt Archive Only Ny");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmStmtPrimaryForeign(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to get Option ARM Stmt Archive Only Ny");

                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmStmtEDeliveryArchiveCopy1(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }


                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED:    To get Option ARM Stmt Archive Only Ny");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmStmtEDeliveryArchiveCopy1(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to get Option ARM Stmt Archive Only Ny");

                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && (accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmStmtArchiveOnly(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && (accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }


                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && (accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && (accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && (accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && (accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && (accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && (accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && (accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && (accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && (accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED:    To get Option ARM Stmt Archive Only Ny");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmStmtArchiveOnly(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to get Option ARM Stmt Archive Only Ny");

                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNy(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }


                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"                  
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"                  
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y"
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED:    To get Option ARM Stmt Archive Only Ny");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmStmtArchiveOnlyNy(AccountsModel accountModel) {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to get Option ARM Stmt Archive Only Ny Hello");

                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No))
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNyHello(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No))
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }


                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No))
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED:    To get Option ARM Stmt Archive Only Ny Hello");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }       
        public List<Borrower> GetOptionArmStmtArchiveOnlyNyHello(AccountsModel accountModel) 
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to get Option ARM Stmt Archive Only Ny Hello");

                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNyHelloDvl(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }


                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED:    To get Option ARM Stmt Archive Only Ny Hello");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        //
        public List<Borrower> GetOptionArmStmtArchiveOnlyNyHelloDvl(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to get Option ARM Stmt Archive Only Ny Hello DVL");

                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmStmtArchiveOnlyNyDvl(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }


                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y"
                   )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                  && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                  || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                  || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                  && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                  && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                  && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                  && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                  && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"
                  && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y")
                  )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED:    To get Option ARM Stmt Archive Only Ny Hello DVL");
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
            bool ClearedPreviousStatement = false;

            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Option ARM STMT ARCHIVE ONLY NY DVL");

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmStmtNyandHelloLetter(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y")
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y")
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y")
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y")
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y")
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y")
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y")
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y")
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y")
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                    || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && (accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                    && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y")
                    )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                //Logger.Trace("ENDED:    To get Option ARM STMT ARCHIVE ONLY NY DVL");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name); throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmStmtNyandHelloLetter(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to get Option ARM STMT NY and Hello Letter");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmStmtNyandHelloDVLLetter(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED:    To get Option ARM STMT NY and Hello Letter");
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
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option ARM STMT NY and Hello DVL Letter");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmStmtNyandDVLLetter(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "STD", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED:    To Get Option ARM STMT NY and Hello DVL Letter");
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
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option ARM STMT NY and DVL Letter");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                 && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt7StmtPrimary(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB1", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                  && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB2", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB3", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB4", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB5", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB6", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB7", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB8", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB9", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                   && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 7
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 11
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 12
                   || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) != 13
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 7
                   || Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_93) != 11
                   && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                   && accountModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "Y"
                   && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                   && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                   && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                   && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL"// need to check
                   )

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "CB10", FlexField2 = "ARM", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED:    To Get Option ARM STMT NY and DVL Letter");
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
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Primary");

                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt7StmtPrimaryForeign(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1primary", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Primary");
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
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Primary Foreign");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetStdBkChpt7StmtArchiveOnlyNY(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                    && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                    && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1primary", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                      || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                      && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                      && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                      || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                      || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                      && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                      && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                      && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "FC", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                //Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Primary Foreign");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetStdBkChpt7StmtArchiveOnlyNY(AccountsModel accountsModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //and RSSI-STATE = 33 and RSSI-LIP-LA-DATE = 0 and RSSI-FIRST-STMT-IND=Y and the "LoanNumber" is not on PM-400-661 file or the “Proposed Supplemental CCF Layout_050820” 
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                      || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                      && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                      && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                      || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                      || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                      && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                      && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)))

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "", FlexField2 = "S04", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyPrimary(accountModel);
                    return lstBrw;
                }
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
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyPrimary(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
               || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
               && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
               && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

               || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
               || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
               && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
               && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
               && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                 && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                 || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                 && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                 && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                 && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
             && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
             && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
             && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
             && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
             && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                //Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Primary");
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
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyHelloPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
             && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
             && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
             && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
             && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
             && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
             && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
             && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
             && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
             && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
             && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
             && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
             && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
             && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
             && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
             && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
             && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                //Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Ny Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyHelloPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Ny Hello Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyHelloDvlPrimary(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                        || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                        && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                        && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                        || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                        || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                        && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                        && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                        && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                        && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                        && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                        && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                        && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
            || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
            && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
            && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

            || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
            || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
            && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
            && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
            && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
            && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
            && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
            && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
            && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
              || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
              && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
              && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

              || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
              || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
              && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
              && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
              && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
              && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
              && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
              && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
              && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")

                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement)
                {
                    ClearedPreviousStatement = true;
                }
                //Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Ny Hello Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyHelloDvlPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Ny Hello Dvl Primary");

                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt7StmtArchiveOnlyNyDvlPrimary(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
             && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
             && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
             && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
             && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
             && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
             && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
             && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
             && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
             && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
               || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
               && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
               && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

               || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
               || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
               && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
               && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
               && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
               && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
               && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
               && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
               && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
              || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
              && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
              && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

              || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
              || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
              && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
              && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
              && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
              && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
              && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
              && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
              && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Ny Hello Dvl Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtArchiveOnlyNyDvlPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Archive Only Ny Dvl Primary");

                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt7StmtNyAndHelloLetterPrimary(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
             && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
             && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
             && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
             && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
             && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
             && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
             && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
             && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
             && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
              || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
              && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
              && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

              || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
              || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
              && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
              && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
              && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
              && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
              && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
              && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
              && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
              || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
              && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
              && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

              || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
              || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
              && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
              && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
              && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
              && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
              && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
              && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
              && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement)
                {
                    ClearedPreviousStatement = true;
                }
                //Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Archive Only Ny Dvl Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtNyAndHelloLetterPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Ny And Hello Letter Primary");

                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt7StmtNyAndHelloDvlLetterPrimary(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                    && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                    || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                    && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                    && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                    && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                    && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                    && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Ny And Hello Letter Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtNyAndHelloDvlLetterPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Ny And Hello Dvl Letter Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt7StmtNyAndDvlLetterPrimary(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
             && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
             && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
             && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
             && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
             && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
             && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
             && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
             && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
            || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
            && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
            && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

            || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
            || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
            && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
            && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
            && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
            && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
            && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
            && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
             && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
             && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
             || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
             && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
             && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
             && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
             && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
             && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
             && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                //Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Ny And Hello Dvl Letter Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7StmtNyAndDvlLetterPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = true;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 Stmt Ny And Dvl Letter Primary");


                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt7EDeliveryArchivePrimary(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                //Logger.Trace("ENDED:    To Get Option Arm Bk Chpt7 Stmt Ny And Dvl Letter Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt7EDeliveryArchivePrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = true;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt7 EDelivery Archive Primary");
                if (((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A07", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt13StmtPrimary(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A07", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A07", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Reaffirm_Dt_PackedData) != Convert.ToDateTime("00/00/00")

                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 7
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 11
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O")
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && (accountModel.EConsentModel.DocumentType == "Bill" && accountModel.EConsentModel.EConsentFlag == "Y"))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A07", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                //Logger.Trace("ENDED: To Get Option Arm Bk Chpt7 EDelivery Archive Primary");
            }
            catch (Exception ex) { Logger.Error(ex, ex.TargetSite.Name); throw; }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt13StmtPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt13 Stmt Primary");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt13StmtPrimaryForeign(accountModel);
                    return lstBrw;
                }

                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED: To Get Option Arm Bk Chpt13 Stmt Primary");
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
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt13 Stmt Primary Foreign");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED: To Get Option Arm Bk Chpt13 Stmt Primary Foreign");
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
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt13 Stmt Archive Only Primary");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                //Logger.Trace("ENDED: To Get Option Arm Bk Chpt13 Stmt Archive Only Primary");
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
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt13 Stmt Archive Only Ny Primary");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyHelloPrimary(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && (!CommonHelper.CheckAccountExistInSupplimentalFile(accountModel.MasterFileDataPart_1Model.Rssi_Acct_No)))
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                //Logger.Trace("ENDED: To Get Option Arm Bk Chpt13 Stmt Archive Only Ny Primary");
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
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt13 Stmt Archive Only Ny Hello Primary");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyHelloDvlPrimary(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                //Logger.Trace("ENDED: To Get Option Arm Bk Chpt13 Stmt Archive Only Ny Hello Primary");
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
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt13StmtArchiveOnlyNyDvlPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                     && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED: ");
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
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt13 Stmt Archive Only Ny Dvl Primary");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt13StmtNyAndHelloLetterPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y"
                    && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "HD", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                //Logger.Trace("ENDED: To Get Option Arm Bk Chpt13 Stmt Archive Only Ny Dvl Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt13StmtNyAndHelloLetterPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt13 Stmt Ny And Hello Letter Primary");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt13StmtNyAndHelloDvlLetterPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "HELLO", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED: To Get Option Arm Bk Chpt13 Stmt Ny And Hello Letter Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt13StmtNyAndHelloDvlLetterPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt13 Stmt Ny And Hello Dvl Letter Primary");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt13StmtNyAndDvlLetterPrimary(accountModel);
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "HELLO_DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "HELLO_DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }
                //Logger.Trace("ENDED: To Get Option Arm Bk Chpt13 Stmt Ny And Hello Dvl Letter Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt13StmtNyAndDvlLetterPrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt13 Stmt Ny And Dvl Letter Primary");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    lstBrw = GetOptionArmBkChpt13EDeliveryArchivePrimary(accountModel);
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y"
                     && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 33
                     && accountModel.MasterFileDataPart_1Model.Rssi_Lip_La_Date == "0"
                     && accountModel.MasterFileDataPart_1Model.Rssi_First_Stmt_Ind == "Y" && accountModel.SupplementalCCFModel.FlagRecordIndicator == "DVL")
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "FC", FlexField4 = "DVL", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                else
                {
                    ClearedPreviousStatement = false;
                    return lstBrw;
                }

                //Logger.Trace("ENDED: To Get Option Arm Bk Chpt13 Stmt Ny And Dvl Letter Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        public List<Borrower> GetOptionArmBkChpt13EDeliveryArchivePrimary(AccountsModel accountModel)
        {
            bool ClearedPreviousStatement = false;
            List<Borrower> lstBrw = new List<Borrower>();
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Option Arm Bk Chpt13 EDelivery Archive Primary");
                if ((Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                     && (accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")
                    )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Primary", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                        || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                        && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                        && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B"
                        && (accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")
                       )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "VEND", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && (accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")
                    )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = false, FlexField1 = "Copy1Primary", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                if (ClearedPreviousStatement && (Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 12
                     || Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_B_Chap) == 13)
                     && accountModel.BlendedRateInformationRecordModel.Rssi_Ml_Alt_Typ_Id == "O"
                     && accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y"
                     && (accountModel.EConsentModel.DocumentType == "Bill") && (accountModel.EConsentModel.EConsentFlag == "Y")
                    )
                {
                    ClearedPreviousStatement = true;
                    lstBrw.Add(new Borrower { DistinctAdditionalRecord = true, FlexField1 = "Copy2Vend", FlexField2 = "A13", FlexField3 = "IM", FlexField4 = "", FlexField5 = "Billing Statement", FlexField6 = "Bill" });
                }
                //Logger.Trace("ENDED: To Get Option Arm Bk Chpt13 EDelivery Archive Primary");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return lstBrw;
        }
        // 
    }
}
