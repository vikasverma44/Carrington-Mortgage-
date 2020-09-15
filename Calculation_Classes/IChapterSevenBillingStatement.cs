using CarringtonMortgage.Models.InputCopyBookModels;

namespace Carrington_Service.Calculation_Classes
{
    public interface IChapterSevenBillingStatement
    {
        string GetFinalChapterSevenBillingStatement(AccountsModel accountModel);
    }
}