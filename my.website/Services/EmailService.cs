using my.website.Services.Abstract;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace my.website.Services
{
    public class EmailService : IEmailService
    {


        public async Task SendMailAsync(string toMail, string subject, string body)
        {
            try
            {
                string selfMail = "YOUR_MAIL"; // guvenligi azaltilmis email hesabi gerekli aksi halde authenticate olmaz.
                string password = "YOUR_PASSWORD";

                MailMessage newMail = new();
                SmtpClient smtpClient = new();

                newMail.To.Add(toMail);
                newMail.Subject = subject;
                newMail.Body = body;
                newMail.From = new MailAddress(selfMail, "SEND_USER", Encoding.UTF8);

                smtpClient.Credentials = new NetworkCredential(selfMail, password);
                smtpClient.EnableSsl = true;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;

                using (newMail)
                {
                    using (smtpClient)
                    {
                        await smtpClient.SendMailAsync(newMail);
                    }
                }

                Console.WriteLine("email send successfuly");
            }
            catch (Exception ex)
            {
                Console.WriteLine("email send error: " + ex.Message);
            }
        }

    }
}
