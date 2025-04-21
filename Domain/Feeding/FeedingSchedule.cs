using Domain.Common;
using Domain.Animals;
using Domain.Events;
using System;

namespace Domain.Feeding
{
    public class FeedingSchedule : Entity<FeedingScheduleId>, IAggregateRoot
    {
        public AnimalId AnimalId { get; private set; }
        public FeedingTime Time { get; private set; }
        public FoodType Food { get; private set; }
        public bool IsCompleted { get; private set; }

        public FeedingSchedule(
            FeedingScheduleId id,
            AnimalId animalId,
            FeedingTime time,
            FoodType food) : base(id)
        {
            AnimalId = animalId ?? throw new ArgumentNullException(nameof(animalId));
            Time = time ?? throw new ArgumentNullException(nameof(time));
            Food = food ?? throw new ArgumentNullException(nameof(food));
            IsCompleted = false;
        }

        public void Reschedule(FeedingTime newTime)
        {
            if (IsCompleted)
                throw new InvalidOperationException("Cannot reschedule a completed feeding.");
            Time = newTime;
            AddDomainEvent(new FeedingTimeEvent(Id, Time.When));
        }

        public void MarkAsDone()
        {
            if (IsCompleted)
                throw new InvalidOperationException("Already marked as done.");
            IsCompleted = true;
            AddDomainEvent(new FeedingTimeEvent(Id, Time.When));
        }
    }
}
