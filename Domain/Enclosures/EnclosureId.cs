using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Enclosures
{
    public sealed class EnclosureId : ValueObject
    {
        public Guid Value { get; }

        private EnclosureId(Guid value) => Value = value;

        public static EnclosureId CreateNew() => new EnclosureId(Guid.NewGuid());

        public static EnclosureId From(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("EnclosureId cannot be empty.", nameof(value));
            return new EnclosureId(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
