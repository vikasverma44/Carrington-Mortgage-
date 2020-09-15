using CarringtonMortgage.Models.InputCopyBookModels;

namespace Carrington_Service.Calculation_Classes
{
    public interface IOptionARMBillingStatement
    {
        string GetFinalOptionARMBillingStatement(AccountsModel accountsModel);
    }
}