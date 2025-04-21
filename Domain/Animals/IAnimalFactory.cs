using System.Collections.Generic;

namespace Domain.Animals
{
    public interface IAnimalFactory
    {
        Animal Create(
            string species,
            string name,
            int foodKgPerDay,
            bool isHealthy,
            int? kindness = null);

        IEnumerable<string> GetRegisteredSpecies();
        void RegisterSpecies(string speciesName, bool isHerbivore);
    }
}
