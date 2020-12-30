using System;
using System.Threading.Tasks;
using LoanApplications.Domain.Model.LoanApplications;
using Microsoft.EntityFrameworkCore;

namespace LoanApplications.Persistence.EF.Repositories
{
    public class LoanApplicationRepository : ILoanApplicationRepository
    {
        private readonly LoanApplicationDbContext _dbContext;
        public LoanApplicationRepository(LoanApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<long> GetNextId()
        {
            //_dbContext.Database.ExecuteSqlRaw("SELECT NEXT VALUE FOR LoanApplication_SEQ");
            throw new NotImplementedException();
        }

        public async Task Add(LoanApplication application)
        {
            await _dbContext.AddAsync(application);
            await _dbContext.SaveChangesAsync();        //TODO: replace with unit of work
        }
    }
}
