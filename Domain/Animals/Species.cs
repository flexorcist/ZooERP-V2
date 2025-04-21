using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Animals
{
    public sealed class Species : ValueObject
    {
        public string Name { get; }

        public Species(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Species name cannot be empty.", nameof(name));
            Name = name.Trim();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }

        public override string ToString() => Name;
    }
}
