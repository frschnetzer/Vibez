using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Components;
using MimeKit;
using System.Net.Mail;
using System.Runtime.ConstrainedExecution;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Vibez.Data.Service
{
    // Method to Send Emails
    public class EmailSercive : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailSercive(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toMail, string fromUsername)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Vibez Team", "vibez.eventinvites@gmail.com"));
            message.To.Add(new MailboxAddress(fromUsername, toMail));
            message.Subject = "Party Einladung";

            message.Body = new TextPart("html")
            {
                Text = $"<h1>Dein Vibez Team,</h1><h1>Eine neue Einladung für dich</h1><p>{fromUsername} hat dich zu einer Party eingeladen:</p> <a href='https://localhost:7242/seeinvites'>Party Einladung auf Vibez anzeigen,</a> <p>Vibez wünscht dir guten Durst.</p><p style='color: black;'>⚠️ <b>Achtung:</b> Dies ist eine automatische Nachricht, bitte antworten sie nicht auf diese!</p>"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("vibez.eventinvites@gmail.com", _configuration["Email:DefaultAuth"]);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
