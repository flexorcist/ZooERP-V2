using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Feeding
{
    public sealed class FeedingTime : ValueObject
    {
        public DateTimeOffset When { get; }

        public FeedingTime(DateTimeOffset when)
        {
            if (when < DateTimeOffset.UtcNow)
                throw new ArgumentException("Feeding time must be in the future.", nameof(when));
            When = when;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return When;
        }

        public override string ToString() => When.ToString("u");
    }
}
