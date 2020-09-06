using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels.MortgageLoanBillingModels
{
    public class MortgageLoanBillingFileModel
    {
        public MortgageLoanBillingFileModel()
        {
            HeaderRecords = new HeaderRecordModel();
            InstitutionRecords = new InstitutionRecordModel();
            AccountModelList = new List<AccountsModel>();
        }
        public HeaderRecordModel HeaderRecords { get; set; }
        public InstitutionRecordModel InstitutionRecords { get; set; }
        public List<AccountsModel> AccountModelList { get; set; }
    }
}
