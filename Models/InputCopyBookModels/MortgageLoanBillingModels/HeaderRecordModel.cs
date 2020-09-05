using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class HeaderRecordModel
    {
        public string RecordIdentifier { get; set; }
        public string InstitutionNumber { get; set; }
        public string Filler1 { get; set; }
        public string Filler2 { get; set; }
        public string FileIdentifier { get; set; }
    }
}
