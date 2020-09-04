using Carrington_Service;
using Carrington_Service.Services;
using System;

namespace Carrington_Service
{
    public class Program
    {
        private static void Main()
        {
            DIContainer.SetupInjector();
            WorkFlowService objWFservice = DIContainer.GetWorkFlowServiceInstance();

            try
            {
                objWFservice.logger.Trace("STARTED: Main");
                if (objWFservice.StartWorkFlowService())
                {
                    objWFservice.logger.Trace("SUCCESS: Application succcesfully executed with 0 error.");
                    objWFservice.logger.Trace("ENDED:   Main");
                }
                else
                {
                    objWFservice.logger.Trace("ERROR:   Application aborted with 1 error.");
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                objWFservice.logger.Error(ex, ex.TargetSite.Name);
            }
        }
    }
}

