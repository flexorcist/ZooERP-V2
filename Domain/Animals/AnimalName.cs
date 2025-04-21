using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Animals
{
    public sealed class AnimalName : ValueObject
    {
        public string Value { get; }

        public AnimalName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Animal name cannot be empty.", nameof(value));
            if (value.Length > 50)
                throw new ArgumentException("Animal name is too long.", nameof(value));
            Value = value.Trim();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value;
    }
}
