using HRLeaveManagement.Application.Contracts.Infrastructure;
using HRLeaveManagement.Application.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace HRLeaveManagement.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings _emailSettings { get; }

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task<bool> GetSendEmail(Email email)
        {
            var result = false;
            try
            {
                using (var client = new SmtpClient())
                {
                    var credential = new NetworkCredential()
                    {
                        UserName = _emailSettings.EmilNetworkCredential.UserName,
                        Password = _emailSettings.EmilNetworkCredential.Password,
                    };
                    client.Credentials = credential;
                    client.Host = _emailSettings.Host;
                    client.Port = _emailSettings.Port;
                    client.EnableSsl = _emailSettings.EnableSSl;
                    using (var message = new MailMessage())
                    {
                        message.To.Add(new MailAddress(email.To));
                        message.From = new MailAddress(email.From);
                        message.Subject = email.Subject;
                        message.Body = email.Body;
                        message.IsBodyHtml = email.IsBodyHtml;
                        client.Send(message);
                    }
                    await Task.CompletedTask;
                }
                result = true;
            }
            catch
            {
                result = false;
            }

            return result;


        }
    }
}

            //var client = new SendGridClient(_emailSettings.ApiKey);
            //var to = new EmailAddress(email.To);
            //var from = new EmailAddress
            //{
            //    Email = _emailSettings.FromAddress,
            //    Name = _emailSettings.FromName,
            //};

            //var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            //var response = await client.SendEmailAsync(message);

            //return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;