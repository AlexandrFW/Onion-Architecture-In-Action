using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using TypesConverterLibrary;

namespace ExceptionHandlingAndLogApp
{
    public class Program
    {
        private static readonly NLog.Logger LoggerN = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            Console.WriteLine("M05. Exception Handling. Logging. NLog");
            Console.WriteLine("");

            var host = Host.CreateDefaultBuilder(args).Build();       
            var logger = host.Services.GetRequiredService<ILogger<Program>>();

            logger.LogInformation("Start HOST");
            host.StartAsync();

            logger.LogInformation("Init StringToIntConverter from TypeConverterLibrary.dll");
            var toIntConverter = new StringToIntConverter(logger);

            try
            {
                logger.LogInformation("Convert string to int");
                toIntConverter.ConvertToInt("45467a");
            }
            catch (Exception ex)
            {
                Console.WriteLine();

                logger.LogError("This exception has thrown from TypeConverterLibrary.dll\r\nMessage: {0}\r\nStackTrace: {1}", new object[] { ex.Message, ex.StackTrace });
                LoggerN.Error(ex);
            }

            logger.LogInformation("Waiting for user reaction");
            Console.ReadKey();

            logger.LogInformation("Stop HOST asynchronously");
            host.StopAsync().Wait();

            logger.LogInformation("NLog shutting down");
            NLog.LogManager.Shutdown(); 
        }
    }
}