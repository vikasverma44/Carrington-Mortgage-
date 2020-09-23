using CarringtonMortgage.Models.InputCopyBookModels;
using System.Text;

namespace CarringtonService.BillingStatements
{
    public interface IStandardBillingStatement
    {
        string  AmountDue { get; set; }
        string AssistanceAmount { get; set; }
        string DeferredBalance { get; set; }
        string DueBalance { get; set; }
        string ExMessage { get; set; }
        string FeesAndChargesPaidLastMonth { get; set; }
        string FeesAndChargesPaidYearToDate { get; set; }
        string LatePaymentAmount { get; set; }
        string Miscellaneous { get; set; }
        string OverduePayment { get; set; }
        string PastDueBalance { get; set; }
        string Principal { get; set; }
        string ReplacementReserveAmount { get; set; }
        string Suspense { get; set; }
        string TotalAmountDue { get; set; }
        string TotalDue { get; set; }
        string TotalFeesAndCharges { get; set; }
        string TotalFeesPaid { get; set; }
        string TotalPaidLastMonth { get; set; }
        string TotalPaidYearToDate { get; set; }
        string UnappliedFunds { get; set; }
        string UnappliedFundsPaidLastMonth { get; set; }
        string UnappliedFundsPaidYearToDate { get; set; }

        string GetACHMessage(AccountsModel accountsModel);
        string GetAmountDue(AccountsModel accountsModel);
        string GetAssistanceAmount(AccountsModel accountsModel);
        string GetAttention(AccountsModel accountsModel);
        string GetAutodraftMessage(AccountsModel accountsModel);
        string GetBankruptcyMessage(AccountsModel accountsModel);
        string GetBuydownBalance(AccountsModel accountsModel);
        string GetCarringtonCharitableDonationbox(AccountsModel accountsModel);
        string GetCarringtonCharitableFoundation(AccountsModel accountsModel);
        string GetCarringtonCharitableFoundationMonth(AccountsModel accountsModel);
        string GetCarringtonCharitablePaidYeartoDate(AccountsModel accountsModel);
        string GetChargeOffNotice(AccountsModel accountsModel);
        string GetChargeOffNoticeDelinquencyNoticeRefinanceMessage(AccountsModel accountsModel);
        string GetCMSPartialClaim(AccountsModel accountsModel);
        string GetDeferredBalance(AccountsModel accountsModel);
        string GetDelinquencyInformationbox(AccountsModel accountsModel);
        string GetEffectiveDate(AccountsModel accountsModel);
        string GetEscrowTaxesInsurance(AccountsModel accountsModel);
        string GetFeesAndChargesPaidLastMonth(AccountsModel accountsModel);
        string GetFeesAndChargesPaidYearToDate(AccountsModel accountsModel);
        StringBuilder GetFinalStringStandardBilling(AccountsModel accountModel);
        string GetForeclosureNotice(AccountsModel accountsModel);
        string GetHUDPartialClaim(AccountsModel accountsModel);
        string GetInterest(AccountsModel accountsModel);
        string GetInterestRateUnit(AccountsModel accountsModel);
        string GetLateCharge(AccountsModel accountsModel);
        string GetLateFee(AccountsModel accountsModel);
        string GetLatePaymentAmount(AccountsModel accountsModel);
        string GetLenderPlacedInsuranceMessage(AccountsModel accountsModel);
        string GetLockboxAddress(AccountsModel accountsModel);
        string GetLossMitigatationNotice(AccountsModel accountsModel);
        string GetMailingAddressLine1(AccountsModel accountsModel);
        string GetMailingAddressLine2(AccountsModel accountsModel);
        string GetMailingCityStateZip(AccountsModel accountsModel);
        string GetMailingCountry(AccountsModel accountsModel);
        string GetMaturityDate(AccountsModel accountsModel);
        string GetMiscellaneous(AccountsModel accountsModel);
        string GetmodificationDate(AccountsModel accountsModel);
        string GetNegativeAmortization(AccountsModel accountsModel);
        string GetOverduePayment(AccountsModel accountsModel);
        string GetPartialClaim(AccountsModel accountsModel);
        string GetPastDueBalance(AccountsModel accountsModel);
        string GetPaymentInformationMessage(AccountsModel accountsModel);
        string GetPaymentReceivedAfter(AccountsModel accountsModel);
        string GetPreForeclosureNotice(AccountsModel accountsModel);
        string GetPrepaymentPenalty(AccountsModel accountsModel);
        string GetPrimaryBorrower(AccountsModel accountsModel);
        string GetPrincipal(AccountsModel accountsModel);
        string GetPrintStatement(AccountsModel accountsModel);
        string GetReceivedAfter(AccountsModel accountsModel);
        string GetRecentPayment1(AccountsModel accountsModel);
        string GetRecentPayment2(AccountsModel accountsModel);
        string GetRecentPayment3(AccountsModel accountsModel);
        string GetRecentPayment4(AccountsModel accountsModel);
        string GetRecentPayment5(AccountsModel accountsModel);
        string GetRecentPayment6(AccountsModel accountsModel);
        string GetRegularMonthlyPayment(AccountsModel accountsModel);
        string GetRepaymentPlanMessage(AccountsModel accountsModel);
        string GetReplacementReserveAmount(AccountsModel accountsModel);
        string GetSecondaryBorrower(AccountsModel accountsModel);
        string GetStateDisclosures(AccountsModel accountsModel);
        string GetStateNSF(AccountsModel accountsModel);
        string GetSuspense(AccountsModel accountsModel);
        string GetTotalAmount(AccountsModel accountsModel);
        string GetTotalAmountDue(AccountsModel accountsModel);
        string GetTotalDue(AccountsModel accountsModel);
        string GetTotalFeesAndCharges(AccountsModel accountsModel);
        string GetTotalFeesPaid(AccountsModel accountsModel);
        string GetTotalPaidLastMonth(AccountsModel accountsModel);
        string GetTotalPaidYearToDate(AccountsModel accountsModel);
        string GetUnappliedFunds(AccountsModel accountsModel);
        string GetUnappliedFundsPaidLastMonth(AccountsModel accountsModel);
        string GetUnappliedFundsPaidYearToDate(AccountsModel accountsModel);
    }
}