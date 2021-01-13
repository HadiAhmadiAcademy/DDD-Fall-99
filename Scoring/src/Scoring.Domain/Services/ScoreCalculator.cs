using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scoring.Domain.Model.Applicants;
using Scoring.Domain.Model.Rules;

namespace Scoring.Domain.Services
{
    public class ScoreCalculator : IScoreCalculator
    {
        private readonly IRuleRepository _repository;
        public ScoreCalculator(IRuleRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> CalculateScoreOfApplicant(Applicant applicant)
        {
            var activeRules = await _repository.GetActiveRules();
            return activeRules.Sum(a => a.Calculate(applicant));
        }
    }
}
