using System;
using Framework.Core.Specifications;

namespace Scoring.Domain.Model.Rules.Criterias
{
    public class WorkingExperience : Specification<ApplicantCondition>
    {
        public TimeSpan Span { get; private set; }
        public WorkingExperience(TimeSpan span)
        {
            this.Span = span;
        }

        public override bool IsSatisfiedBy(ApplicantCondition value)
        {
            return value.HireDate.Add(Span) < DateTime.Now;
        }
    }
}