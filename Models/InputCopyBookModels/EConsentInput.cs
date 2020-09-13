using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarringtonMortgage.Models.InputCopyBookModels
{
    public class EConsentInput
    {
        public EConsentInput()
        {
            EConsentRecord = new EConsentModel();
        }
        public EConsentModel EConsentRecord { get; set; }
    }
}
