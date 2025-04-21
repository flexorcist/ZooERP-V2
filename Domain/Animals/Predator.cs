using Domain.Common;

namespace Domain.Animals
{
    public class Predator : Animal
    {
        public Predator(
            AnimalId id,
            Species species,
            AnimalName name,
            FoodConsumption food,
            bool isHealthy)
            : base(id, species, name, food, isHealthy)
        { }
    }
}
