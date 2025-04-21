using System.Linq;
using Domain.Repositories;
using Application.DTOs;

namespace Application.Services
{
    public class ZooStatisticsService : IZooStatisticsService
    {
        private readonly IAnimalRepository _animalRepo;
        private readonly IEnclosureRepository _encRepo;

        public ZooStatisticsService(
            IAnimalRepository animalRepo,
            IEnclosureRepository enclosureRepo)
        {
            _animalRepo = animalRepo;
            _encRepo = enclosureRepo;
        }

        public ZooStatisticsDto GetStatistics()
        {
            var animals = _animalRepo.ListAll().Count();
            var enclosures = _encRepo.ListAll();

            var totalSlots = enclosures.Sum(e => e.Capacity);
            var occupied = enclosures.Sum(e => e.AnimalIds.Count);

            return new ZooStatisticsDto
            {
                TotalAnimals = animals,
                TotalEnclosures = enclosures.Count(),
                FreeEnclosureSlots = totalSlots - occupied
            };
        }
    }
}
