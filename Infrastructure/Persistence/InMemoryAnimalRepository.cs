using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Animals;
using Domain.Repositories;

namespace Infrastructure.Persistence
{
    public class InMemoryAnimalRepository : IAnimalRepository
    {
        private readonly Dictionary<AnimalId, Animal> _store = new();

        public void Add(Animal animal)
        {
            if (animal == null) throw new ArgumentNullException(nameof(animal));
            _store[animal.Id] = animal;
        }

        public Animal GetById(AnimalId id)
        {
            if (!_store.TryGetValue(id, out var animal))
                throw new KeyNotFoundException($"Animal with id '{id.Value}' not found.");
            return animal;
        }

        public void Remove(AnimalId id)
        {
            if (!_store.Remove(id))
                throw new KeyNotFoundException($"Animal with id '{id.Value}' not found.");
        }

        public IEnumerable<Animal> ListAll() => _store.Values.ToList();
    }
}
