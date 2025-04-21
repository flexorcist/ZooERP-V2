using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using AutoMapper;
using Domain.Animals;
using Domain.Repositories;

namespace Application.Services
{
    public class AnimalManagementService : IAnimalManagementService
    {
        private readonly IAnimalFactory _factory;
        private readonly IAnimalRepository _repo;
        private readonly IMapper _mapper;

        public AnimalManagementService(
            IAnimalFactory factory,
            IAnimalRepository repo,
            IMapper mapper)
        {
            _factory = factory;
            _repo = repo;
            _mapper = mapper;
        }

        public AnimalDto Create(CreateAnimalRequest request)
        {
            var animal = _factory.Create(
                request.Species,
                request.Name,
                request.FoodConsumption,
                request.IsHealthy,
                request.Kindness);

            _repo.Add(animal);
            return _mapper.Map<AnimalDto>(animal);
        }

        public AnimalDto Get(Guid id)
        {
            var animal = _repo.GetById(AnimalId.From(id));
            return _mapper.Map<AnimalDto>(animal);
        }

        public IEnumerable<AnimalDto> GetAll()
            => _repo.ListAll().Select(a => _mapper.Map<AnimalDto>(a));

        public void Delete(Guid id)
        {
            _repo.Remove(AnimalId.From(id));
        }
    }
}
