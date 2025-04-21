using Domain.Common;
using Domain.Animals;
using Domain.Enclosures;
using System;

namespace Domain.Events
{
    public sealed class AnimalMovedEvent : IDomainEvent
    {
        public AnimalId AnimalId { get; }
        public EnclosureId TargetEnclosureId { get; }
        public DateTime OccurredOn { get; }

        public AnimalMovedEvent(AnimalId animalId, EnclosureId targetEnclosureId, DateTime occurredOn)
        {
            AnimalId = animalId;
            TargetEnclosureId = targetEnclosureId;
            OccurredOn = occurredOn;
        }
    }
}
