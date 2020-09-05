using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class MasterFileDataPart_1
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string CreditInsurancePayment { get; set; }
        public string PrincipalBalance { get; set; }
        public string EscrowBalance { get; set; }
        public string LoanType { get; set; }
        public string LoanSubtype { get; set; }
        public string P_IPayment { get; set; }
        public string InvestorOwnershipCode { get; set; }
        public string InvestorInformationOccurrences { get; set; }

        public string LastStatementDate { get; set; }
        public string PrecalculatedInterestAmount { get; set; }
        public string UnappliedFundsBalanceFirst { get; set; }
        public string PropertyTypeCode { get; set; }
        public string InterestPaidYearToDate { get; set; }
        public string PurposeCode { get; set; }
        public string UnappliedFundsCodeFirst { get; set; }
        public string StateCode { get; set; }
        public string DueDate { get; set; }
        public string PaymentsPastDue { get; set; }
        public string PaymentDueCounter { get; set; }
        public string LateChargeAmount { get; set; }

        public string LateChargeDue { get; set; }
        public string PrepaidFlag { get; set; }
        public string EscrowInterestYTD { get; set; }
        public string RunDate { get; set; }
        public string PrimaryBorrowersName { get; set; }
        public string SecondaryBorrowersName { get; set; }
        //
        public string MailingAddress { get; set; }
        public string PropertyAddress { get; set; }
        public string DueDateGrace { get; set; }
        public string CurrentPayment { get; set; }
        public string BranchNumber { get; set; }
        public string PastDueAmtTotalDue { get; set; }
        public string LateCharge { get; set; }
        public string PaymentCycleCode { get; set; }
        public string WarningCode { get; set; }
        public string DistributionMailCode { get; set; }
        public string LastActivityDate { get; set; }
        public string AnnualPercentageRate { get; set; }

        public string NegativeAmortizationTaken { get; set; }
        public string GraceDays { get; set; }
        public string TaxesPaidYearToDate { get; set; }
        public string InterestPaidToDate { get; set; }
        public string CurrentDueDate { get; set; }
        public string UncollectedCreditInsurance { get; set; }
        public string UncollectedInterest { get; set; }
        public string NoteRate { get; set; }
        public string NegativeAmortizationAssessedYTD { get; set; }
        public string NegativeAmortizationPaidYTD { get; set; }
        public string NoteRateOverUnder { get; set; }
        public string OriginalRateOverUnder { get; set; }
        //
        public string BillableNumber { get; set; }
        public string BankTransitRoutingNumber { get; set; }
        public string WithholdingInterestYTD { get; set; }
        public string NegativeAmortizationFlag { get; set; }
        public string InterestOnPymtDue { get; set; }
        public string SecondMortgageCode { get; set; }
        public string SecondaryMortgageAccountNumber { get; set; }
        public string SecondaryMortgagePaymentAmount { get; set; }
        public string FeeReceivable { get; set; }
        public string PastDuePayments { get; set; }
    
    }
}
