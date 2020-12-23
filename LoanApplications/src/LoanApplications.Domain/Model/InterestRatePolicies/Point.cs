using System;

namespace LoanApplications.Domain.Model.InterestRatePolicies
{
    public class Point : IComparable<Point>
    {
        public int Value { get; private set; }
        public Point(int value)
        {
            if (value < 0 || value > 100) throw new ArgumentException("Point must be between '0' and '100'");
            Value = value;
        }

        public int CompareTo(Point other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Value.CompareTo(other.Value);
        }
    }
}