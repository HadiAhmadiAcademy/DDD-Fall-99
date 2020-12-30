using System.Threading.Tasks;
using LoanApplications.Domain.Model.InterestRatePolicies;
using LoanApplications.Domain.Model.LoanApplications;

namespace LoanApplications.Domain.Services
{
    public interface IInterestRateCalculator
    {
        Task<Percent> GetInterestRateFor(long applicantId);
    }
}