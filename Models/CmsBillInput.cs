using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODHS_EDelivery.Models.InputCopyBookModels
{
    public class CmsBillInput
    {
        public CmsBillInput()
        {
            DetRecord = new DetModel();
            TransRecord = new TransModel();
        }
        public DetModel DetRecord { get; set; }
        public TransModel TransRecord { get; set; }
    }
}
