namespace Carrington_Service.Interfaces
{
    internal interface IEmailService
    {
        bool SendNotification(string emailBody);
    }
}
