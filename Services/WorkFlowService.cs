using Carrington_Service.Infrastructure;
using System;

namespace Carrington_Service.Services
{
    public class WorkFlowService : IWorkFlowService
    {
        #region Class Members Definitions & Constructor
        public readonly ILogger logger;
        public readonly IConfigHelper configHelper;
        private bool result = default;
        private readonly IWorkFlowExpert workFlowExpert;
        #endregion

        public WorkFlowService(IWorkFlowExpert workFlowExpert, IConfigHelper configHelper, ILogger logger)
        {
            this.workFlowExpert = workFlowExpert;
            this.logger = logger;
            this.configHelper = configHelper;
        }

        #region Public Methods

        public bool StartWorkFlowService()
        {
            try
            {
                result = workFlowExpert.StartWorkFlow();
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.TargetSite.Name);
                return result;
            }
        }

        #endregion
    }
}