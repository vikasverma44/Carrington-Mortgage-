using CarringtonMortgage.Helpers;
using CarringtonMortgage.Models.InputCopyBookModels;
using CarringtonService.Helpers;
using System;
using System.Text;

namespace CarringtonService.BillingStatements
{
    public class StandardBillingStatement : IStandardBillingStatement
    {
        public string RecentPayment6 { get; set; }
        public string RecentPayment5 { get; set; }
        public string RecentPayment4 { get; set; }
        public string RecentPayment3 { get; set; }
        public string RecentPayment2 { get; set; }
        public string RecentPayment1 { get; set; }
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
        public string DueBalance { get; set; }
        public string ExMessage { get; set; }
        public ILogger Logger;
        public StandardBillingStatement(ILogger logger)
        {
            Logger = logger;
        }
        public StringBuilder finalLine;
        public StringBuilder GetFinalStringStandardBilling(AccountsModel accountModel)
        {
            ExMessage = "Error Message";
            finalLine = new StringBuilder();

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
            //finalLine.Append(GetPrintStatement(accountModel) + "|");
            //finalLine.Append(GetAttention(accountModel) + "|");
            //finalLine.Append(GetPrimaryBorrower(accountModel) + "|");
            //finalLine.Append(GetSecondaryBorrower(accountModel) + "|");
            //finalLine.Append(GetMailingAddressLine1(accountModel) + "|");
            //finalLine.Append(GetMailingAddressLine2(accountModel) + "|");
            //finalLine.Append(GetMailingCityStateZip(accountModel) + "|");
            //finalLine.Append(GetMailingCountry(accountModel) + "|");
            //finalLine.Append(GetPaymentReceivedAfter(accountModel) + "|");
            //finalLine.Append(GetLateFee(accountModel) + "|");
            //finalLine.Append(GetAutodraftMessage(accountModel) + "|");
            //finalLine.Append(GetInterestRateUnit(accountModel) + "|");
            //finalLine.Append(GetPrepaymentPenalty(accountModel) + "|");
            //finalLine.Append(GetMaturityDate(accountModel) + "|");
            //finalLine.Append(GetmodificationDate(accountModel) + "|");
            //finalLine.Append(GetChargeOffNoticeDelinquencyNoticeRefinanceMessage(accountModel) + "|");
            //finalLine.Append(GetInterest(accountModel) + "|");
            //finalLine.Append(GetEscrowTaxesInsurance(accountModel) + "|");
            //finalLine.Append(GetRegularMonthlyPayment(accountModel) + "|");
            //finalLine.Append(GetBuydownBalance(accountModel) + "|");
            //finalLine.Append(GetPartialClaim(accountModel) + "|");
            //finalLine.Append(GetNegativeAmortization(accountModel) + "|");
            //finalLine.Append(GetCarringtonCharitableFoundationMonth(accountModel) + "|");
            //finalLine.Append(GetCarringtonCharitablePaidYeartoDate(accountModel) + "|");
            //finalLine.Append(GetLockboxAddress(accountModel) + "|");
            //finalLine.Append(GetReceivedAfter(accountModel) + "|");
            //finalLine.Append(GetLateCharge(accountModel) + "|");
            //finalLine.Append(GetCarringtonCharitableDonationbox(accountModel) + "|");
            //finalLine.Append(GetEffectiveDate(accountModel) + "|");
            //finalLine.Append(GetTotalAmount(accountModel) + "|");
            //finalLine.Append(GetDelinquencyInformationbox(accountModel) + "|");
            //finalLine.Append(GetRecentPayment6(accountModel) + "|");
            //finalLine.Append(GetRecentPayment5(accountModel) + "|");
            //finalLine.Append(GetRecentPayment4(accountModel) + "|");
            //finalLine.Append(GetRecentPayment3(accountModel) + "|");
            //finalLine.Append(GetRecentPayment2(accountModel) + "|");
            //finalLine.Append(GetRecentPayment1(accountModel) + "|");
            //finalLine.Append(GetLossMitigatationNotice(accountModel) + "|");
            //finalLine.Append(GetForeclosureNotice(accountModel) + "|");
            //finalLine.Append(GetPreForeclosureNotice(accountModel) + "|");
            //finalLine.Append(GetLenderPlacedInsuranceMessage(accountModel) + "|");
            //finalLine.Append(GetBankruptcyMessage(accountModel) + "|");
            //finalLine.Append(GetRepaymentPlanMessage(accountModel) + "|");
            //finalLine.Append(GetStateNSF(accountModel) + "|");
            //finalLine.Append(GetACHMessage(accountModel) + "|");
            //finalLine.Append(GetChargeOffNotice(accountModel) + "|");
            //finalLine.Append(GetCMSPartialClaim(accountModel) + "|");
            //finalLine.Append(GetHUDPartialClaim(accountModel) + "|");
            //finalLine.Append(GetStateDisclosures(accountModel) + "|");
            //finalLine.Append(GetCarringtonCharitableFoundation(accountModel) + "|");
            //finalLine.Append(GetPaymentInformationMessage(accountModel) + "|");



            return finalLine;
        }
        /* While Calculating Conditions must be applied*/
        public string GetAmountDue(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get amount due.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    AmountDue = "0.00";
                }
                else
                {
                    AmountDue = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
                //Logger.Trace("ENDED: Get  amount due.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
            return AmountDue;
        }
        public string GetPrincipal(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get principal.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    Principal = "0.00";
                }

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    Principal = "null";
                }
                else
                {
                    Principal = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_P_I_Pymt_PackedData)
                                     - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                //Logger.Trace("ENDED: Get  principal.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
            return Principal;
        }
        public string GetAssistanceAmount(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get assistance amount.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    AssistanceAmount = string.Empty;

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    AssistanceAmount = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    AssistanceAmount = "0.00";
                else
                {
                    AssistanceAmount = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) * -1);
                }
                //Logger.Trace("ENDED: Get  assistance amount.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
            return AssistanceAmount;
        }
        public string GetReplacementReserveAmount(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to replacement reserve amount.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData)
                       - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_P_I_Pymt_PackedData)
                        - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                       + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData) == 0)
                    ReplacementReserveAmount = string.Empty;

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    ReplacementReserveAmount = "0.00";

                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    ReplacementReserveAmount = "0.00";
                else
                {
                    ReplacementReserveAmount = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData)
                                                - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_P_I_Pymt_PackedData)
                                                - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData)
                                                + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Pre_Int_Amt_PackedData));


                }
                //Logger.Trace("ENDED: Get  replacement reserve amount.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
            return ReplacementReserveAmount;
        }
        public string GetOverduePayment(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to overdue payment.");
                OverduePayment = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                      - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData)
                                      - Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Pd_Since_Lst_Stmt_PackedData)
                                      - Convert.ToDecimal(GetTotalFeesAndCharges(accountsModel)));
                //Logger.Trace("ENDED: Get  overdue payment.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }

            return OverduePayment;
        }
        public string GetTotalFeesAndCharges(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get total fees and charges.");
                var Total = (accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData != null ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) : 0)
                   + accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData != null ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData) : 0;

                if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5605
                        || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                        &&((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67)
                        ||(Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198)))
                {
                    TotalFeesAndCharges = Convert.ToString(Total - Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                }
                else
                {
                    TotalFeesAndCharges = Convert.ToString(Total);
                }
                //Logger.Trace("ENDED: Get  total fees and charges.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }

            return TotalFeesAndCharges;
        }
        public string GetTotalFeesPaid(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get total fees paid.");
                if ((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                             + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                              Convert.ToDecimal(GetTotalFeesAndCharges(accountsModel)))
                {
                    TotalFeesPaid = Convert.ToString((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToDecimal(GetTotalFeesAndCharges(accountsModel))));
                }
                else
                    TotalFeesPaid = "0.00";

                //Logger.Trace("ENDED: Get  total fees paid.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                 return "";
            }

            return TotalFeesPaid;
        }
        public string GetTotalAmountDue(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get total amount due.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalAmountDue = "0.00";
                else
                    TotalAmountDue = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                                   + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                //Logger.Trace("ENDED: Get  total amount due.");


            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
            return TotalAmountDue;
        }

        public string GetPastDueBalance(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get past due balance.");
                DueBalance = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) -
                  Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) -
                  Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData));
                //Logger.Trace("ENDED: Get get past due balance.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                 return "";
            }

            return DueBalance;
        }
        public string GetDeferredBalance(AccountsModel accountsModel)
        { //TOD0:Revisit Again exception
            try
            {
                //Logger.Trace("STARTED:  Execute to get Deferred Balance operation.");
                //if (accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal != "\0\0\0\0\0.\0\f" && accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal != "\0\0\0\u0090¶.\u009d\f"
                //    && accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal == "\0\0\0¿o.Ê\f" && accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal.Trim() == ""
                //    && Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) -
                //Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                //{
                //    DeferredBalance = "N/A";
                //}
                //else
                //{
                //    if (accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal != "\0\0\0\0\0.\0\f" && accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal != "\0\0\0\u0090¶.\u009d\f"
                //        && accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal == "\0\0\0¿o.Ê\f" && accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal.Trim() == "")
                //    {
                //        DeferredBalance = accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal == "\0\0\0\0\0.\0\f" ? "0" : Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) -
                //            Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
                //    }
                //    else { DeferredBalance = "0"; }
                //}
                //TOD0:Revisit Again
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) -
                Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                {
                    DeferredBalance = "N/A";
                }
                else
                {
                    DeferredBalance = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) -
                   Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
                }
                //Logger.Trace("ENDED:    To Deferred Balance operation.");
                return DeferredBalance;
            }
            catch (Exception ex)
            {
                //Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
        }
        public string GetUnappliedFunds(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get unapplied funds.");
                UnappliedFunds = Convert.ToString(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
                    + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);
                //Logger.Trace("ENDED: Get get unapplied funds.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                 return "";
            }
            return UnappliedFunds;
        }
        public string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get fees and charges paid last month.");
                if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                    && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198))
                {
                    FeesAndChargesPaidLastMonth = Convert.ToString((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData)
                    + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData))
                    - Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                }
                else
                {
                    FeesAndChargesPaidLastMonth = Convert.ToString((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData)
                   + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData)));
                }
                //Logger.Trace("ENDED: Get get fees and charges paid last month.");
            }
            catch (Exception ex)
            {
                //Logger.Error(ex, ex.TargetSite.Name);
                 return "";
            }
            return FeesAndChargesPaidLastMonth;
        }
        public string GetUnappliedFundsPaidLastMonth(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get unapplied funds paid last month.");
                if (accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2 != null && accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3 != null
                    && accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04 != null && accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05 != null)
                {
                    UnappliedFundsPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData) +
                   Convert.ToDecimal((accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2.Replace("{", "")).Replace("}", "").Replace("P", "")) +
                   Convert.ToDecimal((accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3.Replace("{", "")).Replace("}", "").Replace("P", "")) +
                   Convert.ToDecimal((accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04.Replace("{", "")).Replace("}", "").Replace("P", "")) +
                   Convert.ToDecimal((accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05.Replace("{", "")).Replace("}", "").Replace("P", "")));
                }
                return UnappliedFundsPaidLastMonth;
                //Logger.Trace("ENDED: Get get unapplied funds paid last month.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
                 return "";

            }
        }
        public string GetTotalPaidLastMonth(AccountsModel accountsModel)
        { //TOD0:Revisit Again exception
            try
            {
                //Logger.Trace("STARTED:  Execute get total paid last month.");
                if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                    && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198))
                {
                    TotalPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData) 
                        - Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData)
                        + Convert.ToDecimal(accountsModel.SupplementalCCFModel.PriorMoAmnt));
                }
                else
                {
                    TotalPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData) 
                        + Convert.ToDecimal(accountsModel.SupplementalCCFModel.PriorMoAmnt));
                }
                //Logger.Trace("ENDED: Get get total paid last month.");
            }
            catch (Exception ex)
            {

               // Logger.Error(ex, ex.TargetSite.Name);
                 return "";

            }

            return TotalPaidLastMonth;
        }
        public string GetFeesAndChargesPaidYearToDate(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get fees and charges paid yeartodate.");
                if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                    && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198))
                {
                    FeesAndChargesPaidYearToDate = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                    + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData)
                    - Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                }
                //Logger.Trace("ENDED: Get get fees and charges paid yeartodate.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                 return "";

            }
            return FeesAndChargesPaidYearToDate;
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get unapplied funds paid yeartodate.");
                UnappliedFundsPaidYearToDate = Convert.ToString(accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
                     + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
                     + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
                     + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
                     + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0);
                //Logger.Trace("ENDED: Get get unapplied funds paid yeartodate.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                 return "";

            }
            return UnappliedFundsPaidYearToDate;
        }
        public string GetTotalPaidYearToDate(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get total paid yeartodate.");
                if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                    && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198))
                {
                    TotalPaidYearToDate = Convert.ToString((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData)
                                           + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData)
                                           + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData)
                                           + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData)
                                           + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData)
                                           + accountsModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0
                                           + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0
                                           + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0
                                           + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0
                                           + accountsModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0)
                                           - Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                }
                //Logger.Trace("ENDED: Get get total paid yeartodate.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                 return "";
            }
            return TotalPaidYearToDate;
        }
        public string GetLatePaymentAmount(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get late payment amount.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    LatePaymentAmount = "N/A";
                }
                else
                {
                    LatePaymentAmount = Convert.ToString(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData != null ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) : 0
                        + accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData != null ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) : 0
                        + accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Amt_PackedData != null ? Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Amt_PackedData) : 0);
                }
                //Logger.Trace("ENDED: Get get late payment amount.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                 return "";

            }
            return LatePaymentAmount;
        }
        public string GetSuspense(AccountsModel accountsModel)
        {//TOD0:Revisit Again exception
            try
            {
                //Logger.Trace("STARTED:  Execute get suspense.");
                Suspense = Convert.ToString(Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData) +
                Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2) +
                Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3) +
                Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04) +
                Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05));
                return Suspense;
                //Logger.Trace("ENDED: Get get suspense.");
            }
            catch (Exception ex)
            {
                //Logger.Error(ex, ex.TargetSite.Name);
                return "";

            }
        }
        public string GetMiscellaneous(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get miscellaneous.");
                    Miscellaneous = Convert.ToString(
                      (accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Lip_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Lip_PackedData))
                    + (accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Cr_Ins_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Cr_Ins_PackedData))
                    + (accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Pi_Shrtg == null ? 0 : Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Pi_Shrtg.Replace("{", "").Replace("}", "")))
                    + (accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Prin_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Prin_PackedData))
                    + (accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Int_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Int_PackedData))
                    + (accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData))
                    + (accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData))
                    + (accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData))
                    + (accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData))
                    + (accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData))
                    + (accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData))
                    );
                    return Miscellaneous;
                //Logger.Trace("ENDED: Get get miscellaneous.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                 return "";

            }
          
        }
        public string GetTotalDue(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get total due.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    TotalDue = "0.00";
                }
                else
                {
                    TotalDue = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData)
                        + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
                //Logger.Trace("ENDED: Get get total due.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                 return "";

            }
            return TotalDue;
        }

        #region MyRegion Ambrish
        public string GetPrintStatement(AccountsModel accountsModel)
        {
            String printStatement = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get print statement.");
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") { printStatement = "create image but do not mail"; }
                //Logger.Trace("ENDED: Get get print statement.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetTotalDue" + ExMessage);
            }

            return printStatement;
        }

        public string GetAttention(AccountsModel accountsModel)
        {

            String attention = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get attention.");
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

                //Logger.Trace("ENDED: Get get attention.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetAttention" + ExMessage);

            }
            return attention;
        }


        public string GetPrimaryBorrower(AccountsModel accountsModel)
        {

            String primaryBorrower = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get primary borrower.");
                
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A") { primaryBorrower =     accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_F; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A") { primaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_F; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A") { primaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_F; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A") { primaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_F; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A") { primaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_F; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A") { primaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_F; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A") { primaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_F; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A") { primaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_F; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A") { primaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_F; }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A") { primaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_F; }
                //Logger.Trace("ENDED: Get get primary borrower.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetPrimaryBorrower" + ExMessage);

            }

            return primaryBorrower;
        }


        public string GetSecondaryBorrower(AccountsModel accountsModel)
        {

            String secondaryBorrower = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get secondary borrower.");
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

                //Logger.Trace("ENDED: Get get secondary borrower.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetSecondaryBorrower" + ExMessage);

            }
            return secondaryBorrower;
        }

        public string GetMailingAddressLine1(AccountsModel accountsModel)
        {

            String mailingAddressLine1 = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get mailing address line1.");
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

                //Logger.Trace("ENDED: Get get mailing address line1.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetMailingAddressLine1" + ExMessage);

            }
            return mailingAddressLine1;
        }

        public string GetMailingAddressLine2(AccountsModel accountsModel)
        {

            String mailingAddressLine2 = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get mailing address line2.");
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
                //Logger.Trace("ENDED: Get get mailing address line2.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetMailingAddressLine2" + ExMessage);

            }
            return mailingAddressLine2;


        }

        public string GetMailingCityStateZip(AccountsModel accountsModel)
        {

            String mailingCityStateZip = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get mailing city state zip.");
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
                //Logger.Trace("ENDED: Get get mailing city state zip.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetMailingCityStateZip" + ExMessage);

            }
            return mailingCityStateZip;


        }

        public string GetMailingCountry(AccountsModel accountsModel)
        {

            String mailingCountry = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get mailing country.");
                if (accountsModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y") { mailingCountry = accountsModel.ForeignInformationRecordModel.Rssi_Altr_Cntry; }
                else if (accountsModel.MasterFileDataPart2Model.Rssi_Prim_Forgn_Flag == "Y") { mailingCountry = accountsModel.ForeignInformationRecordModel.Rssi_Prim_Mail_Country; }
                else if (accountsModel.MasterFileDataPart2Model.Rssi_Appl_Foreign_Flag == "Y") { mailingCountry = accountsModel.ForeignInformationRecordModel.Rssi_Appl_Country; }
                else { mailingCountry = null; }
                //Logger.Trace("ENDED: Get get mailing mailing country.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetMailingCountry" + ExMessage);

            }

            return mailingCountry;
        }

        public string GetPaymentReceivedAfter(AccountsModel accountsModel)
        {
            String paymentReceivedAfter = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get payment received after.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0) { paymentReceivedAfter = "suppress Late Charge message"; }
                //Logger.Trace("ENDED: Get get payment received after.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetPaymentReceivedAfter" + ExMessage);

            }


            return paymentReceivedAfter;
        }

        public string GetLateFee(AccountsModel accountsModel)
        {
            String lateFee = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get late fee.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0) { lateFee = "suppress Late Charge message"; }
                //Logger.Trace("ENDED: Get get late fee.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetLateFee" + ExMessage);
            }
            return lateFee;
        }

        public string GetAutodraftMessage(AccountsModel accountsModel)
        {

            String autodraftMessage = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get auto draft message.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0 &&
                     Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    autodraftMessage = "Autodraft message.";
                }
                //Logger.Trace("ENDED: Get get auto draft message.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetAutodraftMessage" + ExMessage);
            }

            return autodraftMessage;
        }

        public string GetInterestRateUnit(AccountsModel accountsModel)
        {

            String interestRateUnit = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get interest rate unit.");
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date).IncludeCenturyDate(true)) > 19000000) { interestRateUnit = accountsModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date; } else { interestRateUnit = null; }
                //Logger.Trace("ENDED: Get get interest rate unit.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetInterestRateUnit" + ExMessage);

            }

            return interestRateUnit;
        }

        public string GetPrepaymentPenalty(AccountsModel accountsModel)
        {

            String prepaymentPenalty = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get prepayment penalty.");
                decimal val = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData);
                if (val > 0) { prepaymentPenalty = "Yes"; } else { prepaymentPenalty = "No"; }
                //Logger.Trace("ENDED: Get get prepayment penalty.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetPrepaymentPenalty" + ExMessage);
            }

            return prepaymentPenalty;
        }

        public string GetMaturityDate(AccountsModel accountsModel)
        {

            String maturityDate = string.Empty;

            try
            {
               
 
                //Logger.Trace("STARTED:  Execute get maturity date.");
                if (long.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Balloon_Date) > 19000000) { maturityDate = accountsModel.MasterFileDataPart_1Model.Rssi_Balloon_Date; }
                else { maturityDate = accountsModel.MasterFileDataPart_1Model.Rssi_Mat_Date; }
                //Logger.Trace("ENDED: Get get maturity date.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetMaturityDate" + ExMessage);

            }

            return maturityDate;
        }


        public string GetmodificationDate(AccountsModel accountsModel)
        {

            String modificationDate = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get modification date.");
                if (long.Parse(accountsModel.MasterFileDataPart_1Model.Rssi_Balloon_Date) > 19000000) { modificationDate = accountsModel.MasterFileDataPart_1Model.Rssi_Modify_Date; }
                else { modificationDate = "N/A"; }
                //Logger.Trace("Get get modification date.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetmodificationDate" + ExMessage);

            }

            return modificationDate;
        }


        public string GetChargeOffNoticeDelinquencyNoticeRefinanceMessage(AccountsModel accountsModel)
        {

            String chargeOffNoticeDelinquencyNoticeRefinanceMessage = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get charge off notice delinquency notice refinance message.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0) { chargeOffNoticeDelinquencyNoticeRefinanceMessage = "the Charge Off Notice"; }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30 && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                { chargeOffNoticeDelinquencyNoticeRefinanceMessage = "You are late on your mortgage payments.Failure to bring your loan current may result in fees and foreclosure - the loss of your home. See additional comments related to the Delinquency Box on page 2."; }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) < 30 && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0) { chargeOffNoticeDelinquencyNoticeRefinanceMessage = "the Refinance Message"; }

                //Logger.Trace("ENDED: Get get charge off notice delinquency notice refinance message.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetChargeOffNoticeDelinquencyNoticeRefinanceMessage" + ExMessage);

            }

            return chargeOffNoticeDelinquencyNoticeRefinanceMessage;
        }


        public string GetInterest(AccountsModel accountsModel)
        {

            String interest = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get interest.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0 ||
                     Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    interest = "0.00";
                }
                //Logger.Trace("ENDED: Get get interest.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetInterest" + ExMessage);

            }

            return interest;
        }

        public string GetEscrowTaxesInsurance(AccountsModel accountsModel)
        {

            String escrowTaxesInsurance = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get escrow taxes insurance.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0 ||
                   Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    escrowTaxesInsurance = "0.00";
                }
                //Logger.Trace("ENDED: Get get escrow taxes insurance.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetEscrowTaxesInsurance" + ExMessage);

            }

            return escrowTaxesInsurance;
        }

        public string GetRegularMonthlyPayment(AccountsModel accountsModel)
        {

            String regularMonthlyPayment = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get regular monthly payment.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    regularMonthlyPayment = "0.00";
                }
                //Logger.Trace("ENDED: Get get regular monthly payment.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetRegularMonthlyPayment" + ExMessage);

            }
            return regularMonthlyPayment;
        }

        public string GetBuydownBalance(AccountsModel accountsModel)
        {

            String buydownBalance = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get buy down balance.");
                if (Convert.ToDecimal(accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) < 0)
                {
                    buydownBalance = "N/A";
                }
                else
                {
                    buydownBalance = accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData;
                }
                //Logger.Trace("ENDED: Get get buy down balance.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetBuydownBalance" + ExMessage);

            }
            return buydownBalance;
        }

        public string GetPartialClaim(AccountsModel accountsModel)
        {

            String partialClaim = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get partial claim.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0) { partialClaim = "N/A"; } else { partialClaim = accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetPartialClaim" + ExMessage);
            }
            //Logger.Trace("ENDED: Get get partial claim.");
            return partialClaim;
        }

        public string GetNegativeAmortization(AccountsModel accountsModel)
        {

            String negativeAmortization = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get negative amortization.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Neg_Amort_Taken_PackedData) == 0)
                {
                    negativeAmortization = "N/A";
                }
                else
                {
                    negativeAmortization = accountsModel.MasterFileDataPart_1Model.Rssi_Neg_Amort_Taken_PackedData;
                }
                //Logger.Trace("ENDED: Get get negative amortization.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetNegativeAmortization" + ExMessage);

            }
            return negativeAmortization;
        }

        public string GetCarringtonCharitableFoundationMonth(AccountsModel accountsModel)
        {

            String carringtonCharitableFoundation = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get carrington charitable foundation.");
                if (accountsModel.detModel.PriorMoAmnt != null && accountsModel.detModel.YTDAmnt != null)
                {
                    if (Convert.ToDecimal(accountsModel.detModel.PriorMoAmnt) > 0 || Convert.ToDecimal(accountsModel.detModel.YTDAmnt) > 0) { carringtonCharitableFoundation = "Carrington Charitable Foundation Donation line."; }
                }
                //Logger.Trace("ENDED: Get get carrington charitable foundation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetCarringtonCharitableFoundationMonth" + ExMessage);

            }

            return carringtonCharitableFoundation;
        }

        public string GetCarringtonCharitablePaidYeartoDate(AccountsModel accountsModel)
        {

            String carringtonCharitablePaidYeartoDate = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get carrington charitable paid yeartodate.");
                if (accountsModel.detModel.PriorMoAmnt != null && accountsModel.detModel.YTDAmnt != null)
                {
                    if (Convert.ToDecimal(accountsModel.detModel.PriorMoAmnt) > 0 || Convert.ToDecimal(accountsModel.detModel.YTDAmnt) > 0) { carringtonCharitablePaidYeartoDate = "Carrington Charitable Foundation Donation line."; }
                }
                //Logger.Trace("ENDED: Get get carrington charitable paid yeartodate.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetCarringtonCharitablePaidYeartoDate" + ExMessage);

            }

            return carringtonCharitablePaidYeartoDate;
        }

        public string GetLockboxAddress(AccountsModel accountsModel)
        {

            String lockboxAddress = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get lockbox address.");
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA" ||
                       accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK" ||
                       accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX") { lockboxAddress = "Dallas P.O.Box Address else Pasadena P.O.Box Address"; }

                //Logger.Trace("ENDED: Get get lockbox address.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetLockboxAddress" + ExMessage);
            }
            return lockboxAddress;
        }

        public string GetReceivedAfter(AccountsModel accountsModel)
        {

            String receivedAfter = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get received after.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    receivedAfter = "suppress Late Charge message.";
                }
                //Logger.Trace("ENDED: Get get received after.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetReceivedAfter" + ExMessage);
            }
            return receivedAfter;
        }

        public string GetLateCharge(AccountsModel accountsModel)
        {

            String lateCharge = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get late charge.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    lateCharge = "suppress Late Charge message.";
                }
                //Logger.Trace("ENDED: Get get late charge.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetLateCharge" + ExMessage);

            }


            return lateCharge;
        }

        public string GetCarringtonCharitableDonationbox(AccountsModel accountsModel)
        {

            String carringtonCharitableDonationbox = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get carrington charitable donationbox.");
                if (accountsModel.detModel.Eligible == "Yes") { carringtonCharitableDonationbox = "Carrington Charitable Foundation Donation box."; }
                //Logger.Trace("ENDED: Get get carrington charitable donationbox.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetCarringtonCharitableDonationbox" + ExMessage);

            }

            return carringtonCharitableDonationbox;
        }

        public string GetEffectiveDate(AccountsModel accountsModel)
        {

            String effectiveDate = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get effective date.");
                // if (RSSI_FT_TYPE_CODE == 000) { effectiveDate = "RSSI-FEE-DATE-ASSESSED"; } else { effectiveDate= "RSSI-TR-DATE" }

                //Logger.Trace("ENDED: Get get effective date.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetEffectiveDate" + ExMessage);
            }

            return effectiveDate;
        }

        public string GetTotalAmount(AccountsModel accountsModel)
        {

            String totalAmount = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get total amount.");
                decimal val = Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData);
                if (val != 0) { totalAmount = accountsModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData; }
                //else if (RSSI_FT_TYPE_CODE == 000) { totalAmount="RSSI-FEE-AMT-ASSESSED"; } else { totalAmount= "RSSI-TR-AMT";}
                //Logger.Trace("ENDED: Get get total amount.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetTotalAmount" + ExMessage);
            }

            return totalAmount;
        }

        public string GetDelinquencyInformationbox(AccountsModel accountsModel)
        {

            String delinquencyInformationbox = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get delinquency informationbox.");
                decimal val = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq);
                if (val >= 30 && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    delinquencyInformationbox = "include the Delinquency Notice section";
                }
                else { delinquencyInformationbox = ""; }
                //Logger.Trace("ENDED: Get get delinquency informationbox.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetDelinquencyInformationbox" + ExMessage);

            }

            return delinquencyInformationbox;
        }

        public string GetRecentPayment6(AccountsModel accountModel)
        {

            String recentPayment6 = String.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute to Get recent payment6.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { recentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_5 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_5; }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    recentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_4;
                }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                { recentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3; }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                { recentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2; }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5)
                { recentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1; }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 
                    && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0 
                    && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    recentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)"; ;
                }
                //Logger.Trace("ENDED: Get  recent payment6.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetRecentPayment6" + ExMessage);
            }

            return recentPayment6;
        }

        public string GetRecentPayment5(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get Recent Payment5");

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_4;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                   && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0
                   && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment5 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                //Logger.Trace("ENDED:  To Get Recent Payment5");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                 return "";
            }

            return RecentPayment5;
        }

        public string GetRecentPayment4(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Recent Payment4");

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                  && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0
                  && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)

                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)";
                }
                //Logger.Trace("ENDED:  To Get Recent Payment5");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                 return "";
            }

            return RecentPayment4;
        }

        public string GetRecentPayment3(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Recent Payment3");

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0
                 && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)

                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(4): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(4)";
                }
                //Logger.Trace("ENDED:  To Get Recent Payment3");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                 return "";
            }
            return RecentPayment3;
        }

        public string GetRecentPayment2(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Recent Payment2");
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1;
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(4): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(4)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0
                && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)

                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(5): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(5)";
                }
                //Logger.Trace("ENDED:  To Get Recent Payment2");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                 return "";
            }
            return RecentPayment2;
        }

        public string GetRecentPayment1(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Recent Payment1");

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(4): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(4)";

                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(5): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(5)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0
                && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                //else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(5): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(5)";
                }
                //Logger.Trace("ENDED:  To Get Recent Payment1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                 return "";
            }
            return RecentPayment1;
        }



        public string GetLossMitigatationNotice(AccountsModel accountsModel)
        {

            String lossMitigtationNotice = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get loss mitigtation notice.");
                if (!String.IsNullOrEmpty(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) && accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program!= "   ")
                {
                    if (int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) == (2 - 10) || int.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) == (12 - 14))
                    {
                        lossMitigtationNotice = "PLEASE TAKE NOTICE that You have agreed to the following loss mitigation program: [Program Name].";
                    }
                }
                //Logger.Trace("ENDED: Get get loss mitigtation notice.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetLossMitigtationNotice" + ExMessage);

            }

            return lossMitigtationNotice;
        }


        public string GetForeclosureNotice(AccountsModel accountsModel)
        {

            String foreclosureNotice = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get foreclosure notice.");
                if (accountsModel.MasterFileDataPart2Model.Rssi_Fcl_Start_Date != null && accountsModel.MasterFileDataPart2Model.Rssi_Fcl_Start_Date != "")
                {
                    if (decimal.Parse(accountsModel.MasterFileDataPart2Model.Rssi_Fcl_Start_Date) > 0)
                    {
                        foreclosureNotice = "PLEASE TAKE NOTICE that Carrington Mortgage Services, LLC has made the first notice or filing required to start a foreclosure.";
                    }
                }
                //Logger.Trace("ENDED: Get get foreclosure notice.");
             }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetForeclosureNotice" + ExMessage);

            }

            return foreclosureNotice;
        }

        public string GetPreForeclosureNotice(AccountsModel accountsModel)
        {

            String preForeclosureNotice = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get preforeclosure notice.");
                if (accountsModel.detModel.SentNO631 != null)
                {

                    if (int.Parse(accountsModel.detModel.SentNO631) == 1)
                    {
                        preForeclosureNotice = "LEASE TAKE NOTICE that Carrington Mortgage Services, LLC has fulfilled, the pre - foreclosure notice requirements of Real Property Actions and Proceedings Law §1304 or Uniform Commercial Code § 9‐611(f), if applicable.     ";
                    }
                    else if (int.Parse(accountsModel.detModel.SentNO631) == 0) { preForeclosureNotice = "do not print pre - foreclosure message"; }
                }
                //Logger.Trace("ENDED: Get get  preforeclosure notice.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetPreForeclosureNotice" + ExMessage);

            }
            return preForeclosureNotice;
        }

        public string GetLenderPlacedInsuranceMessage(AccountsModel accountsModel)
        {

            String lenderPlacedInsuranceMessage = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get lender placed insurance message.");
                if (accountsModel.EscrowRecordModel.rssi_esc_type == "20" || accountsModel.EscrowRecordModel.rssi_esc_type == "21" &&
                     accountsModel.EscrowRecordModel.Rssi_Ins_Co == "2450" && accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "29000" ||
                     accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "29005" || accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "43000" ||
                     accountsModel.EscrowRecordModel.Rssi_Ins_Ag == "43001")
                { lenderPlacedInsuranceMessage = "Lender Placed Insurance message"; }

                //Logger.Trace("ENDED: Get get  lender placed insurance message.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetLenderPlacedInsuranceMessage" + ExMessage);
            }

            return lenderPlacedInsuranceMessage;
        }

        public string GetBankruptcyMessage(AccountsModel accountsModel)
        {
            String bankruptcyMessage = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get bankruptcy message.");
                if (accountsModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Dschg_Dt_PackedData != null && accountsModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData != null)
                {
                    if (CommonHelper.GetFormatedDateTime(accountsModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Dschg_Dt_PackedData) > Convert.ToDateTime("01/01/01") &&
                    CommonHelper.GetFormatedDateTime(accountsModel.ArchivedBankruptcyDetailRecordModel.Rssi_K_B_Reaffirm_Dt_PackedData) == Convert.ToDateTime("01/01/01"))
                        bankruptcyMessage = "Bankruptcy message.";
                }
                //Logger.Trace("ENDED: Get get bankruptcy message.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetBankruptcyMessage" + ExMessage);
            }
            return bankruptcyMessage;
        }

        public string GetRepaymentPlanMessage(AccountsModel accountsModel)
        {
            String repaymentPlanMessage = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get repayment plan message.");
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Repy_Remain_Bal_PackedData != "00000C")
                {
                    repaymentPlanMessage = "";
                }
                //Logger.Trace("ENDED: Get get  repayment plan message.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetRepaymentPlanMessage" + ExMessage);

            }
            return repaymentPlanMessage;
        }

        public string GetStateNSF(AccountsModel accountsModel)
        {

            String stateNSF = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get stateNSF.");
                if (accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "6" || accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "16"
                   || accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "18" || accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData == "42")
                { stateNSF = "State NSF message"; }
                //Logger.Trace("ENDED: Get get stateNSF.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetStateNSF" + ExMessage);

            }

            return stateNSF;
        }

        public string GetACHMessage(AccountsModel accountsModel)
        {

            String stateNSF = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get ACH message.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) == 0 &&
                      Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) == 0)
                {
                    stateNSF = "AutoPay Service message";
                }
                //Logger.Trace("ENDED: Get ACH message.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetACHMessage" + ExMessage);

            }

            return stateNSF;
        }

        public string GetChargeOffNotice(AccountsModel accountsModel)
        {

            String chargeOffNotice = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get charge off notice.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0)
                {
                    chargeOffNotice = "Charge Off message";
                }
                //Logger.Trace("ENDED: Get charge off notice.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetChargeOffNotice" + ExMessage);

            }
            return chargeOffNotice;
        }

        public string GetCMSPartialClaim(AccountsModel accountsModel)
        {

            String chargeOffNotice = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get CMS partial claim.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "C") { chargeOffNotice = "CMS Partial Claim Message."; }
                //Logger.Trace("ENDED: Get CMS partial claim.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetCMSPartialClaim" + ExMessage);
            }

            return chargeOffNotice;
        }

        public string GetHUDPartialClaim(AccountsModel accountsModel)
        {

            String hUDPartialClaim = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get hud partial claim.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountsModel.UserFieldRecordModel.Rssi_Usr_88 == "H") { hUDPartialClaim = "HUD Partial Claim Message."; }
                //Logger.Trace("ENDED: Get hud partial claim.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetHUDPartialClaim" + ExMessage);
            }


            return hUDPartialClaim;
        }

        public string GetStateDisclosures(AccountsModel accountsModel)
        {
            string stateDisclosures = string.Empty;
            var RSSISTATE = "4, 6, 12, 22, 24, 33, 34, 43, 44 ";
            var MailingState = "AR, CO, HI, MA, MN, NC, NY, TN, TX ";

            try
            {
                //Logger.Trace("STARTED:  Execute get state disclosures.");
                if (RSSISTATE.Contains(accountsModel.MasterFileDataPart_1Model.Rssi_State_PackedData))
                { stateDisclosures = ""; }
                else if (MailingState.Contains(accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
                { stateDisclosures = ""; }
                //Logger.Trace("ENDED: Get state disclosures.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetStateDisclosures" + ExMessage);
            }

            return stateDisclosures;
        }

        public string GetCarringtonCharitableFoundation(AccountsModel accountsModel)
        {

            String carringtonCharitableFoundation = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute get carrington charitable foundation.");
                if (accountsModel.detModel.Eligible != null && accountsModel.detModel.PriorMoAmnt != null && accountsModel.detModel.YTDAmnt != null)
                {
                    if (accountsModel.detModel.Eligible == "Yes" || Convert.ToDecimal(accountsModel.detModel.PriorMoAmnt) > 0 || Convert.ToDecimal(accountsModel.detModel.YTDAmnt) > 0)
                    { carringtonCharitableFoundation = "Carrington Charitable Foundation verbiage."; }
                }
                //Logger.Trace("ENDED: Get carrington charitable foundation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetCarringtonCharitableFoundation" + ExMessage);
            }


            return carringtonCharitableFoundation;
        }

        public string GetPaymentInformationMessage(AccountsModel accountsModel)
        {
            String paymentInformationMessage = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute get payment information message.");
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA" ||
                    accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM" || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX") { paymentInformationMessage = "Dallas P.O.Box Address else Pasadena P.O.Box Address"; }
                //Logger.Trace("ENDED: Get payment information message.");

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
