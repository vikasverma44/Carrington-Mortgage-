using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class MortgageLoanBillingFile
    {
        public HeaderRecord HeaderRecords { get; set; }
        public InstitutionRecord InstitutionRecords { get; set; }
        public List<MasterFileDataPart_1> MasterFileDataPart_1 { get; set; }
        public PL_Record PL_Records { get; set; }


    }
}
