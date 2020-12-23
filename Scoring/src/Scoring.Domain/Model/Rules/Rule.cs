using Framework.Core.Specifications;
using Framework.Domain;

namespace Scoring.Domain.Model.Rules
{
    public class Rule : AggregateRoot<int>
    {
        public string Title { get; private set; }
        public Specification<ApplicantCondition> Criteria { get; private set; }
        public CalculationStrategy Calculation { get; private set; }
        public bool IsActive { get; private set; }
        public Rule(int id, string title, Specification<ApplicantCondition> criteria)
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
        public int Calculate(ApplicantCondition applicant)
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