using System;
using System.Threading.Tasks;
using Framework.Persistence.Mongo;
using MongoDB.Driver;
using Scoring.Domain.Model.Applicants;

namespace Scoring.Infrastructure.Persistence.Mongo.Repositories
{
    public class MongoApplicantRepository : MongoRepository<Applicant, ApplicantId>, IApplicantRepository
    {
        public MongoApplicantRepository(IMongoDatabase database) : base(database) { }
        public Task<Applicant> Get(ApplicantId id)
        {
            return AggregateCollection.Find(a => a.Id.Value == id.Value).FirstOrDefaultAsync();
        }

        public Task Add(Applicant applicant)
        {
            return AggregateCollection.InsertOneAsync(applicant);

        }
    }
}