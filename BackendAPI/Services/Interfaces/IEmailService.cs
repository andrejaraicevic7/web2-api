namespace BackendAPI.Services.Interfaces
{
    public interface IEmailService
    {
        void BlockedEmailNotification(string emailTo);
        void VerifiedEmailNotification(string emailTo);
    }
}
