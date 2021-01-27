using System.Threading.Tasks;

namespace Scoring.Application.Contracts.Applicants
{
    public interface IApplicantService
    {
        Task DefineApplicant(DefineApplicantCommand command);
    }
}