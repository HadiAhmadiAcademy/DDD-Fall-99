using System;
using System.Threading.Tasks;
using LoanApplications.Domain.Model.InterestRatePolicies;
using LoanApplications.Domain.Services;

namespace LoanApplications.Infrastructure.ACL.Scoring
{
    public class ScoringService : IScoreService
    {
        public Task<Point> GetScoreForApplicant(long applicantId)
        {
            var value = 10;
            return Task.FromResult(new Point(value));
        }
    }

}
