using Domain.Interfaces.Services;
using Domain.ServiceTools;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using Services.Tools;

namespace Services.Notification
{
    public class EmailService : IEmailService
    {
        private ILogger<EmailService> _logger;
        private Email _email;

        public EmailService() { }

        public EmailService(IConfigurationSection confSection, ILogger<EmailService> logger)
        {
            _logger = logger;
            _email = JSONSerializer.JSONGetSection<Email>(confSection);
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            if (_email is not null)
            {
                _logger.LogInformation("Creating email to send");
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress("M10 service administration", _email.Auth.User));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };

                _logger.LogInformation("Email is created");
                _logger.LogInformation("Try to send the email");

                using (var client = new SmtpClient())
                {
                    client.Connect(_email.Host, _email.Port, false);

                    if (client.IsConnected)
                        _logger.LogInformation("Try to send the email");
                    else
                        _logger.LogWarning($"Cannot connect to the host { _email.Host }");

                    client.Authenticate(_email.Auth.User, _email.Auth.Pass);

                    if (client.IsAuthenticated)
                        _logger.LogInformation("Client is authenticated");
                    else
                        _logger.LogWarning($"Cannot authenticate to the host { _email.Host }");

                    await client.SendAsync(emailMessage);
                    _logger.LogInformation("Email has been sent");

                    await client.DisconnectAsync(true);
                }
            }
        }
    }
}