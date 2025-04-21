using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Domain.Animals;

namespace Infrastructure.Services
{
    public class AnimalFactory : IAnimalFactory
    {
        private readonly ConcurrentDictionary<string, bool> _registry
            = new(StringComparer.OrdinalIgnoreCase)
            {
                ["Rabbit"] = true,
                ["Monkey"] = true,
                ["Tiger"] = false,
                ["Wolf"] = false
            };

        public Animal Create(
            string species,
            string name,
            int foodKgPerDay,
            bool isHealthy,
            int? kindness = null)
        {
            if (string.IsNullOrWhiteSpace(species))
                throw new ArgumentException("Species cannot be empty.", nameof(species));

            if (!_registry.TryGetValue(species, out var isHerbivore))
                throw new ArgumentException($"Species '{species}' is not registered.");

            // строим VO
            var id = AnimalId.CreateNew();
            var sp = new Species(species);
            var nm = new AnimalName(name);
            var food = new FoodConsumption(foodKgPerDay);

            if (isHerbivore)
            {
                if (!kindness.HasValue)
                    throw new ArgumentException("Kindness must be provided for herbivores.");
                return new GenericHerbivore(id, sp, nm, food, isHealthy, kindness.Value);
            }
            else
            {
                return new GenericPredator(id, sp, nm, food, isHealthy);
            }
        }

        public IEnumerable<string> GetRegisteredSpecies() => _registry.Keys;

        public void RegisterSpecies(string speciesName, bool isHerbivore)
        {
            if (string.IsNullOrWhiteSpace(speciesName))
                throw new ArgumentException("Species name cannot be empty.", nameof(speciesName));
            _registry[speciesName.Trim()] = isHerbivore;
        }
    }
}
