using Domain.Common;
using Domain.Animals;
using System;

namespace Domain.Events
{
    public sealed class AnimalTreatedEvent : IDomainEvent
    {
        public AnimalId AnimalId { get; }
        public DateTime OccurredOn { get; }

        public AnimalTreatedEvent(AnimalId animalId, DateTime occurredOn)
        {
            AnimalId = animalId;
            OccurredOn = occurredOn;
        }
    }
}
