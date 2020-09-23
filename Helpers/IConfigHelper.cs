using CarringtonService.Models;

namespace CarringtonService.Helpers
{
    public interface IConfigHelper
    {
        ConfigModel Model
        {
            get;
            set;
        }
        ConfigModel GetConfigModel();

    }
}
