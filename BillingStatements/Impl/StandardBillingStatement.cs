﻿using CarringtonMortgage.Helpers;
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



        public string Hold { get; set; }
        public string Attention { get; set; }
        public string PrimaryBorrower { get; set; }
        public string SecondaryBorrower { get; set; }
        public string MailingAddressLine1 { get; set; }
        public string MailingAddressLine2 { get; set; }
        public string MailingCityStateZip { get; set; }
        public string MailingCountry { get; set; }
        public string DueDate { get; set; }
        public string IfPaymentisReceivedAfter { get; set; }
        public string LateFee { get; set; }
        public string AutodraftMessage { get; set; }
        public string InterestRateUntil { get; set; }
        public string PrepaymentPenalty { get; set; }
        public string MaturityDate { get; set; }
        public string ModificationDate { get; set; }
        public string ChargeOffNoticeDelinquencyNoticeRefinanceMessage { get; set; }
        public string Interest { get; set; }
        public string EscrowTaxesandorInsurance { get; set; }
        public string RegularMonthlyPayment { get; set; }
        public string BuydownBalance { get; set; }
        public string PartialClaim { get; set; }
        public string NegativeAmortization { get; set; }
        public string CarringtonCharitableFoundationDonationPaidLastMonh { get; set; }
        public string CarringtonCharitableFoundationDonationPaidYeartoDate { get; set; }
        public string LockboxAddress { get; set; }

        public string IfReceivedAfter { get; set; }
        public string LateCharge { get; set; }

        public string CarringtonCharitableFoundationDonationbox { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string DelinquencyInformationbox { get; set; }
        public string LossMitigtationNotice { get; set; }
        public string ForeclosureNotice { get; set; }
        public string PreForeclosureNY90DayNotice { get; set; }
        public string LenderPlacedInsuranceMessage { get; set; }
        public string BankruptcyMessage { get; set; }
        public string RepaymentPlanMessage { get; set; }
        public string StateNSF { get; set; }
        public string ACHMessage { get; set; }
        public string ChargeOffNotice { get; set; }
        public string CMSPartialClaim { get; set; }
        public string HUDPartialClaim { get; set; }
        public string StateDisclosures { get; set; }
        public string CarringtonCharitableFoundation { get; set; }
        public string PaymentInformationMessage { get; set; }

        public string ExMessage { get; set; }
        public ILogger Logger;
        public StandardBillingStatement(ILogger logger)
        {
            Logger = logger;
        }
        public StringBuilder finalLine;
        public StringBuilder GetFinalStringStandardBilling(AccountsModel accountModel, bool isCoBorrower = false)
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
            finalLine.Append(GetHold(accountModel) + "|");
            finalLine.Append(GetAttention(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetPrimaryBorrower(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetSecondaryBorrower(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetMailingAddressLine1(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetMailingAddressLine2(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetMailingCityStateZip(accountModel, isCoBorrower) + "|");
            finalLine.Append(GetMailingCountry(accountModel) + "|");
            finalLine.Append(GetPaymentReceivedAfter(accountModel) + "|");
            finalLine.Append(GetLateFee(accountModel) + "|");
            finalLine.Append(GetAutodraftMessage(accountModel) + "|");
            finalLine.Append(GetInterestRateUnit(accountModel) + "|");
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
            finalLine.Append(GetLossMitigatationNotice(accountModel) + "|");
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
                                      - Convert.ToDecimal(GetTotalFeesPaid(accountsModel)));
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
                        && ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67)
                        || (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198)))
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
                    TotalFeesPaid = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData)
                        + Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)
                        - Convert.ToDecimal(GetTotalFeesAndCharges(accountsModel)));
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
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData) -
                Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                {
                    DeferredBalance = "N/A";
                }
                else
                {
                    DeferredBalance = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData) -
                   Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
                }
                //Logger.Trace("ENDED:    To Deferred Balance operation.");
                return DeferredBalance;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
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
        {//TOD0:Revisit Again exception
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
                Logger.Error(ex, ex.TargetSite.Name);
                return "";
            }
            return FeesAndChargesPaidLastMonth;
        }
        public string GetUnappliedFundsPaidLastMonth(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get unapplied funds paid last month.");
                if (accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2_PackedData != null && accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3_PackedData != null
                    && accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_4_PackedData != null && accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_5_PackedData != null)
                {
                    UnappliedFundsPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData) +
                   Convert.ToDecimal((accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2_PackedData.Replace("{", "")).Replace("}", "").Replace("P", "")) +
                   Convert.ToDecimal((accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3_PackedData.Replace("{", "")).Replace("}", "").Replace("P", "")) +
                   Convert.ToDecimal((accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_4_PackedData.Replace("{", "")).Replace("}", "").Replace("P", "")) +
                   Convert.ToDecimal((accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_5_PackedData.Replace("{", "")).Replace("}", "").Replace("P", "")));
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
        { 
            //TOD0:Revisit Again exception
            try
            {
                //Logger.Trace("STARTED:  Execute get total paid last month.");
                if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                    && (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198))
                {
                    TotalPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData)
                        - Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData)
                        + Convert.ToDecimal(accountsModel.detModel.PriorMoAmnt));
                }
                else
                {
                    TotalPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData)
                        + Convert.ToDecimal(accountsModel.detModel.PriorMoAmnt));
                }
                //Logger.Trace("ENDED: Get get total paid last month.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, ex.TargetSite.Name);
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
                Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2_PackedData) +
                Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3_PackedData) +
                Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_4_PackedData) +
                Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_5_PackedData));
                return Suspense;
                //Logger.Trace("ENDED: Get get suspense.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
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
        public string GetHold(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get print statement.");
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    Hold = string.Empty; //TOD0:Revisit Again exception
                }
                //Logger.Trace("ENDED: Get get print statement.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetTotalDue" + ExMessage);
            }

            return Hold;
        }

        public string GetAttention(AccountsModel accountsModel, bool isCoBorrower)
        {


            try
            {
                //Logger.Trace("STARTED:  Execute get attention.");
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        Attention = accountsModel.MasterFileDataPart_1Model.Rssi_Prim_Attention;
                    else
                        Attention = null;
                }
                //Logger.Trace("ENDED: Get get attention.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetAttention" + ExMessage);

            }
            return Attention;
        }


        public string GetPrimaryBorrower(AccountsModel accountsModel, bool isCoBorrower)
        {



            try
            {
                //Logger.Trace("STARTED:  Execute get primary borrower.");

                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_F;

                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_F;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        PrimaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                    else
                        PrimaryBorrower = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_F;
                }
                //Logger.Trace("ENDED: Get get primary borrower.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPrimaryBorrower" + ExMessage);

            }

            return PrimaryBorrower;
        }


        public string GetSecondaryBorrower(AccountsModel accountsModel, bool isCoBorrower)
        {



            try
            {
                //Logger.Trace("STARTED:  Execute get secondary borrower.");
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A"
                || accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        SecondaryBorrower = accountsModel.MasterFileDataPart_1Model.Rssi_Secondary_Name;
                    else
                        SecondaryBorrower = null;
                }

                //Logger.Trace("ENDED: Get get secondary borrower.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetSecondaryBorrower" + ExMessage);

            }
            return SecondaryBorrower;
        }

        public string GetMailingAddressLine1(AccountsModel accountsModel, bool isCoBorrower)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get mailing address line1.");
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Adrs1;

                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Adrs1;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine1 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingAddressLine1 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_F;
                }

                //Logger.Trace("ENDED: Get get mailing address line1.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetMailingAddressLine1" + ExMessage);

            }
            return MailingAddressLine1;
        }

        public string GetMailingAddressLine2(AccountsModel accountsModel, bool isCoBorrower)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get mailing address line2.");
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Adrs2;

                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Adrs2;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingAddressLine2 = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                    else
                        MailingAddressLine2 = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Adrs2;
                }
                //Logger.Trace("ENDED: Get get mailing address line2.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetMailingAddressLine2" + ExMessage);

            }
            return MailingAddressLine2;
        }

        public string GetMailingCityStateZip(AccountsModel accountsModel, bool isCoBorrower)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get mailing city state zip.");
                if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr1_Zip;

                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr2_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr3_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr4_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr5_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr6_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr7_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr8_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr9_Zip;
                }
                else if (accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Bill_Stmnt == "A")
                {
                    if (!isCoBorrower)
                        MailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                    else
                        MailingCityStateZip = accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_City
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_State
                            + "," + accountsModel.CoBorrowerRecordModel.Rssi_Cb_Cbwr10_Zip;
                }
                //Logger.Trace("ENDED: Get get mailing city state zip.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetMailingCityStateZip" + ExMessage);

            }
            return MailingCityStateZip;
        }

        public string GetMailingCountry(AccountsModel accountsModel)
        {



            try
            {
                //Logger.Trace("STARTED:  Execute get mailing country.");
                if (accountsModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                {
                    MailingCountry = accountsModel.ForeignInformationRecordModel.Rssi_Altr_Cntry;
                }
                else if (accountsModel.MasterFileDataPart2Model.Rssi_Prim_Forgn_Flag == "Y")
                {
                    MailingCountry = accountsModel.ForeignInformationRecordModel.Rssi_Prim_Mail_Country;
                }
                else if (accountsModel.MasterFileDataPart2Model.Rssi_Appl_Foreign_Flag == "Y")
                {
                    MailingCountry = accountsModel.ForeignInformationRecordModel.Rssi_Appl_Country;
                }
                else
                {
                    MailingCountry = null;
                }
                //Logger.Trace("ENDED: Get get mailing mailing country.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetMailingCountry" + ExMessage);

            }

            return MailingCountry;
        }

        public string GetPaymentReceivedAfter(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get payment received after.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    IfPaymentisReceivedAfter = string.Empty;
                }
                else
                {
                    IfPaymentisReceivedAfter = accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Dte;
                }
                //Logger.Trace("ENDED: Get get payment received after.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetPaymentReceivedAfter" + ExMessage);

            }
            return IfPaymentisReceivedAfter;
        }

        public string GetLateFee(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get late fee.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    LateFee = string.Empty;
                }
                else
                {
                    LateFee = accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Amt_PackedData;
                }
                //Logger.Trace("ENDED: Get get late fee.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetLateFee" + ExMessage);
            }
            return LateFee;
        }

        public string GetAutodraftMessage(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get auto draft message.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0 &&
                     Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    AutodraftMessage = "Autodraft_MessageFlag";
                }
                else
                {
                    AutodraftMessage = accountsModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData;
                }
                //Logger.Trace("ENDED: Get get auto draft message.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetAutodraftMessage" + ExMessage);
            }

            return AutodraftMessage;
        }

        public string GetInterestRateUnit(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get interest rate unit.");
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date).IncludeCenturyDate(true)) > 19000000)
                {
                    InterestRateUntil = CommonHelper.GetDateInDDMMYYFormat(accountsModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date);
                }
                else
                {
                    InterestRateUntil = null;
                }
                //Logger.Trace("ENDED: Get get interest rate unit.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetInterestRateUnit" + ExMessage);

            }

            return InterestRateUntil;
        }

        public string GetPrepaymentPenalty(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get prepayment penalty.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
                {
                    PrepaymentPenalty = "Yes";
                }
                else
                {
                    PrepaymentPenalty = "No";
                }
                //Logger.Trace("ENDED: Get get prepayment penalty.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPrepaymentPenalty" + ExMessage);
            }
            return PrepaymentPenalty;
        }

        public string GetMaturityDate(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get maturity date.");
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Balloon_Date).IncludeCenturyDate(true)) > 19000000)
                {
                    MaturityDate = CommonHelper.GetDateInDDMMYYFormat(accountsModel.MasterFileDataPart_1Model.Rssi_Balloon_Date);
                }
                else
                {
                    MaturityDate = CommonHelper.GetDateInDDMMYYFormat(accountsModel.MasterFileDataPart_1Model.Rssi_Mat_Date);
                }
                //Logger.Trace("ENDED: Get get maturity date.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetMaturityDate" + ExMessage);

            }
            return MaturityDate;
        }

        public string GetmodificationDate(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get modification date.");
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Balloon_Date).IncludeCenturyDate(true)) > 19000000)
                {
                    ModificationDate = CommonHelper.GetDateInDDMMYYFormat(accountsModel.MasterFileDataPart_1Model.Rssi_Modify_Date);
                }
                else
                {
                    ModificationDate = "N/A";
                }
                //Logger.Trace("Get get modification date.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetmodificationDate" + ExMessage);

            }
            return ModificationDate;
        }

        public string GetChargeOffNoticeDelinquencyNoticeRefinanceMessage(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get charge off notice delinquency notice refinance message.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Chrg_Off_Dt_PackedData) > 0)
                {
                    ChargeOffNoticeDelinquencyNoticeRefinanceMessage = "ChargeNotice_MessageFlag";
                }
                else if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30
                    && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    ChargeOffNoticeDelinquencyNoticeRefinanceMessage = "DelinquencyNotice_MessageFlag";
                }
                else if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) < 30 && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    ChargeOffNoticeDelinquencyNoticeRefinanceMessage = "ReFinance_MessageFlag";
                }

                //Logger.Trace("ENDED: Get get charge off notice delinquency notice refinance message.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetChargeOffNoticeDelinquencyNoticeRefinanceMessage" + ExMessage);

            }

            return ChargeOffNoticeDelinquencyNoticeRefinanceMessage;
        }

        public string GetInterest(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get interest.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0 ||
                     Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    Interest = "0.00";
                }
                else
                {
                    Interest = accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData;
                }
                //Logger.Trace("ENDED: Get get interest.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetInterest" + ExMessage);

            }

            return Interest;
        }

        public string GetEscrowTaxesInsurance(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get escrow taxes insurance.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0 ||
                   Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    EscrowTaxesandorInsurance = "0.00";
                }
                else
                {
                    EscrowTaxesandorInsurance = accountsModel.MasterFileDataPart_1Model.Rssi_Esc_Pymt_PackedData;
                }
                //Logger.Trace("ENDED: Get get escrow taxes insurance.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetEscrowTaxesInsurance" + ExMessage);

            }

            return EscrowTaxesandorInsurance;
        }

        public string GetRegularMonthlyPayment(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get regular monthly payment.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                {
                    RegularMonthlyPayment = "0.00";
                }
                else
                {
                    RegularMonthlyPayment = accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData;
                }
                //Logger.Trace("ENDED: Get get regular monthly payment.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetRegularMonthlyPayment" + ExMessage);

            }
            return RegularMonthlyPayment;
        }

        public string GetBuydownBalance(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get buy down balance.");
                if (Convert.ToDecimal(accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) < 0)
                {
                    BuydownBalance = "N/A";
                }
                else
                {
                    BuydownBalance = accountsModel.UserFieldRecordModel.Rssi_Usr_303_PackedData;
                }
                //Logger.Trace("ENDED: Get get buy down balance.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetBuydownBalance" + ExMessage);

            }
            return BuydownBalance;
        }

        public string GetPartialClaim(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get partial claim.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                {
                    PartialClaim = "N/A";
                }
                else
                {
                    PartialClaim = accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPartialClaim" + ExMessage);
            }
            //Logger.Trace("ENDED: Get get partial claim.");
            return PartialClaim;
        }

        public string GetNegativeAmortization(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get negative amortization.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Neg_Amort_Taken_PackedData) == 0)
                {
                    NegativeAmortization = "N/A";
                }
                else
                {
                    NegativeAmortization = accountsModel.MasterFileDataPart_1Model.Rssi_Neg_Amort_Taken_PackedData;
                }
                //Logger.Trace("ENDED: Get get negative amortization.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetNegativeAmortization" + ExMessage);

            }
            return NegativeAmortization;
        }

        public string GetCarringtonCharitableFoundationMonth(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get carrington charitable foundation.");
                if (Convert.ToDecimal(accountsModel.detModel.PriorMoAmnt) > 0
                    || Convert.ToDecimal(accountsModel.detModel.YTDAmnt) > 0)
                {
                    CarringtonCharitableFoundation = string.Empty;
                }
                else
                {
                    CarringtonCharitableFoundation = accountsModel.detModel.PriorMoAmnt;
                }
                //Logger.Trace("ENDED: Get get carrington charitable foundation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetCarringtonCharitableFoundationMonth" + ExMessage);

            }

            return CarringtonCharitableFoundation;
        }

        public string GetCarringtonCharitablePaidYeartoDate(AccountsModel accountsModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute get carrington charitable paid yeartodate.");
                if (Convert.ToDecimal(accountsModel.detModel.PriorMoAmnt) > 0
                    || Convert.ToDecimal(accountsModel.detModel.YTDAmnt) > 0)
                {
                    CarringtonCharitableFoundationDonationPaidYeartoDate = string.Empty;
                }
                else
                {
                    CarringtonCharitableFoundationDonationPaidYeartoDate = accountsModel.detModel.YTDAmnt;
                }
                //Logger.Trace("ENDED: Get get carrington charitable paid yeartodate.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetCarringtonCharitablePaidYeartoDate" + ExMessage);

            }

            return CarringtonCharitableFoundationDonationPaidYeartoDate;
        }

        public string GetLockboxAddress(AccountsModel accountsModel)
        {//TOD0:Revisit Again

   

            try
            {
                //Logger.Trace("STARTED:  Execute get lockbox address.");
                if (accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK"
                    || accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX")
                {

                    LockboxAddress = "PO Box 660586 "+ accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 + ", TX 75266-0586";
                }
                else
                {
                    LockboxAddress = "PO Box 7006 " + accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 + ", CA 91109-9998";
                }

                //Logger.Trace("ENDED: Get get lockbox address.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetLockboxAddress" + ExMessage);
            }
            return LockboxAddress;
        }

        public string GetReceivedAfter(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get received after.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    IfPaymentisReceivedAfter = "LateCharge_MessageFlag";//TOD0:Revisit Again
                }
                else
                {
                    IfPaymentisReceivedAfter = accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Dte;
                }
                //Logger.Trace("ENDED: Get get received after.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetReceivedAfter" + ExMessage);
            }
            return IfPaymentisReceivedAfter;
        }

        public string GetLateCharge(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get late charge.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                {
                    LateCharge = "LateCharge_MessageFlag";//TOD0:Revisit Again
                }
                else
                {
                    LateCharge = accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Amt_PackedData;
                }
                //Logger.Trace("ENDED: Get get late charge.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetLateCharge" + ExMessage);

            }


            return LateCharge;
        }

        public string GetCarringtonCharitableDonationbox(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get carrington charitable donationbox.");
                if (accountsModel.detModel.Eligible == "Yes") 
                { 
                    CarringtonCharitableFoundationDonationbox = "CharitableFoundation_MessageFlag";//TOD0:Revisit Again
                }
                else
                {
                    CarringtonCharitableFoundationDonationbox = string.Empty;
                }
                //Logger.Trace("ENDED: Get get carrington charitable donationbox.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetCarringtonCharitableDonationbox" + ExMessage);

            }

            return CarringtonCharitableFoundationDonationbox;
        }

        public string GetEffectiveDate(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get effective date."); 
                if (Convert.ToInt64(accountsModel.FeeRecordModel.Rssi_Fd_Fee_Type) == 000)//TOD0:Revisit Again
                {
                    Date = accountsModel.FeeRecordModel.Rssi_Fd_Assess_Date;
                }
                else
                {
                    Date = accountsModel.TransactionRecordModel.Rssi_Tr_Date_PackedData;
                }
                //Logger.Trace("ENDED: Get get effective date.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetEffectiveDate" + ExMessage);
            }

            return Date;
        }

        public string GetTotalAmount(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get total amount.");

                if (Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData) != 0) 
                {
                    Date = accountsModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData;
                }
                else if (Convert.ToInt64(accountsModel.FeeRecordModel.Rssi_Fd_Fee_Type) == 000)//TOD0:Revisit Again
                {
                    Date = accountsModel.FeeRecordModel.Rssi_Fd_Assess_Amt;
                }
                else
                {
                    Date = accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData;
                }
                //Logger.Trace("ENDED: Get get total amount.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetTotalAmount" + ExMessage);
            }

            return Amount;
        }

        public string GetDelinquencyInformationbox(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute get delinquency informationbox.");
                decimal val = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq);
                if (val >= 30 && Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    DelinquencyInformationbox = "DelinquencyNotice_MessageFlag";//TOD0:Revisit Again
                }
                else 
                {
                    DelinquencyInformationbox = ""; 
                }
                //Logger.Trace("ENDED: Get get delinquency informationbox.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetDelinquencyInformationbox" + ExMessage);

            }

            return DelinquencyInformationbox;
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

                Logger.Error(ex, "Method name : GetRecentPayment6" + ExMessage);
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
                if (!String.IsNullOrEmpty(accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program) && accountsModel.MasterFileDataPart2Model.Rssi_Lmt_Program != "   ")
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
                Logger.Error(ex, "Method name : GetLossMitigtationNotice" + ExMessage);

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
                Logger.Error(ex, "Method name : GetForeclosureNotice" + ExMessage);

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
                Logger.Error(ex, "Method name : GetPreForeclosureNotice" + ExMessage);

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
                Logger.Error(ex, "Method name : GetLenderPlacedInsuranceMessage" + ExMessage);
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
                Logger.Error(ex, "Method name : GetBankruptcyMessage" + ExMessage);
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
                Logger.Error(ex, "Method name : GetRepaymentPlanMessage" + ExMessage);

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
                Logger.Error(ex, "Method name : GetStateNSF" + ExMessage);

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
                Logger.Error(ex, "Method name : GetACHMessage" + ExMessage);

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
                Logger.Error(ex, "Method name : GetChargeOffNotice" + ExMessage);

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
                Logger.Error(ex, "Method name : GetCMSPartialClaim" + ExMessage);
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
                Logger.Error(ex, "Method name : GetHUDPartialClaim" + ExMessage);
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
                Logger.Error(ex, "Method name : GetStateDisclosures" + ExMessage);
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
                Logger.Error(ex, "Method name : GetCarringtonCharitableFoundation" + ExMessage);
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
                Logger.Error(ex, "Method name : GetPaymentInformationMessage" + ExMessage);
            }
            return paymentInformationMessage;
        }
        #endregion Ambrish

    }
}
