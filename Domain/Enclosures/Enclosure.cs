using Domain.Common;
using Domain.Animals;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Enclosures
{
    public class Enclosure : Entity<EnclosureId>, IAggregateRoot
    {
        private readonly List<AnimalId> _animalIds = new();

        public string Type { get; private set; }
        public Size Size { get; private set; }
        public int Capacity { get; private set; }

        public IReadOnlyCollection<AnimalId> AnimalIds => _animalIds.AsReadOnly();

        public Enclosure(EnclosureId id, string type, Size size, int capacity) : base(id)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Type cannot be empty.", nameof(type));
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be positive.", nameof(capacity));

            Type = type.Trim();
            Size = size ?? throw new ArgumentNullException(nameof(size));
            Capacity = capacity;
        }

        public void AddAnimal(AnimalId animalId)
        {
            if (_animalIds.Count >= Capacity)
                throw new InvalidOperationException("Enclosure is full.");
            if (_animalIds.Contains(animalId))
                throw new InvalidOperationException("Animal already in this enclosure.");

            _animalIds.Add(animalId);
        }

        public void RemoveAnimal(AnimalId animalId)
        {
            if (!_animalIds.Remove(animalId))
                throw new InvalidOperationException("Animal not found in this enclosure.");
        }

        public void Clean()
        {
            AddDomainEvent(new EnclosureCleanedEvent(Id));
        }
    }
}
