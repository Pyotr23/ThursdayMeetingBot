using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace ThursdayMeetingBot.Web.Extensions
{
    internal static class ApplicationBuilderExtensions
    {
        internal static IApplicationBuilder StartScheduler(this IApplicationBuilder builder)
        {
            var scheduler = builder
                .ApplicationServices
                .GetService<IScheduler>();
            
            scheduler
                .Start()
                .GetAwaiter()
                .GetResult();

            return builder;
        }
    }
}