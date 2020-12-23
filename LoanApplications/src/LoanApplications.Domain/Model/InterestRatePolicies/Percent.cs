using System;

namespace LoanApplications.Domain.Model.InterestRatePolicies
{
    public class Percent : IComparable<Percent>
    {
        public float Value { get; private set; }
        public Percent(float value)
        {
            if (value < 0) throw new ArgumentException("Percent must be bigger '0'");
            Value = value;
        }
        public int CompareTo(Percent other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Value.CompareTo(other.Value);
        }
    }
}