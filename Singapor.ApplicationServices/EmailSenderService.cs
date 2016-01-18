﻿using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.ApplicationServices
{
    public class EmailSenderService : IEmailSenderService
    {
        public async Task Send(string toEmailAddress, string emailSubject, string emailMessage)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("pavel.shtanko@gmail.com", "zgfif1989")
            };
            using (var message = new MailMessage("pavel.shtanko@gmail.com", toEmailAddress)
            {
                Subject = emailSubject,
                Body = emailMessage
            })
            {
                //TODO: catch errors. And log them.
                await smtp.SendMailAsync(message);
            }
        }
    }
}