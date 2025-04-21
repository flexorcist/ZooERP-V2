using System.Collections.Generic;
using Domain.Animals;

namespace Application.Services
{
    public class SpeciesService : ISpeciesService
    {
        private readonly IAnimalFactory _factory;

        public SpeciesService(IAnimalFactory factory)
        {
            _factory = factory;
        }

        public IEnumerable<string> GetAll()
            => _factory.GetRegisteredSpecies();

        public void Register(string speciesName, bool isHerbivore)
            => _factory.RegisterSpecies(speciesName, isHerbivore);
    }
}
