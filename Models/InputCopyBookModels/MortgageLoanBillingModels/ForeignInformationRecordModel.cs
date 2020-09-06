using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class ForeignInformationRecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string PrimaryBorrowerSIdNumber { get; set; }
        public string PrimaryBorrowerPrefix { get; set; }
        public string PrimaryBorrowerSuffix { get; set; }
        public string Attention { get; set; }
        public string MailCountry { get; set; }
        public string MailZipCode { get; set; }
        public string PrimaryBorrowerHomeTelephoneNumberCountryCode { get; set; }
        public string PrimaryBorrowerHomeTelephoneNumber { get; set; }
        public string PrimaryBorrowerWorkTelephoneNumberCountryCode { get; set; }
        public string PrimaryBorrowerWorkTelephoneNumber { get; set; }
        public string PrimaryBorrowerFaxTelephoneNumberCountryCode { get; set; }
        public string PrimaryBorrowerFaxTelephoneNumber { get; set; }
        public string PrimaryBorrowerCellTelephoneNumberCountryCode { get; set; }
        public string PrimaryBorrowerCellTelephoneNumber { get; set; }

        public string PropertyCountry { get; set; }
        public string PropertyZipCode { get; set; }
        public string AlternateMailCountry { get; set; }
        public string AlternateZipCode { get; set; }
        public string Filler { get; set; }


    }
}
