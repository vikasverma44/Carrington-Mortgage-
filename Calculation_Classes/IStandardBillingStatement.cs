using CarringtonMortgage.Models.InputCopyBookModels;

namespace Carrington_Service.Calculation_Classes
{
    public interface IStandardBillingStatement
    {
        string GetFinalStringStandardBilling(AccountsModel accountModel);
    }
}