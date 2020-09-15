using CarringtonMortgage.Models.InputCopyBookModels;
using System.Text;

namespace Carrington_Service.Calculation_Classes
{
    public interface IChapterSevenOptionARMStatement
    {
        StringBuilder GetFinalChapterSevenOptionARMStatement(AccountsModel accountModel);
        string GetMailingBKAttorneyAddressLine1(AccountsModel accountsModel);
        string GetMailingBKAttorneyAddressLine2(AccountsModel accountsModel);
    }
}