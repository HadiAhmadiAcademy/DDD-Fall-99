using System.Threading.Tasks;
using LoanApplications.Domain.Model.InterestRatePolicies;

namespace LoanApplications.Domain.Services
{
    public class InterestRateCalculator : IInterestRateCalculator
    {
        private readonly IInterestRatePolicyRepository _interestRatePolicyRepository;
        private readonly IScoreService _scoreService;
        public InterestRateCalculator(IInterestRatePolicyRepository interestRatePolicyRepository,
                                        IScoreService scoreService)
        {
            _interestRatePolicyRepository = interestRatePolicyRepository;
            _scoreService = scoreService;
        }
        public async Task<Percent> GetInterestRateFor(long applicantId)
        {
            var score = await _scoreService.GetScoreForApplicant(applicantId);
            var policy = await _interestRatePolicyRepository.GetCurrentPolicy();
            return policy.CalculateInterestRate(score);
        }
    }
}