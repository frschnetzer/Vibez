using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Components;
using MimeKit;
using System.Net.Mail;
using System.Runtime.ConstrainedExecution;

namespace Vibez.Data.Service
{
    // Method to Send Emails
    public class EmailSercive:IEmailService
    {

    //"DefaultAuth": "tvst wnqr bblj vywe",
    //"DefaultEmail": "vibez.partyinvites@gmail.com",
    //"DefaultSender": "Vibez Team",
    //"DefaultSubject": "Party Einladung",
    //"DefaultSMTP": "smtp.gmail.com"

        [Inject]
        public IConfiguration Configuration { get; set; }

        public async Task SendEmailAsync(string toMail, string fromUsername)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(Configuration["Email:DefaultSender"], Configuration["Email:DefaultEmail"]));
            message.To.Add(new MailboxAddress("Jakob Moser", toMail));
            message.Subject = Configuration["Email:DefaultSubject"];

            message.Body = new TextPart("html")
            {
                Text = "<h1>Dein Vibez Team,</h1><h1>Eine neue Einladung für dich</h1><p>@{fromUsername} hat dich zu einer Party eingeladen:</p> <a href='https://localhost:7242/counter'>Party Einladung auf Vibez anzeigen,</a> <p>Vibez wünscht dir guten Durst.</p><p style='color: black;'>⚠️ <b>Achtung:</b> Dies ist eine automatische Nachricht, bitte antworten sie nicht auf diese!</p>"
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync(Configuration["Email:DefaultSMTP"], 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(Configuration["Email:DefaultSender"], Configuration["Email:DefaultAuth"]);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
