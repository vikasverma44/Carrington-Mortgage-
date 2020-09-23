namespace CarringtonService.Services
{
    public interface IWorkFlowService
    {
        bool StartWorkFlowService(string _inputFile, string _trackingId);

    }
}