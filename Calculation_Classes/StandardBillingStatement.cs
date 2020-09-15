using Carrington_Service.Infrastructure;
using CarringtonMortgage.Models.InputCopyBookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrington_Service.Calculation_Classes
{
    public class StandardBillingStatement : IStandardBillingStatement
    {
        private string AmountDue { get; set; }
        private string Principal { get; set; }
        private string AssistanceAmount { get; set; }
        private string ReplacementReserveAmount { get; set; }
        private string OverduePayment { get; set; }
        private string TotalFeesAndCharges { get; set; }
        private string TotalFeesPaid { get; set; }
        private string TotalAmountDue { get; set; }
        private string PastDueBalance { get; set; }
        private string DeferredBalance { get; set; }
        private string UnappliedFunds { get; set; }
        private string FeesAndChargesPaidLastMonth { get; set; }
        private string UnappliedFundsPaidLastMonth { get; set; }
        private string TotalPaidLastMonth { get; set; }
        private string FeesAndChargesPaidYearToDate { get; set; }
        private string UnappliedFundsPaidYearToDate { get; set; }
        private string TotalPaidYearToDate { get; set; }

        private string LatePaymentAmount { get; set; }
        private string Suspense { get; set; }
        private string Miscellaneous { get; set; }
        private string TotalDue { get; set; }
        private string DueBalance { get; set; }
        private string ExMessage { get; set; }
        private ILogger Logger;
        private StringBuilder finalLine;
        public string GetFinalStringStandardBilling(AccountsModel accountModel)
        {
            ExMessage = "Error Message";
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
        private string GetAmountDue(AccountsModel accountsModel)
        {
            try
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
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetAmountDue" + ExMessage);
            }
            return AmountDue;
        }
        private string GetPrincipal(AccountsModel accountsModel)
        {
            try
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
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetPrincipal" + ExMessage);
            }
            return Principal;
        }
        private string GetAssistanceAmount(AccountsModel accountsModel)
        {
            try
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
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetAssistanceAmount" + ExMessage);
            }
            return AssistanceAmount;
        }
        private string GetReplacementReserveAmount(AccountsModel accountsModel)
        {
            try
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
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetReplacementReserveAmount" + ExMessage);
            }
            return ReplacementReserveAmount;
        }
        private string GetOverduePayment(AccountsModel accountsModel)
        {
            try
            {
                OverduePayment = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                      - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData)
                                      - Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Pd_Since_Lst_Stmt_PackedData)
                                      - Convert.ToInt64(GetTotalFeesAndCharges(accountsModel)));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetOverduePayment" + ExMessage);
            }

            return OverduePayment;
        }
        private string GetTotalFeesAndCharges(AccountsModel accountsModel)
        {

            try
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
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetTotalFeesAndCharges" + ExMessage);
            }

            return TotalFeesAndCharges;
        }
        private string GetTotalFeesPaid(AccountsModel accountsModel)
        {
            try
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
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetTotalFeesPaid" + ExMessage);
            }

            return TotalFeesPaid;
        }
        private string GetTotalAmountDue(AccountsModel accountsModel)
        {
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDue = "0.00";
                else
                    TotalAmountDue = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                   + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetTotalAmountDue" + ExMessage);
            }
            return TotalAmountDue;
        }

        private string GetPastDueBalance(AccountsModel accountsModel)
        {
            try
            {
                DueBalance = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) -
                  Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) -
                  Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData));
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetPastDueBalance" + ExMessage);
            }

            return DueBalance;
        }
        private string GetDeferredBalance(AccountsModel accountsModel)
        {
            try
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetDeferredBalance" + ExMessage);
            }
            return DeferredBalance;
        }
        private string GetUnappliedFunds(AccountsModel accountsModel)
        {
            try
            {
                UnappliedFunds = Convert.ToString(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetUnappliedFunds" + ExMessage);
            }
            return UnappliedFunds;
        }
        private string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel)
        {
            try
            {
                if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                      &&
                      (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                {
                    FeesAndChargesPaidLastMonth = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData))
                    - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetFeesAndChargesPaidLastMonth" + ExMessage);
            }
            return FeesAndChargesPaidLastMonth;
        }
        private string GetUnappliedFundsPaidLastMonth(AccountsModel accountsModel)
        {
            try
            {
                UnappliedFundsPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData)
                 + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
                 + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3)
                 + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04)
                 + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05));
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetUnappliedFundsPaidLastMonth" + ExMessage);

            }

            return UnappliedFundsPaidLastMonth;
        }
        private string GetTotalPaidLastMonth(AccountsModel accountsModel)
        {
            try
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
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetTotalPaidLastMonth" + ExMessage);

            }

            return TotalPaidLastMonth;
        }
        private string GetFeesAndChargesPaidYearToDate(AccountsModel accountsModel)
        {
            try
            {
                if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                    && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                {
                    FeesAndChargesPaidYearToDate = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData))
                    - Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetFeesAndChargesPaidYearToDate" + ExMessage);

            }
            return FeesAndChargesPaidYearToDate;
        }
        private string GetUnappliedFundsPaidYearToDate(AccountsModel accountsModel)
        {
            try
            {
                UnappliedFundsPaidYearToDate = Convert.ToString(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
                     + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
                     + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
                     + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
                     + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetUnappliedFundsPaidYearToDate" + ExMessage);

            }
            return UnappliedFundsPaidYearToDate;
        }
        private string GetTotalPaidYearToDate(AccountsModel accountsModel)
        {
            try
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

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetTotalPaidYearToDate" + ExMessage);
            }
            return TotalPaidYearToDate;
        }
        private string GetLatePaymentAmount(AccountsModel accountsModel)
        {
            try
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetLatePaymentAmount" + ExMessage);

            }
            return LatePaymentAmount;
        }
        private string GetSuspense(AccountsModel accountsModel)
        {
            try
            {
                Suspense = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData)
                       + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
                       + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
                       + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2)
                       + Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetSuspense" + ExMessage);

            }

            return Suspense;
        }
        private string GetMiscellaneous(AccountsModel accountsModel)
        {
            try
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetMiscellaneous" + ExMessage);

            }
            return Miscellaneous;
        }
        private string GetTotalDue(AccountsModel accountsModel)
        {
            try
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetTotalDue" + ExMessage);

            }
            return TotalDue;
        }

        #region MyRegion Ambrish
        private string GetPrintStatement(AccountsModel accountsModel)
        {
            String printStatement = string.Empty;
            try
            {
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") { printStatement = "create image but do not mail"; }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetTotalDue" + ExMessage);
            }

            return printStatement;
        }

        private string GetAttention(AccountsModel accountsModel)
        {

            String attention = string.Empty;
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetAttention" + ExMessage);

            }
            return attention;
        }


        private string GetPrimaryBorrower(AccountsModel accountsModel)
        {

            String primaryBorrower = string.Empty;

            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetPrimaryBorrower" + ExMessage);

            }

            return primaryBorrower;
        }


        private string GetSecondaryBorrower(AccountsModel accountsModel)
        {

            String secondaryBorrower = string.Empty;

            try
            {
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
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetSecondaryBorrower" + ExMessage);

            }
            return secondaryBorrower;
        }

        private string GetMailingAddressLine1(AccountsModel accountsModel)
        {

            String mailingAddressLine1 = string.Empty;
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetMailingAddressLine1" + ExMessage);

            }
            return mailingAddressLine1;
        }

        private string GetMailingAddressLine2(AccountsModel accountsModel)
        {

            String mailingAddressLine2 = string.Empty;
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetMailingAddressLine2" + ExMessage);

            }
            return mailingAddressLine2;


        }

        private string GetMailingCityStateZip(AccountsModel accountsModel)
        {

            String mailingCityStateZip = string.Empty;

            try
            {
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

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetMailingCityStateZip" + ExMessage);

            }
            return mailingCityStateZip;


        }

        private string GetMailingCountry(AccountsModel accountsModel)
        {

            String mailingCountry = string.Empty;

            try
            {
                if (accountsModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y") { mailingCountry = "then RSSI-ALTR-CNTRY"; }
                else if (accountsModel.MasterFileDataPart2Model.Rssi_Prim_Forgn_Flag == "Y") { mailingCountry = "then RSSI-PRIM-MAIL-COUNTRY"; }
                else if (accountsModel.MasterFileDataPart2Model.Rssi_Appl_Foreign_Flag == "Y") { mailingCountry = "hen RSSI-APPL-COUNTRY"; }
                else { mailingCountry = null; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetMailingCountry" + ExMessage);

            }

            return mailingCountry;
        }

        private string GetPaymentReceivedAfter(AccountsModel accountsModel)
        {
            String paymentReceivedAfter = string.Empty;

            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0) { paymentReceivedAfter = "suppress Late Charge message"; }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetPaymentReceivedAfter" + ExMessage);

            }


            return paymentReceivedAfter;
        }

        private string GetLateFee(AccountsModel accountsModel)
        {
            String lateFee = string.Empty;
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0) { lateFee = "suppress Late Charge message"; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetLateFee" + ExMessage);
            }
            return lateFee;
        }

        private string GetAutodraftMessage(AccountsModel accountsModel)
        {

            String autodraftMessage = string.Empty;

            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0 &&
                     Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    autodraftMessage = "then print Autodraft message.";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetAutodraftMessage" + ExMessage);
            }

            return autodraftMessage;
        }

        private string GetInterestRateUnti(AccountsModel accountsModel)
        {

            String interestRateUnti = string.Empty;

            try
            {
                if (long.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date) > 19000000) { interestRateUnti = "(Until RSSI-RATE-CHG-DATE)"; } else { interestRateUnti = null; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetInterestRateUnti" + ExMessage);

            }

            return interestRateUnti;
        }

        private string GetPrepaymentPenalty(AccountsModel accountsModel)
        {

            String prepaymentPenalty = string.Empty;

            try
            {
                if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0) { prepaymentPenalty = "Yes"; } else { prepaymentPenalty = "No"; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetPrepaymentPenalty" + ExMessage);
            }

            return prepaymentPenalty;
        }

        private string GetMaturityDate(AccountsModel accountsModel)
        {

            String maturityDate = string.Empty;

            try
            {
                if (long.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Balloon_Date) > 19000000) { maturityDate = "RSSI-BALLOON-DATE"; }
                else { maturityDate = "RSSI - MAT - DATE"; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetMaturityDate" + ExMessage);

            }

            return maturityDate;
        }


        private string GetmodificationDate(AccountsModel accountsModel)
        {

            String modificationDate = string.Empty;

            try
            {
                if (long.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Balloon_Date) > 19000000) { modificationDate = "RSSI-MODIFY-DATE"; }
                else { modificationDate = "N / A"; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetmodificationDate" + ExMessage);

            }

            return modificationDate;
        }


        private string GetChargeOffNoticeDelinquencyNoticeRefinanceMessage(AccountsModel accountsModel)
        {

            String chargeOffNoticeDelinquencyNoticeRefinanceMessage = string.Empty;

            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0) { chargeOffNoticeDelinquencyNoticeRefinanceMessage = "print the Charge Off Notice"; }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30 && Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                { chargeOffNoticeDelinquencyNoticeRefinanceMessage = "You are late on your mortgage payments.Failure to bring your loan current may result in fees and foreclosure - the loss of your home. See additional comments related to the Delinquency Box on page 2."; }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) < 30 && Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0) { chargeOffNoticeDelinquencyNoticeRefinanceMessage = "the Refinance Message"; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetChargeOffNoticeDelinquencyNoticeRefinanceMessage" + ExMessage);

            }

            return chargeOffNoticeDelinquencyNoticeRefinanceMessage;
        }


        private string GetInterest(AccountsModel accountsModel)
        {

            String interest = string.Empty;

            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0 ||
                     Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    interest = "0.00";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetInterest" + ExMessage);

            }

            return interest;
        }

        private string GetEscrowTaxesInsurance(AccountsModel accountsModel)
        {

            String escrowTaxesInsurance = string.Empty;
            try
            {

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0 ||
                   Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    escrowTaxesInsurance = "0.00";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetEscrowTaxesInsurance" + ExMessage);

            }

            return escrowTaxesInsurance;
        }

        private string GetRegularMonthlyPayment(AccountsModel accountsModel)
        {

            String regularMonthlyPayment = string.Empty;
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    regularMonthlyPayment = "0.00";
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetRegularMonthlyPayment" + ExMessage);

            }
            return regularMonthlyPayment;
        }

        private string GetBuydownBalance(AccountsModel accountsModel)
        {

            String buydownBalance = string.Empty;
            try
            {

                if (Convert.ToInt64(accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) < 0)
                {
                    buydownBalance = "N/A";
                }
                else
                {
                    buydownBalance = "RSSI - USR - 303";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetBuydownBalance" + ExMessage);

            }
            return buydownBalance;
        }

        private string GetPartialClaim(AccountsModel accountsModel)
        {

            String partialClaim = string.Empty;

            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0) { partialClaim = "N/A"; } else { partialClaim = "RSSI - DEF - UNPD - EXP - ADV - BAL"; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetPartialClaim" + ExMessage);
            }
            return partialClaim;
        }

        private string GetNegativeAmortization(AccountsModel accountsModel)
        {

            String negativeAmortization = string.Empty;
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Neg_Amort_Taken_PackedData) == 0)
                {
                    negativeAmortization = "N/A";
                }
                else
                {
                    negativeAmortization = "RSSI - NEG - AMORT - TAKEN";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetNegativeAmortization" + ExMessage);

            }
            return negativeAmortization;
        }

        private string GetCarringtonCharitableFoundationMonth(AccountsModel accountsModel)
        {

            String carringtonCharitableFoundation = string.Empty;

            try
            {
                if (int.Parse(accountsModel.detModel.PriorMoAmnt) > 0 || int.Parse(accountsModel.detModel.YTDAmnt) > 0) { carringtonCharitableFoundation = "print Carrington Charitable Foundation Donation line."; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetCarringtonCharitableFoundationMonth" + ExMessage);

            }

            return carringtonCharitableFoundation;
        }

        private string GetCarringtonCharitablePaidYeartoDate(AccountsModel accountsModel)
        {

            String carringtonCharitablePaidYeartoDate = string.Empty;

            try
            {
                if (int.Parse(accountsModel.detModel.PriorMoAmnt) > 0 || int.Parse(accountsModel.detModel.YTDAmnt) > 0) { carringtonCharitablePaidYeartoDate = "print Carrington Charitable Foundation Donation line."; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetCarringtonCharitablePaidYeartoDate" + ExMessage);

            }

            return carringtonCharitablePaidYeartoDate;
        }

        private string GetLockboxAddress(AccountsModel accountsModel)
        {

            String lockboxAddress = string.Empty;

            try
            {
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA" ||
                       accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK" ||
                       accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX") { lockboxAddress = "Dallas P.O.Box Address else Pasadena P.O.Box Address"; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetLockboxAddress" + ExMessage);
            }
            return lockboxAddress;
        }

        private string GetReceivedAfter(AccountsModel accountsModel)
        {

            String receivedAfter = string.Empty;
            try
            {

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    receivedAfter = "suppress Late Charge message.";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetReceivedAfter" + ExMessage);
            }
            return receivedAfter;
        }

        private string GetLateCharge(AccountsModel accountsModel)
        {

            String lateCharge = string.Empty;
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    lateCharge = "suppress Late Charge message.";
                }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetLateCharge" + ExMessage);

            }


            return lateCharge;
        }

        private string GetCarringtonCharitableDonationbox(AccountsModel accountsModel)
        {

            String carringtonCharitableDonationbox = string.Empty;

            try
            {
                if (accountsModel.detModel.Eligible == "Yes") { carringtonCharitableDonationbox = "print the Carrington Charitable Foundation Donation box."; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetCarringtonCharitableDonationbox" + ExMessage);

            }

            return carringtonCharitableDonationbox;
        }

        private string GetEffectiveDate(AccountsModel accountsModel)
        {

            String effectiveDate = string.Empty;

            try
            {
                // if (RSSI_FT_TYPE_CODE == 000) { effectiveDate = "RSSI-FEE-DATE-ASSESSED"; } else { effectiveDate= "RSSI-TR-DATE" }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetEffectiveDate" + ExMessage);
            }

            return effectiveDate;
        }

        private string GetTotalAmount(AccountsModel accountsModel)
        {

            String totalAmount = string.Empty;

            try
            {
                if (int.Parse(accountsModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData) != 0) { totalAmount = "RSSI-TR-EXP-FEE-AMT"; }
                //else if (RSSI_FT_TYPE_CODE == 000) { totalAmount="RSSI-FEE-AMT-ASSESSED"; } else { totalAmount= "RSSI-TR-AMT";}
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetTotalAmount" + ExMessage);
            }

            return totalAmount;
        }

        private string GetDelinquencyInformationbox(AccountsModel accountsModel)
        {

            String delinquencyInformationbox = string.Empty;

            try
            {
                if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30 && Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    delinquencyInformationbox = "include the Delinquency Notice section, else leave blank.";
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetDelinquencyInformationbox" + ExMessage);

            }

            return delinquencyInformationbox;
        }

        private string GetRecentPayment6(AccountsModel accountsModel)
        {

            String recentPayment6 = string.Empty;


            try
            {
                if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1) { recentPayment6 = "Payment Due RSSI-PMT-DUE-5-DATE: Fully paid on RSSI-PMT-PAID-5-DATE"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2) { recentPayment6 = "Payment Due RSSI - PMT - DUE - 4 - DATE: Fully paid on RSSI-PMT - PAID - 4 - DATE"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3) { recentPayment6 = "Payment Due RSSI - PMT - DUE - 3 - DATE: Fully paid on RSSI-PMT - PAID - 3 - DATE"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4) { recentPayment6 = "Payment Due RSSI - PMT - DUE - 2 - DATE: Fully paid on RSSI-PMT - PAID - 2 - DATE"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5) { recentPayment6 = "Payment Due RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }

                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    recentPayment6 = "Payment Due RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)";
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetRecentPayment6" + ExMessage);

            }


            return recentPayment6;
        }

        private string GetRecentPayment5(AccountsModel accountsModel)
        {

            String recentPayment5 = string.Empty;

            try
            {
                if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1) { recentPayment5 = "Payment Due RSSI-PMT-DUE-4-DATE: Fully paid on RSSI-PMT-PAID-5-DATE"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2) { recentPayment5 = "Payment Due RSSI - PMT - DUE - 3 - DATE: Fully paid on RSSI-PMT - PAID - 3 - DATE"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3) { recentPayment5 = "Payment Due RSSI - PMT - DUE - 2 - DATE: Fully paid on RSSI-PMT - PAID - 2 - DATE"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4) { recentPayment5 = "Payment Due RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { recentPayment5 = "Payment Due RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }

                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    recentPayment5 = "Payment Due RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetRecentPayment5" + ExMessage);

            }

            return recentPayment5;
        }

        private string GetRecentPayment4(AccountsModel accountsModel)
        {

            String recentPayment4 = string.Empty;

            try
            {
                if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1) { recentPayment4 = "Payment Due RSSI-PMT-DUE-3-DATE: Fully paid on RSSI-PMT-PAID-3-DATE"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2) { recentPayment4 = "Payment Due RSSI - PMT - DUE - 2 - DATE: Fully paid on RSSI-PMT - PAID - 2 - DATE"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3) { recentPayment4 = "Payment Due RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { recentPayment4 = "Payment Due RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { recentPayment4 = "Payment Due RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }

                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    recentPayment4 = "Payment Due RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetRecentPayment4" + ExMessage);
            }

            return recentPayment4;
        }


        private string GetRecentPayment3(AccountsModel accountsModel)
        {

            String RecentPayment2 = string.Empty;

            try
            {
                if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1) { RecentPayment2 = "Payment Due RSSI-PMT-DUE-2-DATE: Fully paid on RSSI-PMT-PAID-2-DATE"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2) { RecentPayment2 = "Payment Due RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) > 0) { RecentPayment2 = "Payment Due RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) > 0) { RecentPayment2 = "Payment Due RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) > 0) { RecentPayment2 = "Payment Due RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }

                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) > 0 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment2 = "Payment Due RSSI - PAST - DATE(4): Unpaid balance of $RSSI - REG - AMT(4)";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetRecentPayment3" + ExMessage);

            }

            return RecentPayment2;
        }

        private string GetRecentPayment2(AccountsModel accountsModel)
        {

            String RecentPayment2 = string.Empty;

            try
            {
                if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1) { RecentPayment2 = "Payment Due RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment2 = "Payment Due RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment2 = "Payment Due RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment2 = "Payment Due RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment2 = "Payment Due RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }

                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment2 = "Payment Due RSSI - PAST - DATE(5): Unpaid balance of $RSSI - REG - AMT(5)";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetRecentPayment2" + ExMessage);

            }

            return RecentPayment2;
        }

        private string GetRecentPayment1(AccountsModel accountsModel)
        {

            String RecentPayment1 = string.Empty;

            try
            {
                if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment1 = "Payment Due RSSI-PAST-DATE (1): Unpaid balance of $RSSI-REG-AMT (1)"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment1 = "Payment Due RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment1 = "Payment Due RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment1 = "Payment Due RSSI - PAST - DATE(4): Unpaid balance of $RSSI - REG - AMT(4)"; }
                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0) { RecentPayment1 = "Payment Due RSSI - PAST - DATE(5): Unpaid balance of $RSSI - REG - AMT(5)"; }

                else if (int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment1 = "Payment Due RSSI - PAST - DATE(6): Unpaid balance of $RSSI - REG - AMT(6)";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetRecentPayment1" + ExMessage);

            }

            return RecentPayment1;
        }


        private string GetLossMitigtationNotice(AccountsModel accountsModel)
        {

            String lossMitigtationNotice = string.Empty;

            try
            {
                if (int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) == (2 - 10) || int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) == (12 - 14))
                {
                    lossMitigtationNotice = "PLEASE TAKE NOTICE that You have agreed to the following loss mitigation program: [Program Name].";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetLossMitigtationNotice" + ExMessage);

            }

            return lossMitigtationNotice;
        }


        private string GetForeclosureNotice(AccountsModel accountsModel)
        {

            String foreclosureNotice = string.Empty;
            try
            {

                if (int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Fcl_Start_Date) > 0)
                {
                    foreclosureNotice = "PLEASE TAKE NOTICE that Carrington Mortgage Services, LLC has made the first notice or filing required to start a foreclosure.";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetForeclosureNotice" + ExMessage);

            }

            return foreclosureNotice;
        }

        private string GetPreForeclosureNotice(AccountsModel accountsModel)
        {

            String preForeclosureNotice = string.Empty;
            try
            {

                if (int.Parse(accountsModel.detModel.SentNO631) == 1)
                {
                    preForeclosureNotice = "LEASE TAKE NOTICE that Carrington Mortgage Services, LLC has fulfilled, the pre - foreclosure notice requirements of Real Property Actions and Proceedings Law §1304 or Uniform Commercial Code § 9‐611(f), if applicable.     ";
                }
                else if (int.Parse(accountsModel.detModel.SentNO631) == 0) { preForeclosureNotice = "do not print pre - foreclosure message"; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetPreForeclosureNotice" + ExMessage);

            }
            return preForeclosureNotice;
        }

        private string GetLenderPlacedInsuranceMessage(AccountsModel accountsModel)
        {

            String lenderPlacedInsuranceMessage = string.Empty;
            try
            {
                if (accountsModel.EscrowRecordModel.rssi_esc_type == "20" || accountsModel.EscrowRecordModel.rssi_esc_type == "21" &&
                     accountsModel.EscrowRecordModel.Rssi_Ins_Co == "2450" && accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "29000" ||
                     accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "29005" || accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "43000" ||
                     accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "43001")
                { lenderPlacedInsuranceMessage = "then print Lender Placed Insurance message"; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetLenderPlacedInsuranceMessage" + ExMessage);
            }

            return lenderPlacedInsuranceMessage;
        }

        private string GetBankruptcyMessage(AccountsModel accountsModel)
        {

            String bankruptcyMessage = string.Empty;


            try
            {
                if (Convert.ToDateTime(accountsModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Dschg_Dt_PackedData) > Convert.ToDateTime("00/00/00") &&
                      Convert.ToDateTime(accountsModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Dschg_Dt_PackedData) == Convert.ToDateTime("00/00/00"))
                {
                    bankruptcyMessage = "print Bankruptcy message.";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetBankruptcyMessage" + ExMessage);
            }
            return bankruptcyMessage;
        }

        private string GetRepaymentPlanMessage(AccountsModel accountsModel)
        {
            String repaymentPlanMessage = string.Empty;
            try
            {
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Repy_Remain_Bal_PackedData != "00000C")
                {
                    repaymentPlanMessage = "";
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetRepaymentPlanMessage" + ExMessage);

            }
            return repaymentPlanMessage;
        }

        private string GetStateNSF(AccountsModel accountsModel)
        {

            String stateNSF = string.Empty;
            try
            {

                if (accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "6" || accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "16"
                   || accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "18" || accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "42")
                { stateNSF = "print State NSF message"; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetStateNSF" + ExMessage);

            }

            return stateNSF;
        }

        private string GetACHMessage(AccountsModel accountsModel)
        {

            String stateNSF = string.Empty;
            try
            {
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) == 0 &&
                      Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) == 0)
                {
                    stateNSF = "AutoPay Service message";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetACHMessage" + ExMessage);

            }

            return stateNSF;
        }

        private string GetChargeOffNotice(AccountsModel accountsModel)
        {

            String chargeOffNotice = string.Empty;
            try
            {

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0)
                {
                    chargeOffNotice = "print Charge Off message";
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetChargeOffNotice" + ExMessage);

            }
            return chargeOffNotice;
        }

        private string GetCMSPartialClaim(AccountsModel accountsModel)
        {

            String chargeOffNotice = string.Empty;
            try
            {
                if (int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "C") { chargeOffNotice = "print CMS Partial Claim Message."; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetCMSPartialClaim" + ExMessage);
            }

            return chargeOffNotice;
        }

        private string GetHUDPartialClaim(AccountsModel accountsModel)
        {

            String hUDPartialClaim = string.Empty;
            try
            {
                if (int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "H") { hUDPartialClaim = "print HUD Partial Claim Message."; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetHUDPartialClaim" + ExMessage);
            }


            return hUDPartialClaim;
        }

        private string GetStateDisclosures(AccountsModel accountsModel)
        {
            string stateDisclosures = string.Empty;
            var RSSISTATE = "4, 6, 12, 22, 24, 33, 34, 43, 44 ";
            var MailingState = "AR, CO, HI, MA, MN, NC, NY, TN, TX ";

            try
            {
                if (RSSISTATE.Contains(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData))
                { stateDisclosures = ""; }
                else if (MailingState.Contains(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
                { stateDisclosures = ""; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetStateDisclosures" + ExMessage);
            }

            return stateDisclosures;
        }

        private string GetCarringtonCharitableFoundation(AccountsModel accountsModel)
        {

            String carringtonCharitableFoundation = string.Empty;

            try
            {
                if (accountsModel.detModel.Eligible == "Yes" || int.Parse(accountsModel.detModel.PriorMoAmnt) > 0 || int.Parse(accountsModel.detModel.YTDAmnt) > 0)
                { carringtonCharitableFoundation = "print the Carrington Charitable Foundation verbiage."; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetCarringtonCharitableFoundation" + ExMessage);
            }


            return carringtonCharitableFoundation;
        }

        private string GetPaymentInformationMessage(AccountsModel accountsModel)
        {
            String paymentInformationMessage = string.Empty;
            try
            {

                if (accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA" ||
                    accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX") { paymentInformationMessage = "Dallas P.O.Box Address else Pasadena P.O.Box Address"; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetPaymentInformationMessage" + ExMessage);
            }
            return paymentInformationMessage;
        }
        #endregion Ambrish

    }
}
