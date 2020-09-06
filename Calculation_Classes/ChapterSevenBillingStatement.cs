using System;
using System.Runtime.Remoting.Messaging;

/// <summary>
/// Summary description for Class1
/// </summary>
 namespace Carrington_Service.Calculation_Classes
{
public class ChapterSevenBillingStatement
{
    public decimal PaymentAmount { get; set; }
	public decimal DeferredBalance { get; set; }
    public decimal Principal { get; set; }
    public decimal PastUnpaidAmount { get; set; }
    public decimal TotalFeesandCharges { get; set; }
    public decimal TotalFeesPaid { get; set; }
    public decimal TotalPaymentAmount { get; set; }
    public decimal FeesAndChargesPaidLastMonth { get; set; }
    public decimal UnappliedFundsPaidLastMonth { get; set; }
    public decimal TotalPaidLastMonth { get; set; }
    public decimal FeesAndChargesPaidYeartoDate { get; set; }
    public decimal UnappliedFundsPaidYearToDate { get; set; }
    public decimal TotalPaidYearToDate { get; set; }
    public decimal TotalDue { get; set; }
    public decimal Suspense { get; set; }
    public decimal Miscellaneous { get; set; }
    ChapterSevenBillingStatement()
    {

    }

    /* While Calculating Conditions must be applied*/
    public decimal GetPaymentAmount()
    {
        //Calculation =  Past Due Amount + Current Payment
        //Conditional Statement= If RSSI-PRIN-BAL = 0, then "0.00"
        //Copybook Field Name=RSSI-BILL-TOTAL-DUE  plus  RSSI - BILL - PMT - AMT
        return PaymentAmount;
    }
    public decimal GetDeferredBalance()
    {
        //Calculation =  RSSI-DEF-TOT-BAL minus  RSSI - DEF - UNPD - EXP - ADV - BAL
        //Conditional Statement=If RSSI-DEF-TOT-BAL minus  RSSI - DEF - UNPD - EXP - ADV - BAL = 0, then "N/A", else RSSI - DEF - TOT - BAL minus RSSI - DEF - UNPD - EXP - ADV - BAL
        //Copybook Field Name=  RSSI-DEF-TOT-BAL       RSSI - DEF - UNPD - EXP - ADV - BAL
        return DeferredBalance;
    }
    public decimal GetPrincipal()
    {

        //Calculation =  P&I Payment (-) Interest On Payment Due
        //Conditional Statement= If RSSI-PRIN-BAL = 0, then "0.00"    If RSSI-BILL - PMT - AMT = 0, then "0.00"
        //Copybook Field Name=RSSI-P-I-PYMT  minus  RSSI - INT - DUE
        return Principal;
    }

    public decimal GetPastUnpaidAmount()
    {

        //Calculation =  Fees Assessed Since Last Statement (+) Late Charges Accrued Since Last Statement
        //Conditional Statement=
        //Copybook Field Name==RSSI-BILL-TOTAL-DUE  minus RSSI - FEES - ASSESSED - SINCE - LST - STMT  minus RSSI - ACCR - LC minus Total Fees Paid
        return PastUnpaidAmount;
    }
    public decimal GetTotalFeesandCharges()
    {
        //Calculation =  Fees Assessed Since Last Statement (+) Late Charges Accrued Since Last Statement
        //Conditional Statement=RSSI-FEES-ASSESSED-SINCE-LST-STMT  plus RSSI - ACCR - LC   minus  (RSSI - TR - AMT  where RSSI - LOG - TRAN = 5605 and  RSSI - TR - FEE - CODE = 67) minus (RSSI - TR - AMT where RSSI - LOG - TRAN = 5605 or 5707 and RSSI - TR - FEE - CODE = 198)
        //Copybook Field Name=RSSI-FEES-ASSD-SINCE-LST-STMT   plus  RSSI - ACCR - LC   minus RSSI - TR - AMT(where RSSI - LOG - TRAN = 5605 and RSSI - TR - FEE - CODE = 67)   minus RSSI - TR - AMT(where RSSI - LOG - TRAN = 5605 or 5707 and RSSI - TR - FEE - CODE = 198)
        return TotalFeesandCharges;
    }
    public decimal GetTotalFeesPaid()
    {
        //Calculation =  Fee Balance (+) Late Charge Balance (-) Total Fees Charged
        //Conditional Statement=If (RSSI-FEES-NEW (+) RSSI-LATE-CHG-DUE) < Total Fees Charged then   RSSI - FEES - NEW(+)  RSSI - LATE - CHG - DUE(-) Total Fees Charged else 0.00
        //Copybook Field Name=RSSI-FEES-NEW  RSSI - LATE - CHG - DUE RSSI - FEES - ASSD - SINCE - LST - STMT  RSSI - ACCR - LC Total Fees Charged
        return TotalFeesPaid;
    }
    public decimal GetTotalPaymentAmount()
    {
        //Calculation =  Past Due Amount (+) Current Payment Due
        //Conditional Statement=If RSSI-PRIN-BAL = 0, then "0.00"
        //Copybook Field Name=RSSI-BILL-TOTAL-DUE plus RSSI - BILL - PMT - AMT
        return TotalPaymentAmount;
    }
    public decimal GetFeesAndChargesPaidLastMonth()
    {
        //Calculation =  Fees Paid Since Last Statement + Late Charges Paid Since Last Statement
        //Conditional Statement=RSSI-FEES-PD-SINCE-LST-STMT   plus RSSI - LC - PD - SINCE - LST - STMT minus   RSSI - TR - AMT where RSSI-LOG - TRAN = 5705 or 5707 and RSSI - TR - FEE - CODE = 67 or 198
        //Copybook Field Name= RSSI-FEES-PD-SINCE-LST-STMT  plus RSSI - LC - PD - SINCE - LST - STMT minus RSSI - TR - AMT where RSSI-LOG - TRAN = 5705 or 5707 and RSSI - TR - FEE - CODE = 67 or 198
        return FeesAndChargesPaidLastMonth;
    }
    public decimal GetUnappliedFundsPaidLastMonth()
    {
        //Calculation =  Sum (Amount to Unapplied 1, Amount to Unapplied 2, Amount to Unapplied 3, Amount to Unapplied 4, Amount to Unapplied 5) for all transactions.
        //Conditional Statement=
        //Copybook Field Name=RSSI-TR-AMT-TO-EVAR (1) plus RSSI - TR - AMT - to EVAR(2)  plus RSSI - TR - AMT - to EVAR(3)   plus RSSI - TR - AMT - to EVAR(4)   plus RSSI - TR - AMT - to EVAR(5)
        return UnappliedFundsPaidLastMonth;
    }
    public decimal GetTotalPaidLastMonth()
    {
        //Calculation =  RSSI-TOT-PD-SINCE-LST-STMT     minus  (RSSI - TR - AMT  where RSSI - LOG - TRAN = 5705 or  5707 and  RSSI - TR - FEE - CODE = 67 or 198)  + PriorMoAmnt
        //Conditional Statement=
        //Copybook Field Name=RSSI-TOT-PD-SINCE-LST-STMT  minus RSSI - TR - AMT where RSSI-LOG - TRAN = 5705 or 5707 and RSSI - TR - FEE - CODE = 67 or 198  plus PriorMoAmnt
        return TotalPaidLastMonth;
    }
    public decimal GetFeesAndChargesPaidYeartoDate()
    {
        //Calculation =  Fees Paid YTD (+) Late Charges Paid YTD
        //Conditional Statement=RSSI-FEES-PAID-YTD  plus RSSI - LATE - CHG - PAID - YTD minus RSSI - TR - AMT where RSSI-LOG - TRAN = 5705 or 5707 and RSSI - TR - FEE - CODE = 67 or 198
        //Copybook Field Name=RSSI-FEES-PAID-YTD plus RSSI - LATE - CHG - PAID - YTD  minus RSSI - TR - AMT  where RSSI-LOG - TRAN = 5705 or 5707 and RSSI - TR - FEE - CODE = 67 or 198
        return FeesAndChargesPaidYeartoDate;
    }
    public decimal GetUnappliedFundsPaidYearToDate()
    {
        //Calculation =  Unapplied Funds 1 where Unapplied Code 1 is not L (+) Unapplied Funds 2 where Unapplied Code 2 is not L (+) Unapplied Funds 3 where Unapplied Code 3 is not L (+) Unapplied Funds 4 where Unapplied Code 4 is not L (+) Unapplied Funds 5 where Unapplied Code 5 is not L
        //Conditional Statement=
        //Copybook Field Name=RSSI-ESC-VAR (If RSSI-UNAP-FUND-CD <> "L") plus RSSI - UNAP - BAL - 2(If RSSI - UNAP - CD - 2 <> "L") plus RSSI - UNAP - BAL - 3(If RSSI - UNAP - CD - 3 <> "L") plus RSSI - UNAP - BAL - 4(If RSSI - UNAP - CD - 4 <> "L") plus RSSI - UNAP - BAL - 5(If RSSI - UNAP - CD - 5 <> "L")
        return UnappliedFundsPaidYearToDate;
    }
    public decimal GetTotalPaidYearToDate()
    {
        //Calculation = RSSI-PRIN-PAID-YTD  plus RSSI - INT - PD - YTD  plus RSSI - ESC - PAID - YTD  plus RSSI - FEES - PAID - YTD  plus RSSI - LATE - CHG - PAID - YTD
        // plus RSSI - ESC - VAR(If RSSI - UNAP - FUND - CD <> "L") plus RSSI - UNAPL - BAL - 2(If RSSI - UNAP - CD - 2 <> "L") plus RSSI - UNAPL - BAL - 3(If RSSI - UNAP - CD - 3 <> "L")
        //plus  RSSI - UNAPL - BAL - 4(If RSSI - UNAP - CD - 4 <> "L") plus RSSI - UNAPL - BAL - 5(If RSSI - UNAP - CD - 5 <> "L") plus YTDAmnt  minus RSSI - TR - AMT where RSSI-LOG - TRAN = 5705 or 5707 and  RSSI - TR - FEE - CODE = 67 or 198
        //Conditional Statement=
        //Copybook Field Name=RSSI-PRIN-PAID-YTD plus RSSI - INT - PD - YTD  plus RSSI - ESC - PAID - YTD  plus RSSI - FEES - PAID - YTD  plus RSSI - LATE - CHG - PAID - YTD
         //plus  RSSI - ESC - VAR(If RSSI - UNAP - FUND - CD <> "L") plus  RSSI - UNAP - BAL - 2(If RSSI - UNAP - CD - 2 <> "L") plus RSSI - UNAP - BAL - 3(If RSSI - UNAP - CD - 3 <> "L")
         //plus RSSI - UNAP - BAL - 4(If RSSI - UNAP - CD - 4 <> "L") plus RSSI - UNAP - BAL - 5(If RSSI - UNAP - CD - 5 <> "L") plus YTDAmnt minus RSSI - TR - AMT(where RSSI - LOG - TRAN = 5705 or 5707 and RSSI - TR - FEE - CODE = 67 or 198)
        return TotalPaidYearToDate;
    }
    public decimal GetTotalDue()
    {
        //Calculation =  Past Due Amount + Current Payment
        //Conditional Statement=If RSSI-PRIN-BAL = 0, then "0.00"
        //Copybook Field Name=RSSI-BILL-TOTAL-DUE plus RSSI - BILL - PMT - AMT
        return TotalDue;
    }
    public decimal GetSuspense()
    {
        //Calculation =  Transaction Amount Posted to Unapplied 1 (+)  Transaction Amount Posted to Unapplied 2(+) Transaction Amount Posted to Unapplied 3(+) Transaction Amount Posted to Unapplied 4(+) Transaction Amount Posted to Unapplied 5
        //Conditional Statement=
        //Copybook Field Name=RSSI-TR-AMT-TO-EVAR (1) plus RSSI - TR - AMT - to EVAR(2)   plus RSSI - TR - AMT - to EVAR(3)  plus RSSI - TR - AMT - to EVAR(4)   plus RSSI - TR - AMT - to EVAR(5)
        return Suspense;
    }
    public decimal GetMiscellaneous()
    {
        //Calculation =  Buydown Balance + Credit Insurance + P&I Shortage + Deferred Principal + Deferred Interest + Deferred Late Charges + Deferred Escrow + Deferred Expenses + Deferred Unpaid Expenses + Deferred Admin Fees + Deferred Optional Insurance
        //Conditional Statement=
        //Copybook Field Name=RSSI-TR-AMT-TO-LIP  plus RSSI - TR - AMT - TO - CR - INS   plus RSSI - TR - AMT - TO - PI - SHRTG   plus RSSI - TR - AMT - TO - DEF - PRIN
         // plus  RSSI - TR - AMT - TO - DEF - INT  plus  RSSI - TR - AMT - TO - DEF - LC   plus RSSI - TR - AMT - TO - DEF - ESC plus RSSI - TR - AMT - TO - DEF - PD - EXP
         //plus RSSI - TR - AMT - TO - DEF - UNPD - EXP plus RSSI - TR - AMT - TO - DEF - ADMIN - FEES plus  RSSI - TR - AMT - TO - DEF - OPTINS
        return Miscellaneous;
    }
  
}
}