using CarringtonMortgage.Models.InputCopyBookModels.MortgageLoanBillingModels;

namespace ODHS_EDelivery.BusinessExpert
{
    public interface ICRL30FileGeneration
    {
        void GenerateCRL30File(MortgageLoanBillingFileModel mortgageLoanBillingFileModel);
    }
}