using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Fundametals.Security.Client.Web.Areas.Identity
{
    public class EmailSender : IEmailSender
    {
        private readonly string _apiKey;
        private readonly string _fromName;
        private readonly string _fromEmail;
        public EmailSender(IConfiguration configuration)
        {
            _apiKey = configuration["SendGrid:ApiKey"];
            _fromName = configuration["SendGrid:FromName"];
            _fromEmail = configuration["SendGrid:FromEmail"];
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            //var client = new SendGridClient(_apiKey);
            //var msg = new SendGridMessage()
            //{
            //    From = new EmailAddress(_fromEmail, _fromName),
            //    Subject = subject,
            //    PlainTextContent = message,
            //    HtmlContent = message
            //};


            
            //msg.AddTo(new EmailAddress(email));
            ////Disable click tracking
            //msg.SetClickTracking(false, false);

            //var response = await client.SendEmailAsync(msg);


            var apiKey = _apiKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(_fromEmail, _fromName);            
            var to = new EmailAddress(email);
            var plainTextContent = message;
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

        }
    }
}
