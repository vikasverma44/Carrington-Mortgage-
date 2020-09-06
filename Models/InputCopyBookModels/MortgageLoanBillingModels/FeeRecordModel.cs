using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class FeeRecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string FeeType { get; set; }
        public string FeeDescription { get; set; }
        public string FeeLevelAmortizedFeePayment { get; set; }
        public string PreviousFeeBalance { get; set; }
        public string NewReceivableFeesAssessed { get; set; }
        public string AssessedDate { get; set; }
        public string FeesInvoiceCredits { get; set; }
        public string FeesNotPreviouslyAssessedThatAreCollectedThisBillingCycle { get; set; }
        public string FeesWaivedThisBillingCycle { get; set; }
        public string FeeBalanceThisBillingCycle { get; set; }
        public string FeeCollectedTransactionDate { get; set; }
        public string FeeWaivedTransactionDate { get; set; }
        public string RecurringFeesDue { get; set; }
        public string RecurringFeePaymentsPastDue { get; set; }
        public string FillerPart1 { get; set; }
        public string InvoiceExpenseType { get; set; }
        public string InvoicePurchaseOrderNumber { get; set; }
        public string InvoiceExpenseAmountBilled { get; set; }
        public string InvoiceExpenseAmountPaid { get; set; }
        public string InvoiceRecoverabilityFlag { get; set; }
        public string InvoiceDate { get; set; }
        public string DateInvoiceWasPaid { get; set; }
        public string InvoiceVendorCode { get; set; }
        public string InvoiceResponsibilityCode { get; set; }
        public string InvoiceExpenseCode { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceFunctionalArea { get; set; }
        public string FillerPart2 { get; set; }

    }
}
