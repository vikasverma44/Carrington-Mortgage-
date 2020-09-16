
using Carrington_Service.Infrastructure;
using CarringtonMortgage.Helpers;
using CarringtonMortgage.Models.InputCopyBookModels;
using System;
using System.Text;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Carrington_Service.Calculation_Classes
{
    public class ChapterThirteenBillingStatement : IChapterThirteenBillingStatement
    {
        #region Object Declaration  ==>
        private ILogger Logger;
        private string ExMessage { get; set; }

        private StringBuilder finalLine;

        #endregion

        #region private Property ==>
        private string PaymentAmount { get; set; }
        private string Principal { get; set; }
        private string PastUnpaidAmount { get; set; }
        private decimal TotalFeesPaid { get; set; }
        private string TotalPaymentAmount { get; set; }
        private string DeferredBalance { get; set; }
        private string FeesAndChargesPaidLastMonth { get; set; }
        private string UnappliedFundsPaidLastMonth { get; set; }
        private string TotalPaidLastMonth { get; set; }
        private string FeesAndChargesPaidYeartoDate { get; set; }
        private string UnappliedFundsPaidYearToDate { get; set; }
        private string TotalPaidYearToDate { get; set; }
        private string Suspense { get; set; }
        private string Miscellaneous { get; set; }


        private string PrintStatement { get; set; }
        private string PrimaryBorrowerBKAttorney { get; set; }
        private string SecondaryBorrower { get; set; }
        private string MailingBKAttorneyAddressLine1 { get; set; }
        private string MailingBKAttorneyAddressLine2 { get; set; }
        private string BorrowerAttorneyMailingCityStateZip { get; set; }
        private string MailingCountry { get; set; }
        private string Interest { get; set; }
        private string EscrowTaxesandInsurance { get; set; }
        private string RegularMonthlyPayment { get; set; }
        private string BuydownBalance { get; set; }
        private string PartialClaim { get; set; }
        private string InterestRateUntil { get; set; }
        private string PrepaymentPenalty { get; set; }
        private string CarringtonFoundationDonationPaidLastMonth { get; set; }
        private string CarringtonFoundationDonationPaidYearToDate { get; set; }
        private string PostPetitonPastDueMessage { get; set; }
        private string CMSPartialClaim { get; set; }
        private string HUDPartialClaim { get; set; }
        private string POBoxAddress { get; set; }
        private string Date { get; set; }
        private string Amount { get; set; }
        private string LenderPlacedInsuranceMessage { get; set; }
        private string StateNSF { get; set; }
        private string AutodraftMessage { get; set; }
        private string StateDisclosures { get; set; }
        private string CarringtonCharitableFoundation { get; set; }
        private string PaymentInformationMessage { get; set; }

        #endregion


        public string GetFinalChapterThirteenBillingStatement(AccountsModel accountModel)
        {
            ExMessage = "Error Message";
            finalLine = new StringBuilder();
            finalLine.Append("01" + "|");
            finalLine.Append("STD BK CHPT 13 STMT" + "|");
            finalLine.Append(" " + "|");
            finalLine.Append("01" + "|");
            finalLine.Append(GetPaymentAmount(accountModel) + "|");
            finalLine.Append(GetDeferredBalance(accountModel) + "|");
            finalLine.Append(GetPrincipal(accountModel) + "|");
            finalLine.Append(GetPastUnpaidAmount(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaid(accountModel) + "|");
            finalLine.Append(GetTotalPaymentAmount(accountModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetTotalPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidYeartoDate(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetTotalPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetSuspense(accountModel) + "|");
            finalLine.Append(GetMiscellaneous(accountModel) + "|");
            finalLine.Append(GetPrintStatement(accountModel) + "|");
            finalLine.Append(GetPrimaryBorrowerBKAttorney(accountModel) + "|");
            finalLine.Append(GetSecondaryBorrower(accountModel) + "|");
            finalLine.Append(GetMailingBKAttorneyAddressLine1(accountModel) + "|");
            finalLine.Append(GetMailingBKAttorneyAddressLine2(accountModel) + "|");
            finalLine.Append(GetBorrowerAttorneyMailingCityStateZip(accountModel) + "|");
            finalLine.Append(GetMailingCountry(accountModel) + "|");
            finalLine.Append(GetInterest(accountModel) + "|");
            finalLine.Append(GetEscrowTaxesandInsurance(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPayment(accountModel) + "|");
            finalLine.Append(GetBuydownBalance(accountModel) + "|");
            finalLine.Append(GetPartialClaim(accountModel) + "|");
            finalLine.Append(GetInterestRateUntil(accountModel) + "|");
            finalLine.Append(GetPrepaymentPenalty(accountModel) + "|");
            finalLine.Append(GetCarringtonFoundationDonationPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetCarringtonFoundationDonationPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetPostPetitonPastDueMessage(accountModel) + "|");
            finalLine.Append(GetCMSPartialClaim(accountModel) + "|");
            finalLine.Append(GetHUDPartialClaim(accountModel) + "|");
            finalLine.Append(GetPOBoxAddress(accountModel) + "|");
            finalLine.Append(GetLenderPlacedInsuranceMessage(accountModel) + "|");
            finalLine.Append(GetStateNSF(accountModel) + "|");
            finalLine.Append(GetAutodraftMessage(accountModel) + "|");
            finalLine.Append(GetStateDisclosures(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitableFoundation(accountModel) + "|");
            finalLine.Append(GetPaymentInformationMessage(accountModel) + "|");
            return Convert.ToString(finalLine);
        }

        /* While Calculating Conditions must be applied and copybook fields must be verified twice*/
        private string GetPaymentAmount(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to get Payment Amount operation.");

                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                { PaymentAmount = "0.00"; }
                else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                     Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                {
                    PaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                        Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                }
                else
                {
                    PaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) +
                        Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                        Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                }
                Logger.Trace("ENDED:    Get Payment Amount operation.");
                return PaymentAmount;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        private string GetDeferredBalance(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Deferred Balance operation.");

                if ((Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) -
               Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData)) == 0)
                    DeferredBalance = "N/A";
                else
                    DeferredBalance = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) -
                    Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
                Logger.Trace("ENDED:    Get to Deferred Balance operation.");
                return DeferredBalance;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        private string GetPrincipal(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Principal operation.");
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0 ||
               Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    Principal = "0.00";

                else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                        Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    Principal = "0.00";

                else
                {
                    Principal = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_P_I_Pymt_PackedData) -
                        Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));
                }
                Logger.Trace("ENDED:    Get to Principal operation.");
                return Principal;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        private string GetPastUnpaidAmount(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Past Unpaid Amount operation.");
                PastUnpaidAmount = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) - GetTotalFeesPaid(accountsModel));

                Logger.Trace("ENDED:    Get to Past Unpaid Amount operation.");
                return PastUnpaidAmount;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        private decimal GetTotalFeesPaid(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Fees Paid operation.");
                if ((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData) +
                               Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                               Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
                {

                    TotalFeesPaid = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData) +
                        Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData) -
                        Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData);
                }
                else
                {
                    TotalFeesPaid = Convert.ToInt64(0.00);
                }
                Logger.Trace("ENDED:    Get to Total Fees Paid operation.");
                return TotalFeesPaid;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        private string GetTotalPaymentAmount(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Payment Amount operation.");
                if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    TotalPaymentAmount = "0.00";


                else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                     Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))

                    TotalPaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                        Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                else
                    TotalPaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) +
                        Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                        Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
                Logger.Trace("ENDED:    Get to Total Payment Amount operation.");
                return TotalPaymentAmount;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        private string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Fees And Charges Paid Last Month operation.");
                if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                 &&
                (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                {
                    FeesAndChargesPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData) +
                    Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData) -
                    Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                }
                Logger.Trace("ENDED:    Get to Fees And Charges Paid Last Month operation.");
                return FeesAndChargesPaidLastMonth;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
        private string GetUnappliedFundsPaidLastMonth(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Unapplied Funds Paid Last Month operation.");
                UnappliedFundsPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05));
                Logger.Trace("ENDED:    Get to Unapplied Funds Paid Last Month operation.");
                return UnappliedFundsPaidLastMonth;

            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        private string GetTotalPaidLastMonth(AccountsModel accountsModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Paid Last Month operation.");
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
                Logger.Trace("ENDED:    Get to Total Paid Last Month operation.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return TotalPaidLastMonth;
        }
        private string GetFeesAndChargesPaidYeartoDate(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Fees And Charges Paid Year to Date operation.");
                Decimal total = Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData) - Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData);
                if ((Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Log_Tran) == 5707) && (Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67 || Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198))
                {
                    FeesAndChargesPaidYeartoDate = Convert.ToString(total);
                }
                else
                {
                    FeesAndChargesPaidYeartoDate = string.Empty;
                }
                Logger.Trace("ENDED:    Get to Fees And Charges Paid Year to Date operation.");
                return FeesAndChargesPaidYeartoDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        private string GetUnappliedFundsPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Unapplied Funds Paid Year To Date operation.");
                UnappliedFundsPaidYearToDate = Convert.ToString((accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0));
                Logger.Trace("ENDED:    Get to Unapplied Funds Paid Year To Date operation.");
                return UnappliedFundsPaidYearToDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        private string GetTotalPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Total Paid Year To Date operation.");
                TotalPaidYearToDate = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData) + (accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData));
                Logger.Trace("ENDED:    Get to Get Total Paid Year To Date operation.");
                return TotalPaidYearToDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        private string GetSuspense(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Get Suspense operation.");
                Suspense = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05));
                Logger.Trace("ENDED:    Get to Get Total Paid Year To Date operation.");
                return Suspense;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        private string GetMiscellaneous(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Miscellaneous operation.");
                Miscellaneous = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Lip_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Cr_Ins_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Pi_Shrtg) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Prin_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Int_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData));
                Logger.Trace("ENDED:    To Miscellaneous operation.");
                return Miscellaneous;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }



        #region  New Method ==>

        private string GetPrintStatement(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Print Statement operation.");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                    PrintStatement = "Create image but do not mail.";
                Logger.Trace("ENDED:    To Print Statement operation.");
                return PrintStatement;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        private string GetPrimaryBorrowerBKAttorney(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Primary Borrower BK Attorney operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                    PrimaryBorrowerBKAttorney = accountModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                    PrimaryBorrowerBKAttorney = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                    PrimaryBorrowerBKAttorney = accountModel.MasterFileDataPart_1Model.Rssi_Primary_Name + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1;
                Logger.Trace("ENDED:    To Print Primary Borrower BK Attorney operation.");
                return PrimaryBorrowerBKAttorney;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        private string GetSecondaryBorrower(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Secondary Borrower operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    SecondaryBorrower = accountModel.MasterFileDataPart_1Model.Rssi_Secondary_Name;
                }
                Logger.Trace("ENDED:    To Secondary Borrower operation.");
                return SecondaryBorrower;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        public string GetMailingBKAttorneyAddressLine1(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Mailing BK Attorney AddressLine1 operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                    MailingBKAttorneyAddressLine1 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                    MailingBKAttorneyAddressLine1 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                    MailingBKAttorneyAddressLine1 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1;
                Logger.Trace("ENDED:    To Mailing BK Attorney AddressLine1 operation.");
                return MailingBKAttorneyAddressLine1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        public string GetMailingBKAttorneyAddressLine2(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Mailing BK Attorney AddressLine2 operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                    MailingBKAttorneyAddressLine2 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                    MailingBKAttorneyAddressLine2 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                    MailingBKAttorneyAddressLine2 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2 + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2;
                Logger.Trace("ENDED:    To Mailing BK Attorney AddressLine2 operation.");
                return MailingBKAttorneyAddressLine2;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        private string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Borrower Attorney Mailing City State Zip operation.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                    BorrowerAttorneyMailingCityStateZip = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                    BorrowerAttorneyMailingCityStateZip = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_City +
                        accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_State + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Zip;
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                    BorrowerAttorneyMailingCityStateZip = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_City +
                        accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_State + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Zip;
                Logger.Trace("ENDED:    To Borrower Attorney Mailing City State Zip operation.");
                return BorrowerAttorneyMailingCityStateZip;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        private string GetMailingCountry(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Mailing Country operation.");
                if (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                    MailingCountry = accountModel.ForeignInformationRecordModel.Rssi_Altr_Cntry;
                else if (accountModel.MasterFileDataPart2Model.Rssi_Prim_Forgn_Flag == "Y")
                    MailingCountry = accountModel.ForeignInformationRecordModel.Rssi_Prim_Mail_Country;
                else if (accountModel.MasterFileDataPart2Model.Rssi_Appl_Foreign_Flag == "Y")
                    MailingCountry = "RSSI-APPL-COUNTRY to copy 1";
                else
                    MailingCountry = null;
                Logger.Trace("ENDED:    To Mailing Country operation.");
                return MailingCountry;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        private string GetInterest(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Interest operation.");
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    Interest = "0.00";
                else if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    Interest = "0.00";
                else if (Convert.ToDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    Interest = "0.00";
                Logger.Trace("ENDED:    To Interest operation.");
                return Interest;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        private string GetEscrowTaxesandInsurance(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Escrow Taxes and Insurance operation.");
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    EscrowTaxesandInsurance = "0.00";
                else if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                    EscrowTaxesandInsurance = "0.00";
                else if (Convert.ToDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    EscrowTaxesandInsurance = "0.00";
                Logger.Trace("ENDED:    To Escrow Taxes and Insurance operation.");
                return EscrowTaxesandInsurance;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        private string GetRegularMonthlyPayment(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Regular Monthly Payment operation.");
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                    RegularMonthlyPayment = "0.00";
                else if (Convert.ToDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                    RegularMonthlyPayment = "0.00";
                Logger.Trace("ENDED:    To Regular Monthly Payment operation.");
                return RegularMonthlyPayment;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        private string GetBuydownBalance(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Buy down Balance operation.");
                if (Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
                    BuydownBalance = "N/A";
                else
                    BuydownBalance = accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData;
                Logger.Trace("ENDED:    To Buy down Balance operation.");

                return BuydownBalance;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        private string GetPartialClaim(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Partial Claim operation.");
                if (Convert.ToInt64(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                    PartialClaim = "N/A";
                else
                    PartialClaim = accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData;
                Logger.Trace("ENDED:    To Partial Claim operation.");
                return PartialClaim;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        private string GetInterestRateUntil(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Interest Rate Until operation.");
                if (Convert.ToUInt64(Convert.ToDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date).IncludeCenturyDate(true)) > 19000000)
                    InterestRateUntil = "Until RSSI-RATE-CHG-DATE";
                else
                    InterestRateUntil = null;
                Logger.Trace("ENDED:    To Interest Rate Until operation.");
                return InterestRateUntil;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        private string GetPrepaymentPenalty(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Prepayment Penalty operation.");
                if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
                    PrepaymentPenalty = "Yes";
                else
                    PrepaymentPenalty = "No";
                Logger.Trace("ENDED:    To Prepayment Penalty operation.");
                return PrepaymentPenalty;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        private string GetCarringtonFoundationDonationPaidLastMonth(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Carrington Foundation Donation Paid Last Month operation.");
                if (Convert.ToInt64(accountModel.SupplementalCCFModel.PriorMoAmnt) > 0 || Convert.ToInt64(accountModel.SupplementalCCFModel.YTDAmnt) > 0)
                    CarringtonFoundationDonationPaidLastMonth = "Carrington Charitable Foundation Donation line";
                Logger.Trace("ENDED:    To Carrington Foundation Donation Paid Last Month operation.");
                return CarringtonFoundationDonationPaidLastMonth;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        private string GetCarringtonFoundationDonationPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Carrington Foundation Donation Paid Year To Date operation.");
                if (Convert.ToInt64(accountModel.SupplementalCCFModel.PriorMoAmnt) > 0 || Convert.ToInt64(accountModel.SupplementalCCFModel.YTDAmnt) > 0)
                    CarringtonFoundationDonationPaidYearToDate = "Carrington Charitable Foundation Donation line";
                Logger.Trace("ENDED:    To Carrington Foundation Donation Paid Year To Date operation.");
                return CarringtonFoundationDonationPaidYearToDate;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        private string GetPostPetitonPastDueMessage(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Post Petiton Past Due Message operation.");
                TimeSpan timeSpan = Convert.ToDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Run_Date) -
                                Convert.ToDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date);
                if (timeSpan.Days >= 45)
                    PostPetitonPastDueMessage = "We have not received all of your mortgage payments due since you filed for bankruptcy.";
                Logger.Trace("ENDED:    To Post Petiton Past Due Message operation.");
                return PostPetitonPastDueMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        private string GetCMSPartialClaim(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to CMS Partial Claim operation.");
                if (Convert.ToInt64(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountModel.UserFieldRecordModel.Rssi_Usr_88 == "C")
                    CMSPartialClaim = "CMS Partial Claim Message.";
                Logger.Trace("ENDED:    To CMS Partial Claim operation.");
                return CMSPartialClaim;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        private string GetHUDPartialClaim(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get HUD Partial Claim operation.");
                if (Convert.ToInt64(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountModel.UserFieldRecordModel.Rssi_Usr_88 == "H")
                    HUDPartialClaim = "HUD Partial Claim Message.";
                Logger.Trace("ENDED:    To HUD Partial Claim operation.");
                return HUDPartialClaim;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        // This condition statement is not cleared ===>  If Mailing State = KS, LA, NM, OK, or TX then Dallas P.O.Box Address else Pasadena P.O.Box  Address
        private string GetPOBoxAddress(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get POBox Address operation.");
                var mailingState = "KS, LA, NM, OK, TX";
                if (mailingState.Contains(accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
                    POBoxAddress = "Dallas P.O.Box Address.";
                else
                    POBoxAddress = "Pasadena P.O.Box  Address.";
                Logger.Trace("ENDED:    To POBox Address operation.");
                return POBoxAddress;
            }

            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        //private string GetDate(AccountsModel accountModel)
        //{
        //    if (accountModel.FeeRecordModel.RSSI_FT_TYPE_CODE == "000")
        //        Date = accountModel.FeeRecordModel.RSSI_FEE_DATE_ASSESSED;
        //    else
        //        Date = accountModel.MasterFileDataPart_1Model.Rssi_Bank_Trans_PackedData;
        //    return Date;

        //}
        //private string GetAmount(AccountsModel accountModel)
        //{
        //    if (Convert.ToInt64(accountModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData) != 0)
        //        Amount = accountModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData;
        //    else if (accountModel.TransactionRecordModel.RSSI_FT_TYPE_CODE == "000")
        //        Amount = accountModel.TransactionRecordModel.RSSI_FEE_AMT_ASSESSED;
        //    else
        //        Amount = accountModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData;
        //    return Amount;

        //}
        private string GetLenderPlacedInsuranceMessage(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Lender Placed Insurance Message operation.");
                var agencyCode = "29000, 29005, 43000, 43001";
                if ((Convert.ToInt64(accountModel.EscrowRecordModel.Rssi_Esc_Type) == 22 || Convert.ToInt64(accountModel.EscrowRecordModel.Rssi_Esc_Type) == 21)
                    && Convert.ToInt64(accountModel.EscrowRecordModel.Rssi_Ins_Co) == 2450
                    && agencyCode.Contains(accountModel.EscrowRecordModel.Rssi_Ins_Ag))
                {
                    LenderPlacedInsuranceMessage = "Lender Placed Insurance message.";
                }
                Logger.Trace("ENDED:    To Lender Placed Insurance Message operation.");
                return LenderPlacedInsuranceMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }
        private string GetStateNSF(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get State NSF operation.");
                var rssiState = "6, 16, 18, 42";
                if (rssiState.Contains(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData))
                {
                    StateNSF = "State NSF message.";
                }
                Logger.Trace("ENDED:    To State NSF operation.");
                return StateNSF;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        private string GetAutodraftMessage(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Auto draft Message operation.");
                if (Convert.ToInt64(accountModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0 && Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                {
                    AutodraftMessage = "Autodraft message.";
                }
                Logger.Trace("ENDED:    To Auto draft Message operation.");
                return AutodraftMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        //What to do if the condition is satisfied
        private string GetStateDisclosures(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get State Disclosures operation.");
                var rssiState = "4, 6, 12, 22, 24, 33, 34, 43, 44";
                var mailingState = " AR, CO, HI, MA, MN, NC, NY, TN, TX";
                if (rssiState.Contains(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) || mailingState.Contains(accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
                    StateDisclosures = "?";
                Logger.Trace("ENDED:    To State Disclosures operation.");
                return StateDisclosures;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        private string GetCarringtonCharitableFoundation(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Carrington Charitable Foundation operation.");
                if (Convert.ToInt64(accountModel.SupplementalCCFModel.PriorMoAmnt) > 0 || Convert.ToInt64(accountModel.SupplementalCCFModel.YTDAmnt) > 0)
                    CarringtonCharitableFoundation = "The Carrington Charitable Foundation verbiage.";
                Logger.Trace("ENDED:    To Carrington Charitable Foundation operation.");
                return CarringtonCharitableFoundation;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }

        private string GetPaymentInformationMessage(AccountsModel accountModel)
        {
            try
            {
                Logger.Trace("STARTED:  Execute to Get Payment Information Message operation.");
                var mailingState = "KS, LA, NM, OK, TX";
                if (mailingState.Contains(accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
                    PaymentInformationMessage = "Dallas P.O.Box Address.";
                else
                    PaymentInformationMessage = "Pasadena P.O.Box  Address.";
                Logger.Trace("ENDED:    To Payment Information Message operation.");
                return PaymentInformationMessage;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
        }



        #endregion
    }
}