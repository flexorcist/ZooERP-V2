using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Enclosures;
using Domain.Repositories;

namespace Infrastructure.Persistence
{
    public class InMemoryEnclosureRepository : IEnclosureRepository
    {
        private readonly Dictionary<EnclosureId, Enclosure> _store = new();

        public void Add(Enclosure enclosure)
        {
            if (enclosure == null) throw new ArgumentNullException(nameof(enclosure));
            _store[enclosure.Id] = enclosure;
        }

        public Enclosure GetById(EnclosureId id)
        {
            if (!_store.TryGetValue(id, out var enc))
                throw new KeyNotFoundException($"Enclosure with id '{id.Value}' not found.");
            return enc;
        }

        public void Remove(EnclosureId id)
        {
            if (!_store.Remove(id))
                throw new KeyNotFoundException($"Enclosure with id '{id.Value}' not found.");
        }

        public IEnumerable<Enclosure> ListAll() => _store.Values.ToList();
    }
}
