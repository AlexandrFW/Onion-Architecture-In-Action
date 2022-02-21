using Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Services.Notification;

namespace AuxiliaryServices
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddEmailService(this IServiceCollection services, ILogger<EmailService> logger, IConfigurationSection confSection)
        {
            return services
                .AddScoped<IEmailService>(email => new EmailService(confSection, logger));
        }

        public static IServiceCollection AddSMSService(this IServiceCollection services, ILogger<SMSService> logger, IConfigurationSection confSection)
        {
            return services
                .AddScoped<ISMSService>(email => new SMSService(confSection, logger));
        }
    }
}