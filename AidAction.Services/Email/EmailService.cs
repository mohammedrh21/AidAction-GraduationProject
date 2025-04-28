using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Services.Email
{
    public class EmailService : IEmailService
    {

        public async Task Send(string to, string subject, string body)
        {
            try
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(to));
                message.From = new MailAddress("aidactionplatform@gmail.com", "FTC Test Email");
                message.Body = body;
                message.Subject = subject;


                var EmailClient = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("aidactionplatform@gmail.com", "WolfXI21$$")
                };
                await EmailClient.SendMailAsync(message);
            }catch(Exception e)
            {
                Console.Write(e.Message);
                throw;
            }
        }

    }
}
