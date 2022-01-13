using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
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
            Console.WriteLine();

            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .WriteTo.Console(outputTemplate: "{Timestamp:dd.MM.yyyy HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
                            .CreateLogger();

            // Register Serilog while creating Microsoft.Extensions.Logging.LoggerFactory
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddSerilog(dispose: true));

            // Create an instance of ILogger using the factory
            var logger = loggerFactory.CreateLogger<Program>();

            logger.LogInformation("Start HOST");

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

                logger.LogError("This exception has thrown from TypeConverterLibrary.dll\r\nMessage: {0}\r\nStackTrace: {1}", ex.Message, ex.StackTrace);
                LoggerN.Error(ex);
            }

            logger.LogInformation("Waiting for user reaction");
            Console.ReadKey();            

            logger.LogInformation("NLog shutting down");

            Log.CloseAndFlush();

            NLog.LogManager.Shutdown(); 
        }
    }
}