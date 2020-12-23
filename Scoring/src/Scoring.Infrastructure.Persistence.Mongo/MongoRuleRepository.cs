using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Framework.Persistence.Mongo;
using MongoDB.Driver;
using Scoring.Domain.Model.Rules;

namespace Scoring.Infrastructure.Persistence.Mongo
{
    public class MongoRuleRepository : MongoRepository<Rule, int>, IRuleRepository
    {
        public MongoRuleRepository(IMongoDatabase database) : base(database) { }

        public Task Add(Rule rule)
        {
            return AggregateCollection.InsertOneAsync(rule);
        }

        public Task<Rule> Get(int id)
        {
            return AggregateCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Rule>> GetActiveRules()
        {
            return AggregateCollection.Find(a => a.IsActive == true).ToListAsync();
        }
    }
}
