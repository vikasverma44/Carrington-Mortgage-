namespace Carrington_Service.Infrastructure
{
    public interface IWorkFlowService
    {
        bool StartWorkFlowService(string _inputFile, string _trackingId);

    }
}