using Domain.Common;
using Domain.Enclosures;
using Domain.Events;
using System;

namespace Domain.Animals
{
    public abstract class Animal : Entity<AnimalId>, IAggregateRoot
    {
        public Species Species { get; private set; }
        public AnimalName Name { get; private set; }
        public FoodConsumption Food { get; private set; }
        public bool IsHealthy { get; private set; }

        protected Animal(AnimalId id, Species species, AnimalName name, FoodConsumption food, bool isHealthy)
            : base(id)
        {
            Species = species;
            Name = name;
            Food = food;
            IsHealthy = isHealthy;
        }

        public void Feed()
        {
            if (!IsHealthy)
                throw new InvalidOperationException("Cannot feed an unhealthy animal.");
            AddDomainEvent(new AnimalFedEvent(Id, DateTime.UtcNow));
        }

        public void Treat()
        {
            if (IsHealthy) return;
            IsHealthy = true;
            AddDomainEvent(new AnimalTreatedEvent(Id, DateTime.UtcNow));
        }

        public void MoveTo(EnclosureId targetEnclosureId)
        {
            if (!IsHealthy)
                throw new InvalidOperationException("Cannot move an unhealthy animal.");

            // проверка вместимости и совместимости на уровне Application
            AddDomainEvent(new AnimalMovedEvent(Id, targetEnclosureId, DateTime.UtcNow));
        }
    }
}
