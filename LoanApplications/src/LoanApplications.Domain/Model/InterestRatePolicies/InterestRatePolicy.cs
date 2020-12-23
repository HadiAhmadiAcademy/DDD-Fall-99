using System;
using System.Collections.Generic;
using System.Linq;
using LoanApplications.Domain.Model.InterestRatePolicies.Exceptions;

namespace LoanApplications.Domain.Model.InterestRatePolicies
{
    public class InterestRatePolicy
    {
        private List<Rule> _rules;
        public int Id { get; private set; }
        public Percent DefaultPercent { get; private set; }
        public IReadOnlyList<Rule> Rules => _rules.AsReadOnly();
        public InterestRatePolicy(int id, Percent defaultPercent)
        {
            this.Id = id;
            this.DefaultPercent = defaultPercent;
            this._rules = new List<Rule>();
        }
        public void AddRule(Rule rule)
        {
            if (_rules.Any(a=> a.HasConflictWith(rule)))
                throw new ConflictRuleException();
            this._rules.Add(rule);
        }
        public void AddRules(List<Rule> rules)
        {
            rules.ForEach(AddRule);
        }
        public Percent CalculateInterestRate(Point score)
        {
            var rule = this._rules.FirstOrDefault(a => a.AppliesTo(score));
            if (rule != null) 
                return rule.Percent;
            return DefaultPercent;
        }
    }
}