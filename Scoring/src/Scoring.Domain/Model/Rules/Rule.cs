using System;
using Framework.Core.Specifications;
using Framework.Domain;
using Scoring.Domain.Model.Applicants;

namespace Scoring.Domain.Model.Rules
{
    public class Rule : AggregateRoot<Guid>
    {
        public string Title { get; private set; }
        public Specification<Applicant> Criteria { get; private set; }
        public CalculationStrategy Calculation { get; private set; }
        public bool IsActive { get; private set; }
        public Rule(Guid id, string title, Specification<Applicant> criteria)
        {
            Id = id;
            Title = title;
            Criteria = criteria;
            this.Calculation = CalculationStrategy.None;
        }
        public void SetCalculation(CalculationStrategy calculationStrategy)
        {
            this.Calculation = calculationStrategy;
        }
        public int Calculate(Applicant applicant)
        {
            if (Criteria.IsSatisfiedBy(applicant))
                return this.Calculation.Value;
            return 0;
        }
        public void Activate()
        {
            this.IsActive = true;
        }
        public void Deactivate()
        {
            this.IsActive = false;
        }
    }
}