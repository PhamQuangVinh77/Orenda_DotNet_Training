using DotNetTrainingProject.Entities;
using DotNetTrainingProject.MailUtilities;
using DotNetTrainingProject.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MimeKit;

namespace DotNetTrainingProject.Services
{
    public class SendMailService : ISendMailService
    {
        private MailSettings _mailSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        public SendMailService(IOptions<MailSettings> mailSettings, UserManager<ApplicationUser> userManager) 
        {
            _mailSettings = mailSettings.Value;
            _userManager = userManager;
        }
        public async Task<string> SendMail(string userName) 
        {
            var existUser = await _userManager.FindByNameAsync(userName);
            if (existUser == null) return "Username doesn't exist!";
            var toEmail = existUser.Email.ToString();

            var email = new MimeMessage();
            email.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail);
            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            email.To.Add(new MailboxAddress(toEmail, toEmail));
            email.Subject = "FORGET PASSWORD MAIL";
            var builder = new BodyBuilder();
            builder.HtmlBody = "This is forget password mail!";
            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
                return String.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                smtp.Disconnect(true);
                return "Send OTP failed";
            }
        } 
    }
}
