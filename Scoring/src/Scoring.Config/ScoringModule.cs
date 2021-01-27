using System;
using Autofac;
using MongoDB.Driver;
using Scoring.Application;
using Scoring.Application.Contracts.Applicants;
using Scoring.Application.Contracts.Rules;
using Scoring.Config.Configuration;
using Scoring.Domain.Model.Applicants;
using Scoring.Domain.Model.Rules;
using Scoring.Infrastructure.Persistence.Mongo;
using Scoring.Infrastructure.Persistence.Mongo.Repositories;

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
            //TODO: refactor to batch registration
            builder.RegisterType<MongoRuleRepository>().As<IRuleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MongoApplicantRepository>().As<IApplicantRepository>().InstancePerLifetimeScope();

            builder.RegisterType<RuleService>().As<IRulesService>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicantService>().As<IApplicantService>().InstancePerLifetimeScope();

            builder.RegisterInstance(MongoDatabaseFactory.CreateDatabase(_configuration.Persistence.MongoConnectionString,
                                                                         _configuration.Persistence.MongoDbName));
        }
    }
}
