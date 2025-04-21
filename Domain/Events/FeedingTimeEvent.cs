using System;
using Domain.Common;
using Domain.Feeding;

namespace Domain.Events
{
    public sealed class FeedingTimeEvent : IDomainEvent
    {
        public FeedingScheduleId ScheduleId { get; }
        public DateTimeOffset ScheduledFor { get; }
        public DateTime OccurredOn { get; }

        public FeedingTimeEvent(FeedingScheduleId scheduleId, DateTimeOffset scheduledFor)
        {
            ScheduleId = scheduleId;
            ScheduledFor = scheduledFor;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
