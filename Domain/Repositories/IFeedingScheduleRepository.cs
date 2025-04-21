using Domain.Feeding;
using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IFeedingScheduleRepository
    {
        FeedingSchedule GetById(FeedingScheduleId id);
        void Add(FeedingSchedule schedule);
        void Remove(FeedingScheduleId id);
        IEnumerable<FeedingSchedule> ListAll();
    }
}
