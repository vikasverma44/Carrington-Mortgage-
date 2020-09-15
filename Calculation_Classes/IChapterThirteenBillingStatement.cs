using CarringtonMortgage.Models.InputCopyBookModels;

namespace Carrington_Service.Calculation_Classes
{
    public interface IChapterThirteenBillingStatement
    {
        string GetFinalChapterThirteenBillingStatement(AccountsModel accountModel);
    }
}