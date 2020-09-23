using CarringtonMortgage.Models.InputCopyBookModels.MortgageLoanBillingModels;

namespace CarringtonService.BusinessExpert
{
    public interface ICRL30FileGeneration
    {
        void GenerateCRL30File(MortgageLoanBillingFileModel mortgageLoanBillingFileModel, string inputFile);
    }
}