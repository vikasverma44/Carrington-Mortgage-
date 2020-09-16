namespace Carrington_Service.Infrastructure
{
    public interface IWorkFlowExpert
    {
        bool StartWorkFlow(string _inputFile, string _trackingId);
    }
}
