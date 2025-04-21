using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Enclosures
{
    public sealed class Size : ValueObject
    {
        public decimal SquareMeters { get; }

        public Size(decimal squareMeters)
        {
            if (squareMeters <= 0)
                throw new ArgumentException("Size must be positive.", nameof(squareMeters));
            SquareMeters = squareMeters;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return SquareMeters;
        }

        public override string ToString() => $"{SquareMeters} m²";
    }
}
