using PRJRepository.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PRJRepository.Repo
{
    public class SendEmail
    {
        public async Task EmailSender(string toEmail, string message, string Subject)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("Timbercreek@stream.com", "Stream");
            var subject = Subject;
            var to = new EmailAddress(toEmail,"Client");
            var plainTextContent = message;
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
