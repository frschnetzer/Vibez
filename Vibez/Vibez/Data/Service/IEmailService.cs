namespace Vibez.Data.Service
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string toMail, string fromUsername);
    }
}