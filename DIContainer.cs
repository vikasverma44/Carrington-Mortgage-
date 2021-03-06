﻿using CarringtonService.BusinessExpert;
using CarringtonService.BillingStatements;
using CarringtonService.Helpers;

using CarringtonService.Services;
using CarringtonMortgage.Calculation_Classes;
using SimpleInjector;
using CarringtonMortgage.OptionAssignment;
using CarringtonService.BusinessExpert;

namespace CarringtonService
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
            container.Register<ILogger, Logger>(lifestyle);
            container.Register<IWorkFlowService, WorkFlowService>(lifestyle);
            container.Register<IChapterThirteenOptionARMStatement, ChapterThirteenOptionARMStatement>(lifestyle);
            container.Register<IChapterSevenBillingStatement, ChapterSevenBillingStatement>(lifestyle);
            container.Register<IChapterThirteenBillingStatement, ChapterThirteenBillingStatement>(lifestyle);
            container.Register<IStandardBillingStatement, StandardBillingStatement>(lifestyle);
            container.Register<IOptionARMBillingStatement, OptionARMBillingStatement>(lifestyle);
            container.Register<ICRL30FileGeneration, CRL30FileGeneration>(lifestyle);
            container.Register<IOptionAssignmentLogic, OptionAssignmentLogic>(lifestyle);
            container.Register<IChapterSevenOptionARMStatement, ChapterSevenOptionARMStatement>(lifestyle);
            container.Register<IRejectStatement, RejectStatement>(lifestyle);
            
        }

        public static WorkFlowService GetWorkFlowServiceInstance()
        {
            return container.GetInstance<WorkFlowService>();
        }
    }
}
