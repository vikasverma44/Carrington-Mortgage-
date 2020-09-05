using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class MortgageLoanBillingFileModel
    {
        public HeaderRecordModel HeaderRecords { get; set; }
        public InstitutionRecordModel InstitutionRecords { get; set; }
        public List<MasterFileDataPart_1Model> MasterFileDataPart_1 { get; set; }
        public PL_RecordModel PL_Records { get; set; }


    }
}
