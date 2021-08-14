using System;
using Quartz;
using Quartz.Spi;

namespace ThursdayMeetingBot.Libraries.Quartz.Jobs.Factory
{
    public class JobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public JobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IJob? NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var jobType = bundle
                .JobDetail
                .JobType;
            
            return _serviceProvider.GetService(jobType) as IJob;
        }

        public void ReturnJob(IJob job)
        {
            // i couldn't find a way to release services with your preferred DI, 
            // its up to you to google such things
        }
    }
}