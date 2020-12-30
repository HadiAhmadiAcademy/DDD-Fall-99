using System.Threading.Tasks;

namespace LoanApplications.Domain.Model.LoanApplications
{
    public interface ILoanApplicationRepository
    {
        Task<long> GetNextId();
        Task Add(LoanApplication application);
    }
}