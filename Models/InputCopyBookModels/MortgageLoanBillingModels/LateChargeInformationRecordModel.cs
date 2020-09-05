using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class LateChargeInformationRecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string InterestPaidToDate { get; set; }
        public string LateChargeCode { get; set; }
        public string LateChargeAssessCode { get; set; }
        public string LateChargePaidToDate { get; set; }
        public string LateChargeCollectionMethod { get; set; }
        public string LateChargeFactor { get; set; }
        public string LateChargeAssessmentMethod { get; set; }
        public string LateChargeMaximum { get; set; }
        public string LateChargeMinimum { get; set; }
        public string LateChargesAssessmentMaximumAnnual { get; set; }
        public string LateChargeAssessmentMaximumLifeTime { get; set; }
        public string LateChargeCounter { get; set; }
        public string LateChargeFreezeDateTo { get; set; }
        public string LateChargeFreezeDateFrom { get; set; }
        public string LateChargeFreezeDateType { get; set; }
        public string LateChargeYearType { get; set; }
        public string LateChargesAssessedLifeOfLoan { get; set; }
        public string LateChargesAssessedYtd { get; set; }
        public string Filler { get; set; }

    }
}
