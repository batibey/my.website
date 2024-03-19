namespace my.website.Services.Abstract
{
    public interface IEmailService
    {
        Task SendMailAsync(string toMail, string subject, string body);
    }
}
