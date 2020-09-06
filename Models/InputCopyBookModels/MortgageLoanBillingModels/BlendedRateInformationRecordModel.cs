using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class BlendedRateInformationRecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string SpecialProductType { get; set; }
        public string SpecialLoanTypeId { get; set; }
        public string AlternativeChangeAmount1 { get; set; }
        public string AlternativeChangeAmount2 { get; set; }
        public string AlternativeChangeAmount3 { get; set; }
        public string AlternativeChangeAmount4 { get; set; }
        public string AlternativePaymentAmount1 { get; set; }
        public string AlternativePaymentAmount2 { get; set; }
        public string AlternativePaymentAmount3 { get; set; }
        public string AlternativePaymentAmount4 { get; set; }
        public string BlendedAdjustableRate { get; set; }
        public string BlendedFixedRate { get; set; }
        public string BlendedRateAdjustableComponent { get; set; }
        public string BlendedRateFixedComponent { get; set; }
        public string BlendedRateFlag { get; set; }
        public string BlendedRateMargin { get; set; }
        public string BlendedRateTerm { get; set; }
        public string OriginalBlendedAdjustablePercent { get; set; }
        public string OriginalBlendedFixedPercent { get; set; }
        public string BlendedRateLoanOptionIndicator { get; set; }
        public string CurrentBlendedRateFixedPerc { get; set; }
        public string CurrentBlendedRateAdjustablePerc { get; set; }
        public string Filler1 { get; set; }

    }
}
