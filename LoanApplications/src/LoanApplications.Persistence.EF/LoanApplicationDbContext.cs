using LoanApplications.Domain.Model.InterestRatePolicies;
using LoanApplications.Domain.Model.LoanApplications;
using Microsoft.EntityFrameworkCore;

namespace LoanApplications.Persistence.EF
{
    public class LoanApplicationDbContext : DbContext
    {
        public DbSet<LoanApplication> LoanApplications {get; set; }
        public DbSet<InterestRatePolicy> InterestRatePolicies {get; set; }
    }
}