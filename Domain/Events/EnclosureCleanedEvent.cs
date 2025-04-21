using System;
using Domain.Common;
using Domain.Enclosures;

namespace Domain.Events
{
    public sealed class EnclosureCleanedEvent : IDomainEvent
    {
        public EnclosureId EnclosureId { get; }
        public DateTime OccurredOn { get; }

        public EnclosureCleanedEvent(EnclosureId enclosureId)
        {
            EnclosureId = enclosureId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
