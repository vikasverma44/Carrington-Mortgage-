using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class TransactionRecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string DayOfTaskInitiation { get; set; }
        public string BinaryTimeOfDayOfTaskInitiation { get; set; }
        public string TransactionDate { get; set; }
        public string PatternID { get; set; }
        public string Filler1 { get; set; }
        public string LogTransaction { get; set; }
        public string Filler2 { get; set; }
        public string TellerOverride { get; set; }
        public string Filler3 { get; set; }
        public string TransactionAmount { get; set; }
        public string CashAmount { get; set; }
        public string TellerNumber { get; set; }
        public string UnappliedFundCodeBefore { get; set; }

        public string UnappliedFundCodeAfter { get; set; }

        public string TransactionAmountPrincipal { get; set; }
        public string TransactionAmountInterest { get; set; }
        public string TransactionAmountEscrow { get; set; }
        public string TransactionAmountLateCharge { get; set; }
        public string TransactionAmountUncollectedOptionalInsurance { get; set; }
        public string TransactionAmountUncollectedInterest { get; set; }
        public string TransactionAmountPostedToUnappliedFunds { get; set; }

        public string TransactionAmountUncollectedLateCharges { get; set; }
        public string TransactionAmountConstructionBalance { get; set; }
        public string TransactionPaymentCounter { get; set; }
        public string TransactionAmountOptionalInsurance { get; set; }
        public string PrincipalBalanceAfterTransaction { get; set; }
        public string EscrowBalanceAfterTransaction { get; set; }
        public string InterestPaidToDateAfterTransaction { get; set; }
        public string StandardEscrowPayment { get; set; }
        public string UncollectedCreditInsuranceBalanceAfterTransaction { get; set; }
        public string UncollectedInterestBalanceAfterTransaction { get; set; }
        public string UnappliedFundsBalanceAfterTransaction { get; set; }
        public string UncollectedLateChargeBalanceAfterTransaction { get; set; }
        public string LastActivityDateBeforeTransaction { get; set; }
        public string ConstructionLoanBalanceAfterTransaction { get; set; }
        public string LastActivityDateConstructionLoanBeforeTransaction { get; set; }
        public string PreCalculationInterestAmountAfterTransaction { get; set; }
        public string PreCalculationInterestDateAfterTransaction { get; set; }
        public string TransactionAmountFees { get; set; }
        public string FeeCode { get; set; }
        public string FeeDescription { get; set; }
        public string TransactionAmountNegativeAmortizationTaken { get; set; }
        public string TransactionAmountNegativeAmortizationPaid { get; set; }
        public string EscrowPayeeTypeCode { get; set; }
        public string AmortizedFeePayment { get; set; }
        public string TransactionAmountUnappliedFunds2 { get; set; }
        public string TransactionAmountUnappliedFunds3 { get; set; }
        public string TransactionAmountUnappliedFunds4 { get; set; }
        public string TransactionAmountUnappliedFunds5 { get; set; }
        public string PurchaseOrderExpenseCode { get; set; }
        public string ExpenseFeeDescription { get; set; }
        public string ExpenseFeeAmount { get; set; }
        public string TransactionAmountToP_IShortage { get; set; }
        public string TransactionAmountEscrowShortageOverage { get; set; }
        public string AmountToHmpBorrowerIncentive { get; set; }
        public string TransactionAmountToPra { get; set; }
        public string TransactionAmountPostedToDeferredPrincipal { get; set; }
        public string DeferredPrincipalBalanceAfterTransaction { get; set; }
        public string TranAmountToDeferredInterest { get; set; }
        public string DeferredInterestBalanceAfterTransaction { get; set; }
        public string TranAmountToDeferredLateCharge { get; set; }
        public string DeferredLateChgBalanceAfterTransaction { get; set; }
        public string TranAmountToDeferredEscrowAdv { get; set; }
        public string DeferredEscrowAdvanceAfterTransaction { get; set; }
        public string TranAmountToDeferredPaidExpensesAdv { get; set; }
        public string DeferredPaidExpensesAfterTransaction { get; set; }
        public string TranAmountToDeferredUnpaidExpenseAdv { get; set; }
        public string DeferredUnpaidExpensesAfterTransaction { get; set; }
        public string TranAmountToDeferredAdminFees { get; set; }
        public string DeferredAdminFeesBalAfterTransaction { get; set; }
        public string OptionalDeferredAmount { get; set; }
        public string DeferredOptionalInsAfterTransaction { get; set; }
        public string TransactionAmountEscrowPart2 { get; set; }
        public string Filler4 { get; set; }
    }
}
