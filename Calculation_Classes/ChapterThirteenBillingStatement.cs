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
        ChapterThirteenBillingStatement()
        {

        }

        /* While Calculating Conditions must be applied and copybook fields must be verified twice*/
        public string GetPaymentAmount(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                PaymentAmount = "0.00";


            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                 Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.CurrentDueDate))

                PaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                    Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
            else
                PaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) +
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
            if ((Convert.ToInt64(accountsModel.MasterFileDataPart2Model.TotalDeferredItemsBalance) -
                Convert.ToInt64(accountsModel.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance)) == 0)
                DeferredBalance = "N/A";
            else
                DeferredBalance = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart2Model.TotalDeferredItemsBalance) -
                Convert.ToInt64(accountsModel.MasterFileDataPart2Model.DeferredDrmExpenseAdvancesUnpaidBalance));

            return DeferredBalance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public string GetPrincipal(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0 ||
                Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) == 0)

                Principal = "0.00";

            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                    Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.CurrentDueDate))

                Principal = "0.00";

            else
            {
                Principal = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.P_IPayment) -
                    Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.InterestOnPymtDue));
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

            PastUnpaidAmount =Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) - GetTotalFeesPaid(accountsModel));
            return PastUnpaidAmount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsModel"></param>
        /// <returns></returns>
        public decimal GetTotalFeesPaid(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeeReceivable) +
                Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeDue)) <
                Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData))
            {

                TotalFeesPaid = Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeeReceivable) +
                    Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeDue) -
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
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
                TotalPaymentAmount = "0.00";


            else if (Convert.ToDateTime(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Due_Date) >
                 Convert.ToDateTime(accountsModel.MasterFileDataPart_1Model.CurrentDueDate))

                TotalPaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Unpaid_PackedData) +
                    Convert.ToInt64(accountsModel.ActiveBankruptcyInformationRecordModel.Rssi_Poc_Post_Pet_Fees_PackedData));
            else
                TotalPaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment) +
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
            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
              &&
              (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
            {

                FeesAndChargesPaidLastMonth =Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeesPaidSinceLastStatement) +
                Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesPaidSinceLastStatement) -
                Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
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
            UnappliedFundsPaidLastMonth = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountPostedToUnappliedFunds) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds2) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds3) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds4) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds5));
            return UnappliedFundsPaidLastMonth;
        }
        public string GetTotalPaidLastMonth(AccountsModel accountsModel)
        {

            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
            &&
            (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
            {
                //Need to know and Add PriorMoAmnt in this section
                TotalPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.TotalAmountPaidSinceLastStatement) - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
            }
            else
            {
                TotalPaidLastMonth = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.TotalAmountPaidSinceLastStatement) - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
            }

            return TotalPaidLastMonth;
        }
        public string GetFeesAndChargesPaidYeartoDate(AccountsModel accountModel)
        {

            Decimal total = Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.FeesPaidYTD) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.LateChargesPaidYTD) - Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmount);
            if ((Convert.ToInt32(accountModel.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt32(accountModel.TransactionRecordModel.LogTransaction) == 5707) && (Convert.ToInt32(accountModel.TransactionRecordModel.FeeCode) == 67 || Convert.ToInt32(accountModel.TransactionRecordModel.FeeCode) == 198))
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

            UnappliedFundsPaidYearToDate = Convert.ToString((accountModel.MasterFileDataPart_1Model.UnappliedFundsCodeFirst != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.UnappliedFundsBalanceFirst) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0));
            return UnappliedFundsPaidYearToDate;
        }
        public string GetTotalPaidYearToDate(AccountsModel accountModel)
        {

            TotalPaidYearToDate = Convert.ToString(Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.PrincipalPaidYTD) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.InterestPaidYearToDate) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.EscrowPaidYTD) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.FeesPaidYTD) + Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.LateChargesPaidYTD) + (accountModel.MasterFileDataPart_1Model.UnappliedFundsCodeFirst != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart_1Model.UnappliedFundsBalanceFirst) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0) + (accountModel.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToDecimal(accountModel.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0) + Convert.ToDecimal(accountModel.TransactionRecordModel.OptionalDeferredAmount));
            return TotalPaidYearToDate;
        }

        public string GetSuspense(AccountsModel accountModel)
        {
            Suspense = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountPostedToUnappliedFunds) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds2) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds3) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds4) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountUnappliedFunds5));
            return Suspense;
        }
        public string GetMiscellaneous(AccountsModel accountModel)
        {
            Miscellaneous = Convert.ToString(Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountConstructionBalance) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountOptionalInsurance) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountToP_IShortage) + Convert.ToDecimal(accountModel.TransactionRecordModel.TransactionAmountPostedToDeferredPrincipal) + Convert.ToDecimal(accountModel.TransactionRecordModel.TranAmountToDeferredInterest) + Convert.ToDecimal(accountModel.TransactionRecordModel.TranAmountToDeferredLateCharge) + Convert.ToDecimal(accountModel.TransactionRecordModel.TranAmountToDeferredEscrowAdv) + Convert.ToDecimal(accountModel.TransactionRecordModel.TranAmountToDeferredPaidExpensesAdv) + Convert.ToDecimal(accountModel.TransactionRecordModel.TranAmountToDeferredUnpaidExpenseAdv) + Convert.ToDecimal(accountModel.TransactionRecordModel.TranAmountToDeferredAdminFees) + Convert.ToDecimal(accountModel.TransactionRecordModel.OptionalDeferredAmount));
            return Miscellaneous;
        }

    }
}