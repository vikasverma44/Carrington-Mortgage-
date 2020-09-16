using CarringtonMortgage.Models.InputCopyBookModels;

namespace Carrington_Service.Calculation_Classes
{
    public interface IChapterSevenOptionARMStatement
    {
        string GetFinalChapterSevenOptionARMStatement(AccountsModel accountModel);
    }
}