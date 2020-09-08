namespace Carrington_Service.Interfaces
{
    public interface IEmailService
    {
        bool SendNotification(string emailBody);
    }
}
