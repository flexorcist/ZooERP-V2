using Domain.Animals;
using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IAnimalRepository
    {
        Animal GetById(AnimalId id);
        void Add(Animal animal);
        void Remove(AnimalId id);
        IEnumerable<Animal> ListAll();
    }
}
