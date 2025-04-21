using System;
using Domain.Repositories;
using Domain.Animals;
using Domain.Enclosures;
using Application.DTOs;

namespace Application.Services
{
    public class AnimalTransferService : IAnimalTransferService
    {
        private readonly IAnimalRepository _animalRepo;
        private readonly IEnclosureRepository _encRepo;

        public AnimalTransferService(
            IAnimalRepository animalRepo,
            IEnclosureRepository enclosureRepo)
        {
            _animalRepo = animalRepo;
            _encRepo = enclosureRepo;
        }

        public void Transfer(TransferAnimalRequest request)
        {
            var animalId = AnimalId.From(request.AnimalId);
            var fromEnclosureId = EnclosureId.From(request.FromEnclosureId);
            var toEnclosureId = EnclosureId.From(request.ToEnclosureId);

            var animal = _animalRepo.GetById(animalId);
            var from = _encRepo.GetById(fromEnclosureId);
            var to = _encRepo.GetById(toEnclosureId);

            // вместимость, здоровье и т.п. проверяются внутри сущностей
            from.RemoveAnimal(animalId);
            to.AddAnimal(animalId);
            animal.MoveTo(toEnclosureId);

            // Поскольку репозитории in-memory, изменения сохранены автоматически
        }
    }
}
