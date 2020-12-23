using System;
using FluentAssertions;
using LoanApplications.Domain.Model.InterestRatePolicies;
using LoanApplications.Domain.Model.InterestRatePolicies.Exceptions;
using Xunit;

namespace LoanApplications.Domain.Tests.Unit
{
    public class RangeTests
    {
        [Fact]
        public void range_construction()
        {
            var range = new Range<int>(10, 15);

            range.Minimum.Should().Be(10);
            range.Maximum.Should().Be(15);
        }

        [Fact]
        public void minimum_value_is_smaller_or_equal_to_maximum_value()
        {
            Action constructor =() => new Range<int>(11 , 10);

            constructor.Should().Throw<InvalidRangeException>();
        }

    }
}