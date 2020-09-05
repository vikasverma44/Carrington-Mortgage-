using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
   public class RHCDSOnlyRecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionCode { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string AssistanceAgreementExpirationDate { get; set; }
        public string SubsidyPaidYearToDate { get; set; }
        public string MoratoriumEffectiveDate { get; set; }
        public string MoratoriumFlag { get; set; }
        public string MoratoriumExpirationDate { get; set; }
        public string NoticeControl { get; set; }
        public string PendingStartDate { get; set; }
        public string BankruptcyFlag { get; set; }
        public string BankruptcyTypeCode { get; set; }
        public string RepaymentPlanStatusFlag { get; set; }
        public string RepaymentPlanCancellationDate { get; set; }
        public string RepaymentPlanAdditionalPaymentAmount { get; set; }
        public string RepaymentPlanTerm { get; set; }
        public string RepaymentPlanCreationDate { get; set; }
        public string DownpaymentAmount { get; set; }
        public string PlanPaymentStartDate { get; set; }
        public string AmountOfDwaDelinquency { get; set; }
        public string PostPetitionReaffAgrmtPlanSource	{ get; set; }

}
}
