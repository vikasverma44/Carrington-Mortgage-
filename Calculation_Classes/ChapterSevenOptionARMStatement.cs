using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Calculation_Classes
{
  public class ChapterSevenOptionARMStatement
    {
        public decimal AmountDueOption1 { get; set; }
        public decimal AmountDueOption2 { get; set; }
        public decimal AmountDueOption3 { get; set; }
        public decimal AmountDueOption4 { get; set; }
        public decimal PrincipalOption1 { get; set; }
        public decimal AssistanceAmount  { get; set; }
        public decimal ReplacementReserve { get; set; }
        public decimal OverduePaymentsOption1 { get; set; }
        public decimal TotalFeesChargedOption1 { get; set; }
        public decimal TotalFeesPaidOption1 { get; set; }
        public decimal TotalAmountDueOption1 { get; set; }
        public decimal PrincipalOption2 { get; set; }
        public decimal AssistanceAmountOption2 { get; set; }
        public decimal ReplacementReserveOption2 { get; set; }
        public decimal OverduePaymentsOption2 { get; set; }
        public decimal TotalFeesChargedOption2 { get; set; }

        public decimal TotalFeesPaidOption2 { get; set; }
        public decimal TotalAmountDueOption2 { get; set; }
        public decimal PrincipalOption3 { get; set; }
        public decimal AssistanceAmountOption3 { get; set; }
        public decimal ReplacementReserveOption3 { get; set; }
        public decimal OverduePaymentsOption3 { get; set; }
        public decimal TotalFeesChargedOption3 { get; set; }
        public decimal TotalFeesPaidOption3 { get; set; }
        public decimal TotalAmountDueOption3 { get; set; }
        public decimal PrincipalOption4 { get; set; }
        public decimal AssistanceAmountOption4 { get; set; }
        public decimal ReplacementReserveOption4 { get; set; }
        public decimal OverduePaymentsOption4 { get; set; }
        public decimal TotalFeesChargedOption4 { get; set; }
        public decimal TotalFeesPaidOption4 { get; set; }
        public decimal TotalAmountDueOption4 { get; set; }
        public decimal FeesandChargesPaidLastMonth { get; set; }
        public decimal UnappliedFundsPaidLastMonth { get; set; }
        public decimal FeesandChargesPaidYeartoDate { get; set; }
        public decimal UnappliedFundsPaidYearToDate { get; set; }
        public decimal PaymentAmountOption1 { get; set; }
        public decimal PaymentAmountOption2 { get; set; }
        public decimal PaymentAmountOption3 { get; set; }
        public decimal PaymentAmountOption4 { get; set; }
        public decimal Suspense { get; set; }
        public decimal Miscellaneous { get; set; }
        public decimal DeferredBalance { get; set; }
        public decimal TotalDue { get; set; }


        /* While Calculating Conditions must be applied*/
        public decimal GetAmountDueOption1()
        {
          
            return AmountDueOption1;
        }
        public decimal GetAmountDueOption2()
        {
           
            return AmountDueOption2;
        }
        public decimal GetAmountDueOption3()
        {

            return AmountDueOption3;
        }

        public decimal GetAmountDueOption4()
        {

             return AmountDueOption4;
        }
        public decimal GetPrincipalOption1()
        {
          
            return PrincipalOption1;
        }
        public decimal GetAssistanceAmount()
        {
           
            return AssistanceAmount;
        }
        public decimal GetReplacementReserve()
        {
          
            return ReplacementReserve;
        }
        public decimal GetOverduePaymentsOption1()
        {
            return OverduePaymentsOption1;
        }
        public decimal GetTotalFeesChargedOption1()
        {
          
            return TotalFeesChargedOption1;
        }
        public decimal GetTotalFeesPaidOption1()
        {
           
            return TotalFeesPaidOption1;
        }
        public decimal GetTotalAmountDueOption1()
        {
           
            return TotalAmountDueOption1;
        }
        public decimal GetPrincipalOption2()
        {
           
            return PrincipalOption2;
        }
        public decimal GetAssistanceAmountOption2()
        {
           
            return AssistanceAmountOption2;
        }
        public decimal GetReplacementReserveOption2()
        {
           
            return ReplacementReserveOption2;
        }
        public decimal GetOverduePaymentsOption2()
        {
           
            return OverduePaymentsOption2;
        }
        public decimal GetTotalFeesChargedOption2()
        {
           
            return TotalFeesChargedOption2;
        }
        public decimal GetTotalFeesPaidOption2()
        {

            return TotalFeesPaidOption2;
        }
        public decimal GetTotalAmountDueOption2()
        {

            return TotalAmountDueOption2;
        }

        public decimal GetPrincipalOption3()
        {

            return PrincipalOption3;
        }
        public decimal GetAssistanceAmountOption3()
        {

            return AssistanceAmountOption3;
        }
        public decimal GetReplacementReserveOption3()
        {

            return ReplacementReserveOption3;
        }
        public decimal GetOverduePaymentsOption3()
        {

            return OverduePaymentsOption3;
        }
        public decimal GetTotalFeesChargedOption3()
        {

            return TotalFeesChargedOption3;
        }
        public decimal GetTotalFeesPaidOption3()
        {

            return TotalFeesPaidOption3;
        }




        public decimal GetTotalAmountDueOption3()
        {

            return TotalAmountDueOption3;
        }
        public decimal GetPrincipalOption4()
        {

            return PrincipalOption4;
        }
     
        public decimal GetAssistanceAmountOption4()
        {

            return AssistanceAmountOption4;
        }
        public decimal GetReplacementReserveOption4()
        {

            return ReplacementReserveOption4;
        }

        public decimal GetOverduePaymentsOption4()
        {

            return OverduePaymentsOption4;
        }
        public decimal GetTotalFeesChargedOption4()
        {

            return TotalFeesChargedOption4;
        }

        public decimal GetTotalFeesPaidOption4()
        {

            return TotalFeesPaidOption4;
        }
        public decimal GetTotalAmountDueOption4()
        {

            return TotalAmountDueOption4;
        }

       public decimal GetFeesandChargesPaidLastMonth()
        {

            return FeesandChargesPaidLastMonth;
        }
        public decimal GeUnappliedFundsPaidLastMonth()
        {

            return UnappliedFundsPaidLastMonth;
        }

        public decimal GetFeesandChargesPaidYeartoDate()
        {

            return FeesandChargesPaidYeartoDate;
        }
        public decimal GetUnappliedFundsPaidYearToDate()
        {

            return UnappliedFundsPaidYearToDate;
        }



        public decimal GetPaymentAmountOption1()
        {

            return PaymentAmountOption1;
        }

        public decimal GetPaymentAmountOption2()
        {

            return PaymentAmountOption2;
        }
        public decimal GetPaymentAmountOption3()
        {

            return PaymentAmountOption3;
        }
        public decimal GetPaymentAmountOption4()
        {

            return PaymentAmountOption4;
        }

       public decimal GeSuspense()
        {

            return Suspense;
        }

        public decimal GetMiscellaneous()
        {

            return Miscellaneous;
        }
        public decimal GetDeferredBalance()
        {

            return DeferredBalance;
        }
        public decimal GetTotalDue()
        {

            return TotalDue;
        }
    }
}
