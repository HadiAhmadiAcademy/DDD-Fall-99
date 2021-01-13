using System;
using System.Linq;
using System.Reflection;
using Framework.Core.Specifications;
using Framework.Persistence.Mongo;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Core.Misc;
using Scoring.Domain.Model.Applicants;
using Scoring.Domain.Model.Rules;
using Scoring.Domain.Model.Rules.Criterias;
using Xunit;

namespace Scoring.Infrastructure.Persistence.Mongo.Tests.Integration
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            MappingRegistration.RegisterAll(typeof(UnitTest1).Assembly);

             var client = new MongoClient("mongodb://root:changeit@192.168.39.31");
            var database = client.GetDatabase("Scoring");
            var repository = new MongoRuleRepository(database);

            //var spec = new WorkingExperience(TimeSpan.FromDays(365)).And(new WorkingExperience(TimeSpan.FromDays(10)));
            //var rule = new Rule(1, "Test rule", spec);
            //rule.SetCalculation(CalculationStrategy.IncreasePointsTo(1000));
            //repository.Add(rule).Wait();

            //var rule = repository.Get(1).Result;
        }
    }

    public class RuleMapping : IBsonMapping
    {
        public void Register()
        {
            BsonClassMap.RegisterClassMap<Specification<Applicant>>(map =>
            {
                map.AutoMap();
                map.SetIsRootClass(true);

                map.AddKnownType(typeof(WorkingExperience));
                map.AddKnownType(typeof(AndSpecification<Applicant>));
                map.AddKnownType(typeof(OrSpecification<Applicant>));
            });
        }
    }
}
