using FluentAssertions;
using LoanApplications.Domain.Model.InterestRatePolicies;
using Xunit;

namespace LoanApplications.Domain.Tests.Unit
{
    public class PointCompareTests
    {
        [Fact]
        public void point_with_greater_value_is_bigger()
        {
            var point1 = new Point(20);
            var point2 = new Point(10);

            point1.CompareTo(point2).Should().Be(1);
        }

        [Fact]
        public void point_with_smaller_value_is_smaller()
        {
            var point1 = new Point(10);
            var point2 = new Point(20);

            point1.CompareTo(point2).Should().Be(-1);
        }

        [Fact]
        public void points_are_equal_when_values_are_equal()
        {
            var point1 = new Point(20);
            var point2 = new Point(20);

            point1.CompareTo(point2).Should().Be(0);
        }

        [Fact]
        public void point_is_equal_to_itself()
        {
            var point1 = new Point(20);

            point1.CompareTo(point1).Should().Be(0);
        }

        [Fact]
        public void point_is_bigger_than_null()
        {
            var point1 = new Point(20);

            point1.CompareTo(null).Should().Be(1);
        }
    }
}