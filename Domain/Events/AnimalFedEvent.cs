using Domain.Common;
using Domain.Animals;
using System;

namespace Domain.Events
{
    public sealed class AnimalFedEvent : IDomainEvent
    {
        public AnimalId AnimalId { get; }
        public DateTime OccurredOn { get; }

        public AnimalFedEvent(AnimalId animalId, DateTime occurredOn)
        {
            AnimalId = animalId;
            OccurredOn = occurredOn;
        }
    }
}
