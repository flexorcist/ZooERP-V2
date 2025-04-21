using Domain.Enclosures;
using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IEnclosureRepository
    {
        Enclosure GetById(EnclosureId id);
        void Add(Enclosure enclosure);
        void Remove(EnclosureId id);
        IEnumerable<Enclosure> ListAll();
    }
}
