using Carrington_Service.Infrastructure;
using System;
using System.Timers;
namespace Carrington_Service.Services
{
    public class WorkFlowService : IWorkFlowService
    {
        #region Class Members Definitions & Constructor
        public readonly ILogger logger;
        public readonly IConfigHelper configHelper;
        private bool result = default;
        private readonly IWorkFlowExpert workFlowExpert;
        private readonly Timer TimerPurge;
        #endregion

        public WorkFlowService(IWorkFlowExpert workFlowExpert, IConfigHelper configHelper, ILogger logger)
        {
            this.workFlowExpert = workFlowExpert;
            this.logger = logger;
            this.configHelper = configHelper;
            TimerPurge = new Timer();
        }

        #region Public Methods

        public bool StartWorkFlowService()
        {
            try

            {
                result = workFlowExpert.StartWorkFlow();

                Timer timer;
                DateTime time = DateTime.Now;

                time = DateTime.Now.AddMinutes(2);
                TimeSpan span = time - DateTime.Now;
                timer = new Timer { Interval = span.TotalMilliseconds < 1 ? 10 : span.TotalMilliseconds, AutoReset = false };
                //   Logger.Trace("Service Processing will be started at :" + DateTime.Now.AddMilliseconds(timer.Interval).ToString());


                timer.Elapsed += (sender, e) => { InitializeServiceTimers(); };
                timer.Start();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.TargetSite.Name);
                return false; ;
            }
        }
        private void InitializeServiceTimers()
        {
            TimerPurge.Elapsed += new System.Timers.ElapsedEventHandler(PurgeTimer_Elapsed);
            TimerPurge.Enabled = true;
            TimerPurge.AutoReset = true;
            TimerPurge.Interval = 60 * 1000;

            TimerPurge.Start();
            // Logger.Trace("Service Processing Timers Initialized");


        }

        public void PurgeTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour > 12 && DateTime.Now.Hour < 8)
            {
                result = workFlowExpert.StartWorkFlow();
            }

        }


        #endregion
    }
}