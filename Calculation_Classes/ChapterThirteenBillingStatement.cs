using ODHS_EDelivery.Models.InputCopyBookModels;
using ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels;
using System;
using System.Runtime.Remoting.Messaging;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Carrington_Service.Calculation_Classes
{
    public class ChapterThirteenBillingStatement
    {
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

        public string PrimaryBorrowerBKAttorney { get; set; }
        public string SecondaryBorrower { get; set; }
        public string MailingBKAttorneyAddressLine1 { get; set; }
        public string MailingBKAttorneyAddressLine2 { get; set; }
        public string BorrowerAttorneyMailingCityStateZip { get; set; }
        public string MailingCountry { get; set; }
        public string Interest { get; set; }
        public string EscrowTaxesandInsurance { get; set; }
        public string RegularMonthlyPayment { get; set; }
        public string BuydownBalance{ get; set; }
        public string PartialClaim{ get; set; }
        public string InterestRateUntil { get; set; }
        public string PrepaymentPenalty{ get; set; }

        #region "Old Code==>>"
        ChapterThirteenBillingStatement()
        {

        }

        /* While Calculating Conditions must be applied and copybook fields must be verified twice*/
        public string GetPaymentAmount(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                PaymentAmount = "0.00";


            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                 Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))

                PaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                    Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
            else
                PaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) +
                    Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                    Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));

            return PaymentAmount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetDeferredBalance(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) -
                Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData)) == 0)
                DeferredBalance = "N/A";
            else
                DeferredBalance = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Tot_Bal) -
                Convert.ToInt64(accountsModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData));

            return DeferredBalance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetPrincipal(AccountsModel accountsModel)
        {
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

            return Principal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetPastUnpaidAmount(AccountsModel accountsModel)
        {

            PastUnpaidAmount = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) - GetTotalFeesPaid(accountsModel));
            return PastUnpaidAmount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public decimal GetTotalFeesPaid(AccountsModel accountsModel)
        {
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

            return TotalFeesPaid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetTotalPaymentAmount(AccountsModel accountsModel)
        {
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

            return TotalPaymentAmount;


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Log_Tran) == 5707)
              &&
              (Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Fee_Desc) == 198))
            {

                FeesAndChargesPaidLastMonth =Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Fees_Pd_Since_Lst_Stmt_PackedData) +
                Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.Rssi_Lc_Pd_Since_Lst_Stmt_PackedData) -
                Convert.ToInt64(accountsModel.TransactionRecordModel.Rssi_Tr_Amt_PackedData));
            }

            return FeesAndChargesPaidLastMonth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountModel"></param>
        /// <returns></returns>
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
            if ((Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Log_Tran) == 5705 || Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Log_Tran) == 5707) && (Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 67 || Convert.ToInt32(accountModel.TransactionRecordModel.Rssi_Tr_Fee_Code) == 198))
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

            UnappliedFundsPaidYearToDate = Convert.ToString((accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0));
            return UnappliedFundsPaidYearToDate;
        }
        public string GetTotalPaidYearToDate(AccountsModel accountModel)
        {

            TotalPaidYearToDate = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Int_Pd_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Fees_Paid_Ytd_PackedData) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Late_Chg_Paid_Ytd_PackedData) + (accountModel.MasterFileDataPart_1Model.Rssi_Unap_Fund_Cd != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.Rssi_Esc_Var_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_2_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_3_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_4_PackedData) : 0) + (accountModel.MasterFileDataPart2Model.Rssi_Unap_Cd_5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.Rssi_Unap_Bal_5_PackedData) : 0) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData));
            return TotalPaidYearToDate;
        }

        public string GetSuspense(AccountsModel accountModel)
        {
            Suspense = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_2) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_3) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_04) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Evar_05));
            return Suspense;
        }
        public string GetMiscellaneous(AccountsModel accountModel)
        {
            Miscellaneous = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Lip_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Cr_Ins_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Pi_Shrtg) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Prin_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Int_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Late_Chrg_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Esc_Adv_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Pd_Exp_Adv_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Unp_Exp_Adv_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Admin_Fees_PackedData) + Convert.ToDecimal(accountModel.TransactionRecordModel.Rssi_Tr_Amt_To_Def_Optins_PackedData));
            return Miscellaneous;
        }
        #endregion

        #region Method ==>

        public string GetPrimaryBorrowerBKAttorney(AccountsModel accountModel)
        {
            if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                PrimaryBorrowerBKAttorney = accountModel.MasterFileDataPart_1Model.Rssi_Primary_Name;
            else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                PrimaryBorrowerBKAttorney = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1;
            else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                PrimaryBorrowerBKAttorney = accountModel.MasterFileDataPart_1Model.Rssi_Primary_Name + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Name1;
            return PrimaryBorrowerBKAttorney;
        }

        public string GetSecondaryBorrower(AccountsModel accountModel)
        {
            if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y" || accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
            {
                SecondaryBorrower = accountModel.MasterFileDataPart_1Model.Rssi_Secondary_Name;
            }
            return SecondaryBorrower;
        }

        public string GetMailingBKAttorneyAddressLine1(AccountsModel accountModel)
        {
            if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                MailingBKAttorneyAddressLine1 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1;
            else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                MailingBKAttorneyAddressLine1 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1;
            else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                MailingBKAttorneyAddressLine1 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_1 + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs1;
            return MailingBKAttorneyAddressLine1;
        }

        public string GetMailingBKAttorneyAddressLine2(AccountsModel accountModel)
        {
            if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                MailingBKAttorneyAddressLine2 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2;
            else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                MailingBKAttorneyAddressLine2 = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2;
            else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                MailingBKAttorneyAddressLine2 = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_2 + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Adrs2;
            return MailingBKAttorneyAddressLine2;
        }
        public string GetBorrowerAttorneyMailingCityStateZip(AccountsModel accountModel)
        {
            if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "B")
                BorrowerAttorneyMailingCityStateZip = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3;
            else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "L")
                BorrowerAttorneyMailingCityStateZip = accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_City +
                    accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_State + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Zip;
            else if (accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Statement_Flag == "Y")
                BorrowerAttorneyMailingCityStateZip = accountModel.MasterFileDataPart_1Model.Rssi_Mail_Adrs_3 + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_City +
                    accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_State + accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Vend_Zip;
            return BorrowerAttorneyMailingCityStateZip;
        }

        public string GetMailingCountry(AccountsModel accountModel)
        {
            if (accountModel.MasterFileDataPart2Model.Rssi_Altr_Forgn_Flag == "Y")
                MailingCountry = accountModel.ForeignInformationRecordModel.Rssi_Altr_Cntry;
            else if (accountModel.MasterFileDataPart2Model.Rssi_Prim_Forgn_Flag == "Y")
                MailingCountry = accountModel.ForeignInformationRecordModel.Rssi_Prim_Mail_Country;
            else if (accountModel.MasterFileDataPart2Model.Rssi_Appl_Foreign_Flag == "Y")
                MailingCountry = "RSSI-APPL-COUNTRY to copy 1";
            else
                MailingCountry = null;
            return MailingCountry;
        }

        public string GetInterest(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                Interest = "0.00";
            else if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                Interest = "0.00";
            else if (Convert.ToDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                Interest = "0.00";
           
            return Interest;
        }
        public string GetEscrowTaxesandInsurance(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                EscrowTaxesandInsurance = "0.00";
            else if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Bill_Pmt_Amt_PackedData) == 0)
                EscrowTaxesandInsurance = "0.00";
            else if (Convert.ToDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                EscrowTaxesandInsurance = "0.00";

            return EscrowTaxesandInsurance;
        }
        public string GetRegularMonthlyPayment(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Prin_Bal_PackedData) == 0)
                RegularMonthlyPayment = "0.00";
            else if (Convert.ToDateTime(accountModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) > Convert.ToDateTime(accountModel.MasterFileDataPart_1Model.Rssi_Cur_Due_Dte))
                RegularMonthlyPayment = "0.00";

            return RegularMonthlyPayment;
        }
        public string GetBuydownBalance(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData) <= 0)
                BuydownBalance = "N/A";
            else
                BuydownBalance = accountModel.UserFieldRecordModel.Rssi_Usr_303_PackedData;

            return BuydownBalance;
        }
        public string GetPartialClaim(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData) == 0)
                PartialClaim = "N/A";
            else
                PartialClaim = accountModel.MasterFileDataPart2Model.Rssi_Def_Unpd_Exp_Adv_Bal_PackedData;

            return PartialClaim;
        }
        public string GetInterestRateUntil(AccountsModel accountModel)
        {
            if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.Rssi_Rate_Chg_Date) > 19000000)
                InterestRateUntil = "Until RSSI-RATE-CHG-DATE";
            else
                InterestRateUntil = null;

            return InterestRateUntil;
        }

        //public string GetPrepaymentPenalty(AccountsModel accountModel)
        //{
        //    if (Convert.ToInt64(accountModel.MasterFileDataPart_1Model.RSSI_PREPAY_PEN_AMT) > 0)
        //        PrepaymentPenalty = "Yes";
        //    else
        //        PrepaymentPenalty = "No";

        //    return PrepaymentPenalty;
        //}

       

        













        #endregion
    }
}