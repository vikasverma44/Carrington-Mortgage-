using ODHS_EDelivery.Models.InputCopyBookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrington_Service.Calculation_Classes
{
    public class StandardBillingStatement
    {
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
       
        /* While Calculating Conditions must be applied*/
        public decimal GetAmountDue()
        {

            return AmountDue;
        }
        public decimal GetPrincipal()
        {

            return Principal;
        }
        public decimal GetAssistanceAmount()
        {

            return AssistanceAmount;
        }

        public decimal GetReplacementReserveAmount()
        {

            return ReplacementReserveAmount;
        }
        public decimal GetOverduePayment()
        {

            return OverduePayment;
        }

        public decimal GetTotalFeesAndCharges()
        {
            return TotalFeesAndCharges;
        }

        public decimal GetTotalFeesPaid()
        {

            return TotalFeesPaid;
        }
        public decimal GetTotalAmountDue()
        {

            return TotalAmountDue;
        }
        public decimal GetPastDueBalance()
        {

            return PastDueBalance;
        }
        public decimal GetDeferredBalance()
        {

            return DeferredBalance;
        }
        public decimal GetUnappliedFunds()
        {

            return UnappliedFunds;
        }
        public decimal GetFeesAndChargesPaidLastMonth()
        {

            return FeesAndChargesPaidLastMonth;
        }

        public decimal GetUnappliedFundsPaidLastMonth()
        {

            return UnappliedFundsPaidLastMonth;
        }
        public decimal GetTotalPaidLastMonth()
        {

            return TotalPaidLastMonth;
        }

        public decimal GetFeesAndChargesPaidYearToDate()
        {

            return FeesAndChargesPaidYearToDate;
        }
        public decimal GetUnappliedFundsPaidYearToDate()
        {
            return UnappliedFundsPaidYearToDate;
        }
        public string GetTotalPaidYearToDate(AccountsModel accountsModel)
        {
            if ((Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5705 || Convert.ToInt64(accountsModel.TransactionRecordModel.LogTransaction) == 5707)
                          &&
                          (Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 67 || Convert.ToInt64(accountsModel.TransactionRecordModel.FeeDescription) == 198))
            {
                TotalPaidYearToDate = Convert.ToString((Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalPaidYTD)
                                       + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.InterestPaidYearToDate)
                                       + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.EscrowPaidYTD)
                                       + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.FeesPaidYTD)
                                       + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargesPaidYTD)
                                       + accountsModel.MasterFileDataPart_1Model.UnappliedFundsCodeFirst != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.UnappliedFundsBalanceFirst) : 0
                                       + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode2 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance2) : 0
                                       + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode3 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance3) : 0
                                       + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode4 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance4) : 0
                                       + accountsModel.MasterFileDataPart2Model.UnappliedFundsCode5 != "L" ? Convert.ToInt64(accountsModel.MasterFileDataPart2Model.UnappliedFundsBalance5) : 0)
                                       - Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmount));
            }

            return TotalPaidYearToDate;
        }
        public string GetLatePaymentAmount(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                LatePaymentAmount = "N/A";
            }
            else
            {
                LatePaymentAmount = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.LateChargeAmount));
            }
            return LatePaymentAmount;
        }
        public string GetSuspense(AccountsModel accountsModel)
        {
            Suspense = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountPostedToUnappliedFunds)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds2)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds2)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds2)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountUnappliedFunds2));

            return Suspense;
        }
        public string GetMiscellaneous(AccountsModel accountsModel)
        {
            Miscellaneous = Convert.ToString(Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountConstructionBalance)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountOptionalInsurance)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountToP_IShortage)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountPostedToDeferredPrincipal)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TranAmountToDeferredInterest)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountLateCharge)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TransactionAmountEscrow)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TranAmountToDeferredPaidExpensesAdv)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TranAmountToDeferredUnpaidExpenseAdv)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.TranAmountToDeferredAdminFees)
                + Convert.ToInt64(accountsModel.TransactionRecordModel.OptionalDeferredAmount)
                );
            return Miscellaneous;
        }
        public string GetTotalDue(AccountsModel accountsModel)
        {
            if (Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PrincipalBalance) == 0)
            {
                TotalDue = "0";
            }
            else
            {
                TotalDue = Convert.ToString(Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.PastDueAmtTotalDue)
                    + Convert.ToInt64(accountsModel.MasterFileDataPart_1Model.CurrentPayment));
            }
            return TotalDue;
        }

    }
}
