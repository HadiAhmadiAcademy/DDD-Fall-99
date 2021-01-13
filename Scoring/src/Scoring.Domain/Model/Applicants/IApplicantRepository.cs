using System.Threading.Tasks;

namespace Scoring.Domain.Model.Applicants
{
    public interface IApplicantRepository
    {
        Task Add(Applicant applicant);
    }
}