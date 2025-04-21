using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Feeding;
using Domain.Repositories;

namespace Infrastructure.Persistence
{
    public class InMemoryFeedingScheduleRepository : IFeedingScheduleRepository
    {
        private readonly Dictionary<FeedingScheduleId, FeedingSchedule> _store = new();

        public void Add(FeedingSchedule schedule)
        {
            if (schedule == null) throw new ArgumentNullException(nameof(schedule));
            _store[schedule.Id] = schedule;
        }

        public FeedingSchedule GetById(FeedingScheduleId id)
        {
            if (!_store.TryGetValue(id, out var sched))
                throw new KeyNotFoundException($"Feeding schedule with id '{id.Value}' not found.");
            return sched;
        }

        public void Remove(FeedingScheduleId id)
        {
            if (!_store.Remove(id))
                throw new KeyNotFoundException($"Feeding schedule with id '{id.Value}' not found.");
        }

        public IEnumerable<FeedingSchedule> ListAll() => _store.Values.ToList();
    }
}
