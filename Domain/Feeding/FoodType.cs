using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Feeding
{
    public sealed class FoodType : ValueObject
    {
        public string Name { get; }

        public FoodType(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Food type cannot be empty.", nameof(name));
            Name = name.Trim();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }

        public override string ToString() => Name;
    }
}
