using System;
using LoanApplications.Domain.Model.InterestRatePolicies.Exceptions;

namespace LoanApplications.Domain.Model.InterestRatePolicies
{
    public class Range<T> where T : IComparable<T>
    {
        public T Minimum { get; private set; }
        public T Maximum { get; private set; }
        public Range(T minimum, T maximum)
        {
            if (minimum.CompareTo(maximum) > 0) throw new InvalidRangeException();

            Minimum = minimum;
            Maximum = maximum;
        }
        public bool IsOverlapWith(Range<T> range)
        {
            return this.Minimum.CompareTo(range.Maximum) < 0 && range.Minimum.CompareTo(this.Maximum) < 0;
        }
        public bool Contains(T value)
        {
            return (Minimum.CompareTo(value) <= 0) && (value.CompareTo(Maximum) <= 0);
        }
    }
}