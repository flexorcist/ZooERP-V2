using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Animals
{
    public sealed class FoodConsumption : ValueObject
    {
        public int KilogramsPerDay { get; }

        public FoodConsumption(int kilogramsPerDay)
        {
            if (kilogramsPerDay < 0)
                throw new ArgumentException("Food consumption must be non-negative.", nameof(kilogramsPerDay));
            KilogramsPerDay = kilogramsPerDay;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return KilogramsPerDay;
        }

        public override string ToString() => $"{KilogramsPerDay} kg/day";
    }
}
