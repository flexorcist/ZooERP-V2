using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Common
{
    public abstract class Entity<TId>
    {
        public TId Id { get; protected set; }

        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        // Возвращаем ReadOnlyCollection
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected Entity(TId id)
        {
            Id = id;
        }

        protected void AddDomainEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }

        public void ClearDomainEvents() => _domainEvents.Clear();
    }
}
