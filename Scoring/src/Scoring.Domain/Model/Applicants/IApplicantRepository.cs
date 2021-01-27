using System.Threading.Tasks;

namespace Scoring.Domain.Model.Applicants
{
    public interface IApplicantRepository
    {
        Task<Applicant> Get(ApplicantId id);
        Task Add(Applicant applicant);
    }
}