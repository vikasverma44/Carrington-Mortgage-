using CarringtonMortgage.Models.InputCopyBookModels;
using System.Text;

namespace Carrington_Service.Calculation_Classes
{
    public interface IStandardBillingStatement
    {
        StringBuilder GetFinalStringStandardBilling(AccountsModel accountModel);
        string GetLatePaymentAmount(AccountsModel accountsModel);
        string GetMailingAddressLine1(AccountsModel accountsModel);
        string GetMailingAddressLine2(AccountsModel accountsModel);
        string GetMailingCityStateZip(AccountsModel accountsModel);
    }
}