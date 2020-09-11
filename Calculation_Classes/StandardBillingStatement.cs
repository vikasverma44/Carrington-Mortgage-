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

        public StringBuilder finalLine;
        public string GetFinalStringStandardBilling(AccountsModel accountModel)
        {
            finalLine = new StringBuilder();

            finalLine.Append("01" + "|");
            finalLine.Append("STD BK CHPT 7 STMT" + "|");
            finalLine.Append(" " + "|");
            finalLine.Append("01" + "|");

            finalLine.Append(GetAmountDue(accountModel) + "|");
            finalLine.Append(GetPrincipal(accountModel) + "|");
            finalLine.Append(GetAssistanceAmount(accountModel) + "|");
            finalLine.Append(GetReplacementReserveAmount(accountModel) + "|");
            finalLine.Append(GetOverduePayment(accountModel) + "|");
            finalLine.Append(GetTotalFeesAndCharges(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaid(accountModel) + "|");
            finalLine.Append(GetTotalAmountDue(accountModel) + "|");
            finalLine.Append(GetPastDueBalance(accountModel) + "|");
            finalLine.Append(GetDeferredBalance(accountModel) + "|");
            finalLine.Append(GetUnappliedFunds(accountModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetTotalPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetTotalPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetLatePaymentAmount(accountModel) + "|");
            finalLine.Append(GetSuspense(accountModel) + "|");
            finalLine.Append(GetMiscellaneous(accountModel) + "|");
            finalLine.Append(GetTotalDue(accountModel) + "|");
            finalLine.Append(GetPrintStatement(accountModel) + "|");
            finalLine.Append(GetAttention(accountModel) + "|");
            finalLine.Append(GetPrimaryBorrower(accountModel) + "|");
            finalLine.Append(GetSecondaryBorrower(accountModel) + "|");
            finalLine.Append(GetMailingAddressLine1(accountModel) + "|");
            finalLine.Append(GetMailingAddressLine2(accountModel) + "|");
            finalLine.Append(GetMailingCityStateZip(accountModel) + "|");
            finalLine.Append(GetMailingCountry(accountModel) + "|");
            finalLine.Append(GetPaymentReceivedAfter(accountModel) + "|");
            finalLine.Append(GetLateFee(accountModel) + "|");
            finalLine.Append(GetAutodraftMessage(accountModel) + "|");
            finalLine.Append(GetInterestRateUnti(accountModel) + "|");
            finalLine.Append(GetPrepaymentPenalty(accountModel) + "|");
            finalLine.Append(GetMaturityDate(accountModel) + "|");
            finalLine.Append(GetmodificationDate(accountModel) + "|");
            finalLine.Append(GetChargeOffNoticeDelinquencyNoticeRefinanceMessage(accountModel) + "|");
            finalLine.Append(GetInterest(accountModel) + "|");
            finalLine.Append(GetEscrowTaxesInsurance(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPayment(accountModel) + "|");
            finalLine.Append(GetBuydownBalance(accountModel) + "|");
            finalLine.Append(GetPartialClaim(accountModel) + "|");
            finalLine.Append(GetNegativeAmortization(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitableFoundationMonth(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitablePaidYeartoDate(accountModel) + "|");
            finalLine.Append(GetLockboxAddress(accountModel) + "|");
            finalLine.Append(GetReceivedAfter(accountModel) + "|");
            finalLine.Append(GetLateCharge(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitableDonationbox(accountModel) + "|");
            finalLine.Append(GetEffectiveDate(accountModel) + "|");
            finalLine.Append(GetTotalAmount(accountModel) + "|");
            finalLine.Append(GetDelinquencyInformationbox(accountModel) + "|");
            finalLine.Append(GetRecentPayment6(accountModel) + "|");
            finalLine.Append(GetRecentPayment5(accountModel) + "|");
            finalLine.Append(GetRecentPayment4(accountModel) + "|");
            finalLine.Append(GetRecentPayment3(accountModel) + "|");
            finalLine.Append(GetRecentPayment2(accountModel) + "|");
            finalLine.Append(GetRecentPayment1(accountModel) + "|");
            finalLine.Append(GetLossMitigtationNotice(accountModel) + "|");
            finalLine.Append(GetForeclosureNotice(accountModel) + "|");
            finalLine.Append(GetPreForeclosureNotice(accountModel) + "|");
            finalLine.Append(GetLenderPlacedInsuranceMessage(accountModel) + "|");
            finalLine.Append(GetBankruptcyMessage(accountModel) + "|");
            finalLine.Append(GetRepaymentPlanMessage(accountModel) + "|");
            finalLine.Append(GetStateNSF(accountModel) + "|");
            finalLine.Append(GetACHMessage(accountModel) + "|");
            finalLine.Append(GetChargeOffNotice(accountModel) + "|");
            finalLine.Append(GetCMSPartialClaim(accountModel) + "|");
            finalLine.Append(GetHUDPartialClaim(accountModel) + "|");
            finalLine.Append(GetStateDisclosures(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitableFoundation(accountModel) + "|");
            finalLine.Append(GetPaymentInformationMessage(accountModel) + "|");



            return Convert.ToString(finalLine);
        }
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
            if ((Convert.ToInt32(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal)
                - Convert.ToInt32(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData)) == 0)
            {
                DeferredBalance = "N/A";
            }
            else
            {
                DeferredBalance = Convert.ToString(Convert.ToInt32(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal)
                    - Convert.ToInt32(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
            }
            return DeferredBalance;
        }
        public string GetUnappliedFunds(AccountsModel accountsModel)
        {
            UnappliedFunds = Convert.ToString(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
              + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
              + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
              + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
              + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);
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
             && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
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
              + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
              + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
              + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
              + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);

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
                                       + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
                                       + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
                                       + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
                                       + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0)
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

        #region MyRegion Ambrish
        public string GetPrintStatement(AccountsModel accountsModel)
        {
            String printStatement = string.Empty;


            if (accountsModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") { printStatement = "create image but do not mail"; }

            return printStatement;
        }

        public string GetAttention(AccountsModel accountsModel)
        {

            String attention = string.Empty;
            if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") { attention = "then attention name null for copy 2"; }
            return attention;
        }


        public string GetPrimaryBorrower(AccountsModel accountsModel)
        {

            String primaryBorrower = string.Empty;

            if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR1-F"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR2-F"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR3-F"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR4-F"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR5-F"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR6-F"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR1-F"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR8-F"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR9-F"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") { primaryBorrower = "copy 2 to RSSI-CB-CBWR10-F"; }

            return primaryBorrower;
        }


        public string GetSecondaryBorrower(AccountsModel accountsModel)
        {

            String secondaryBorrower = string.Empty;

            if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") { secondaryBorrower = "then secondary name null for copy 2"; }
            return secondaryBorrower;
        }

        public string GetMailingAddressLine1(AccountsModel accountsModel)
        {

            String mailingAddressLine1 = string.Empty;
            if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR01-ADRS1"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR02-ADRS1"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR03-ADRS1"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR04-ADRS1"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR05-ADRS1"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR06-ADRS1"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR07-ADRS1"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR08-ADRS1"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR09-ADRS1"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") { mailingAddressLine1 = "then copy 2 to CB-CBWR10-ADRS1"; }
            return mailingAddressLine1;
        }

        public string GetMailingAddressLine2(AccountsModel accountsModel)
        {

            String mailingAddressLine2 = string.Empty;
            if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR01 - ADRS2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR02-ADRS2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR03-ADRS2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR04-ADRS2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR05-ADRS2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR06-ADRS2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR07-ADRS2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR08-ADRS2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR09-ADRS2"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") { mailingAddressLine2 = "then copy 2 to CB-CBWR10-ADRS2"; }
            return mailingAddressLine2;


        }

        public string GetMailingCityStateZip(AccountsModel accountsModel)
        {

            String mailingCityStateZip = string.Empty;

            if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") { mailingCityStateZip = " RSSI-CB_CBWR1_CITY, RSSI-CB-CBWR1-STATE RSSI-CB-CBWR1-ZIP"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR2_CITY, RSSI-CB-CBWR2-STATE RSSI-CB-CBWR2-ZIP"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR3_CITY, RSSI-CB-CBWR3-STATE RSSI-CB-CBWR3-ZIP"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR4_CITY, RSSI-CB-CBWR4-STATE RSSI-CB-CBWR4-ZIP"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR5_CITY, RSSI-CB-CBWR5-STATE RSSI-CB-CBWR5-ZIP"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR6_CITY, RSSI-CB-CBWR6-STATE RSSI-CB-CBWR6-ZIP"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR7_CITY, RSSI-CB-CBWR7-STATE RSSI-CB-CBWR7-ZIP"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR8_CITY, RSSI-CB-CBWR8-STATE RSSI-CB-CBWR8-ZIP"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR9_CITY, RSSI-CB-CBWR9-STATE RSSI-CB-CBWR9-ZIP"; }
            else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") { mailingCityStateZip = "copy 2 to RSSI-CB-CBWR10-ITY, RSSI-CB-CBWR10-STATE RSSI-CB-CBWR10-ZIP"; }

            return mailingCityStateZip;


        }

        public string GetMailingCountry(AccountsModel accountsModel)
        {

            String mailingCountry = string.Empty;

            if (accountsModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y") { mailingCountry = "then RSSI-ALTR-CNTRY"; }
            else if (accountsModel.MasterFileDataPart2Model.Rssi_Prim_Forgn_Flag == "Y") { mailingCountry = "then RSSI-PRIM-MAIL-COUNTRY"; }
            else if (accountsModel.MasterFileDataPart2Model.Rssi_Appl_Foreign_Flag == "Y") { mailingCountry = "hen RSSI-APPL-COUNTRY"; }
            else { mailingCountry = null; }

            return mailingCountry;
        }

        public string GetPaymentReceivedAfter(AccountsModel accountsModel)
        {
            String paymentReceivedAfter = string.Empty;

            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0) { paymentReceivedAfter = "suppress Late Charge message"; }


            return paymentReceivedAfter;
        }

        public string GetLateFee(AccountsModel accountsModel)
        {
            String lateFee = string.Empty;
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0) { lateFee = "suppress Late Charge message"; }


            return lateFee;
        }

        public string GetAutodraftMessage(AccountsModel accountsModel)
        {

            String autodraftMessage = string.Empty;

            if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0 &&
              Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
            {
                autodraftMessage = "then print Autodraft message.";
            }

            return autodraftMessage;
        }

        public string GetInterestRateUnti(AccountsModel accountsModel)
        {

            String interestRateUnti = string.Empty;

            if (long.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date) > 19000000) { interestRateUnti = "(Until RSSI-RATE-CHG-DATE)"; } else { interestRateUnti = null; }

            return interestRateUnti;
        }

        public string GetPrepaymentPenalty(AccountsModel accountsModel)
        {

            String prepaymentPenalty = string.Empty;

            if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0) { prepaymentPenalty = "Yes"; } else { prepaymentPenalty = "No"; }

            return prepaymentPenalty;
        }

        public string GetMaturityDate(AccountsModel accountsModel)
        {

            String maturityDate = string.Empty;

            if (long.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Balloon_Date) > 19000000) { maturityDate = "RSSI-BALLOON-DATE"; }
            else { maturityDate = "RSSI - MAT - DATE"; }

            return maturityDate;
        }


        public string GetmodificationDate(AccountsModel accountsModel)
        {

            String modificationDate = string.Empty;

            if (long.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Balloon_Date) > 19000000) { modificationDate = "RSSI-MODIFY-DATE"; }
            else { modificationDate = "N / A"; }

            return modificationDate;
        }


        public string GetChargeOffNoticeDelinquencyNoticeRefinanceMessage(AccountsModel accountsModel)
        {

            String chargeOffNoticeDelinquencyNoticeRefinanceMessage = string.Empty;

            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0) { chargeOffNoticeDelinquencyNoticeRefinanceMessage = "print the Charge Off Notice"; }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30 && Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
            { chargeOffNoticeDelinquencyNoticeRefinanceMessage = "You are late on your mortgage payments.Failure to bring your loan current may result in fees and foreclosure - the loss of your home. See additional comments related to the Delinquency Box on page 2."; }
            else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) < 30 && Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0) { chargeOffNoticeDelinquencyNoticeRefinanceMessage = "the Refinance Message"; }


            return chargeOffNoticeDelinquencyNoticeRefinanceMessage;
        }


        public string GetInterest(AccountsModel accountsModel)
        {

            String interest = string.Empty;

            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0 ||
              Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                interest = "0.00";
            }

            return interest;
        }

        public string GetEscrowTaxesInsurance(AccountsModel accountsModel)
        {

            String escrowTaxesInsurance = string.Empty;

            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0 ||
               Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                escrowTaxesInsurance = "0.00";
            }

            return escrowTaxesInsurance;
        }

        public string GetRegularMonthlyPayment(AccountsModel accountsModel)
        {

            String regularMonthlyPayment = string.Empty;
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
            {
                regularMonthlyPayment = "0.00";
            }

            return regularMonthlyPayment;
        }

        public string GetBuydownBalance(AccountsModel accountsModel)
        {

            String buydownBalance = string.Empty;

            if (Convert.ToInt64(accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) < 0)
            {
                buydownBalance = "N/A";
            }
            else
            {
                buydownBalance = "RSSI - USR - 303";
            }
            return buydownBalance;
        }

        public string GetPartialClaim(AccountsModel accountsModel)
        {

            String partialClaim = string.Empty;

            if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0) { partialClaim = "N/A"; } else { partialClaim = "RSSI - DEF - UNPD - EXP - ADV - BAL"; }



            return partialClaim;
        }

        public string GetNegativeAmortization(AccountsModel accountsModel)
        {

            String negativeAmortization = string.Empty;


            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Neg_Amort_Taken_PackedData) == 0)
            {
                negativeAmortization = "N/A";
            }
            else
            {
                negativeAmortization = "RSSI - NEG - AMORT - TAKEN";
            }
            return negativeAmortization;
        }

        public string GetCarringtonCharitableFoundationMonth(AccountsModel accountsModel)
        {

            String carringtonCharitableFoundation = string.Empty;

            if (int.Parse(accountsModel.detModel.PriorMoAmnt) > 0 || int.Parse(accountsModel.detModel.YTDAmnt) > 0) { carringtonCharitableFoundation = "print Carrington Charitable Foundation Donation line."; }

            return carringtonCharitableFoundation;
        }

        public string GetCarringtonCharitablePaidYeartoDate(AccountsModel accountsModel)
        {

            String carringtonCharitablePaidYeartoDate = string.Empty;

            if (int.Parse(accountsModel.detModel.PriorMoAmnt) > 0 || int.Parse(accountsModel.detModel.YTDAmnt) > 0) { carringtonCharitablePaidYeartoDate = "print Carrington Charitable Foundation Donation line."; }

            return carringtonCharitablePaidYeartoDate;
        }

        public string GetLockboxAddress(AccountsModel accountsModel)
        {

            String lockboxAddress = string.Empty;

            if (accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA" ||
                accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK" ||
                accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX") { lockboxAddress = "Dallas P.O.Box Address else Pasadena P.O.Box Address"; }

            return lockboxAddress;
        }

        public string GetReceivedAfter(AccountsModel accountsModel)
        {

            String receivedAfter = string.Empty;

            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                receivedAfter = "suppress Late Charge message.";
            }
            return receivedAfter;
        }

        public string GetLateCharge(AccountsModel accountsModel)
        {

            String lateCharge = string.Empty;
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
            {
                lateCharge = "suppress Late Charge message.";
            }


            return lateCharge;
        }

        public string GetCarringtonCharitableDonationbox(AccountsModel accountsModel)
        {

            String carringtonCharitableDonationbox = string.Empty;

            if (accountsModel.detModel.Eligible == "Yes") { carringtonCharitableDonationbox = "print the Carrington Charitable Foundation Donation box."; }

            return carringtonCharitableDonationbox;
        }

        public string GetEffectiveDate(AccountsModel accountsModel)
        {

            String effectiveDate = string.Empty;

            // if (RSSI_FT_TYPE_CODE == 000) { effectiveDate = "RSSI-FEE-DATE-ASSESSED"; } else { effectiveDate= "RSSI-TR-DATE" }

            return effectiveDate;
        }

        public string GetTotalAmount(AccountsModel accountsModel)
        {

            String totalAmount = string.Empty;

            if (int.Parse(accountsModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData) != 0) { totalAmount = "RSSI-TR-EXP-FEE-AMT"; }
            //else if (RSSI_FT_TYPE_CODE == 000) { totalAmount="RSSI-FEE-AMT-ASSESSED"; } else { totalAmount= "RSSI-TR-AMT";}

            return totalAmount;
        }

        public string GetDelinquencyInformationbox(AccountsModel accountsModel)
        {

            String delinquencyInformationbox = string.Empty;


            if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30 && Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
            {
                delinquencyInformationbox = "include the Delinquency Notice section, else leave blank.";
            }


            return delinquencyInformationbox;
        }

        public string GetRecentPayment6(AccountsModel accountsModel)
        {

            String recentPayment6 = string.Empty;


            if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1) { recentPayment6 = "Payment Due RSSI-PMT-DUE-5-DATE: Fully paid on RSSI-PMT-PAID-5-DATE"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2) { recentPayment6 = "Payment Due RSSI - PMT - DUE - 4 - DATE: Fully paid on RSSI-PMT - PAID - 4 - DATE"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3) { recentPayment6 = "Payment Due RSSI - PMT - DUE - 3 - DATE: Fully paid on RSSI-PMT - PAID - 3 - DATE"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4) { recentPayment6 = "Payment Due RSSI - PMT - DUE - 2 - DATE: Fully paid on RSSI-PMT - PAID - 2 - DATE"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5) { recentPayment6 = "Payment Due RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }

            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
            {
                recentPayment6 = "Payment Due RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)";
            }



            return recentPayment6;
        }

        public string GetRecentPayment5(AccountsModel accountsModel)
        {

            String recentPayment5 = string.Empty;

            if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1) { recentPayment5 = "Payment Due RSSI-PMT-DUE-4-DATE: Fully paid on RSSI-PMT-PAID-5-DATE"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2) { recentPayment5 = "Payment Due RSSI - PMT - DUE - 3 - DATE: Fully paid on RSSI-PMT - PAID - 3 - DATE"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3) { recentPayment5 = "Payment Due RSSI - PMT - DUE - 2 - DATE: Fully paid on RSSI-PMT - PAID - 2 - DATE"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4) { recentPayment5 = "Payment Due RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { recentPayment5 = "Payment Due RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }

            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
            {
                recentPayment5 = "Payment Due RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)";
            }

            return recentPayment5;
        }

        public string GetRecentPayment4(AccountsModel accountsModel)
        {

            String recentPayment4 = string.Empty;

            if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1) { recentPayment4 = "Payment Due RSSI-PMT-DUE-3-DATE: Fully paid on RSSI-PMT-PAID-3-DATE"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2) { recentPayment4 = "Payment Due RSSI - PMT - DUE - 2 - DATE: Fully paid on RSSI-PMT - PAID - 2 - DATE"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3) { recentPayment4 = "Payment Due RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { recentPayment4 = "Payment Due RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { recentPayment4 = "Payment Due RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }

            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
            {
                recentPayment4 = "Payment Due RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)";
            }

            return recentPayment4;
        }


        public string GetRecentPayment3(AccountsModel accountsModel)
        {

            String RecentPayment2 = string.Empty;

            if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1) { RecentPayment2 = "Payment Due RSSI-PMT-DUE-2-DATE: Fully paid on RSSI-PMT-PAID-2-DATE"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2) { RecentPayment2 = "Payment Due RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) > 0) { RecentPayment2 = "Payment Due RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) > 0) { RecentPayment2 = "Payment Due RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) > 0) { RecentPayment2 = "Payment Due RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }

            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) > 0 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
            {
                RecentPayment2 = "Payment Due RSSI - PAST - DATE(4): Unpaid balance of $RSSI - REG - AMT(4)";
            }

            return RecentPayment2;
        }

        public string GetRecentPayment2(AccountsModel accountsModel)
        {

            String RecentPayment2 = string.Empty;

            if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1) { RecentPayment2 = "Payment Due RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment2 = "Payment Due RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment2 = "Payment Due RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment2 = "Payment Due RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment2 = "Payment Due RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }

            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
            {
                RecentPayment2 = "Payment Due RSSI - PAST - DATE(5): Unpaid balance of $RSSI - REG - AMT(5)";
            }

            return RecentPayment2;
        }

        public string GetRecentPayment1(AccountsModel accountsModel)
        {

            String RecentPayment1 = string.Empty;

            if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment1 = "Payment Due RSSI-PAST-DATE (1): Unpaid balance of $RSSI-REG-AMT (1)"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment1 = "Payment Due RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment1 = "Payment Due RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment1 = "Payment Due RSSI - PAST - DATE(4): Unpaid balance of $RSSI - REG - AMT(4)"; }
            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment1 = "Payment Due RSSI - PAST - DATE(5): Unpaid balance of $RSSI - REG - AMT(5)"; }

            else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
            {
                RecentPayment1 = "Payment Due RSSI - PAST - DATE(6): Unpaid balance of $RSSI - REG - AMT(6)";
            }

            return RecentPayment1;
        }


        public string GetLossMitigtationNotice(AccountsModel accountsModel)
        {

            String lossMitigtationNotice = string.Empty;

            if (int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) == (2 - 10) || int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) == (12 - 14))
            {
                lossMitigtationNotice = "PLEASE TAKE NOTICE that You have agreed to the following loss mitigation program: [Program Name].";
            }

            return lossMitigtationNotice;
        }


        public string GetForeclosureNotice(AccountsModel accountsModel)
        {

            String foreclosureNotice = string.Empty;

            if (int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Fcl_Start_Date) > 0)
            {
                foreclosureNotice = "PLEASE TAKE NOTICE that Carrington Mortgage Services, LLC has made the first notice or filing required to start a foreclosure.";
            }

            return foreclosureNotice;
        }

        public string GetPreForeclosureNotice(AccountsModel accountsModel)
        {

            String preForeclosureNotice = string.Empty;

            if (int.Parse(accountsModel.detModel.SentNO631) == 1)
            {
                preForeclosureNotice = "LEASE TAKE NOTICE that Carrington Mortgage Services, LLC has fulfilled, the pre - foreclosure notice requirements of Real Property Actions and Proceedings Law §1304 or Uniform Commercial Code § 9‐611(f), if applicable.     ";
            }
            else if (int.Parse(accountsModel.detModel.SentNO631) == 0) { preForeclosureNotice = "do not print pre - foreclosure message"; }
            return preForeclosureNotice;
        }

        public string GetLenderPlacedInsuranceMessage(AccountsModel accountsModel)
        {

            String lenderPlacedInsuranceMessage = string.Empty;
            if (accountsModel.EscrowRecordModel.rssi_esc_type == "20" || accountsModel.EscrowRecordModel.rssi_esc_type == "21" &&
                accountsModel.EscrowRecordModel.Rssi_Ins_Co == "2450" && accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "29000" ||
                accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "29005" || accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "43000" ||
                accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "43001")
            { lenderPlacedInsuranceMessage = "then print Lender Placed Insurance message"; }

            return lenderPlacedInsuranceMessage;
        }

        public string GetBankruptcyMessage(AccountsModel accountsModel)
        {

            String bankruptcyMessage = string.Empty;


            if (Convert.ToDateTime(accountsModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Dschg_Dt_PackedData) > Convert.ToDateTime("00/00/00") &&
                Convert.ToDateTime(accountsModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Dschg_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
            {
                bankruptcyMessage = "print Bankruptcy message.";
            }
            return bankruptcyMessage;
        }

        public string GetRepaymentPlanMessage(AccountsModel accountsModel)
        {
            String repaymentPlanMessage = string.Empty;
            if (accountsModel.MasterFileDataPart_1Model.Rssi_Repy_Remain_Bal_PackedData != "00000C")
            {
                repaymentPlanMessage = "";
            }

            return repaymentPlanMessage;
        }

        public string GetStateNSF(AccountsModel accountsModel)
        {

            String stateNSF = string.Empty;

            if (accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "6" || accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "16"
               || accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "18" || accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "42")
            { stateNSF = "print State NSF message"; }

            return stateNSF;
        }

        public string GetACHMessage(AccountsModel accountsModel)
        {

            String stateNSF = string.Empty;
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) == 0 &&
                Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) == 0)
            {
                stateNSF = "AutoPay Service message";
            }

            return stateNSF;
        }

        public string GetChargeOffNotice(AccountsModel accountsModel)
        {

            String chargeOffNotice = string.Empty;

            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0)
            {
                chargeOffNotice = "print Charge Off message";
            }

            return chargeOffNotice;
        }

        public string GetCMSPartialClaim(AccountsModel accountsModel)
        {


            String chargeOffNotice = string.Empty;
            if (int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "C") { chargeOffNotice = "print CMS Partial Claim Message."; }

            return chargeOffNotice;
        }

        public string GetHUDPartialClaim(AccountsModel accountsModel)
        {

            String hUDPartialClaim = string.Empty;
            if (int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "H") { hUDPartialClaim = "print HUD Partial Claim Message."; }


            return hUDPartialClaim;
        }

        public string GetStateDisclosures(AccountsModel accountsModel)
        {
            string stateDisclosures = string.Empty;
            var RSSISTATE = "4, 6, 12, 22, 24, 33, 34, 43, 44 ";
            var MailingState = "AR, CO, HI, MA, MN, NC, NY, TN, TX ";

            if (RSSISTATE.Contains(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData))
            { stateDisclosures = ""; }
            else if (MailingState.Contains(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
            { stateDisclosures = ""; }

            return stateDisclosures;
        }

        public string GetCarringtonCharitableFoundation(AccountsModel accountsModel)
        {

            String carringtonCharitableFoundation = string.Empty;

            if (accountsModel.detModel.Eligible == "Yes" || int.Parse(accountsModel.detModel.PriorMoAmnt) > 0 || int.Parse(accountsModel.detModel.YTDAmnt) > 0)
            { carringtonCharitableFoundation = "print the Carrington Charitable Foundation verbiage."; }


            return carringtonCharitableFoundation;
        }

        public string GetPaymentInformationMessage(AccountsModel accountsModel)
        {
            String paymentInformationMessage = string.Empty;

            if (accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA" ||
                accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK"
                || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX") { paymentInformationMessage = "Dallas P.O.Box Address else Pasadena P.O.Box Address"; }

            return paymentInformationMessage;
        }
        #endregion Ambrish

    }
}
