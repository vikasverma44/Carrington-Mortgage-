using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrington_Service.Calculation_Classes
{
  public class ChapterThirteenOptionARMStatement
    {
        public decimal AmountDueOption1 { get; set; }
        public decimal AmountDueOption2 { get; set; }
        public decimal AmountDueOption3 { get; set; }
        public decimal AmountDueOption4 { get; set; }
        public decimal FeesandChargesPaidLastMonth { get; set; }
        public decimal UnappliedFundsPaidLastMonth { get; set; }
        public decimal FeesandChargesPaidYeartoDate { get; set; }
        public decimal UnappliedFundsPaidYearToDate { get; set; }
        public decimal PrincipalOption1 { get; set; }
        public decimal AssistanceAmountOption1 { get; set; }
        public decimal ReplacementReserveOption1 { get; set; }
        public decimal OverduePaymentsOption1 { get; set; }
        public decimal TotalFeesPaidOption1 { get; set; }
        public decimal TotalAmountDueOption1 { get; set; }
        public decimal PrincipalOption2 { get; set; }
        public decimal AssistanceAmountOption2 { get; set; }
        public decimal ReplacementReserveOption2 { get; set; }
        public decimal OverduePaymentsOption2 { get; set; }
        public decimal TotalFeesPaidOption2 { get; set; }
        public decimal TotalAmountDueOption2 { get; set; }
        public decimal PrincipalOption3 { get; set; }
        public decimal AssistanceAmountOption3 { get; set; }
        public decimal ReplacementReserveOption3 { get; set; }
        public decimal OverduePaymentsOption3 { get; set; }
        public decimal TotalFeesPaidOption3 { get; set; }
        public decimal TotalAmountDueOption3 { get; set; }
        public decimal PrincipalOption4 { get; set; }
       public decimal AssistanceAmountOption4 { get; set; }
        public decimal ReplacementReserveOption4 { get; set; }
        public decimal OverduePaymentsOption4 { get; set; }
        public decimal TotalFeesPaidOption4 { get; set; }
        public decimal TotalAmountDueOption4 { get; set; }
        public decimal Suspense { get; set; }
        public decimal Miscellaneous { get; set; }
      


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
       
        public decimal GetOverduePaymentsOption1()
        {
            return OverduePaymentsOption1;
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
       public decimal GeSuspense()
        {

            return Suspense;
        }

        public decimal GetMiscellaneous()
        {

            return Miscellaneous;
        }
      
    }
}
