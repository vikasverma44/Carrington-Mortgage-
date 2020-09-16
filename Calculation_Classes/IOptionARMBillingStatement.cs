using CarringtonMortgage.Models.InputCopyBookModels;

namespace Carrington_Service.Calculation_Classes
{
    public interface IOptionARMBillingStatement
    {
        string GetFinalOptionARMBillingStatement(AccountsModel accountsModel);
        string GetMailingAddressLine1(AccountsModel extractAccount);
        string GetMailingAddressLine2(AccountsModel extractAccount);
    }
}