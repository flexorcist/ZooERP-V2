using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using AutoMapper;
using Domain.Animals;
using Domain.Enclosures;
using Domain.Repositories;

namespace Application.Services
{
    public class EnclosureManagementService : IEnclosureManagementService
    {
        private readonly IAnimalRepository _animalRepo;
        private readonly IEnclosureRepository _repo;
        private readonly IMapper _mapper;

        public EnclosureManagementService(
        IEnclosureRepository repo,
        IAnimalRepository animalRepo,
        IMapper mapper)
        {
            _repo = repo;
            _animalRepo = animalRepo;
            _mapper = mapper;
        }

        public EnclosureDto Create(CreateEnclosureRequest request)
        {
            var id = EnclosureId.CreateNew();
            var enc = new Enclosure(
                id,
                request.Type,
                new Size(request.Size),
                request.Capacity);

            _repo.Add(enc);
            return _mapper.Map<EnclosureDto>(enc);
        }

        public void AddAnimalToEnclosure(Guid enclosureId, Guid animalId)
        {
            var enc = _repo.GetById(EnclosureId.From(enclosureId));
            var animal = _animalRepo.GetById(AnimalId.From(animalId));

            // проверим что животное здорово
            if (!animal.IsHealthy)
                throw new InvalidOperationException("Cannot place an unhealthy animal.");

            // добавляем в вольер и "сообщаем" животному, что оно "переехало"
            enc.AddAnimal(animal.Id);
            animal.MoveTo(enc.Id);
        }

        public EnclosureDto Get(Guid id)
        {
            var enc = _repo.GetById(EnclosureId.From(id));
            return _mapper.Map<EnclosureDto>(enc);
        }

        public IEnumerable<EnclosureDto> GetAll()
            => _repo.ListAll().Select(e => _mapper.Map<EnclosureDto>(e));

        public void Delete(Guid id) =>
            _repo.Remove(EnclosureId.From(id));

        public void Clean(Guid id)
        {
            var enc = _repo.GetById(EnclosureId.From(id));
            enc.Clean();
        }
    }
}
