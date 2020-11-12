using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.Security.Client.Web.Areas.Identity
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

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(_apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_fromEmail, _fromName),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };

            msg.AddTo(new EmailAddress(email));
            msg.SetClickTracking(false, false);

            var response = await client.SendEmailAsync(msg);
        }
    }
}
