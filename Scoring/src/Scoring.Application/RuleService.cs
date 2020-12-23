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
        public async Task<int> DefineRule(DefineRuleCommand command)
        {
            var id = 1;     //TODO: remove hard-coded id
            var criteria = CriteriaMapper.Map(command.Criteria);
            var rule = new Rule(1, command.Title, criteria);
            await _repository.Add(rule);
            return id;
        }

        public Task DeactivateRule(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task ActivateRule(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}