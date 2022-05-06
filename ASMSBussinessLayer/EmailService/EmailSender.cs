using ASMSBusinessLayer.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ASMSBusinessLayer.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string SenderMail => _configuration.GetSection("EmailOptions:SenderMail").Value;
        public string Password=> _configuration.GetSection("EmailOptions:Password").Value;
        public string Smtp => _configuration.GetSection("EmailOptions:Smtp").Value;
        public int SmtpPort => Convert.ToInt32(_configuration.GetSection("EmailOptions:SmtpPort").Value);
        public async Task SendMessage(EmailMessage message)
        {
            try
            {
                var mail = new MailMessage()
                {
                    From = new MailAddress(SenderMail)
                }; 
                foreach(var item in message.Contacts)
                {
                    mail.To.Add(item);
                }
                if (message.CC!=null)
                {
                    foreach (var item in message.CC)
                    {
                        mail.CC.Add(item);
                    }
                }
                if (message.CC != null)
                {
                    foreach (var item in message.BCC)
                    {
                        mail.Bcc.Add(item);
                    }
                }
                var managerCC = _configuration.GetSection("ProjectManagers:Email").Value.Split(",");
                if (managerCC!=null)
                {
                    foreach(var item in managerCC)
                    {
                        mail.CC.Add(item);
                    }

                }
                mail.Subject = message.Subject;
                mail.Body = message.Body;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.HeadersEncoding = Encoding.UTF8;
                var smtpClient = new SmtpClient(Smtp,SmtpPort)
                {
                    EnableSsl = true,
                    Credentials=new NetworkCredential(SenderMail,Password)
                };
            await smtpClient.SendMailAsync(mail);
            }
            catch (Exception)
            {

               //loglanacak
            }
        }
    }
}
