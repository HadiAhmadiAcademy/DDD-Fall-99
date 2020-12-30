using System.Linq;
using System.Threading.Tasks;
using LoanApplications.Domain.Model.InterestRatePolicies;
using Microsoft.EntityFrameworkCore;

namespace LoanApplications.Persistence.EF.Repositories
{
    public class InterestRatePolicyRepository : IInterestRatePolicyRepository
    {
        private readonly LoanApplicationDbContext _dbContext;
        public InterestRatePolicyRepository(LoanApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<InterestRatePolicy> GetCurrentPolicy()
        {
            return _dbContext.InterestRatePolicies.FirstAsync();
        }
    }
}