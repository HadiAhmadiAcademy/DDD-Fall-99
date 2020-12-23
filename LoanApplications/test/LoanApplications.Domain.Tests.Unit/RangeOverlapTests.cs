using FluentAssertions;
using LoanApplications.Domain.Model.InterestRatePolicies;
using Xunit;

namespace LoanApplications.Domain.Tests.Unit
{
    public class RangeOverlapTests
    {

        [Theory]
        [InlineData(10, 15)]
        [InlineData(10, 25)]
        //[InlineData(11, 15)]
        //[InlineData(11, 25)]
        public void minimum_should_not_exists_in_range(int minimum, int maximum)
        {
            var sourceRange = new Range<int>(minimum, maximum);
            var targetRange = new Range<int>(10, 20);

            var overlap = targetRange.IsOverlapWith(sourceRange);

            overlap.Should().BeTrue();
        }

        [Theory]
        [InlineData(5, 20)]
        [InlineData(5, 15)]
        [InlineData(15, 18)]
        [InlineData(15, 20)]
        public void maximum_should_not_exists_in_range(int minimum, int maximum)
        {
            var sourceRange = new Range<int>(minimum, maximum);
            var targetRange = new Range<int>(10, 20);

            var overlap = targetRange.IsOverlapWith(sourceRange);

            overlap.Should().BeTrue();
        }

        [Fact]
        public void overlaps_when_range_contains_another_range()
        {
            var sourceRange = new Range<int>(5, 30);
            var targetRange = new Range<int>(10, 20);

            var overlap = targetRange.IsOverlapWith(sourceRange);

            overlap.Should().BeTrue();
        }

        [Fact]
        public void when_range_are_not_overlaps_eachother()
        {
            var sourceRange = new Range<int>(10, 20);
            var targetRange = new Range<int>(21, 30);

            var overlap = targetRange.IsOverlapWith(sourceRange);

            overlap.Should().BeFalse();
        }
    }
}