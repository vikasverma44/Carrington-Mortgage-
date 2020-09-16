using CarringtonMortgage.Models.InputCopyBookModels;

namespace Carrington_Service.Calculation_Classes
{
    public interface IChapterThirteenBillingStatement
    {
        string GetFinalChapterThirteenBillingStatement(AccountsModel accountModel);
        string GetMailingBKAttorneyAddressLine1(AccountsModel extractAccount);
        string GetMailingBKAttorneyAddressLine2(AccountsModel extractAccount);
    }
}