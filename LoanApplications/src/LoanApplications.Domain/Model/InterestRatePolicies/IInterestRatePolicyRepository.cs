using System.Threading.Tasks;

namespace LoanApplications.Domain.Model.InterestRatePolicies
{
    public interface IInterestRatePolicyRepository
    {
        Task<InterestRatePolicy> GetCurrentPolicy();
    }
}