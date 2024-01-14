﻿using HRLeaveManagement.Application.Contracts.Infrastructure;
using HRLeaveManagement.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
                        UserName = "",
                        Password = ""
                    };
                    client.Credentials = credential;
                    client.Host = "";
                    client.Port = ;
                    client.EnableSsl = true;
                    using (var message = new MailMessage())
                    {
                        message.To.Add(new MailAddress(email.To));
                        message.From = new MailAddress("");
                        message.Subject = email.Subject;
                        message.Body = email.Body;
                        message.IsBodyHtml = ;
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