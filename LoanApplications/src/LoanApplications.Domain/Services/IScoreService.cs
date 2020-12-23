using LoanApplications.Domain.Model.InterestRatePolicies;

namespace LoanApplications.Domain.Services
{
    public interface IScoreService
    {
        Point GetScoreForApplicant(long applicantId);
    }
}