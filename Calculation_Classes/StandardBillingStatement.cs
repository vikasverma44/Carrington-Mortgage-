using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrington_Service.Calculation_Classes
{
    public class StandardBillingStatement
    {
        public decimal AmountDue { get; set; }
        public decimal Principal { get; set; }
        public decimal AssistanceAmount { get; set; }
        public decimal ReplacementReserveAmount { get; set; }
        public decimal OverduePayment { get; set; }
        public decimal TotalFeesAndCharges { get; set; }
        public decimal TotalFeesPaid { get; set; }
        public decimal TotalAmountDue { get; set; }
        public decimal PastDueBalance { get; set; }
        public decimal DeferredBalance { get; set; }
        public decimal UnappliedFunds { get; set; }
        public decimal FeesAndChargesPaidLastMonth { get; set; }
        public decimal UnappliedFundsPaidLastMonth { get; set; }
        public decimal TotalPaidLastMonth { get; set; }
        public decimal FeesAndChargesPaidYearToDate { get; set; }
        public decimal UnappliedFundsPaidYearToDate { get; set; }
        public decimal TotalPaidYearToDate { get; set; }
        
        public decimal LatePaymentAmount { get; set; }
        public decimal Suspense { get; set; }
        public decimal Miscellaneous { get; set; }
        public decimal TotalDue { get; set; }
       
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
        public decimal GetTotalPaidYearToDate()
        {

            return TotalPaidYearToDate;
        }
        public decimal GetLatePaymentAmount()
        {

            return LatePaymentAmount;
        }
        public decimal GetSuspense()
        {

            return Suspense;
        }
        public decimal GetMiscellaneous()
        {
            return Miscellaneous;
        }
        public decimal GetTotalDue()
        {
            return TotalDue;
        }
       
    }
}
