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

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var jobType = bundle
                .JobDetail
                .JobType;

            if (_serviceProvider.GetService(jobType) is IJob job)
                return job;

            return null!;
        }

        public void ReturnJob(IJob job)
        {
            throw new NotImplementedException();
        }
    }
}