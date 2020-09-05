using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class DisasterTrackingRecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string DisasterOccurrenceNumber { get; set; }
        public string DisasterStatus { get; set; }
        public string DisasterName { get; set; }
        public string DisasterType { get; set; }
        public string DesignationDate { get; set; }
        public string DisasterEndDate { get; set; }
        public string DisasterExtendedEndDate { get; set; }
        public string DeclarationNumber { get; set; }
        public string ApplicantNumber { get; set; }
        public string PropertyImpact { get; set; }
        public string PropertyImpactDeterminationDate { get; set; }
        public string PropertyImpactResolutionDate { get; set; }
        public string PropertyImpactSeverity { get; set; }
        public string WorkplaceImpact { get; set; }
        public string WorkplaceImpactDeterminationDate { get; set; }
        public string WorkplaceImpactResolutionDate { get; set; }
        public string WorkplaceImpactSeverity { get; set; }
        public string AttemptedContact { get; set; }
        public string DateAttempted { get; set; }
        public string ContactMade { get; set; }
        public string DateContacted { get; set; }
        public string Filler { get; set; }

    }
}
