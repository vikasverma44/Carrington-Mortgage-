using CarringtonMortgage.Models.InputCopyBookModels;

namespace CarringtonMortgage.Calculation_Classes
{
    public interface IRejectStatement
    {
        bool IsRejectAccount(AccountsModel accountModel);
    }
}