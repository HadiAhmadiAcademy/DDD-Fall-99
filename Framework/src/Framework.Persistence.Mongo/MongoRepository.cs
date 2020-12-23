using System;
using Framework.Domain;
using Humanizer;
using MongoDB.Driver;

namespace Framework.Persistence.Mongo
{
    public abstract class MongoRepository<T, TKey> where T : AggregateRoot<TKey>
    {
        public IMongoCollection<T> AggregateCollection { get; private set; }
        protected MongoRepository(IMongoDatabase database)
        {
            AggregateCollection = database.GetCollection<T>(typeof(T).Name.Pluralize());
        }
    }
}
