using System;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace ThursdayMeetingBot.Web.Helpers
{
    internal static class StdSchedulerHelper
    {
        internal static IScheduler GetScheduler(IServiceProvider serviceProvider)
        {
            var stdScheduler = new StdSchedulerFactory()
                                    .GetScheduler()
                                    .GetAwaiter()
                                    .GetResult();
            
            stdScheduler.JobFactory = serviceProvider.GetService<IJobFactory>();

            return stdScheduler;
        }
    }
}