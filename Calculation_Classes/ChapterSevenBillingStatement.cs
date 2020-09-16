using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Carrington_Service.Infrastructure;
using CarringtonMortgage.Models.InputCopyBookModels;
using SCT.Common;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace Carrington_Service.Calculation_Classes
{
    public class ChapterSevenBillingStatement : IChapterSevenBillingStatement
    {
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
        public StringBuilder finalLine;
        public ILogger Logger;
        public StringBuilder GetFinalChapterSevenBillingStatement(AccountsModel accountModel)
        {
            ExMessage = "Error Message";
            finalLine = new StringBuilder();
            finalLine.Append("01" + "|");
            finalLine.Append("STD stmp" + "|");
            finalLine.Append(" " + "|");
            finalLine.Append("01" + "|");

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
            finalLine.Append(GetPrintStatement(accountModel) + "|");
            finalLine.Append(GetPrimaryBorrowerBKAttorney(accountModel) + "|");
            finalLine.Append(GetSecondaryBorrower(accountModel) + "|");
            finalLine.Append(GetMailingBKAttorneyAddressLine1(accountModel) + "|");
            finalLine.Append(GetMailingBKAttorneyAddressLine2(accountModel) + "|");
            finalLine.Append(GetBorrowerAttorneyMailingCityStateZip(accountModel) + "|");
            finalLine.Append(GetMailingCountry(accountModel) + "|");
            finalLine.Append(GetBuydownBalance(accountModel) + "|");
            finalLine.Append(GetPartialClaim(accountModel) + "|");
            finalLine.Append(GetInterestRateUntil(accountModel) + "|");
            finalLine.Append(GetPrepaymentPenalty(accountModel) + "|");
            finalLine.Append(GetInterest(accountModel) + "|");
            finalLine.Append(GetEscrowTaxesandInsurance(accountModel) + "|");
            finalLine.Append(GetRegularMonthlyPayment(accountModel) + "|");
            finalLine.Append(GetCarringtonPaidLastMonh(accountModel) + "|");
            finalLine.Append(GetCarringtonCharitablePaidYeartoDate(accountModel) + "|");
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
                if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
                {
                    PaymentAmount = Convert.ToString("0.00");
                }
                else
                {
                    PaymentAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetPaymentAmount" + ExMessage);

            }
            return PaymentAmount;
        }
        public string GetDeferredBalance(AccountsModel accountModel)
        {
            try
            {
                if ((Convert.ToInt32(accountModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) - Convert.ToInt32(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData)) == 0)
                {
                    DeferredBalance = "N/A";
                }
                else
                {
                    DeferredBalance = Convert.ToString(Convert.ToInt32(accountModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) - Convert.ToInt32(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetDeferredBalance" + ExMessage);
            }
            return DeferredBalance;
        }
        public string GetPrincipal(AccountsModel accountModel)
        {
            try
            {
                if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0" || accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData == "0")
                {
                    Principal = "0.00";
                }
                else
                {
                    Principal = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_P_I_Pymt_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));

                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetPrincipal" + ExMessage);
            }
            return Principal;
        }

        public string GetPastUnpaidAmount(AccountsModel accountModel)
        {
            //Total Fees Paid was not there so used total fees due
            try
            {
                PastUnpaidAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData) - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Tot_Fees_Due_PackedData));

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetPastUnpaidAmount" + ExMessage);
            }
            return PastUnpaidAmount;
        }
        public string GetTotalFeesandCharges(AccountsModel accountModel)
        {
            //conditional statement is ther but not applying
            try
            {
                TotalFeesandCharges = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData));
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetTotalFeesandCharges" + ExMessage);
            }
            return TotalFeesandCharges;
        }
        public decimal GetTotalFeesPaid(AccountsModel accountModel)
        {
            try
            {
                if ((Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData) +
                        Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData)) <
                        Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))


                    TotalFeesPaid = Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Fees_PackedData) +
                    Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Due_PackedData) -
                    Convert.ToInt64(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData);

                else
                {
                    TotalFeesPaid = Convert.ToInt64(0.00);
                }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetTotalFeesPaid" + ExMessage);
            }

            return TotalFeesPaid;
        }
        public string GetTotalPaymentAmount(AccountsModel accountModel)
        {
            try
            {
                if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
                {
                    TotalPaymentAmount = Convert.ToString("0.00");
                }
                else
                {
                    TotalPaymentAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetTotalPaymentAmount" + ExMessage);
            }
            return TotalPaymentAmount;

        }
        public string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel)
        {

            try
            {
                if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
                    &&
                    (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
                {

                    FeesAndChargesPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData) +
                    Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData));
                }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetFeesAndChargesPaidLastMonth" + ExMessage);
            }

            return FeesAndChargesPaidLastMonth;
        }
        public string GetUnappliedFundsPaidLastMonth(AccountsModel accountModel)
        {
            try
            {
                UnappliedFundsPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05));
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetUnappliedFundsPaidLastMonth" + ExMessage);
            }
            return UnappliedFundsPaidLastMonth;
        }
        public string GetTotalPaidLastMonth(AccountsModel accountsModel)
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
        public string GetFeesAndChargesPaidYeartoDate(AccountsModel accountModel)
        {
            try
            {
                Decimal total = Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData) - Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData);
                if ((Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Log_Tran) == 5707) && (Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67 || Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198))
                {
                    FeesAndChargesPaidYeartoDate = Convert.ToString(total);
                }
                else
                {
                    FeesAndChargesPaidYeartoDate = string.Empty;
                }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetFeesAndChargesPaidYeartoDate" + ExMessage);
            }
            return FeesAndChargesPaidYeartoDate;
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                UnappliedFundsPaidYearToDate = Convert.ToString((accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0));
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetUnappliedFundsPaidYearToDate" + ExMessage);
            }
            return UnappliedFundsPaidYearToDate;
        }
        public string GetTotalPaidYearToDate(AccountsModel accountModel)
        {
            try
            {
                TotalPaidYearToDate = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) + (accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData));
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetTotalPaidYearToDate" + ExMessage);
            }
            return TotalPaidYearToDate;
        }
        public string GetTotalDue(AccountsModel accountModel)
        {
            try
            {
                if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
                {
                    TotalDue = Convert.ToString("0.00");
                }
                else
                {
                    TotalDue = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
                }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetTotalDue" + ExMessage);
            }
            return TotalDue;

        }
        public string GetSuspense(AccountsModel accountModel)
        {
            try
            {
                Suspense = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05));
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetSuspense" + ExMessage);
            }
            return Suspense;
        }
        public string GetMiscellaneous(AccountsModel accountModel)
        {
            try
            {
                Miscellaneous = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Lip_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Cr_Ins_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Pi_Shrtg) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Prin_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Int_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData));
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetMiscellaneous" + ExMessage);
            }
            return Miscellaneous;
        }

        #region MyRegion Ambrish
        public string GetPrintStatement(AccountsModel accountModel)
        {

            String printStatement = String.Empty;

            try
            {
                if (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") { printStatement = "create image but do not mail"; }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetPrintStatement" + ExMessage);
            }

            return printStatement;
        }

        public string GetPrimaryBorrowerBKAttorney(AccountsModel accountModel)
        {

            String primaryBorrowerBKAttorney = String.Empty;

            try
            {
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "N" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == null)
                { primaryBorrowerBKAttorney = "do not print statement"; }
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B") { primaryBorrowerBKAttorney = "RSSI - PRIMARY - NAME"; }
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L") { primaryBorrowerBKAttorney = "RSSI - VEND - NAME1"; }
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") { primaryBorrowerBKAttorney = "copy 1 to RSSI-PRIMARY - NAME and copy 2 to RSSI - VEND - NAME1"; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetPrimaryBorrowerBKAttorney" + ExMessage);
            }

            return primaryBorrowerBKAttorney;
        }

        public string GetSecondaryBorrower(AccountsModel accountModel)
        {

            String secondaryBorrower = String.Empty;
            try
            {
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                { secondaryBorrower = "RSSI - SECONDARY - NAME"; }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetSecondaryBorrower" + ExMessage);
            }

            return secondaryBorrower;
        }

        public string GetMailingBKAttorneyAddressLine1(AccountsModel accountModel)
        {

            String mailingBKAttorneyAddressLine1 = String.Empty;
            try
            {

                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                { mailingBKAttorneyAddressLine1 = "RSSI-MAI-ADRS-1"; }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                { mailingBKAttorneyAddressLine1 = "RSSI-VEND-ADRS1"; }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                { mailingBKAttorneyAddressLine1 = "copy 1 to RSSI-MAIL-ADRS-1 and copy 2 to RSSI-VEND-ADRS1"; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetMailingBKAttorneyAddressLine1" + ExMessage);
            }
            return mailingBKAttorneyAddressLine1;
        }

        public string GetMailingBKAttorneyAddressLine2(AccountsModel accountModel)
        {

            String mailingBKAttorneyAddressLine2 = String.Empty;

            try
            {
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                { mailingBKAttorneyAddressLine2 = "RSSI-MAIL-ADRS-2"; }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                { mailingBKAttorneyAddressLine2 = "RSSI-VEND-ADRS2"; }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                { mailingBKAttorneyAddressLine2 = "copy 1 to RSSI-MAIL-ADRS-2 and copy 2 to RSSI-VEND-ADRS2"; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetMailingBKAttorneyAddressLine2" + ExMessage);
            }
            return mailingBKAttorneyAddressLine2;
        }

        public string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountModel)
        {

            String borrowerAttorneyMailingCityStateZip = String.Empty;

            try
            {
                if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                { borrowerAttorneyMailingCityStateZip = "RSSI-MAIL-ADRS-3"; }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                { borrowerAttorneyMailingCityStateZip = "RSSI-VEND-CITY, RSSI-VEND-STATE, RSSI-VEND-ZIP"; }
                else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                { borrowerAttorneyMailingCityStateZip = "copy 1 to RSSI-MAIL-ADRS - 3 and copy 2 to RSSI-VEND-CITY, RSSI-VEND-STATE, RSSI-VEND-ZIP"; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetBorrowerAttorneyMailingCityStateZip" + ExMessage);
            }
            return borrowerAttorneyMailingCityStateZip;
        }

        public string GetMailingCountry(AccountsModel accountModel)
        {

            String mailingCountry = String.Empty;

            try
            {
                if (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                { mailingCountry = "RSSI-ALTR-CNTRY"; }
                else if (accountModel.MasterFileDataPart2Model.Rssi_Prim_Forgn_Flag == "Y")
                { mailingCountry = "RSSI-PRIM-MAIL-COUNTRY"; }
                else if (accountModel.MasterFileDataPart2Model.Rssi_Appl_Foreign_Flag == "Y")
                { mailingCountry = "RSSI-APPL-COUNTRY to copy 1"; }
                else { mailingCountry = null; }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetMailingCountry" + ExMessage);
            }

            return mailingCountry;
        }

        public string GetBuydownBalance(AccountsModel accountModel)
        {

            String buydownBalance = String.Empty;

            try
            {
                if (int.Parse(accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
                { buydownBalance = "N/A"; }
                else { buydownBalance = "RSSI-USR-303"; }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetBuydownBalance" + ExMessage);
            }

            return buydownBalance;
        }

        public string GetPartialClaim(AccountsModel accountModel)
        {

            String partialClaim = String.Empty;

            try
            {
                if (int.Parse(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                { partialClaim = "N/A"; }
                else { partialClaim = "RSSI-DEF-UNPD-EXP-ADV-BAL"; }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetPartialClaim" + ExMessage);
            }

            return partialClaim;
        }

        public string GetInterestRateUntil(AccountsModel accountModel)
        {

            String interestRateUntil = String.Empty;

            try
            {
                if (long.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date) > 19000000)
                { interestRateUntil = "(Until RSSI-RATE-CHG-DATE)"; }
                else { interestRateUntil = null; }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetInterestRateUntil" + ExMessage);
            }

            return interestRateUntil;
        }

        public string GetPrepaymentPenalty(AccountsModel accountModel)
        {

            String prepaymentPenalty = String.Empty;

            try
            {
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
                { prepaymentPenalty = "Yes"; }
                else { prepaymentPenalty = "No"; }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetPrepaymentPenalty" + ExMessage);
            }

            return prepaymentPenalty;
        }
        public string GetInterest(AccountsModel accountModel)
        {

            String interest = String.Empty;
            try
            {

                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                { interest = "0.00"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0) { interest = "0.00"; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetInterest" + ExMessage);
            }
            return interest;
        }

        public string GetEscrowTaxesandInsurance(AccountsModel accountModel)
        {

            String escrowTaxesandInsurance = String.Empty;

            try
            {
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                { escrowTaxesandInsurance = "0.00"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0) { escrowTaxesandInsurance = "0.00"; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetEscrowTaxesandInsurance" + ExMessage);
            }
            return escrowTaxesandInsurance;
        }

        public string GetRegularMonthlyPayment(AccountsModel accountModel)
        {

            String regularMonthlyPayment = String.Empty;

            try
            {
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                { regularMonthlyPayment = "0.00"; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetRegularMonthlyPayment" + ExMessage);
            }

            return regularMonthlyPayment;
        }

        public string GetCarringtonPaidLastMonh(AccountsModel accountModel)
        {

            String carringtonPaidLastMonh = String.Empty;

            try
            {
                if (int.Parse(accountModel.detModel.PriorMoAmnt) > 0 || int.Parse(accountModel.detModel.YTDAmnt) > 0)
                { carringtonPaidLastMonh = "print Carrington Charitable Foundation Donation line."; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetCarringtonPaidLastMonh" + ExMessage);
            }

            return carringtonPaidLastMonh;
        }

        public string GetCarringtonCharitablePaidYeartoDate(AccountsModel accountModel)
        {

            String carringtonCharitablePaidYeartoDate = String.Empty;

            try
            {
                if (int.Parse(accountModel.detModel.PriorMoAmnt) > 0 || int.Parse(accountModel.detModel.YTDAmnt) > 0)
                { carringtonCharitablePaidYeartoDate = "print Carrington Charitable Foundation Donation line."; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetCarringtonCharitablePaidYeartoDate" + ExMessage);
            }

            return carringtonCharitablePaidYeartoDate;
        }

        public string GetPOBoxAddress(AccountsModel accountModel)
        {

            String pOBoxAddress = String.Empty;

            try
            {
                if (accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 == "KS" || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 == "LA" || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 == "NM" || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 == "OK" || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 == "TX")
                { pOBoxAddress = "Dallas P.O.Box Address"; }
                else { pOBoxAddress = "Pasadena P.O.Box Address"; }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetPOBoxAddress" + ExMessage);
            }

            return pOBoxAddress;
        }

        public string GetAccountHistoryInformationbox(AccountsModel accountModel)
        {

            String accountHistoryInformationbox = String.Empty;


            try
            {
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                { accountHistoryInformationbox = "include the Delinquency Notice section"; }
                else { accountHistoryInformationbox = "leave blank."; }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetAccountHistoryInformationbox" + ExMessage);
            }

            return accountHistoryInformationbox;
        }

        public string GetRecentPayment6(AccountsModel accountModel)
        {

            String recentPayment6 = String.Empty;

            try
            {
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { recentPayment6 = "RSSI-PMT-DUE-5-DATE: Fully paid on RSSI-PMT-PAID-5-DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                { recentPayment6 = "RSSI - PMT - DUE - 4 - DATE: Fully paid on RSSI-PMT - PAID - 4 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                { recentPayment6 = "RSSI - PMT - DUE - 3 - DATE: Fully paid on RSSI-PMT - PAID - 3 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                { recentPayment6 = "RSSI - PMT - DUE - 2 - DATE: Fully paid on RSSI-PMT - PAID - 2 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5)
                { recentPayment6 = "RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { recentPayment6 = "RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetRecentPayment6" + ExMessage);
            }

            return recentPayment6;
        }

        public string GetRecentPayment5(AccountsModel accountModel)
        {

            String recentPayment5 = String.Empty;

            try
            {
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { recentPayment5 = "RSSI-PMT-DUE-4-DATE: Fully paid on RSSI-PMT-PAID-4-DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                { recentPayment5 = "RSSI - PMT - DUE - 3 - DATE: Fully paid on RSSI-PMT - PAID - 3 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                { recentPayment5 = "RSSI - PMT - DUE - 2 - DATE: Fully paid on RSSI-PMT - PAID - 2 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4)
                { recentPayment5 = "RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment5 = "RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { recentPayment5 = "RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetRecentPayment5" + ExMessage);
            }

            return recentPayment5;
        }

        public string GetRecentPayment4(AccountsModel accountModel)
        {

            String recentPayment4 = String.Empty;

            try
            {
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { recentPayment4 = "RSSI-PMT-DUE-3-DATE: Fully paid on RSSI-PMT-PAID-3-DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                { recentPayment4 = "RSSI - PMT - DUE - 2 - DATE: Fully paid on RSSI-PMT - PAID - 2 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3)
                { recentPayment4 = "RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment4 = "RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment4 = "RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { recentPayment4 = "RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetRecentPayment4" + ExMessage);
            }

            return recentPayment4;
        }

        public string GetRecentPayment3(AccountsModel accountModel)
        {

            String recentPayment3 = String.Empty;

            try
            {
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { recentPayment3 = "RSSI-PMT-DUE-2-DATE: Fully paid on RSSI-PMT-PAID-2-DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2)
                { recentPayment3 = "RSSI - PMT - DUE - 1 - DATE: Fully paid on RSSI-PMT - PAID - 1 - DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment3 = "RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment3 = "RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment3 = "RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { recentPayment3 = "RSSI - PAST - DATE(4): Unpaid balance of $RSSI - REG - AMT(4)"; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetRecentPayment3" + ExMessage);
            }

            return recentPayment3;
        }

        public string GetRecentPayment2(AccountsModel accountModel)
        {

            String recentPayment2 = String.Empty;

            try
            {
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1)
                { recentPayment2 = "RSSI-PMT-DUE-1-DATE: Fully paid on RSSI-PMT-PAID-1-DATE"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment2 = "RSSI - PAST - DATE(1): Unpaid balance of $RSSI - REG - AMT(1)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment2 = "RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment2 = "RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment2 = "RSSI - PAST - DATE(4): Unpaid balance of $RSSI - REG - AMT(4)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { recentPayment2 = "RSSI - PAST - DATE(5): Unpaid balance of $RSSI - REG - AMT(5)"; }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetRecentPaymente2" + ExMessage);
            }

            return recentPayment2;
        }

        public string GetRecentPayment1(AccountsModel accountModel)
        {

            String recentPayment1 = String.Empty;

            try
            {
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 1 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment1 = "RSSI-PAST-DATE (1): Unpaid balance of $RSSI-REG-AMT (1)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 2 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment1 = "RSSI - PAST - DATE(2): Unpaid balance of $RSSI - REG - AMT(2)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 3 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment1 = "RSSI - PAST - DATE(3): Unpaid balance of $RSSI - REG - AMT(3)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 4 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment1 = "RSSI - PAST - DATE(4): Unpaid balance of $RSSI - REG - AMT(4)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) == 5 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0)
                { recentPayment1 = "RSSI - PAST - DATE(5): Unpaid balance of $RSSI - REG - AMT(5)"; }
                else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Pymts_Due_Ctr_PackedData) >= 6 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Past_Date) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Reg_Amt_PackedData) > 0)
                { recentPayment1 = "RSSI - PAST - DATE(5): Unpaid balance of $RSSI - REG - AMT(5)"; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetRecentPayment1" + ExMessage);
            }

            return recentPayment1;
        }

        public string GetLenderPlacedInsuranceMessage(AccountsModel accountModel)
        {

            String lenderPlacedInsuranceMessage = String.Empty;

            try
            {
                if (accountModel.EscrowRecordModel.rssi_esc_type == "20" || accountModel.EscrowRecordModel.rssi_esc_type == "21" && accountModel.EscrowRecordModel.Rssi_Ins_Co == "2450" && accountModel.EscrowRecordModel.Rssi_Ins_Ag == "29000" || accountModel.EscrowRecordModel.Rssi_Ins_Ag == "29005" || accountModel.EscrowRecordModel.Rssi_Ins_Ag == "43000" || accountModel.EscrowRecordModel.Rssi_Ins_Ag == "43001")
                { lenderPlacedInsuranceMessage = "then print Lender Placed Insurance message"; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetLenderPlacedInsuranceMessage" + ExMessage);
            }
            return lenderPlacedInsuranceMessage;
        }

        public string GetStateNSF(AccountsModel accountModel)
        {

            String stateNSF = String.Empty;

            try
            {
                if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 6 || int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 16 ||
                      int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 18 || int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 42)
                { stateNSF = "print State NSF message"; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetStateNSF" + ExMessage);
            }
            return stateNSF;
        }

        public string GetAutodraftMessage(AccountsModel accountModel)
        {


            String autodraftMessage = String.Empty;

            try
            {
                if (int.Parse(accountModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
                { autodraftMessage = "print Autodraft message."; }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetAutodraftMessage" + ExMessage);
            }

            return autodraftMessage;
        }

        public string GetCMSPartialClaim(AccountsModel accountModel)
        {


            string cMSPartialClaim = string.Empty;
            try
            {
                if (int.Parse(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountModel.UserFieldRecordModel.Rssi_Usr_88 == "C")
                { cMSPartialClaim = "print Autodraft message."; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetCMSPartialClaim" + ExMessage);
            }
            return cMSPartialClaim;
        }

        public string GetHUDPartialClaim(AccountsModel accountModel)
        {


            string HUDPartialClaim = string.Empty;

            try
            {
                if (int.Parse(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 && accountModel.UserFieldRecordModel.Rssi_Usr_88 == "H")
                { HUDPartialClaim = "print HUD Partial Claim Message."; }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Mathod name : GetHUDPartialClaim" + ExMessage);
            }

            return HUDPartialClaim;
        }

        public string Geteffectivedate(AccountsModel accountModel)
        {

            string effectivedate = string.Empty;

            try
            {
                //if (RSSI_FT_TYPE_CODE == "000")
                //{ effectivedate = "RSSI-FEE-DATE-ASSESSED"; }
                //else { effectivedate = "RSSI-TR-DATE"; }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : Geteffectivedate" + ExMessage);
            }

            return effectivedate;
        }

        public string GetAmount(AccountsModel accountModel)
        {

            string amount = string.Empty;

            try
            {
                if (int.Parse(accountModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData) != 0)
                { amount = "RSSI-TR-EXP-FEE-AMT"; }
                //else if (RSSI_FT_TYPE_CODE == 000)
                //{ amount = "RSSI-FEE-AMT-ASSESSED"; }
                else { amount = "RSSI-TR-AMT"; }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetAmount" + ExMessage);
            }

            return amount;
        }

        public string GetStateDisclosures(AccountsModel accountModel)
        {

            string stateDisclosures = string.Empty;
            try
            {
                var RSSISTATE = "4, 6, 12, 22, 24, 33, 34, 43, 44 ";
                var MailingState = "AR, CO, HI, MA, MN, NC, NY, TN, TX ";
                if (RSSISTATE.Contains(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData))
                { stateDisclosures = ""; }
                else if (MailingState.Contains(accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
                { stateDisclosures = ""; }
            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetStateDisclosures" + ExMessage);
            }

            return stateDisclosures;
        }

        public string GetCarringtonCharitableFoundation(AccountsModel accountModel)
        {

            string carringtonCharitableFoundation = string.Empty;
            try
            {

                if (int.Parse(accountModel.detModel.PriorMoAmnt) > 0 || int.Parse(accountModel.detModel.YTDAmnt) > 0)
                { carringtonCharitableFoundation = "Print the Carrington Charitable Foundation verbiage."; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetCarringtonCharitableFoundation" + ExMessage);
            }
            return carringtonCharitableFoundation;
        }

        public string GetPaymentInformationMessage(AccountsModel accountModel)
        {

            string carringtonCharitableFoundation = string.Empty;

            try
            {
                if (accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA" || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "KS"
                       || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM" || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "OK"
                       || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX")
                { carringtonCharitableFoundation = "Dallas P.O.Box Address else Pasadena P.O.Box Address"; }

            }
            catch (Exception ex)
            {

                Logger.Error(ex, "Mathod name : GetPaymentInformationMessage" + ExMessage);
            }
            return carringtonCharitableFoundation;
        }
        #endregion Ambrish
    }
}