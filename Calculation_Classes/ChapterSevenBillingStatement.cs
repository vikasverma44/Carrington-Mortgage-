using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using ODHS_EDelivery.Models.InputCopyBookModels;
using SCT.Common;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace Carrington_Service.Calculation_Classes
{
    public class ChapterSevenBillingStatement
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
        ChapterSevenBillingStatement()
        {

        }

        /* While Calculating Conditions must be applied*/
        public string GetPaymentAmount(AccountsModel accountModel)
        {

            if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
            {
                PaymentAmount = Convert.ToString("0.00");
            }
            else
            {
                PaymentAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
            }
            return PaymentAmount;
        }
        public string GetDeferredBalance(AccountsModel accountModel)
        {
            if ((Convert.ToInt32(accountModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) - Convert.ToInt32(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData)) == 0)
            {
                DeferredBalance = "N/A";
            }
            else
            {
                DeferredBalance = Convert.ToString(Convert.ToInt32(accountModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) - Convert.ToInt32(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));
            }
            return DeferredBalance;
        }
        public string GetPrincipal(AccountsModel accountModel)
        {
            if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0" || accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData=="0")
            {
                Principal = "0.00";
            }
            else
            {
                Principal = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_P_I_Pymt_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Due_PackedData));

            }

                return Principal;
        }

        public string GetPastUnpaidAmount(AccountsModel accountModel)
        {
            //Total Fees Paid was not there so used total fees due
            PastUnpaidAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData) - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData) - Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Tot_Fees_Due_PackedData));
           
            return PastUnpaidAmount;
        }
        public string GetTotalFeesandCharges(AccountsModel accountModel)
        {
            //conditional statement is ther but not applying
            TotalFeesandCharges = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Assd_Since_Lst_Stmt_PackedData)+Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Accr_Lc_PackedData));
            return TotalFeesandCharges;
        }
        public decimal GetTotalFeesPaid(AccountsModel accountModel)
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

            return TotalFeesPaid;
        }
        public string GetTotalPaymentAmount(AccountsModel accountModel)
        {
            if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
            {
                TotalPaymentAmount = Convert.ToString("0.00");
            }
            else
            {
                TotalPaymentAmount = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
            }
            return TotalPaymentAmount;

            }
        public string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel)
        {

            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
              &&
              (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
            {

                FeesAndChargesPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData) +
                Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData));
            }

            return FeesAndChargesPaidLastMonth;
        }
        public string GetUnappliedFundsPaidLastMonth(AccountsModel accountModel)
        {
            UnappliedFundsPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05));
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
        public string GetFeesAndChargesPaidYeartoDate(AccountsModel accountModel)
        {
            Decimal total = Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData) - Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData);
            if((Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Log_Tran)==5705 || Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Log_Tran) == 5707) && (Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code)==67 || Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code)==198))
            {
                FeesAndChargesPaidYeartoDate = Convert.ToString(total);
            }
            else
            {
                FeesAndChargesPaidYeartoDate = string.Empty;
            }
            return FeesAndChargesPaidYeartoDate;
        }
        public string GetUnappliedFundsPaidYearToDate(AccountsModel accountModel)
        {
            UnappliedFundsPaidYearToDate= Convert.ToString((accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0));
            return UnappliedFundsPaidYearToDate;
        }
        public string GetTotalPaidYearToDate(AccountsModel accountModel)
        {
            TotalPaidYearToDate= Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) +(accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd !="L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData));
            return TotalPaidYearToDate;
        }
        public string GetTotalDue(AccountsModel accountModel)
        {
            if (accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData == "0")
            {
                TotalDue = Convert.ToString("0.00");
            }
            else
            {
                TotalDue = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Total_Due_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData));
            }
            return TotalDue;
            
        }
        public string GetSuspense(AccountsModel accountModel)
        {
            Suspense = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05));
            return Suspense;
        }
        public string GetMiscellaneous(AccountsModel accountModel)
        {
            Miscellaneous= Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Lip_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Cr_Ins_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Pi_Shrtg) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Prin_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Int_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData));
            return Miscellaneous;
        }

        #region MyRegion Ambrish
        public string PrintStatement(AccountsModel accountModel)
        {
           
            String printStatement = String.Empty;
            
            if (accountModel.MasterFileDataPart_1Model.Rssi_Print_Stmt == "H") { printStatement = "create image but do not mail"; }

            return printStatement;
        }

        public string PrimaryBorrowerBKAttorney(AccountsModel accountModel)
        {
            
            String primaryBorrowerBKAttorney = String.Empty;
            
            if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "N" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == null)
            { primaryBorrowerBKAttorney = "do not print statement"; }
            if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B") { primaryBorrowerBKAttorney = "RSSI - PRIMARY - NAME"; }
            if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L") { primaryBorrowerBKAttorney = "RSSI - VEND - NAME1"; }
            if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y") { primaryBorrowerBKAttorney = "copy 1 to RSSI-PRIMARY - NAME and copy 2 to RSSI - VEND - NAME1"; }


            return primaryBorrowerBKAttorney;
        }

        public string SecondaryBorrower(AccountsModel accountModel)
        {
            
            String secondaryBorrower = String.Empty;
            if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
            { secondaryBorrower = "RSSI - SECONDARY - NAME"; }

            return secondaryBorrower;
        }

        public string MailingBKAttorneyAddressLine1(AccountsModel accountModel)
        {
            
            String mailingBKAttorneyAddressLine1 = String.Empty;

            if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
            { mailingBKAttorneyAddressLine1 = "RSSI-MAI-ADRS-1"; }
            else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
            { mailingBKAttorneyAddressLine1 = "RSSI-VEND-ADRS1"; }
            else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
            { mailingBKAttorneyAddressLine1 = "copy 1 to RSSI-MAIL-ADRS-1 and copy 2 to RSSI-VEND-ADRS1"; }

            return mailingBKAttorneyAddressLine1;
        }

        public string MailingBKAttorneyAddressLine2(AccountsModel accountModel)
        {
            
            String mailingBKAttorneyAddressLine2 = String.Empty;

            if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
            { mailingBKAttorneyAddressLine2 = "RSSI-MAIL-ADRS-2"; }
            else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
            { mailingBKAttorneyAddressLine2 = "RSSI-VEND-ADRS2"; }
            else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
            { mailingBKAttorneyAddressLine2 = "copy 1 to RSSI-MAIL-ADRS-2 and copy 2 to RSSI-VEND-ADRS2"; }

            return mailingBKAttorneyAddressLine2;
        }

        public string BorrowerAttorneyMailingCityStateZip(AccountsModel accountModel)
        {
            
            String borrowerAttorneyMailingCityStateZip = String.Empty;

            if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
            { borrowerAttorneyMailingCityStateZip = "RSSI-MAIL-ADRS-3"; }
            else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
            { borrowerAttorneyMailingCityStateZip = "RSSI-VEND-CITY, RSSI-VEND-STATE, RSSI-VEND-ZIP"; }
            else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
            { borrowerAttorneyMailingCityStateZip = "copy 1 to RSSI-MAIL-ADRS - 3 and copy 2 to RSSI-VEND-CITY, RSSI-VEND-STATE, RSSI-VEND-ZIP"; }

            return borrowerAttorneyMailingCityStateZip;
        }

        public string MailingCountry(AccountsModel accountModel)
        {
            
            String mailingCountry = String.Empty;

            if (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
            { mailingCountry = "RSSI-ALTR-CNTRY"; }
            else if (accountModel.MasterFileDataPart2Model.Rssi_Prim_Forgn_Flag == "Y")
            { mailingCountry = "RSSI-PRIM-MAIL-COUNTRY"; }
            else if (accountModel.MasterFileDataPart2Model.Rssi_Appl_Foreign_Flag == "Y")
            { mailingCountry = "RSSI-APPL-COUNTRY to copy 1"; }
            else { mailingCountry = null; }

            return mailingCountry;
        }

        public string BuydownBalance(AccountsModel accountModel)
        {
            
            String buydownBalance = String.Empty;
           
            if (int.Parse( accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
            { buydownBalance = "N/A"; }
            else { buydownBalance = "RSSI-USR-303"; }

            return buydownBalance;
        }

        public string PartialClaim(AccountsModel accountModel)
        {
            
            String partialClaim = String.Empty;

            if (int.Parse(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
            { partialClaim = "N/A"; }
            else { partialClaim = "RSSI-DEF-UNPD-EXP-ADV-BAL"; }

            return partialClaim;
        }

        public string InterestRateUntil(AccountsModel accountModel)
        {
           
            String interestRateUntil = String.Empty;
            
            if (long.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date) > 19000000)
            { interestRateUntil = "(Until RSSI-RATE-CHG-DATE)"; }
            else { interestRateUntil = null; }

            return interestRateUntil;
        }

        public string PrepaymentPenalty(AccountsModel accountModel)
        {
           
            String prepaymentPenalty = String.Empty;

            if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Prepay_Pen_Amt_PackedData) > 0)
            { prepaymentPenalty = "Yes"; }
            else { prepaymentPenalty = "No"; }

            return prepaymentPenalty;
        }
        public string Interest(AccountsModel accountModel)
        {
           
            String interest = String.Empty;

            if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
            { interest = "0.00"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0) { interest = "0.00"; }

            return interest;
        }

        public string EscrowTaxesandInsurance(AccountsModel accountModel)
        {
           
            String escrowTaxesandInsurance = String.Empty;

            if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
            { escrowTaxesandInsurance = "0.00"; }
            else if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0) { escrowTaxesandInsurance = "0.00"; }

            return escrowTaxesandInsurance;
        }

        public string RegularMonthlyPayment(AccountsModel accountModel)
        {
           
            String regularMonthlyPayment = String.Empty;

            if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
            { regularMonthlyPayment = "0.00"; }


            return regularMonthlyPayment;
        }

        public string CarringtonPaidLastMonh(AccountsModel accountModel)
        {
            
            String carringtonPaidLastMonh = String.Empty;

            if (int.Parse( accountModel.detModel.PriorMoAmnt) > 0 || int.Parse( accountModel.detModel.YTDAmnt) > 0)
            { carringtonPaidLastMonh = "print Carrington Charitable Foundation Donation line."; }


            return carringtonPaidLastMonh;
        }

        public string CarringtonCharitablePaidYeartoDate(AccountsModel accountModel)
        {
            
            String carringtonCharitablePaidYeartoDate = String.Empty;

            if (int.Parse( accountModel.detModel.PriorMoAmnt) > 0 || int.Parse( accountModel.detModel.YTDAmnt) > 0)
            { carringtonCharitablePaidYeartoDate = "print Carrington Charitable Foundation Donation line."; }


            return carringtonCharitablePaidYeartoDate;
        }

        public string POBoxAddress(AccountsModel accountModel)
        {
           
            String pOBoxAddress = String.Empty;

            if (accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 == "KS" || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 == "LA" || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 == "NM" || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 == "OK" || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 == "TX")
            { pOBoxAddress = "Dallas P.O.Box Address"; }
            else { pOBoxAddress = "Pasadena P.O.Box Address"; }

            return pOBoxAddress;
        }

        public string AccountHistoryInformationbox(AccountsModel accountModel)
        {
           
            String accountHistoryInformationbox = String.Empty;


            if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Num_Days_Delq) >= 30 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
            { accountHistoryInformationbox = "include the Delinquency Notice section"; }
            else { accountHistoryInformationbox = "leave blank."; }

            return accountHistoryInformationbox;
        }

        public string RecentPayment6(AccountsModel accountModel)
        {
           
            String recentPayment6 = String.Empty;

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


            return recentPayment6;
        }

        public string RecentPayment5(AccountsModel accountModel)
        {
           
            String recentPayment5 = String.Empty;

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


            return recentPayment5;
        }

        public string RecentPayment4(AccountsModel accountModel)
        {
           
            String recentPayment4 = String.Empty;

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


            return recentPayment4;
        }

        public string RecentPayment3(AccountsModel accountModel)
        {
           
            String recentPayment3 = String.Empty;

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


            return recentPayment3;
        }

        public string RecentPayment2(AccountsModel accountModel)
        {
           
            String recentPayment2 = String.Empty;

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


            return recentPayment2;
        }

        public string RecentPayment1(AccountsModel accountModel)
        {
           
            String recentPayment1 = String.Empty;

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


            return recentPayment1;
        }

        public string LenderPlacedInsuranceMessage(AccountsModel accountModel)
        {
            
             String lenderPlacedInsuranceMessage = String.Empty;

            if (accountModel.EscrowRecordModel.rssi_esc_type == "20" || accountModel.EscrowRecordModel.rssi_esc_type == "21" && accountModel.EscrowRecordModel.Rssi_Ins_Co == "2450" && accountModel.EscrowRecordModel.Rssi_Ins_Ag == "29000" || accountModel.EscrowRecordModel.Rssi_Ins_Ag == "29005" || accountModel.EscrowRecordModel.Rssi_Ins_Ag == "43000" || accountModel.EscrowRecordModel.Rssi_Ins_Ag == "43001")
            { lenderPlacedInsuranceMessage = "then print Lender Placed Insurance message"; }

            return lenderPlacedInsuranceMessage;
        }

        public string StateNSF(AccountsModel accountModel)
        {
           
            String stateNSF = String.Empty;
            
            if (int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 6 || int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 16 ||
                int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 18 || int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData) == 42)
            { stateNSF = "print State NSF message"; }

            return stateNSF;
        }

        public string AutodraftMessage(AccountsModel accountModel)
        {
            
           
            String autodraftMessage = String.Empty;

            if (int.Parse(accountModel.MasterFileDataPart2Model.Rssi_Tot_Draft_Amt_PackedData) > 0 && int.Parse(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) > 0)
            { autodraftMessage = "print Autodraft message."; }

            return autodraftMessage;
        }

        public string CMSPartialClaim(AccountsModel accountModel)
        {
            
            
            string cMSPartialClaim = string.Empty;
            if (int.Parse(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 &&  accountModel.UserFieldRecordModel.Rssi_Usr_88 == "C")
            { cMSPartialClaim = "print Autodraft message."; }

            return cMSPartialClaim;
        }

        public string HUDPartialClaim(AccountsModel accountModel)
        {
            
            
            string HUDPartialClaim = string.Empty;

            if (int.Parse(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) > 0 &&  accountModel.UserFieldRecordModel.Rssi_Usr_88 == "H")
            { HUDPartialClaim = "print HUD Partial Claim Message."; }

            return HUDPartialClaim;
        }

        public string effectivedate(AccountsModel accountModel)
        {
            
            string effectivedate = string.Empty;

            //if (RSSI_FT_TYPE_CODE == "000")
            //{ effectivedate = "RSSI-FEE-DATE-ASSESSED"; }
            //else { effectivedate = "RSSI-TR-DATE"; }

            return effectivedate;
        }

        public string Amount(AccountsModel accountModel)
        {
           
            string amount = string.Empty;
           
            if (int.Parse(accountModel.TransactionRecordModel.Rssi_Tr_Exp_Fee_Amt_PackedData) != 0)
            { amount = "RSSI-TR-EXP-FEE-AMT"; }
            //else if (RSSI_FT_TYPE_CODE == 000)
            //{ amount = "RSSI-FEE-AMT-ASSESSED"; }
            else { amount = "RSSI-TR-AMT"; }

            return amount;
        }

        public string StateDisclosures(AccountsModel accountModel)
        {
            
            string stateDisclosures = string.Empty;
            var RSSISTATE = "4, 6, 12, 22, 24, 33, 34, 43, 44 ";
            var MailingState = "AR, CO, HI, MA, MN, NC, NY, TN, TX ";
            if (RSSISTATE.Contains(accountModel.MasterFileDataPart_1Model.Rssi_State_PackedData))
            { stateDisclosures = ""; }
            else if (MailingState.Contains(accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3))
            { stateDisclosures = ""; }

            return stateDisclosures;
        }

        public string CarringtonCharitableFoundation(AccountsModel accountModel)
        {
            
            string carringtonCharitableFoundation = string.Empty;
           
            if (int.Parse( accountModel.detModel.PriorMoAmnt) > 0 || int.Parse( accountModel.detModel.YTDAmnt) > 0)
            { carringtonCharitableFoundation = "Print the Carrington Charitable Foundation verbiage."; }

            return carringtonCharitableFoundation;
        }

        public string PaymentInformationMessage(AccountsModel accountModel)
        {
            
            string carringtonCharitableFoundation = string.Empty;
           
            if (accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "LA" || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3== "KS"
                || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "NM" || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3== "OK"
                || accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 == "TX")
            { carringtonCharitableFoundation = "Dallas P.O.Box Address else Pasadena P.O.Box Address"; }

            return carringtonCharitableFoundation;
        }
        #endregion Ambrish
    }
}