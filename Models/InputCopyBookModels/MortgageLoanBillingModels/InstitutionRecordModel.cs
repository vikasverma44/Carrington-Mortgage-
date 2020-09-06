using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class InstitutionRecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string Filler { get; set; }
        public string SequenceNumber { get; set; }
        public string InstitutionName { get; set; }
        public string InstitutionAddress1 { get; set; }
        public string InstitutionAddress2 { get; set; }
        public string InstitutionCity { get; set; }
        public string InstitutionState { get; set; }
        public string InstitutionZip { get; set; }
        public string InstitutionPhone { get; set; }
        public string AlternativeCouponAddress1 { get; set; }
        public string AlternativeCouponAddress2 { get; set; }

        public string AlternativeCouponCity { get; set; }
        public string AlternativeCouponState { get; set; }
        public string AlternativeCouponZip { get; set; }
        public string AlternativePhoneNumberDescription1  { get; set; }
        public string AlternativePhoneNumber1 { get; set; }
        public string AlternativePhoneNumberDescription2 { get; set; }
        public string AlternativePhoneNumber2 { get; set; }
        public string AlternativePhoneNumberDescription3 { get; set; }
        public string AlternativePhoneNumber3 { get; set; }
        public string AlternativePhoneNumberDescription4 { get; set; }
        public string AlternativePhoneNumber4 { get; set; }
        public string AlternativePhoneNumberDescription5 { get; set; }

        public string AlternativePhoneNumber5 { get; set; }
        public string LockboxAddress1  { get; set; }
        public string LockboxAddress2 { get; set; }
        public string LockboxCity { get; set; }
        public string LockboxState { get; set; }
        public string LockboxZipCode { get; set; }
       
    }
}
