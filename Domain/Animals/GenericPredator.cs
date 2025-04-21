namespace Domain.Animals
{
    public class GenericPredator : Predator
    {
        public GenericPredator(
            AnimalId id,
            Species species,
            AnimalName name,
            FoodConsumption food,
            bool isHealthy)
            : base(id, species, name, food, isHealthy)
        { }
    }
}
