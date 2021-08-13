using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Quartz;
using Quartz.Spi;
using ThursdayMeetingBot.Web.Interfaces;
using ThursdayMeetingBot.Web.Models;
using ThursdayMeetingBot.Web.Quartz;

namespace ThursdayMeetingBot.Web.Services
{
    /// <inheritdoc cref="IQuartzHostedService"/>
    public class QuartzHostedService : IQuartzHostedService
    {
        private readonly IScheduler _scheduler;
        
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="schedulerFactory"> Scheduler factory. </param>
        public QuartzHostedService(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        /// <inheritdoc cref="IQuartzHostedService.CreateJobAsync"/>
        public async Task CreateJobAsync(NotificationInfo info, CancellationToken cancellationToken)
        {
            var sdf = await _scheduler.GetJobDetail(new JobKey(info.ChatId.ToString()), cancellationToken);
            var tr = await _scheduler.GetTrigger(new TriggerKey(info.ChatId.ToString()), cancellationToken);
            
            var (chatId, notificationMessage, dateTime) = info;
            
            var job = JobBuilder
                .Create<TextNotificationJob>()
                .WithIdentity(chatId.ToString())
                .UsingJobData("NotificationMessage", notificationMessage)
                .Build();

            var trigger = TriggerBuilder
                .Create()
                .WithIdentity(chatId.ToString())
                .StartNow()
                // .StartAt(new DateTimeOffset(dateTime))
                .WithSimpleSchedule(builder 
                    => builder
                        .WithIntervalInSeconds(5)
                        .RepeatForever())
                .Build();

            await _scheduler.ScheduleJob(job, trigger, cancellationToken);
        }
    }
}