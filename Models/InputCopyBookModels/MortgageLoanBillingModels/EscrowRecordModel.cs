using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class EscrowRecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string PayeeType { get; set; }
        public string EscrowLineCompanyCountyCode { get; set; }
        public string EscrowLineAgencyTownshipCode { get; set; }
        public string PayeePrimaryName { get; set; }
        public string PayeeTelephoneNumber { get; set; }
        public string ProductName { get; set; }
        public string AmountDueForOneCycle { get; set; }
        public string TotalNumberOfPaymentsDue { get; set; }
        public string EscrowLineExpirationDate { get; set; }







    }
}
