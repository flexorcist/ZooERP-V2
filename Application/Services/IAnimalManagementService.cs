using Application.DTOs;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IAnimalManagementService
    {
        AnimalDto Create(CreateAnimalRequest request);
        AnimalDto Get(Guid id);
        IEnumerable<AnimalDto> GetAll();
        void Delete(Guid id);
    }
}
