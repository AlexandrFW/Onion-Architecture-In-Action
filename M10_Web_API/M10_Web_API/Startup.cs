using AuxiliaryServices;
using BusinessLogic;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Services.Notification;

namespace M10_Web_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            using var loggerFactory = LoggerFactory.Create(loggingBuilder =>
            {
                loggingBuilder.AddSeq();
                loggingBuilder.AddConsole();
            });

            ILogger logger = loggerFactory.CreateLogger<Startup>();
            ILogger<EmailService> loggerEmailService = loggerFactory.CreateLogger<EmailService>();
            ILogger<SMSService> loggerSMSService = loggerFactory.CreateLogger<SMSService>();

            services
                .AddControllers();

            services
                 .AddEmailService(loggerEmailService, Configuration.GetSection("EmailCreadentials"))
                 .AddSMSService(loggerSMSService, Configuration.GetSection("SMSCong"))
                 .AddDataAccess(Configuration.GetConnectionString("UniversitatDb"))
                 .AddBusinessLogic();
                 
                 

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "M10_Web_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "M10_Web_API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}