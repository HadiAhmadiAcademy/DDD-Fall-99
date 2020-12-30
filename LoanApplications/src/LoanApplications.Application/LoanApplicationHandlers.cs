using System.Threading.Tasks;
using LoanApplications.Application.Contracts;
using LoanApplications.Application.Framework;
using LoanApplications.Domain.Model.InterestRatePolicies;
using LoanApplications.Domain.Model.LoanApplications;
using LoanApplications.Domain.Services;

namespace LoanApplications.Application
{
    public class LoanApplicationHandlers : ICommandHandler<PlaceLoanApplication>
    {
        private readonly ILoanApplicationRepository _loanApplicationRepository;
        private readonly IInterestRateCalculator _interestRateCalculator;

        public LoanApplicationHandlers(ILoanApplicationRepository loanApplicationRepository,
                                       IInterestRateCalculator interestRateCalculator)
        {
            _loanApplicationRepository = loanApplicationRepository;
            _interestRateCalculator = interestRateCalculator;
        }

        public async Task Handle(PlaceLoanApplication command)
        {
            var id = await _loanApplicationRepository.GetNextId();
            var loanApplication = new LoanApplication(id, command.ApplicantId, command.Amount);
            var interestRate = await _interestRateCalculator.GetInterestRateFor(command.ApplicantId);
            loanApplication.SetInterestRate(interestRate);
            await _loanApplicationRepository.Add(loanApplication);
        }
    }
}