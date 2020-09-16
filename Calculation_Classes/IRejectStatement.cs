using CarringtonMortgage.Models.InputCopyBookModels;

namespace CarritonMortgage.Calculation_Classes
{
    public interface IRejectStatement
    {
        bool IsRejectAccount(AccountsModel accountModel);
    }
}