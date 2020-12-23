using System;
using LoanApplications.Domain.Model.InterestRatePolicies;
using LoanApplications.Domain.Services;

namespace LoanApplications.Infrastructure.ACL.Scoring
{
    public class ScoringService : IScoreService
    {
        public Point GetScoreForApplicant(long applicantId)
        {
            //Call api of scoring BC

            var value = 10;
            return new Point(value);
        }
    }
}
