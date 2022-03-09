using Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AuxiliaryServices.Notification;
using AuxiliaryServices.Reports;

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
                .AddScoped<ISMSService>(sms => new SMSService(confSection, logger));
        }

        public static IServiceCollection AddReportService(this IServiceCollection services)
        {
            return services
                .AddScoped<IReportService, JSONReportService>()
                .AddScoped<IReportStrategyFactory, ReportStrategyFactory>();
        }
    }
}