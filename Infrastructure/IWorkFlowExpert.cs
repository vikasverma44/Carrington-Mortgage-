namespace Carrington_Service.Infrastructure
{
    public interface IWorkFlowExpert
    {
        bool StartWorkFlow();
        bool FileReadingProcess(string _inputifle, string _trackingId);
    }
}
