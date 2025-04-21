using Application.DTOs;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IEnclosureManagementService
    {
        EnclosureDto Create(CreateEnclosureRequest request);
        void AddAnimalToEnclosure(Guid enclosureId, Guid animalId);
        EnclosureDto Get(Guid id);
        IEnumerable<EnclosureDto> GetAll();
        void Delete(Guid id);
        void Clean(Guid id);
    }
}
