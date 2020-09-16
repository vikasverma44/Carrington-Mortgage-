using CarringtonMortgage.Models.InputCopyBookModels;
using System.Text;

namespace Carrington_Service.Calculation_Classes
{
    public interface IChapterThirteenOptionARMStatement
    {
        StringBuilder GetFinalChapterThirteenOptionARMStatement(AccountsModel accountModel);
    }
}