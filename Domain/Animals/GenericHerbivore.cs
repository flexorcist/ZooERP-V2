namespace Domain.Animals
{
    public class GenericHerbivore : Herbivore
    {
        public GenericHerbivore(
            AnimalId id,
            Species species,
            AnimalName name,
            FoodConsumption food,
            bool isHealthy,
            int kindness)
            : base(id, species, name, food, isHealthy, kindness)
        { }
    }
}
