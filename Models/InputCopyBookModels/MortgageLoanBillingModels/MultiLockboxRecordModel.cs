using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class MultiLockboxRecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SequenceNumber { get; set; }
        public string LoanLockboxIdentification { get; set; }
        public string LockboxAddress1 { get; set; }
        public string LockboxAddress2 { get; set; }
        public string LockboxCity { get; set; }
        public string LockboxState { get; set; }
        public string LockboxZipCode { get; set; }

    }
}
