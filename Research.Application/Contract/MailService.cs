using Research.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Research.Application.Contract
{
    public class MailService : IMailService
    {
        public async Task SendEmail(string email, string name, string surname)
        {
            try
            {

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("ahmettayyip72@gmail.com", "llfk ylei sngn cdav"),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("ahmettayyip72@gmail.com"),
                    Subject = "Başvurunuz Onaylandı",
                    Body = $"Merhaba {name} {surname}, başvurunuz onaylanmıştır. Tebrikler !",
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }


    }
}
