using System.Threading.Tasks;

namespace Scoring.Application.Contracts.Rules
{
    public interface IRulesService
    {
        Task<int> DefineRule(DefineRuleCommand command);       //Add dto to method
        Task DeactivateRule(int id);
        Task ActivateRule(int id);
    }
}
