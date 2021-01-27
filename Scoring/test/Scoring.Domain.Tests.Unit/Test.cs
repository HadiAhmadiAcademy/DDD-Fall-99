using System;
using System.Collections.Generic;
using System.Text;
using Scoring.Domain.Model.Rules;
using Scoring.Domain.Model.Rules.Criterias;
using Xunit;

namespace Scoring.Domain.Tests.Unit
{
    public class Test
    {
        [Fact]
        public void Test1()
        {
            var spec = new WorkingExperience(TimeSpan.FromDays(365));
            var rule = new Rule(Guid.NewGuid(), "x", spec);

            rule.SetCalculation(CalculationStrategy.DecreasePointsTo(10));
        }
    }
}
