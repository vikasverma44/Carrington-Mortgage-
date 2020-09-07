using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class RateReductionRecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string RateReductionPlanNumber { get; set; }
        public string RateReductionLoanStatus { get; set; } 
        public string RateReductionTotalReductionToDate { get; set; }
        public string RateReductionTiersCompletedToDate { get; set; }
        public string RateReductionTierStatus { get; set; }
        public string RateReductionDisqualificationDate { get; set; }
        public string RateReductionDisqualificationDueDate { get; set; } 
        public string RateReductionCompletionDate { get; set; }
        public string RateReductionCompletionDueDate { get; set; }
        public string RateReductionReQualificationDate { get; set; }
        public string RateReductionReQualificationDueDate { get; set; }
        public string RateReductionLoanRequiredOnTimePayments { get; set; }
        public string RateReductionOnTimePaymentsCtr { get; set; }
        public string RateReductionRemainingPaymentsCtr { get; set; }
        public string RateReductionNewRate { get; set; }
        public string RateReductionNewPayment { get; set; }
        public string RateReductionNewEffDate { get; set; }
        public string RateReductionPaymentDifference { get; set; }
        public string RateReductionResetDate { get; set; }
        public string RateReductionResetDueDate { get; set; }
        public string RateReductionBeginningDueDate { get; set; }
        public string RateReductionAmount { get; set; }





    }
}
