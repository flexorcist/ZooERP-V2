using System;
using Domain.Common;
using Domain.Events;

namespace Domain.Animals
{
    public class Herbivore : Animal
    {
        public int Kindness { get; private set; }
        public bool CanContact => Kindness > 5;

        public Herbivore(
            AnimalId id,
            Species species,
            AnimalName name,
            FoodConsumption food,
            bool isHealthy,
            int kindness)
            : base(id, species, name, food, isHealthy)
        {
            if (kindness < 0 || kindness > 10)
                throw new ArgumentException("Kindness must be between 0 and 10", nameof(kindness));
            Kindness = kindness;
        }
    }
}
