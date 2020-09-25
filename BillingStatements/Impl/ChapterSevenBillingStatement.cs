using System;
using System.Text;
using CarringtonMortgage.Helpers;
using CarringtonMortgage.Models.InputCopyBookModels;
using CarringtonService.Helpers;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace CarringtonService.BillingStatements
{
    public class ChapterSevenBillingStatement : IChapterSevenBillingStatement
    {

        public string PrintStatement { get; set; }
        public string PaymentAmount { get; set; }
        public string DeferredBalance { get; set; }
        public string Principal { get; set; }
        public string PastUnpaidAmount { get; set; }
        public string TotalFeesandCharges { get; set; }
        public Decimal TotalFeesPaid { get; set; }
        public string TotalPaymentAmount { get; set; }
        public string FeesAndChargesPaidLastMonth { get; set; }
        public string UnappliedFundsPaidLastMonth { get; set; }
        public string TotalPaidLastMonth { get; set; }
        public string FeesAndChargesPaidYeartoDate { get; set; }
        public string UnappliedFundsPaidYearToDate { get; set; }
        public string TotalPaidYearToDate { get; set; }
        public string TotalDue { get; set; }
        public string Suspense { get; set; }
        public string Miscellaneous { get; set; }
        public string ExMessage { get; set; }
        public string RecentPayment5 { get; set; }
        public string RecentPayment4 { get; set; }
        public string RecentPayment3 { get; set; }
        public string RecentPayment2 { get; set; }
        public string RecentPayment1 { get; set; }
        public string PrimaryBorrowerBkAttorney { get; set; }
        public string SecondaryBorrower { get; set; }
        public string MailingBkAttorneyAddressLine1 { get; set; }
        public string MailingBkAttorneyAddressLine2 { get; set; }
        public string BorrowerAttorneyMailingCityStateZip { get; set; }
        public string MailingCountry { get; set; }
        public string PaymentDate { get; set; }
        public string BuydownBalance { get; set; }
        public string PartialClaim { get; set; }
        public string InterestRateUntil { get; set; }
        public string PrepaymentPenalty { get; set; }
        public string Interest { get; set; }
        public string EscrowTaxesAndOrInsurance { get; set; }
        public string RegularMonthlyPayment { get; set; }
        public string CarringtonCharitableFoundationDonationPaidLastMonh { get; set; }
        public string CarringtonCharitableFoundationDonationPaidYearToDate { get; set; }
        //public string PaymentDate { get; set; }
        public string PoBoxAddress { get; set; }
        public string AccountHistoryInformationBox { get; set; }
        public string RecentPayment6 { get; set; }
        public string LenderPlacedInsuranceMessage { get; set; }
        public string StateNsf { get; set; }
        public string AutodraftMessage { get; set; }
        public string CmsPartialClaim { get; set; }
        public string HudPartialClaim { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string StateDisclosures { get; set; }
        public string CarringtonCharitableFoundation { get; set; }
        public string PaymentInformationMessage { get; set; }


        public StringBuilder finalLine;
        public ILogger Logger;
        public ChapterSevenBillingStatement(ILogger logger)
        {
            Logger = logger;
        }
        public StringBuilder GetFinalChapterSevenBillingStatement(AccountsModel accountModel, bool isCoborrower = false)
        {
            ExMessage = "Error Message";
            finalLine = new StringBuilder();

            finalLine.Append(GetPaymentAmount(accountModel) + "|");
            finalLine.Append(GetDeferredBalance(accountModel) + "|");
            finalLine.Append(GetPrincipal(accountModel) + "|");
            finalLine.Append(GetPastUnpaidAmount(accountModel) + "|");
            finalLine.Append(GetTotalFeesandCharges(accountModel) + "|");
            finalLine.Append(GetTotalFeesPaid(accountModel) + "|");
            finalLine.Append(GetTotalPaymentAmount(accountModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetTotalPaidLastMonth(accountModel) + "|");
            finalLine.Append(GetFeesAndChargesPaidYeartoDate(accountModel) + "|");
            finalLine.Append(GetUnappliedFundsPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetTotalPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetTotalDue(accountModel) + "|");
            finalLine.Append(GetSuspense(accountModel) + "|");
            finalLine.Append(GetMiscellaneous(accountModel) + "|");

            //TOD0:Revisit Again
            //Conditional Statement Methods
            finalLine.Append(GetPrintStatement(accountModel) + "|");
            finalLine.Append(GetPrimaryBorrowerBKAttorney(accountModel) + "|");
            finalLine.Append(GetSecondaryBorrower(accountModel) + "|");
            finalLine.Append(GetMailingBKAttorneyAddressLine1(accountModel) + "|");
            finalLine.Append(GetMailingBKAttorneyAddressLine2(accountModel) + "|");

            finalLine.Append(GetBorrowerAttorneyMailingCityStateZip(accountModel) + "|");
            finalLine.Append(GetMailingCountry(accountModel) + "|");
            finalLine.Append(GetPaymentDate(accountModel) + "|");


            finalLine.Append(GetBuydownBalance(accountModel) + "|");
            finalLine.Append(GetPartialClaim(accountModel) + "|");
            finalLine.Append(GetInterestRateUntil(accountModel) + "|");
            finalLine.Append(GetPrepaymentPenalty(accountModel) + "|");
            finalLine.Append(GetInterest(accountModel) + "|");
            finalLine.Append(GetEscrowTaxesandInsurance(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPayment(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitableFoundationDonationPaidLastMonh(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitableFoundationDonationPaidYearToDate(accountModel) + "|");
            finalLine.Append(GetPOBoxAddress(accountModel) + "|");
            finalLine.Append(GetAccountHistoryInformationbox(accountModel) + "|");
            finalLine.Append(GetRecentPayment6(accountModel) + "|");
            finalLine.Append(GetRecentPayment5(accountModel) + "|");
            finalLine.Append(GetRecentPayment4(accountModel) + "|");
            finalLine.Append(GetRecentPayment3(accountModel) + "|");
            finalLine.Append(GetRecentPayment2(accountModel) + "|");
            finalLine.Append(GetRecentPayment1(accountModel) + "|");
            finalLine.Append(GetLenderPlacedInsuranceMessage(accountModel) + "|");
            finalLine.Append(GetStateNSF(accountModel) + "|");
            finalLine.Append(GetAutodraftMessage(accountModel) + "|");
            finalLine.Append(GetCMSPartialClaim(accountModel) + "|");
            finalLine.Append(GetHUDPartialClaim(accountModel) + "|");
            finalLine.Append(Geteffectivedate(accountModel) + "|");
            finalLine.Append(GetAmount(accountModel) + "|");
            finalLine.Append(GetStateDisclosures(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitableFoundation(accountModel) + "|");
            finalLine.Append(GetPaymentInformationMessage(accountModel) + "|");

            return finalLine;
        }

        /* While Calculating Conditions must be applied*/
        public string GetPaymentAmount(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get payment amount");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
                {
                    PaymentAmount = Convert.ToString("0.00");
                }
                else
                {
                    PaymentAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
                //Logger.Trace("ENDED: Get payment amount");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPaymentAmount" + ExMessage);

            }
            return PaymentAmount;
        }
        public string GetDeferredBalance(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get deferred bBalance");
                if ((Convert.ToInt32(accountModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData) - Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData)) == 0)
                {
                    DeferredBalance = "N/A";
                }
                else
                {
                    DeferredBalance = Convert.ToString(Convert.ToInt32(accountModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal_PackedData) - Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
                }
                //Logger.Trace("ENDED: Get deferred Balance");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetDeferredBalance" + ExMessage);
            }
            return DeferredBalance;
        }
        public string GetPrincipal(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get principal");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0" || accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData == "0")
                {
                    Principal = "0.00";
                }
                else
                {
                    Principal = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_P_I_Pymt_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));

                }
                //Logger.Trace("ENDED: Get principal");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetPrincipal" + ExMessage);
            }
            return Principal;
        }

        public string GetPastUnpaidAmount(AccountsModel accountModel)
        {
            //Total Fees Paid was not there so used total fees due
            try
            {
                //Logger.Trace("STARTED:  Execute to Get past unpaid amount");
                PastUnpaidAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData) - Convert.ToDecimal(GetTotalFeesPaid(accountModel)));
                //Logger.Trace("ENDED: Get past unpaid amount");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetPastUnpaidAmount" + ExMessage);
            }
            return PastUnpaidAmount;
        }
        public string GetTotalFeesandCharges(AccountsModel accountModel)
        {
            //conditional statement is ther but not applying
            try
            {
                decimal result = 0;
                //Logger.Trace("STARTED:  Execute to Get total fees and charges");
                result = Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData);
                if (accountModel.TransactionRecordModel.Rssi_Log_Tran == "5605" && accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code == "67")
                {
                    result = result - Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData);

                }
                if ((accountModel.TransactionRecordModel.Rssi_Log_Tran == "5605" || accountModel.TransactionRecordModel.Rssi_Log_Tran == "5707") && accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code == "198")
                {
                    result = result - Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData);

                }

                TotalFeesandCharges = Convert.ToString(result);
                //Logger.Trace("ENDED: Get total fees and charges");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetTotalFeesandCharges" + ExMessage);
            }
            return TotalFeesandCharges;
        }
        public decimal GetTotalFeesPaid(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get total fees paid");
                if ((Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData) +
                        Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                        Convert.ToDecimal(GetTotalFeesandCharges(accountModel)))


                    TotalFeesPaid = Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_New_PackedData) +
                    Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData) -
                     Convert.ToDecimal(GetTotalFeesandCharges(accountModel));

                else
                {
                    TotalFeesPaid = Convert.ToInt64(0.00);
                }
                //Logger.Trace("ENDED: Get total fees paid");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetTotalFeesPaid" + ExMessage);
            }

            return TotalFeesPaid;
        }
        public string GetTotalPaymentAmount(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get total payment amount");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
                {
                    TotalPaymentAmount = Convert.ToString("0.00");
                }
                else
                {
                    TotalPaymentAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
                //Logger.Trace("ENDED: Get total payment amount");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetTotalPaymentAmount" + ExMessage);
            }
            return TotalPaymentAmount;

        }
        public string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel)
        {

            try
            {
                var result = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData) +
                   Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData);

                //Logger.Trace("STARTED:  Execute to Get fees and charges paid last month");
                if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                    &&
                    (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198))
                {

                    result -= Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData);
                }
                FeesAndChargesPaidLastMonth = Convert.ToString(result);
                //Logger.Trace("ENDED: Get fees and charges paid last month");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetFeesAndChargesPaidLastMonth" + ExMessage);
            }

            return FeesAndChargesPaidLastMonth;
        }
        public string GetUnappliedFundsPaidLastMonth(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get unapplied funds paid last month");
                UnappliedFundsPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_4_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_5_PackedData));
                //Logger.Trace("ENDED: Get  unapplied funds paid last month");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetUnappliedFundsPaidLastMonth" + ExMessage);
            }
            return UnappliedFundsPaidLastMonth;
        }
        public string GetTotalPaidLastMonth(AccountsModel accountsModel)
        {
            try
            {
                var result = Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData);

                //Logger.Trace("STARTED:  Execute to Get total paid last month");
                if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                    &&
                    (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198))
                {
                    //Need to know and Add PriorMoAmnt in this section
                    result -= Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData);
                }

                TotalPaidLastMonth = Convert.ToString(result + Convert.ToDecimal(accountsModel.detModel.PriorMoAmnt));

                //else
                //{
                //    TotalPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountsModel.MasterFileDataPart_1Model.Rssi_Tot_Pd_Since_Lst_Stmt_PackedData) - Convert.ToDecimal(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
                //}
                //Logger.Trace("ENDED: Get  total paid last month");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetTotalPaidLastMonth" + ExMessage);
            }

            return TotalPaidLastMonth;
        }
        public string GetFeesAndChargesPaidYeartoDate(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get fees and charges paid year to date");
                var total = Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData);
                if ((Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Log_Tran) == 5707) && (Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67 || Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198))
                {
                    total -= Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData);
                }
                FeesAndChargesPaidYeartoDate = Convert.ToString(total);
                //Logger.Trace("ENDED: Get fees and charges paid year to date");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetFeesAndChargesPaidYeartoDate" + ExMessage);
            }
            return FeesAndChargesPaidYeartoDate;
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get unapplied funds paid year to date");
                UnappliedFundsPaidYearToDate = Convert.ToString((accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ?
                    Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) +
                    (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0)
                    + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) +
                    (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) +
                    (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0));
                //Logger.Trace("ENDED: Get unapplied funds paid year to date");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetUnappliedFundsPaidYearToDate" + ExMessage);
            }
            return UnappliedFundsPaidYearToDate;
        }
        public string GetTotalPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get total paid year to date");
                var result = Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData) +
                    Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData)
                    + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) +
                    Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData) + (accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ?
                    Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ?
                    Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ?
                    Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ?
                    Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ?
                    Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0) +
                    Convert.ToDecimal(accountModel.SupplementalCCFModel.YTDAmnt);

                if ((Convert.ToInt64(accountModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                    &&
                    (Convert.ToInt64(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67 || Convert.ToInt64(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198))
                {
                    result -= Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData);
                }
                TotalPaidYearToDate = Convert.ToString(result);

                //Logger.Trace("ENDED: Get total paid year to date");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetTotalPaidYearToDate" + ExMessage);
            }
            return TotalPaidYearToDate;
        }

        public string GetTotalDue(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get total due");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
                {
                    TotalDue = Convert.ToString("0.00");
                }
                else
                {
                    TotalDue = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
                //Logger.Trace("ENDED: Get total due");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetTotalDue" + ExMessage);
            }
            return TotalDue;

        }
        public string GetSuspense(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get suspense");
                Suspense = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_4_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_5_PackedData));
                //Logger.Trace("ENDED: Get suspense");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetSuspense" + ExMessage);
            }
            return Suspense;
        }
        public string GetMiscellaneous(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get miscellaneous");
                Miscellaneous = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Lip_PackedData) +
                    Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Cr_Ins_PackedData) +
                    Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Pi_Shrtg) +
                    Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Prin_PackedData) +
                    Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Int_PackedData) +

                    Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData) +
                    Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData) +
                    Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData) +
                    Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData) +
                    Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData) +
                    Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData));
                //Logger.Trace("ENDED: Get miscellaneous");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetMiscellaneous" + ExMessage);
            }
            return Miscellaneous;
        }

        #region MyRegion Ambrish
        public string GetPrintStatement(AccountsModel accountModel)
        {



            try
            {
                //Logger.Trace("STARTED:  Execute to Get print statement");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H")
                {
                    PrintStatement = string.Empty;
                }
                //Logger.Trace("ENDED: Get print statement");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetPrintStatement" + ExMessage);
            }

            return PrintStatement;
        }

        public string GetPrimaryBorrowerBKAttorney(AccountsModel accountModel, bool isCoborrower = false)
        {


            try
            {
                //Logger.Trace("STARTED:  Execute to Get primary borrower bKAttorney");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "N" ||
                    accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == null)
                {
                    PrimaryBorrowerBkAttorney = string.Empty;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    PrimaryBorrowerBkAttorney = accountModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    PrimaryBorrowerBkAttorney = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    PrimaryBorrowerBkAttorney = !isCoborrower
                        ? accountModel.MasterFileDataPart_1Model.Rssi_Primary_Name
                        : accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1;

                }

                //Logger.Trace("ENDED: Get primary borrower bKAttorney");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetPrimaryBorrowerBKAttorney" + ExMessage);
            }

            return PrimaryBorrowerBkAttorney;
        }

        //public string GetPrimaryBorrowerBKAttorneycopy2(AccountsModel accountModel)
        //{

        //    String primaryBorrowerBKAttorney = String.Empty;

        //    try
        //    {
        //        //Logger.Trace("STARTED:  Execute to Get primary borrower bKAttorney");
        //        if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "N" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == null)
        //        { primaryBorrowerBKAttorney = ""; }
        //        if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B") { primaryBorrowerBKAttorney = accountModel.MasterFileDataPart_1Model.Rssi_Primary_Name; }
        //        if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L") { primaryBorrowerBKAttorney = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1; }
        //        if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
        //        {
        //            primaryBorrowerBKAttorney = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1;
        //        }
        //        //Logger.Trace("ENDED: Get primary borrower bKAttorney");
        //    }
        //    catch (Exception ex)
        //    {

        //        Logger.Error(ex, "Method name : GetPrimaryBorrowerBKAttorney" + ExMessage);
        //    }

        //    return primaryBorrowerBKAttorney;
        //}



        public string GetSecondaryBorrower(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get secondary borrower");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y" ||
                    accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    SecondaryBorrower = accountModel.MasterFileDataPart_1Model.Rssi_Secondary_Name;
                }
                //Logger.Trace("ENDED: Get secondary borrower");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetSecondaryBorrower" + ExMessage);
            }

            return SecondaryBorrower;
        }

        public string GetMailingBKAttorneyAddressLine1(AccountsModel accountModel, bool isCoborrower = false)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get mailing bKAttorney addressLine1.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    MailingBkAttorneyAddressLine1 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    MailingBkAttorneyAddressLine1 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    MailingBkAttorneyAddressLine1 = !isCoborrower
                        ? accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1
                        : accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1;

                }
                //Logger.Trace("ENDED: Get mailing bKAttorney addressLine1.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetMailingBKAttorneyAddressLine1" + ExMessage);
            }
            return MailingBkAttorneyAddressLine1;
        }

        //public string GetMailingBKAttorneyAddressLine1Copy2(AccountsModel accountModel)
        //{

        //    String mailingBKAttorneyAddressLine1 = String.Empty;
        //    try
        //    {
        //        //Logger.Trace("STARTED:  Execute to Get mailing bKAttorney addressLine1.");
        //        if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
        //        { mailingBKAttorneyAddressLine1 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1; }
        //        else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
        //        { mailingBKAttorneyAddressLine1 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1; }
        //        else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
        //        { mailingBKAttorneyAddressLine1 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1; }
        //        //Logger.Trace("ENDED: Get mailing bKAttorney addressLine1.");

        //    }
        //    catch (Exception ex)
        //    {

        //        Logger.Error(ex, "Method name : GetMailingBKAttorneyAddressLine1" + ExMessage);
        //    }
        //    return mailingBKAttorneyAddressLine1;
        //}

        public string GetMailingBKAttorneyAddressLine2(AccountsModel accountModel, bool isCoborrower = false)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get mailing bKAttorney addressLine2.");
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    MailingBkAttorneyAddressLine2 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    MailingBkAttorneyAddressLine2 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2;
                }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    MailingBkAttorneyAddressLine2 = !isCoborrower
                        ? accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2
                        : accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2;

                }
                //Logger.Trace("ENDED: Get mailing bKAttorney addressLine2.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetMailingBKAttorneyAddressLine2" + ExMessage);
            }
            return MailingBkAttorneyAddressLine2;
        }

        //public string GetMailingBKAttorneyAddressLine2Copy2(AccountsModel accountModel)
        //{

        //    String mailingBKAttorneyAddressLine2 = String.Empty;

        //    try
        //    {
        //        //Logger.Trace("STARTED:  Execute to Get mailing bKAttorney addressLine2.");
        //        if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
        //        { mailingBKAttorneyAddressLine2 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2; }
        //        else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
        //        { mailingBKAttorneyAddressLine2 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2; }
        //        else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
        //        { mailingBKAttorneyAddressLine2 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2; }
        //        //Logger.Trace("ENDED: Get mailing bKAttorney addressLine2.");
        //    }
        //    catch (Exception ex)
        //    {

        //        Logger.Error(ex, "Method name : GetMailingBKAttorneyAddressLine2" + ExMessage);
        //    }
        //    return mailingBKAttorneyAddressLine2;
        //}

        //public string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountModel)
        //{


        //    try
        //    {
        //        //Logger.Trace("STARTED:  Execute to Get borrower attorney mailing city state zip.");
        //        if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
        //        { BorrowerAttorneyMailingCityStateZip = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3; }
        //        else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
        //        { BorrowerAttorneyMailingCityStateZip = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_City + "," + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_State + "," + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Zip; }
        //        else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
        //        { BorrowerAttorneyMailingCityStateZip = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3; }
        //        //Logger.Trace("ENDED: Get borrower attorney mailing city state zip.");
        //    }
        //    catch (Exception ex)
        //    {

        //        Logger.Error(ex, "Method name : GetBorrowerAttorneyMailingCityStateZip" + ExMessage);
        //    }
        //    return BorrowerAttorneyMailingCityStateZip;
        //}

        //public string GetBorrowerAttorneyMailingCityStateZipCopy2(AccountsModel accountModel)
        //{

        //    String borrowerAttorneyMailingCityStateZip = String.Empty;

        //    try
        //    {
        //        //Logger.Trace("STARTED:  Execute to Get borrower attorney mailing city state zip.");
        //        if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
        //        { borrowerAttorneyMailingCityStateZip = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3; }
        //        else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
        //        { borrowerAttorneyMailingCityStateZip = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_City + "," + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_State + "," + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Zip; }
        //        else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
        //        { borrowerAttorneyMailingCityStateZip = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_City + "," + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_State + "," + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Zip; }
        //        //Logger.Trace("ENDED: Get borrower attorney mailing city state zip.");
        //    }
        //    catch (Exception ex)
        //    {

        //        Logger.Error(ex, "Method name : GetBorrowerAttorneyMailingCityStateZip" + ExMessage);
        //    }
        //    return borrowerAttorneyMailingCityStateZip;
        //}
        //public string GetMailingCountry(AccountsModel accountModel)
        //{

        //    String mailingCountry = String.Empty;

        //    try
        //    {
        //        //Logger.Trace("STARTED:  Execute to Get mailing country.");
        //        if (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
        //        { mailingCountry = accountModel.ForeignInformationRecordModel.Rssi_Altr_Cntry; }
        //        else if (accountModel.MasterFileDataPart2Model.Rssi_Prim_Forgn_Flag == "Y")
        //        { mailingCountry = accountModel.ForeignInformationRecordModel.Rssi_Prim_Mail_Country; }
        //        else if (accountModel.MasterFileDataPart2Model.Rssi_Appl_Foreign_Flag == "Y")
        //        { mailingCountry = accountModel.ForeignInformationRecordModel.Rssi_Prim_Mail_Country; }
        //        else { mailingCountry = null; }
        //        //Logger.Trace("ENDED: Get mailing country.");
        //    }
        //    catch (Exception ex)
        //    {

        //        Logger.Error(ex, "Method name : GetMailingCountry" + ExMessage);
        //    }

        //    return mailingCountry;
        //}

        public string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountsModel, bool isCoBorrower = false)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Borrower Attorney Mailing City State Zip");

                if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                {
                    BorrowerAttorneyMailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                }
                else if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                {
                    BorrowerAttorneyMailingCityStateZip = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_City + "," +
                         accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_State + "," +
                         accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Zip;
                }
                if (accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                {
                    if (!isCoBorrower)
                        BorrowerAttorneyMailingCityStateZip = accountsModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
                    else
                    {

                        BorrowerAttorneyMailingCityStateZip = accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_City + "," +
                                     accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_State + "," +
                                     accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Zip;
                    }
                }
                //Logger.Trace("ENDED:  To Get Borrower Attorney Mailing City State Zip");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return BorrowerAttorneyMailingCityStateZip;
        }
        /// <summary>
        /// 8
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetMailingCountry(AccountsModel accountsModel, bool isCoBorrower = false)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Mailing Country");

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
                    if (isCoBorrower)
                        MailingCountry = accountsModel.ForeignInformationRecordModel.Rssi_Appl_Country;
                    else
                        MailingCountry = "null";
                }
                else
                {
                    MailingCountry = "null";
                }
                //Logger.Trace("ENDED:  To Get Mailing Country");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return MailingCountry;
        }
        /// <summary>
        /// 15
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetPaymentDate(AccountsModel accountsModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Mailing Country");

                PaymentDate = accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte;

                //Logger.Trace("ENDED:  To Get Mailing Country");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return PaymentDate;
        }



        public string GetBuydownBalance(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get buy down balance.");
                if (Convert.ToDecimal(accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
                { BuydownBalance = "N/A"; }
                else { BuydownBalance = accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData; }
                //Logger.Trace("ENDED: Get buy down balance.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetBuydownBalance" + ExMessage);
            }

            return BuydownBalance;
        }

        public string GetPartialClaim(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get partial claim.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                { PartialClaim = "N/A"; }
                else { PartialClaim = accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData; }
                //Logger.Trace("ENDED: Get partial claim.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetPartialClaim" + ExMessage);
            }

            return PartialClaim;
        }

        //TOD0:Revisit Again check the date format
        public string GetInterestRateUntil(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get interest rate until.");
                if (long.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date) > 19000000)
                { InterestRateUntil = "Until " + accountModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date; }
                else { InterestRateUntil = null; }
                //Logger.Trace("ENDED: Get interest rate until.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetInterestRateUntil" + ExMessage);
            }

            return InterestRateUntil;
        }

        public string GetPrepaymentPenalty(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get prepayment penalty.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
                { PrepaymentPenalty = "Yes"; }
                else { PrepaymentPenalty = "No"; }
                //Logger.Trace("ENDED: Get prepayment penalty.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetPrepaymentPenalty" + ExMessage);
            }

            return PrepaymentPenalty;
        }
        public string GetInterest(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get interest.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                { Interest = "0.00"; }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0) { Interest = "0.00"; }
                //Logger.Trace("ENDED: Get interest.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetInterest" + ExMessage);
            }
            return Interest;
        }

        public string GetEscrowTaxesandInsurance(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get escrow taxes and insurance.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                { EscrowTaxesAndOrInsurance = "0.00"; }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0) { EscrowTaxesAndOrInsurance = "0.00"; }
                //Logger.Trace("ENDED: Get escrow taxes and insurance.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetEscrowTaxesandInsurance" + ExMessage);
            }
            return EscrowTaxesAndOrInsurance;
        }

        public string GetRegularMonthlyPayment(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get regular monthly payment.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                { RegularMonthlyPayment = "0.00"; }
                //Logger.Trace("ENDED: Get regular monthly payment.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetRegularMonthlyPayment" + ExMessage);
            }

            return RegularMonthlyPayment;
        }

        //TOD0:Revisit Again
        public string GetCarringtonCharitableFoundationDonationPaidLastMonh(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get carrington paid last month.");
                if (Convert.ToDecimal(accountModel.SupplementalCCFModel.PriorMoAmnt) > 0 || Convert.ToDecimal(accountModel.SupplementalCCFModel.YTDAmnt) > 0)
                { CarringtonCharitableFoundationDonationPaidLastMonh = "CharitableFoundationDonation_MessageFlag"; }
                //Logger.Trace("ENDED: Get regular monthly payment.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetCarringtonPaidLastMonh" + ExMessage);
            }

            return CarringtonCharitableFoundationDonationPaidLastMonh;
        }

        public string GetCarringtonCharitableFoundationDonationPaidYearToDate(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get carrington charitable paid yearto date.");
                if (Convert.ToDecimal(accountModel.SupplementalCCFModel.PriorMoAmnt) > 0 || Convert.ToDecimal(accountModel.SupplementalCCFModel.YTDAmnt) > 0)
                { CarringtonCharitableFoundationDonationPaidYearToDate = "CharitableFoundationDonation_MessageFlag"; }
                //Logger.Trace("ENDED: Get carrington charitable paid yearto date.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetCarringtonCharitablePaidYeartoDate" + ExMessage);
            }

            return CarringtonCharitableFoundationDonationPaidYearToDate;
        }

        //TOD0 Revist
        public string GetPOBoxAddress(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get POBox address.");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 == "KS" ||
                    accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 == "LA" ||
                    accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 == "NM" ||
                    accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 == "OK" ||
                    accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 == "TX")
                { PoBoxAddress = "Dallas P.O.Box Address"; }
                else { PoBoxAddress = "Pasadena P.O.Box Address"; }
                //Logger.Trace("ENDED: Get  POBox address.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetPOBoxAddress" + ExMessage);
            }

            return PoBoxAddress;
        }

        //TOD0:Revisit Again
        public string GetAccountHistoryInformationbox(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get account history information box.");
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30 &&
                    Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                { AccountHistoryInformationBox = "DelinquencyNoticeSection_MessageFlag"; }
                else { AccountHistoryInformationBox = string.Empty; }
                //Logger.Trace("ENDED: Get  account history information box.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetAccountHistoryInformationbox" + ExMessage);
            }

            return AccountHistoryInformationBox;
        }

        public string GetRecentPayment6(AccountsModel accountModel)
        {

            try
            {
                //Logger.Trace("STARTED:  Execute to Get recent payment6.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_5 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_5; }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_4 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_4;
                }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                { RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_3 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_3; }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                { RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_2 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_2; }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5)
                { RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Due_Date_1 + ": Fully paid on " + accountModel.MasterFileDataPart_1Model.Rssi_Pmt_Paid_Date_1; }
                else if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 
                    && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment6 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)"; ;
                }
                //Logger.Trace("ENDED: Get  recent payment6.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetRecentPayment6" + ExMessage);
            }

            return RecentPayment6;
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
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
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
                throw;
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
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment4 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
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
                throw;
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
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment3 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
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
                throw;
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
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment2 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
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
                throw;
            }
            return RecentPayment2;
        }

        public string GetRecentPayment1(AccountsModel accountModel)
        {
            try
            {
                //Logger.Trace("STARTED:  Execute to Get Recent Payment1");

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(1): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(1)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(2): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(2)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(3): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(3)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(4): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(4)";

                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(5): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(5)";
                }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6
                && Convert.ToUInt64(CommonHelper.GetFormatedDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date).IncludeCenturyDate(true)) > 0
                && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                //else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                {
                    RecentPayment1 = accountModel.MasterFileDataPart_1Model.Rssi_Past_Date + "(5): Unpaid balance of " + accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData + "(5)";
                }
                //Logger.Trace("ENDED:  To Get Recent Payment1");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.TargetSite.Name);
                throw;
            }
            return RecentPayment1;
        }

        //TOD0:Revisit Again
        public string GetLenderPlacedInsuranceMessage(AccountsModel accountModel)
        {          
            try
            {
                //Logger.Trace("STARTED:  Execute to Get lender placed insurance message.");
                if (accountModel.EscrowRecordModel.rssi_esc_type == "20" || 
                    accountModel.EscrowRecordModel.rssi_esc_type == "21" &&
                    accountModel.EscrowRecordModel.Rssi_Ins_Co == "2450" && 
                    accountModel.EscrowRecordModel.Rssi_Ins_Ag == "29000" || 
                    accountModel.EscrowRecordModel.Rssi_Ins_Ag == "29005" || 
                    accountModel.EscrowRecordModel.Rssi_Ins_Ag == "43000" || 
                    accountModel.EscrowRecordModel.Rssi_Ins_Ag == "43001")
                { LenderPlacedInsuranceMessage = "LenderPlacedInsurance_MessageFlag"; }
                //Logger.Trace("ENDED: Get  lender placed insurance message.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetLenderPlacedInsuranceMessage" + ExMessage);
            }
            return LenderPlacedInsuranceMessage;
        }
        
        public string GetStateNSF(AccountsModel accountModel)
        {


            try
            {
                //Logger.Trace("STARTED:  Execute to Get StateNSF.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 6 || Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 16 ||
                      Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 18 || Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 42)
                { StateNsf = "State NSF message"; }
                //Logger.Trace("ENDED: Get  StateNSF.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetStateNSF" + ExMessage);
            }
            return StateNsf;
        }

        public string GetAutodraftMessage(AccountsModel accountModel)
        {


            String autodraftMessage = String.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute to Get auto draft message.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0 && Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                { autodraftMessage = "Autodraft message."; }
                //Logger.Trace("ENDED: Get  auto draft message.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetAutodraftMessage" + ExMessage);
            }

            return autodraftMessage;
        }

        public string GetCMSPartialClaim(AccountsModel accountModel)
        {


            string cMSPartialClaim = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute to Get CMS partial claim.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountModel.UserFieldRecordModel.Rssi_Usr_88 == "C")
                { cMSPartialClaim = "Autodraft message."; }
                //Logger.Trace("ENDED: Get  CMS partial claim.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetCMSPartialClaim" + ExMessage);
            }
            return cMSPartialClaim;
        }

        public string GetHUDPartialClaim(AccountsModel accountModel)
        {


            string HUDPartialClaim = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute to Get HUD partial claim.");
                if (Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountModel.UserFieldRecordModel.Rssi_Usr_88 == "H")
                { HUDPartialClaim = "HUD Partial Claim Message."; }
                //Logger.Trace("ENDED: Get  HUD partial claim.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Method name : GetHUDPartialClaim" + ExMessage);
            }

            return HUDPartialClaim;
        }

        public string Geteffectivedate(AccountsModel accountModel)
        {

            string effectivedate = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute to Get effective date.");
                //if (RSSI_FT_TYPE_CODE == "000")
                //{ effectivedate = "RSSI-FEE-DATE-ASSESSED"; }
                //else { effectivedate = "RSSI-TR-DATE"; }
                //Logger.Trace("ENDED: Get  effective date.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : Geteffectivedate" + ExMessage);
            }

            return effectivedate;
        }

        public string GetAmount(AccountsModel accountModel)
        {

            string amount = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute to Get amount.");
                if (Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData) != 0)
                { amount = "RSSI-TR-EXP-FEE-AMT"; }
                //else if (RSSI_FT_TYPE_CODE == 000)
                //{ amount = "RSSI-FEE-AMT-ASSESSED"; }
                else { amount = "RSSI-TR-AMT"; }
                //Logger.Trace("ENDED: Get amount.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetAmount" + ExMessage);
            }

            return amount;
        }

        public string GetStateDisclosures(AccountsModel accountModel)
        {

            string stateDisclosures = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute to Get state disclosures.");
                var RSSISTATE = "4, 6, 12, 22, 24, 33, 34, 43, 44 ";
                var MailingState = "AR, CO, HI, MA, MN, NC, NY, TN, TX ";
                if (RSSISTATE.Contains(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData))
                { stateDisclosures = ""; }
                else if (MailingState.Contains(accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
                { stateDisclosures = ""; }
                //Logger.Trace("ENDED: Get state disclosures.");
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetStateDisclosures" + ExMessage);
            }

            return stateDisclosures;
        }

        public string GetCarringtonCharitableFoundation(AccountsModel accountModel)
        {

            string carringtonCharitableFoundation = string.Empty;
            try
            {
                //Logger.Trace("STARTED:  Execute to Get carrington charitable foundation.");
                if (accountModel.detModel.PriorMoAmnt != null && accountModel.detModel.YTDAmnt != null)
                {
                    if (int.Parse(accountModel.detModel.PriorMoAmnt) > 0 || int.Parse(accountModel.detModel.YTDAmnt) > 0)
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

        public string GetPaymentInformationMessage(AccountsModel accountModel)
        {

            string carringtonCharitableFoundation = string.Empty;

            try
            {
                //Logger.Trace("STARTED:  Execute to Get payment information message.");
                if (accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA" || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS"
                       || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM" || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK"
                       || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX")
                { carringtonCharitableFoundation = "Dallas P.O.Box Address else Pasadena P.O.Box Address"; }

                //Logger.Trace("ENDED: Get payment information message.");

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Method name : GetPaymentInformationMessage" + ExMessage);
            }
            return carringtonCharitableFoundation;
        }
        #endregion Ambrish
    }
}