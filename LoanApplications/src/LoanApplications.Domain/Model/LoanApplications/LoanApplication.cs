using System;
using LoanApplications.Domain.Model.InterestRatePolicies;

namespace LoanApplications.Domain.Model.LoanApplications
{
    public class LoanApplication
    {
        public long Id { get; private set; }
        public long ApplicantId { get; private set; }
        public long Amount { get; private set; }
        //Payback....
        public Percent InterestRate { get; private set; }
        public LoanApplication(long id, long applicantId, long amount)
        {
            Id = id;
            ApplicantId = applicantId;
            Amount = amount;
        }
        public void SetInterestRate(Percent interestRate)
        {
            this.InterestRate = interestRate;
        }
    }
}