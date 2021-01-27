using System;
using Autofac;
using MongoDB.Driver;
using Scoring.Application;
using Scoring.Application.Contracts.Rules;
using Scoring.Config.Configuration;
using Scoring.Domain.Model.Rules;
using Scoring.Infrastructure.Persistence.Mongo;

namespace Scoring.Config
{
    public class ScoringModule : Module
    {
        private readonly ScoringConfiguration _configuration;
        public ScoringModule(ScoringConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MongoRuleRepository>().As<IRuleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RuleService>().As<IRulesService>().InstancePerLifetimeScope();
            builder.RegisterInstance(MongoDatabaseFactory.CreateDatabase(_configuration.Persistence.MongoConnectionString,
                                                                         _configuration.Persistence.MongoDbName));
        }
    }
}
