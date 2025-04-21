using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Feeding
{
    public sealed class FeedingScheduleId : ValueObject
    {
        public Guid Value { get; }

        private FeedingScheduleId(Guid value) => Value = value;

        public static FeedingScheduleId CreateNew() => new FeedingScheduleId(Guid.NewGuid());

        public static FeedingScheduleId From(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("FeedingScheduleId cannot be empty.", nameof(value));
            return new FeedingScheduleId(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
