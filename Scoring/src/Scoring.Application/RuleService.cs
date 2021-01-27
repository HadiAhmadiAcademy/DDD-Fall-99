using System;
using System.Threading.Tasks;
using Scoring.Application.Contracts;
using Scoring.Application.Contracts.Rules;
using Scoring.Domain.Model.Rules;

namespace Scoring.Application
{
    public class RuleService : IRulesService
    {
        private readonly IRuleRepository _repository;
        public RuleService(IRuleRepository repository)
        {
            _repository = repository;
        }
        public async Task DefineRule(DefineRuleCommand command)
        {
            var id = Guid.NewGuid();
            var criteria = CriteriaMapper.Map(command.Criteria);
            var rule = new Rule(id, command.Title, criteria);
            await _repository.Add(rule);
        }

        public Task DeactivateRule(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public Task ActivateRule(Guid id)
        {
            throw new System.NotImplementedException();
        }
    }
}