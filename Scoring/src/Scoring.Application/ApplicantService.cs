using System.Threading.Tasks;
using Scoring.Application.Contracts.Applicants;
using Scoring.Domain.Model.Applicants;

namespace Scoring.Application
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        public ApplicantService(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public async Task DefineApplicant(DefineApplicantCommand command)
        {
            var id = new ApplicantId(command.Id);
            var existingApplicant = await _applicantRepository.Get(id);
            if (existingApplicant != null) return;

            var name = new Name(command.Firstname, command.Lastname);
            var applicant = new Applicant(id, name, command.HireDate);
            await _applicantRepository.Add(applicant);
        }
    }
}