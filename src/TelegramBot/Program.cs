using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ThursdayMeetingBot.TelegramBot.Constants;
using ThursdayMeetingBot.TelegramBot.Helpers;

namespace ThursdayMeetingBot.TelegramBot
{
    /// <summary>
    ///     App entry point
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main class. 
        /// </summary>
        /// <param name="args"> Application arguments. </param>
        public static async Task Main(string[] args) =>
            await CreateHostBuilder(args)
                .Build()
                .RunAsync();

        /// <summary>
        ///     Creating web app host.
        /// </summary>
        /// <param name="args"> Application arguments. </param>
        /// <returns> Web app host object. </returns>
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((_, builder)
                    => builder.AddConfiguration(BuildConfiguration(args)))
                .ConfigureWebHostDefaults(webHostBuilder => webHostBuilder.UseStartup<Startup>());
        }
        
        /// <summary>
        ///     Create application configuration.
        /// </summary>
        /// <param name="args"> Application argiments. </param>
        /// <returns> Application configuration object. </returns>
        private static IConfiguration BuildConfiguration(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{EnvironmentHelper.GetEnvironment()}.json", 
                    true, 
                    true)
                .AddEnvironmentVariables();

            if(EnvironmentHelper.IsDevelopment())
                configurationBuilder.AddUserSecrets<Startup>();

            return configurationBuilder
                .AddCommandLine(args)
                .Build();
        }
    }
}