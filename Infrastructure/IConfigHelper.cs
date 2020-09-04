using Carrington_Service.Models;

namespace Carrington_Service.Infrastructure
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
