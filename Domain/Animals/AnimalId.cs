using Domain.Common;
using System;

namespace Domain.Animals
{
    public sealed class AnimalId : ValueObject
    {
        public Guid Value { get; }

        private AnimalId(Guid value) => Value = value;

        public static AnimalId CreateNew() => new AnimalId(Guid.NewGuid());

        public static AnimalId From(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("AnimalId cannot be empty.", nameof(value));
            return new AnimalId(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
