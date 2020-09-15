using Carrington_Service.Agents;
using Carrington_Service.BusinessExpert;
using Carrington_Service.Helpers;
using Carrington_Service.Infrastructure;
using Carrington_Service.Interfaces;
using Carrington_Service.Services;
using SimpleInjector;

namespace Carrington_Service
{
    public static class DIContainer
    {
        private static Container container;
        public static void SetupInjector()
        {
            container = new Container();
            container.Options.ResolveUnregisteredConcreteTypes = true;
            SimpleInjector.Lifestyles.SingletonLifestyle lifestyle = Lifestyle.Singleton;

            container.Register<IWorkFlowExpert, WorkFlowExpert>(lifestyle);
            container.Register<IConfigHelper, ConfigHelper>(lifestyle);
            container.Register<IAgentApi, AgentApi>(lifestyle);
            container.Register<ILogger, Logger>(lifestyle);
            container.Register<IWorkFlowService, WorkFlowService>(lifestyle);
            container.Register<IEmailService, EmailService>(lifestyle);
        }

        public static WorkFlowService GetWorkFlowServiceInstance()
        {
            return container.GetInstance<WorkFlowService>();
        }
    }
}
