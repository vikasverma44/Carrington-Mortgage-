﻿using CarringtonMortgage.Helpers;
using CarringtonMortgage.Models.InputCopyBookModels;
using System;
using System.Text;
using CarringtonService.Helpers;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace CarringtonService.BillingStatements
{
    public class ChapterThirteenBillingStatement : IChapterThirteenBillingStatement
    {
        public ChapterThirteenBillingStatement(ILogger logger)
        {
            Logger = logger;
        }
        #region Object Declaration  ==>
        public ILogger Logger;
        public string ExMessage { get; set; }

        public StringBuilder finalLine;

        #endregion

        #region public Property ==>
        public string PaymentAmount { get; set; }
        public string Principal { get; set; }
        public string PastUnpaidAmount { get; set; }
        public decimal TotalFeesPaid { get; set; }
        public string TotalPaymentAmount { get; set; }
        public string DeferredBalance { get; set; }
        public string FeesAndChargesPaidLastMonth { get; set; }
        public string UnappliedFundsPaidLastMonth { get; set; }
        public string TotalPaidLastMonth { get; set; }
        public string FeesAndChargesPaidYeartoDate { get; set; }
        public string UnappliedFundsPaidYearToDate { get; set; }
        public string TotalPaidYearToDate { get; set; }
        public string Suspense { get; set; }
        public string Miscellaneous { get; set; }


        public string PrintStatement { get; set; }
        public string PrimaryBorrowerBKAttorney { get; set; }
        public string SecondaryBorrower { get; set; }
        public string MailingBKAttorneyAddressLine1 { get; set; }
        public string MailingBKAttorneyAddressLine2 { get; set; }
        public string BorrowerAttorneyMailingCityStateZip { get; set; }
        public string MailingCountry { get; set; }
        public string Interest { get; set; }
        public string EscrowTaxesandInsurance { get; set; }
        public string RegularMonthlyPayment { get; set; }
        public string BuydownBalance { get; set; }
        public string PartialClaim { get; set; }
        public string InterestRateUntil { get; set; }
        public string PrepaymentPenalty { get; set; }
        public string CarringtonFoundationDonationPaidLastMonth { get; set; }
        public string CarringtonFoundationDonationPaidYearToDate { get; set; }
        public string PostPetitonPastDueMessage { get; set; }
        public string CMSPartialClaim { get; set; }
        public string HUDPartialClaim { get; set; }
        public string POBoxAddress { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string LenderPlacedInsuranceMessage { get; set; }
        public string StateNSF { get; set; }
        public string AutodraftMessage { get; set; }
        public string StateDisclosures { get; set; }
        public string CarringtonCharitableFoundation { get; set; }
        public string PaymentInformationMessage { get; set; }

        #endregion


        public StringBuilder GetFinalChapterThirteenBillingStatement(AccountsModel accountModel)
        {
            ExMessage = "Error Message";
            finalLine = new StringBuilder();
   
            finalLine.Append(GetPaymentAmount(accountModel) + "|");
            finalLine.Append(GetPrincipal(accountModel) + "|");
            finalLine.Append(GetPastUnpaidAmount(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaid(accountModel) + "|");
            finalLine.Append(GetTotalPaymentAmount(accountModel) + "|");
            finalLine.Append(GetDeferredBalance(accountModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetTotalPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidYeartoDate(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetTotalPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetSuspense(accountModel) + "|");
            finalLine.Append(GetMiscellaneous(accountModel) + "|");
            //finalLine.Append(GetPrintStatement(accountModel) + "|");
            //finalLine.Append(GetPrimaryBorrowerBKAttorney(accountModel) + "|");
            //finalLine.Append(GetSecondaryBorrower(accountModel) + "|");
            //finalLine.Append(GetMailingBKAttorneyAddressLine1(accountModel) + "|");
            //finalLine.Append(GetMailingBKAttorneyAddressLine2(accountModel) + "|");
            //finalLine.Append(GetBorrowerAttorneyMailingCityStateZip(accountModel) + "|");
            //finalLine.Append(GetMailingCountry(accountModel) + "|");
            //finalLine.Append(GetInterest(accountModel) + "|");
            //finalLine.Append(GetEscrowTaxesandInsurance(accountModel) + "|");
            //finalLine.Append(GetRegularMonthlyPayment(accountModel) + "|");
            //finalLine.Append(GetBuydownBalance(accountModel) + "|");
            //finalLine.Append(GetPartialClaim(accountModel) + "|");
            //finalLine.Append(GetInterestRateUntil(accountModel) + "|");
            //finalLine.Append(GetPrepaymentPenalty(accountModel) + "|");
            //finalLine.Append(GetCarringtonFoundationDonationPaidLastMonth(accountModel) + "|");
            //finalLine.Append(GetCarringtonFoundationDonationPaidYearToDate(accountModel) + "|");
            //finalLine.Append(GetPostPetitonPastDueMessage(accountModel) + "|");
            //finalLine.Append(GetCMSPartialClaim(accountModel) + "|");
            //finalLine.Append(GetHUDPartialClaim(accountModel) + "|");
            //finalLine.Append(GetPOBoxAddress(accountModel) + "|");
            //finalLine.Append(GetLenderPlacedInsuranceMessage(accountModel) + "|");
            //finalLine.Append(GetStateNSF(accountModel) + "|");
            //finalLine.Append(GetAutodraftMessage(accountModel) + "|");
            //finalLine.Append(GetStateDisclosures(accountModel) + "|");
            //finalLine.Append(GetCarringtonCharitableFoundation(accountModel) + "|");
            //finalLine.Append(GetPaymentInformationMessage(accountModel) + "|");
            return finalLine;
        }

        /* While Calculating Conditions must be applied and copybook fields must be verified twice*/
        public string GetPaymentAmount(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to get Payment Amount operation.");

                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                { 
                    PaymentAmount = "0.00"; 
                }
                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date != null && accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte != null &&
                    CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                     CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                {
                    PaymentAmount = Convert.ToString(Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                        Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                }
                else
                {
                    PaymentAmount = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) +
                        Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                        Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                }
                //Logger.Trace("ENDED:    Get Payment Amount operation.");
                return PaymentAmount;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPaymentAmount "+ ex.TargetSite.Name);
                return DateTime.MinValue.ToString(); 
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetPrincipal(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Principal operation.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0 ||
               Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    Principal = "0.00";

                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date != null && CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                        CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    Principal = "0.00";

                else
                {
                    Principal = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_P_I_Pymt_PackedData) -
                        Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                //Logger.Trace("ENDED:    Get to Principal operation.");
                return Principal;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrincipal " + ex.TargetSite.Name);
                return DateTime.MinValue.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetPastUnpaidAmount(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Past Unpaid Amount operation.");
                PastUnpaidAmount = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData != null 
                    ? Convert.ToString(Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) - GetTotalFeesPaid(accountsModel)) : "0";

                //Logger.Trace("ENDED:    Get to Past Unpaid Amount operation.");
                return PastUnpaidAmount;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPastUnpaidAmount " + ex.TargetSite.Name);
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public decimal GetTotalFeesPaid(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Fees Paid operation.");
                if ((Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData) +
                               Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                               Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
                {

                    TotalFeesPaid = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData) +
                        Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData) -
                        Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData);
                }
                else
                {
                    TotalFeesPaid = Convert.ToDecimal(0.00);
                }
                //Logger.Trace("ENDED:    Get to Total Fees Paid operation.");
                return TotalFeesPaid;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalFeesPaid " + ex.TargetSite.Name);
                return Convert.ToDecimal(0.00);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetTotalPaymentAmount(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Payment Amount operation.");
                if (Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalPaymentAmount = "0.00";


                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date != null && CommonHelper.GetFormatedDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                     CommonHelper.GetFormatedDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))

                    TotalPaymentAmount = Convert.ToString(Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                        Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                else
                    TotalPaymentAmount = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) +
                        Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                        Convert.ToDecimal(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                //Logger.Trace("ENDED:    Get to Total Payment Amount operation.");
                return TotalPaymentAmount;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalPaymentAmount " + ex.TargetSite.Name);
                return DateTime.MinValue.ToString();
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetDeferredBalance(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Deferred Balance operation.");


                if ((accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData)
                    - (accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData))) == 0)
                {
                    DeferredBalance = "N/A";
                }
                else
                {
                    DeferredBalance = Convert.ToString(
                        (accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData))
                    - (accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData == null ? 0 : Convert.ToDecimal(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData)));
                }

                //Logger.Trace("ENDED:    Get to Deferred Balance operation.");
                return DeferredBalance;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetDeferredBalance " + ex.TargetSite.Name);
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Fees And Charges Paid Last Month operation.");
                if ((Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                 && (Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67 || Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198))
                {
                    FeesAndChargesPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData) +
                    Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData) -
                    Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                }
                else
                {
                    FeesAndChargesPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData) +
                   Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData));

                }
                //Logger.Trace("ENDED:    Get to Fees And Charges Paid Last Month operation.");
                return FeesAndChargesPaidLastMonth;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetFeesAndChargesPaidLastMonth " + ex.TargetSite.Name);
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        public string GetUnappliedFundsPaidLastMonth(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Unapplied Funds Paid Last Month operation.");

                    UnappliedFundsPaidLastMonth = Convert.ToString((accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData!=null?Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData):0) +
                              (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2_PackedData!=null? Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2_PackedData.Replace("{", "").Replace("}", "")):0) +
                               (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3_PackedData != null ? Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3_PackedData.Replace("{", "").Replace("}", "")) : 0) +
                               (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_4_PackedData != null ? Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_4_PackedData.Replace("{", "").Replace("}", "")) : 0) +
                            (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_5_PackedData!=null?Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_5_PackedData.Replace("{", "").Replace("}", "")):0));

                //Logger.Trace("ENDED:    Get to Unapplied Funds Paid Last Month operation.");
                return UnappliedFundsPaidLastMonth;

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetUnappliedFundsPaidLastMonth " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetTotalPaidLastMonth(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Paid Last Month operation.");
                int RSSITransLog = accountsModel.TransactionRecordModel.Rssi_Log_Tran != null ? Convert.ToInt32(accountsModel.TransactionRecordModel.Rssi_Log_Tran) : 0;
                int RSSITrFeeCoide = accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code != null ? Convert.ToInt32(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) : 0;
                if ((RSSITransLog == 5705 || RSSITransLog == 5707)
                    &&
                    (RSSITrFeeCoide == 67 || RSSITrFeeCoide == 198))
                {
                    //Need to know and Add PriorMoAmnt in this section
                    TotalPaidLastMonth = Convert.ToString((accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData!=null?Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData) :0)
                        -(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData!=null? Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData):0)
                        + (accountsModel.SupplementalCCFModel.PriorMoAmnt!=null?Convert.ToDecimal(accountsModel.SupplementalCCFModel.PriorMoAmnt):0));
                }
                else
                {
                    TotalPaidLastMonth = Convert.ToString((accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData!=null?Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData) :0)
                        + (accountsModel.SupplementalCCFModel.PriorMoAmnt!=null? Convert.ToDecimal(accountsModel.SupplementalCCFModel.PriorMoAmnt):0));
                }
                //Logger.Trace("ENDED:    Get to Total Paid Last Month operation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalPaidLastMonth " + ex.TargetSite.Name);
                return "";
            }
            return TotalPaidLastMonth;
        }
        public string GetFeesAndChargesPaidYeartoDate(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Fees And Charges Paid Year to Date operation.");
                var total = Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) 
                    + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData);
                
                if ((Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Log_Tran) == 5707) 
                    && (Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67 || Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198))
                {
                    FeesAndChargesPaidYeartoDate = Convert.ToString(total 
                        - Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                }
                else
                {
                    FeesAndChargesPaidYeartoDate = Convert.ToString(total);
                }
                //Logger.Trace("ENDED:    Get to Fees And Charges Paid Year to Date operation.");
                return FeesAndChargesPaidYeartoDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetFeesAndChargesPaidYeartoDate " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Unapplied Funds Paid Year To Date operation.");
                UnappliedFundsPaidYearToDate = Convert.ToString((accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) 
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0) 
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) 
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) 
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0));
                //Logger.Trace("ENDED:    Get to Unapplied Funds Paid Year To Date operation.");
                return UnappliedFundsPaidYearToDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetUnappliedFundsPaidYearToDate " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetTotalPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Total Paid Year To Date operation.");
                var Total = Convert.ToString((accountModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData!=null?Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData) :0)
                    + (accountModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData!=null? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData):0) 
                    + (accountModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData!=null?Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData):0) 
                    + (accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData!=null?Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData):0) 
                    + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData) 
                    + (accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) 
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0) 
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) 
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) 
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0) 
                    + Convert.ToDecimal(accountModel.SupplementalCCFModel.YTDAmnt));

                if ((Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                    && (Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67 || Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198))
                {
                    TotalPaidYearToDate = Convert.ToString(Convert.ToDecimal(Total)
                        - Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                }
                else
                {
                    TotalPaidYearToDate = Total;
                }

                    //Logger.Trace("ENDED:    Get to Get Total Paid Year To Date operation.");
               return TotalPaidYearToDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetTotalPaidYearToDate " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetSuspense(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Get Suspense operation.");
                    Suspense = Convert.ToString((accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData!=null?Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData):0) +
                  (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2_PackedData!=null? Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2_PackedData.Replace("{", "").Replace("}", "")):0) +
                   (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3_PackedData!=null? Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3_PackedData.Replace("{", "").Replace("}", "")):0) +
                    (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_4_PackedData!=null?Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_4_PackedData.Replace("{", "").Replace("}", "")):0) +
                  (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_5_PackedData!=null? Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_5_PackedData.Replace("{", "").Replace("}", "")) :0));
                //Logger.Trace("ENDED:    Get to Get Total Paid Year To Date operation.");
                return Suspense;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetSuspense " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetMiscellaneous(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Miscellaneous operation.");

                    Miscellaneous = Convert.ToString((accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Lip_PackedData!=null?Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Lip_PackedData):0) +
                            (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Cr_Ins_PackedData!=null?  Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Cr_Ins_PackedData):0) +
                            (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Pi_Shrtg!=null?  Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Pi_Shrtg.Replace("{", "").Replace("}", "")):0) +
                            (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Prin_PackedData!=null?  Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Prin_PackedData):0) +
                            (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Int_PackedData!=null?  Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Int_PackedData):0) +
                            (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData!=null?  Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData):0) +
                            (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData!=null?  Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData):0) +
                            (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData!=null?  Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData):0) +
                            (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData!=null?  Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData):0) +
                            (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData!=null?  Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData):0) +
                            (accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData!=null?  Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData):0));
                //Logger.Trace("ENDED:    To Miscellaneous operation.");
                return Miscellaneous;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMiscellaneous " + ex.TargetSite.Name);
                return "";
            }
        }



        #region  New Method ==>

        public string GetPrintStatement(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Print Statement operation.");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                    PrintStatement = "Create image but do not mail.";
                //Logger.Trace("ENDED:    To Print Statement operation.");
                return PrintStatement;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrintStatement " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetPrimaryBorrowerBKAttorney(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Primary Borrower BK Attorney operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                    PrimaryBorrowerBKAttorney = accountModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                    PrimaryBorrowerBKAttorney = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                    PrimaryBorrowerBKAttorney = accountModel.MasterFileDataPart_1Model.Rssi_Primary_Name + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1;
                //Logger.Trace("ENDED:    To Print Primary Borrower BK Attorney operation.");
                return PrimaryBorrowerBKAttorney;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrimaryBorrowerBKAttorney " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetSecondaryBorrower(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Secondary Borrower operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    SecondaryBorrower = accountModel.MasterFileDataPart_1Model.Rssi_Secondary_Name;
                }
                //Logger.Trace("ENDED:    To Secondary Borrower operation.");
                return SecondaryBorrower;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetSecondaryBorrower " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetMailingBKAttorneyAddressLine1(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Mailing BK Attorney AddressLine1 operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                    MailingBKAttorneyAddressLine1 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                    MailingBKAttorneyAddressLine1 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                    MailingBKAttorneyAddressLine1 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1;
                //Logger.Trace("ENDED:    To Mailing BK Attorney AddressLine1 operation.");
                return MailingBKAttorneyAddressLine1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMailingBKAttorneyAddressLine1 " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetMailingBKAttorneyAddressLine2(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Mailing BK Attorney AddressLine2 operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                    MailingBKAttorneyAddressLine2 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                    MailingBKAttorneyAddressLine2 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                    MailingBKAttorneyAddressLine2 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2 + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2;
                //Logger.Trace("ENDED:    To Mailing BK Attorney AddressLine2 operation.");
                return MailingBKAttorneyAddressLine2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMailingBKAttorneyAddressLine2 " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Borrower Attorney Mailing City State Zip operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                    BorrowerAttorneyMailingCityStateZip = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                    BorrowerAttorneyMailingCityStateZip = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_City +
                        accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_State + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Zip;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                    BorrowerAttorneyMailingCityStateZip = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_City +
                        accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_State + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Zip;
                //Logger.Trace("ENDED:    To Borrower Attorney Mailing City State Zip operation.");
                return BorrowerAttorneyMailingCityStateZip;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetBorrowerAttorneyMailingCityStateZip " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetMailingCountry(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Mailing Country operation.");
                if (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                    MailingCountry = accountModel.ForeignInformationRecordModel.Rssi_Altr_Cntry;
                else if (accountModel.MasterFileDataPart2Model.Rssi_Prim_Forgn_Flag == "Y")
                    MailingCountry = accountModel.ForeignInformationRecordModel.Rssi_Prim_Mail_Country;
                else if (accountModel.MasterFileDataPart2Model.Rssi_Appl_Foreign_Flag == "Y")
                    MailingCountry = "RSSI-APPL-COUNTRY to copy 1";
                else
                    MailingCountry = null;
                //Logger.Trace("ENDED:    To Mailing Country operation.");
                return MailingCountry;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetMailingCountry " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetInterest(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Interest operation.");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData != null && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    Interest = "0.00";
                else if (accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData != null && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    Interest = "0.00";
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date != null && accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte != null && CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    Interest = "0.00";
                //Logger.Trace("ENDED:    To Interest operation.");
                return Interest;
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetInterest " + ex.TargetSite.Name);
                return DateTime.MinValue.ToString();
            }
        }
        public string GetEscrowTaxesandInsurance(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Escrow Taxes and Insurance operation.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    EscrowTaxesandInsurance = "0.00";
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    EscrowTaxesandInsurance = "0.00";
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date != null && accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte != null &&
                    CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    EscrowTaxesandInsurance = "0.00";
                //Logger.Trace("ENDED:    To Escrow Taxes and Insurance operation.");
                return EscrowTaxesandInsurance;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetEscrowTaxesandInsurance" + ex.TargetSite.Name);
                return DateTime.MinValue.ToString();
            }
        }
        public string GetRegularMonthlyPayment(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Regular Monthly Payment operation.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    RegularMonthlyPayment = "0.00";
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date != null && accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte != null &&
                    CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    RegularMonthlyPayment = "0.00";
                //Logger.Trace("ENDED:    To Regular Monthly Payment operation.");
                return RegularMonthlyPayment;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetRegularMonthlyPayment" + ex.TargetSite.Name);
                return DateTime.MinValue.ToString();
            }
        }
        public string GetBuydownBalance(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Buy down Balance operation.");
                if (Convert.ToDecimal(accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
                    BuydownBalance = "N/A";
                else
                    BuydownBalance = accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData;
                //Logger.Trace("ENDED:    To Buy down Balance operation.");

                return BuydownBalance;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetBuydownBalance " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetPartialClaim(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Partial Claim operation.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                    PartialClaim = "N/A";
                else
                    PartialClaim = accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData;
                //Logger.Trace("ENDED:    To Partial Claim operation.");
                return PartialClaim;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPartialClaim " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetInterestRateUntil(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Interest Rate Until operation.");
                if (Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date).IncludeCenturyDate(true)) > 19000000)
                    InterestRateUntil = "Until RSSI-RATE-CHG-DATE";
                else
                    InterestRateUntil = null;
                //Logger.Trace("ENDED:    To Interest Rate Until operation.");
                return InterestRateUntil;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetInterestRateUntil " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetPrepaymentPenalty(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Prepayment Penalty operation.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
                    PrepaymentPenalty = "Yes";
                else
                    PrepaymentPenalty = "No";
                //Logger.Trace("ENDED:    To Prepayment Penalty operation.");
                return PrepaymentPenalty;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPrepaymentPenalty " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetCarringtonFoundationDonationPaidLastMonth(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Carrington Foundation Donation Paid Last Month operation.");
                if (accountModel.SupplementalCCFModel != null)
                    if (Convert.ToDecimal(accountModel.SupplementalCCFModel.PriorMoAmnt) > 0 || Convert.ToDecimal(accountModel.SupplementalCCFModel.YTDAmnt) > 0)
                        CarringtonFoundationDonationPaidLastMonth = "Carrington Charitable Foundation Donation line";
                //Logger.Trace("ENDED:    To Carrington Foundation Donation Paid Last Month operation.");
                return CarringtonFoundationDonationPaidLastMonth;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetCarringtonFoundationDonationPaidLastMonth " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetCarringtonFoundationDonationPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Carrington Foundation Donation Paid Year To Date operation.");
                if (accountModel.SupplementalCCFModel != null)
                    if (Convert.ToDecimal(accountModel.SupplementalCCFModel.PriorMoAmnt) > 0 || Convert.ToDecimal(accountModel.SupplementalCCFModel.YTDAmnt) > 0)
                        CarringtonFoundationDonationPaidYearToDate = "Carrington Charitable Foundation Donation line";
                //Logger.Trace("ENDED:    To Carrington Foundation Donation Paid Year To Date operation.");
                return CarringtonFoundationDonationPaidYearToDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetCarringtonFoundationDonationPaidYearToDate " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetPostPetitonPastDueMessage(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Post Petiton Past Due Message operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date != null && accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte != null)
                {
                    TimeSpan timeSpan = CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Run_Date) -
                                    CommonHelper.GetFormatedDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date);
                    if (timeSpan.Days >= 45)
                        PostPetitonPastDueMessage = "We have not received all of your mortgage payments due since you filed for bankruptcy.";
                }
                //Logger.Trace("ENDED:    To Post Petiton Past Due Message operation.");
                return PostPetitonPastDueMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPostPetitonPastDueMessage " + ex.TargetSite.Name);
                return DateTime.MinValue.ToString();
            }
        }

        public string GetCMSPartialClaim(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to CMS Partial Claim operation.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountModel.UserFieldRecordModel.Rssi_Usr_88 == "C")
                    CMSPartialClaim = "CMS Partial Claim Message.";
                //Logger.Trace("ENDED:    To CMS Partial Claim operation.");
                return CMSPartialClaim;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetCMSPartialClaim " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetHUDPartialClaim(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get HUD Partial Claim operation.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountModel.UserFieldRecordModel.Rssi_Usr_88 == "H")
                    HUDPartialClaim = "HUD Partial Claim Message.";
                //Logger.Trace("ENDED:    To HUD Partial Claim operation.");
                return HUDPartialClaim;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetHUDPartialClaim " + ex.TargetSite.Name);
                return "";
            }
        }
        // This condition statement is not cleared ===>  If Mailing State = KS, LA, NM, OK, or TX then Dallas P.O.Box Address else Pasadena P.O.Box  Address
        public string GetPOBoxAddress(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get POBox Address operation.");
                var mailingState = "KS, LA, NM, OK, TX";
                if (mailingState.Contains(accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
                    POBoxAddress = "Dallas P.O.Box Address.";
                else
                    POBoxAddress = "Pasadena P.O.Box  Address.";
                //Logger.Trace("ENDED:    To POBox Address operation.");
                return POBoxAddress;
            }

            catch (Exception ex)
            {
                Logger.Error(ex, "GetPOBoxAddress " + ex.TargetSite.Name);
                return "";
            }
        }
        //public string GetDate(AccountsModel accountModel)
        //{
        //    if (accountModel.FeeRecordModel.RSSI_FT_TYPE_CODE == "000")
        //        Date = accountModel.FeeRecordModel.RSSI_FEE_DATE_ASSESSED;
        //    else
        //        Date = accountModel.MasterFileDataPart_1Model.Rssi_Bank_Trans_PackedData;
        //    return Date;

        //}
        //public string GetAmount(AccountsModel accountModel)
        //{
        //    if (Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData) != 0)
        //        Amount = accountModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData;
        //    else if (accountModel.TransactionRecordModel.RSSI_FT_TYPE_CODE == "000")
        //        Amount = accountModel.TransactionRecordModel.RSSI_FEE_AMT_ASSESSED;
        //    else
        //        Amount = accountModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData;
        //    return Amount;

        //}
        public string GetLenderPlacedInsuranceMessage(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Lender Placed Insurance Message operation.");
                var agencyCode = "29000, 29005, 43000, 43001";
                if ((Convert.ToDecimal(accountModel.EscrowRecordModel.Rssi_Esc_Type) == 22 || Convert.ToDecimal(accountModel.EscrowRecordModel.Rssi_Esc_Type) == 21)
                    && Convert.ToDecimal(accountModel.EscrowRecordModel.Rssi_Ins_Co) == 2450
                    && agencyCode.Contains(accountModel.EscrowRecordModel.Rssi_Ins_Ag))
                {
                    LenderPlacedInsuranceMessage = "Lender Placed Insurance message.";
                }
                //Logger.Trace("ENDED:    To Lender Placed Insurance Message operation.");
                return LenderPlacedInsuranceMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetLenderPlacedInsuranceMessage " + ex.TargetSite.Name);
                return "";
            }
        }
        public string GetStateNSF(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get State NSF operation.");
                var rssiState = "6, 16, 18, 42";
                if (rssiState.Contains(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData))
                {
                    StateNSF = "State NSF message.";
                }
                //Logger.Trace("ENDED:    To State NSF operation.");
                return StateNSF;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetStateNSF " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetAutodraftMessage(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Auto draft Message operation.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0 && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    AutodraftMessage = "Autodraft message.";
                }
                //Logger.Trace("ENDED:    To Auto draft Message operation.");
                return AutodraftMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAutodraftMessage " + ex.TargetSite.Name);
                return "";
            }
        }

        //What to do if the condition is satisfied
        public string GetStateDisclosures(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get State Disclosures operation.");
                var rssiState = "4, 6, 12, 22, 24, 33, 34, 43, 44";
                var mailingState = " AR, CO, HI, MA, MN, NC, NY, TN, TX";
                if (rssiState.Contains(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) || mailingState.Contains(accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
                    StateDisclosures = "?";
                //Logger.Trace("ENDED:    To State Disclosures operation.");
                return StateDisclosures;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetStateDisclosures " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetCarringtonCharitableFoundation(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Carrington Charitable Foundation operation.");
                if (accountModel.SupplementalCCFModel != null)
                    if (accountModel.SupplementalCCFModel != null && Convert.ToDecimal(accountModel.SupplementalCCFModel.PriorMoAmnt) > 0 || Convert.ToDecimal(accountModel.SupplementalCCFModel.YTDAmnt) > 0)
                        CarringtonCharitableFoundation = "The Carrington Charitable Foundation verbiage.";
                //Logger.Trace("ENDED:    To Carrington Charitable Foundation operation.");
                return CarringtonCharitableFoundation;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetCarringtonCharitableFoundation " + ex.TargetSite.Name);
                return "";
            }
        }

        public string GetPaymentInformationMessage(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Payment Information Message operation.");
                var mailingState = "KS, LA, NM, OK, TX";
                if (mailingState.Contains(accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
                    PaymentInformationMessage = "Dallas P.O.Box Address.";
                else
                    PaymentInformationMessage = "Pasadena P.O.Box  Address.";
                //Logger.Trace("ENDED:    To Payment Information Message operation.");
                return PaymentInformationMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetPaymentInformationMessage " + ex.TargetSite.Name);
                return "";
            }
        }



        #endregion
    }
}