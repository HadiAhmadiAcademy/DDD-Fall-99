using System;
using System.Threading.Tasks;

namespace Scoring.Application.Contracts.Rules
{
    public interface IRulesService
    {
        Task DefineRule(DefineRuleCommand command);       //Add dto to method
        Task DeactivateRule(Guid id);
        Task ActivateRule(Guid id);
    }
}
