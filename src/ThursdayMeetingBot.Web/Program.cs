using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ThursdayMeetingBot.Web
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
                .ConfigureWebHostDefaults(webHostBuilder => webHostBuilder.UseStartup<Startup>());
        }
    }
}