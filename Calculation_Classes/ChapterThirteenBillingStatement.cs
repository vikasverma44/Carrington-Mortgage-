using System;
using System.Runtime.Remoting.Messaging;

/// <summary>
/// Summary description for Class1
/// </summary>
 namespace Carrington_Service.Calculation_Classes
{
public class ChapterThirteenBillingStatement
    {
    public decimal PaymentAmount { get; set; }
    public decimal Principal { get; set; }
    public decimal PastUnpaidAmount { get; set; }
    public decimal TotalFeesPaid { get; set; }
    public decimal TotalPaymentAmount { get; set; }
    public decimal DeferredBalance { get; set; }
    public decimal FeesAndChargesPaidLastMonth { get; set; }
    public decimal UnappliedFundsPaidLastMonth { get; set; }
    public decimal TotalPaidLastMonth { get; set; }
    public decimal FeesAndChargesPaidYeartoDate { get; set; }
    public decimal UnappliedFundsPaidYearToDate { get; set; }
    public decimal TotalPaidYearToDate { get; set; }
    public decimal Suspense { get; set; }
    public decimal Miscellaneous { get; set; }
    ChapterThirteenBillingStatement()
    {

    }

    /* While Calculating Conditions must be applied and copybook fields must be verified twice*/
    public decimal GetPaymentAmount()
    {
       
        return PaymentAmount;
    }
    public decimal GetDeferredBalance()
    {
      
        return DeferredBalance;
    }
    public decimal GetPrincipal()
    {

           return Principal;
    }

    public decimal GetPastUnpaidAmount()
    {

       
        return PastUnpaidAmount;
    }
  
    public decimal GetTotalFeesPaid()
    {
       
        return TotalFeesPaid;
    }
    public decimal GetTotalPaymentAmount()
    {
       
        return TotalPaymentAmount;
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
    public decimal GetFeesAndChargesPaidYeartoDate()
    {
       
        return FeesAndChargesPaidYeartoDate;
    }
    public decimal GetUnappliedFundsPaidYearToDate()
    {
       
        return UnappliedFundsPaidYearToDate;
    }
    public decimal GetTotalPaidYearToDate()
    {
       
        return TotalPaidYearToDate;
    }
 
    public decimal GetSuspense()
    {
        return Suspense;
    }
    public decimal GetMiscellaneous()
    {
       
        return Miscellaneous;
    }
  
}
}