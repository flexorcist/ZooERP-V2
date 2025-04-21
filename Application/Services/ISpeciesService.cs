using System.Collections.Generic;

namespace Application.Services
{
    public interface ISpeciesService
    {
        IEnumerable<string> GetAll();
        void Register(string speciesName, bool isHerbivore);
    }
}
