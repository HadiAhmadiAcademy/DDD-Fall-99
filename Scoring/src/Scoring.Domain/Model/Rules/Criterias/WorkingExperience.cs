using System;
using Framework.Core.Specifications;
using Scoring.Domain.Model.Applicants;

namespace Scoring.Domain.Model.Rules.Criterias
{
    public class WorkingExperience : Specification<Applicant>
    {
        public TimeSpan Span { get; private set; }
        public WorkingExperience(TimeSpan span)
        {
            this.Span = span;
        }

        public override bool IsSatisfiedBy(Applicant value)
        {
            return value.HireDate.Add(Span) < DateTime.Now;
        }
    }
}