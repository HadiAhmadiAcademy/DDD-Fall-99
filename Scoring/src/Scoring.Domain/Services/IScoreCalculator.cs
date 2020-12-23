using System.Threading.Tasks;
using Scoring.Domain.Model.Rules;

namespace Scoring.Domain.Services
{
    public interface IScoreCalculator
    {
        Task<int> CalculateScoreOfApplicant(ApplicantCondition applicant);
    }
}