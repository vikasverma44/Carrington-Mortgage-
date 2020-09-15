using CarringtonMortgage.Models.InputCopyBookModels;
using System.Text;

namespace Carrington_Service.Calculation_Classes
{
    public interface IChapterSevenBillingStatement
    {
        StringBuilder GetFinalChapterSevenBillingStatement(AccountsModel accountModel);
        string GetMailingBKAttorneyAddressLine1(AccountsModel accountModel);
        string GetMailingBKAttorneyAddressLine2(AccountsModel accountModel);
    }
}