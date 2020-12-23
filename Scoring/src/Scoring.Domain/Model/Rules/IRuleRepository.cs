using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scoring.Domain.Model.Rules
{
    public interface IRuleRepository
    {
        Task Add(Rule rule);
        Task<Rule> Get(int id);
        Task<List<Rule>> GetActiveRules();
    }
}