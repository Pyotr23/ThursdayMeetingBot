using System;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using ThursdayMeetingBot.Web.Interfaces;
using ThursdayMeetingBot.Web.Models;
using ThursdayMeetingBot.Web.Quartz;

namespace ThursdayMeetingBot.Web.Services
{
    /// <inheritdoc cref="IQuartzHostedService"/>
    public class QuartzHostedService : IQuartzHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private IScheduler _scheduler;
        
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="schedulerFactory"> Scheduler factory. </param>
        public QuartzHostedService(ISchedulerFactory schedulerFactory)
        {
            _schedulerFactory = schedulerFactory;
        }
        
        /// <inheritdoc cref="IQuartzHostedService.StartAsync"/>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            await _scheduler.Start(cancellationToken);
        }

        /// <inheritdoc cref="IQuartzHostedService.StopAsync"/>
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _scheduler?.Shutdown(cancellationToken);
        }

        /// <inheritdoc cref="IQuartzHostedService.GetJobDetailAsync"/>
        public async Task<IJobDetail> GetJobDetailAsync(string jobName, CancellationToken cancellationToken)
        {
            var jobKey = new JobKey(jobName);
            return await _scheduler.GetJobDetail(jobKey, cancellationToken);
        }
        
        /// <inheritdoc cref="IQuartzHostedService.CreateJobAsync"/>
        public async Task CreateJobAsync(NotificationInfo info, CancellationToken cancellationToken)
        {
            var (chatId, notificationMessage, dateTime) = info;
            
            var job = JobBuilder
                .Create<TextNotificationJob>()
                .WithIdentity(chatId.ToString())
                .UsingJobData(nameof(notificationMessage), notificationMessage)
                .Build();

            var trigger = TriggerBuilder
                .Create()
                .StartAt(new DateTimeOffset(dateTime))
                .WithSimpleSchedule(builder 
                    => builder
                        .WithIntervalInSeconds(5)
                        .RepeatForever())
                .Build();

            await _scheduler.ScheduleJob(job, trigger, cancellationToken);
        }
    }
}