using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
   public class LateChargeDetailRecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string LateChargePaymentDueDate { get; set; }
        public string LateChargeDueDate { get; set; }
        public string LateChargeCalculatedDate { get; set; }
        public string LateChargeAmountForLcDueDate { get; set; }
        public string LateChargePaidDate { get; set; }
        public string LateChargeFactor { get; set; }
        public string LateChargeCalculationMethod { get; set; }
        public string LateChargeWaiverDate { get; set; }
        public string LateChargeWaiverCode { get; set; }
        public string LateChargeReversalDate { get; set; }
        public string LateChargePaidAmount { get; set; }
        public string LateChargeWaiverAmount { get; set; }
        public string LateChargeReversalAmount { get; set; }
        public string LateChargeAdjDate { get; set; }
        public string LateChargePaymentDueDate2 { get; set; }

        public string LateChargeOsBalance { get; set; }
        public string Filler { get; set; }

    }
}
