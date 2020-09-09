using ODHS_EDelivery.Models.InputCopyBookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrington_Service.Calculation_Classes
{
    public class StandardBillingStatement
    {
        public string AmountDue { get; set; }
        public string Principal { get; set; }
        public string AssistanceAmount { get; set; }
        public string ReplacementReserveAmount { get; set; }
        public string OverduePayment { get; set; }
        public string TotalFeesAndCharges { get; set; }
        public string TotalFeesPaid { get; set; }
        public string TotalAmountDue { get; set; }
        public string PastDueBalance { get; set; }
        public string DeferredBalance { get; set; }
        public string UnappliedFunds { get; set; }
        public string FeesAndChargesPaidLastMonth { get; set; }
        public string UnappliedFundsPaidLastMonth { get; set; }
        public string TotalPaidLastMonth { get; set; }
        public string FeesAndChargesPaidYearToDate { get; set; }
        public string UnappliedFundsPaidYearToDate { get; set; }
        public string TotalPaidYearToDate { get; set; }
               
        public string LatePaymentAmount { get; set; }
        public string Suspense { get; set; }
        public string Miscellaneous { get; set; }
        public string TotalDue { get; set; }
       
        /* While Calculating Conditions must be applied*/
        public string GetAmountDue(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                AmountDue = "0";
            }
            else
            {
                AmountDue = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                    + Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData));
            }
            return AmountDue;
        }
        public string GetPrincipal(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                Principal = "0.00";
            }

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                Principal = "null";
            }
            else
            {
                Principal = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
                                 - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
            }
            return Principal;
        }
        public string GetAssistanceAmount(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                AssistanceAmount = "do not print the Assistance Amount line";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                AssistanceAmount = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                AssistanceAmount = "0.00";
            else
            {
                AssistanceAmount = accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData;
            }
            return AssistanceAmount;
        }
        public string GetReplacementReserveAmount(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
               - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
                - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
               + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0))
                ReplacementReserveAmount = "do not print the Replacement Reserve line";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                ReplacementReserveAmount = "0.00";

            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                ReplacementReserveAmount = "0.00";
            else
            {
                ReplacementReserveAmount = Convert.ToString(Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Pymt4_PackedData)
                                            - Convert.ToInt64(accountsModel.BlendedRateInformationRecordModel.Rssi_Alt_Chg_Amt4_PackedData)
                                            - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                            + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));


            }
            return ReplacementReserveAmount;
        }
        public string GetOverduePayment(AccountsModel accountsModel)
        {
            return OverduePayment = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                               - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData)
                               - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Pd_Since_Lst_Stmt_PackedData)
                               - Convert.ToInt64(GetTotalFeesAndCharges(accountsModel)));
        }
        public string GetTotalFeesAndCharges(AccountsModel accountsModel)
        {
            
            var Total = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)
            + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);

            if (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67))
            {
                TotalFeesAndCharges = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
            }
            else if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                    || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                    && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
            {
                TotalFeesAndCharges = Convert.ToString(Total - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
            }
            else
            {
                TotalFeesAndCharges = Convert.ToString(Total);
            }
          
            return TotalFeesAndCharges;
        }
        public string GetTotalFeesPaid(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                      + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                       Convert.ToInt64(GetTotalFeesAndCharges(accountsModel)))
            {
                TotalFeesPaid = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                    - Convert.ToInt64(GetTotalFeesAndCharges(accountsModel))));
            }
            else
                TotalFeesPaid = "0.00";

            return TotalFeesPaid;
        }
        public string GetTotalAmountDue(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                TotalAmountDue = "0.00";
            else
                TotalAmountDue = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                               + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));

            return TotalAmountDue;
        }

        public string GetPastDueBalance(AccountsModel accountsModel)
        {
            return Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) -
             Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) -
             Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData));
        }
        public string GetDeferredBalance(AccountsModel accountsModel)
        {
            if ((Convert.ToInt32(accountsModel.MasterFileDataPart2Model.TotalDeferredItemsBalance)
                - Convert.ToInt32(accountsModel.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance)) == 0)
            {
                DeferredBalance = "N/A";
            }
            else
            {
                DeferredBalance = Convert.ToString(Convert.ToInt32(accountsModel.MasterFileDataPart2Model.TotalDeferredItemsBalance)
                    - Convert.ToInt32(accountsModel.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance));
            }
            return DeferredBalance;
        }
        public string GetUnappliedFunds(AccountsModel accountsModel)
        {
            UnappliedFunds = Convert.ToString(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0);
            return UnappliedFunds;
        }
        public string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
              &&
              (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
            {
                FeesAndChargesPaidLastMonth = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData)
                + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData))
                - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
            }
            return FeesAndChargesPaidLastMonth;
        }
        public string GetUnappliedFundsPaidLastMonth(AccountsModel accountsModel)
        {
            UnappliedFundsPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData)
          + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
          + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3)
          + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04)
          + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05));

            return UnappliedFundsPaidLastMonth;
        }
        public string GetTotalPaidLastMonth(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
           &&
           (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
            {
                //Need to know and Add PriorMoAmnt in this section
                TotalPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData) - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
            }
            else
            {
                TotalPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData) - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
            }

            return TotalPaidLastMonth;
        }
        public string GetFeesAndChargesPaidYearToDate(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
             &&(Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
            {
                FeesAndChargesPaidYearToDate = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData))
                - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
            }
            return FeesAndChargesPaidYearToDate;
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountsModel)
        {
            UnappliedFundsPaidYearToDate = Convert.ToString(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0
              + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0);

            return UnappliedFundsPaidYearToDate;
        }
        public string GetTotalPaidYearToDate(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                          &&
                          (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
            {
                TotalPaidYearToDate = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData)
                                       + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData)
                                       + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData)
                                       + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                                       + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData)
                                       + accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
                                       + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0
                                       + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0
                                       + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0
                                       + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0)
                                       - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
            }

            return TotalPaidYearToDate;
        }
        public string GetLatePaymentAmount(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                LatePaymentAmount = "N/A";
            }
            else
            {
                LatePaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Amt_PackedData));
            }
            return LatePaymentAmount;
        }
        public string GetSuspense(AccountsModel accountsModel)
        {
            Suspense = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2));

            return Suspense;
        }
        public string GetMiscellaneous(AccountsModel accountsModel)
        {
            Miscellaneous = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Lip_PackedData)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Cr_Ins_PackedData)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Pi_Shrtg)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Prin_PackedData)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Int_PackedData)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Lc_PackedData)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Esc_PackedData)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData)
                );
            return Miscellaneous;
        }
        public string GetTotalDue(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                TotalDue = "0";
            }
            else
            {
                TotalDue = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
            }
            return TotalDue;
        }

    }
}
