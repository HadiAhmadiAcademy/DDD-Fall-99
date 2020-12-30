using System.Threading.Tasks;
using LoanApplications.Domain.Model.InterestRatePolicies;

namespace LoanApplications.Domain.Services
{
    public interface IScoreService
    {
        Task<Point> GetScoreForApplicant(long applicantId);
    }
}