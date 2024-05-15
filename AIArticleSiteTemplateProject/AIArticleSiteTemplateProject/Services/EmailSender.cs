using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace AIArticleSiteTemplateProject.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpClient _client;
        private readonly string? _fromEmail;
        public EmailSender(IConfiguration configuration)
        {
            _fromEmail = configuration["Email:FromEmail"];
            _client = new SmtpClient
            {
                Host = configuration["Email:Smtp:Host"]!,
                Port = int.Parse(configuration["Email:Smtp:Port"]!),
                EnableSsl = bool.Parse(configuration["Email:Smtp:EnableSsl"]!),
                Credentials = new NetworkCredential(
                    configuration["Email:Smtp:Username"],
                    configuration["Email:Smtp:Password"]
                )
            };
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mailMessage = new MailMessage(_fromEmail, email, subject, htmlMessage)
            {
                IsBodyHtml = true
            };
            return _client.SendMailAsync(mailMessage);
        }

    }

}

//using Microsoft.AspNetCore.Identity;
//using System.Net.Mail;
//using System.Net;
//using System.Threading.Tasks;

//namespace AIArticleSiteTemplateProject.Services
//{
//    public class EmailSender<TUser> : IEmailSender<TUser> where TUser : class
//    {
//        private readonly SmtpClient _client;
//        private readonly string? _fromEmail;

//        public EmailSender(IConfiguration configuration)
//        {
//            _fromEmail = configuration["Email:FromEmail"];
//            _client = new SmtpClient
//            {
//                Host = configuration["Email:Smtp:Host"]!,
//                Port = int.Parse(configuration["Email:Smtp:Port"]!),
//                EnableSsl = bool.Parse(configuration["Email:Smtp:EnableSsl"]!),
//                Credentials = new NetworkCredential(
//                    configuration["Email:Smtp:Username"],
//                    configuration["Email:Smtp:Password"]
//                )
//            };
//        }

//        public Task SendConfirmationLinkAsync(TUser user, string email, string confirmationLink)
//        {
//            var subject = "Confirm your email";
//            var htmlMessage = $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.";
//            return SendEmailAsync(email, subject, htmlMessage);
//        }

//        public Task SendPasswordResetLinkAsync(TUser user, string email, string resetLink)
//        {
//            var subject = "Reset Password";
//            var htmlMessage = $"Reset your password by <a href='{resetLink}'>clicking here</a>.";
//            return SendEmailAsync(email, subject, htmlMessage);
//        }

//        public Task SendPasswordResetCodeAsync(TUser user, string email, string resetCode)
//        {
//            var subject = "Password Reset Code";
//            var htmlMessage = $"Your password reset code is: {resetCode}";
//            return SendEmailAsync(email, subject, htmlMessage);
//        }

//        public Task SendEmailAsync(string email, string subject, string htmlMessage)
//        {
//            var mailMessage = new MailMessage(_fromEmail, email, subject, htmlMessage)
//            {
//                IsBodyHtml = true
//            };
//            return _client.SendMailAsync(mailMessage);
//        }
//    }
//}

