using System.Reflection;
using Framework.Core.Events;
using Framework.OutboxProcessor.DataStore;
using Framework.OutboxProcessor.DataStore.Sql;
using Framework.OutboxProcessor.EventBus;
using Framework.OutboxProcessor.EventBus.MassTransit;
using Framework.OutboxProcessor.EventTransformation;
using Framework.OutboxProcessor.Filtering;
using Framework.OutboxProcessor.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.OutboxProcessor.Setup
{
    public class OutboxProcessorConfigurator
    {
        private readonly IServiceCollection services;
        private readonly IConfiguration _configuration;
        private readonly IFilter _filter;

        public OutboxProcessorConfigurator(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            services = serviceCollection;
            _configuration = configuration;
        }

        public OutboxProcessorConfigurator ReadFromSqlServer()
        {
            services.AddSingleton<IDataStore, SqlDataStore>();
            services.Configure<SqlStoreConfig>(_configuration.GetSection("SqlStoreConfig"));
            return this;
        }
        public OutboxProcessorConfigurator PublishWithMassTransit()
        {
            services.AddSingleton<IEventBus, MassTransitBusAdapter>();
            services.Configure<MassTransitConfig>(_configuration.GetSection("MassTransitConfig"));
            return this;
        }
        public OutboxProcessorConfigurator WithFilter(IFilter filter)
        {
            services.AddSingleton(filter);
            return this;
        }

        public OutboxProcessorConfigurator WithNoFilter()
        {
            return WithFilter(new NoFilter());
        }

        public OutboxProcessorConfigurator UseEventsInAssemblies(params Assembly[] assemblies)
        {
            var eventTypeResolver = new EventTypeResolver();
            if (assemblies.Length > 0)
            {
                foreach (var assembly in assemblies)
                    eventTypeResolver.AddTypesFromAssembly(assembly);
            }
            services.AddSingleton<IEventTypeResolver>(eventTypeResolver);
            return this;
        }

        public OutboxProcessorConfigurator UseEventTransformersInAssemblies(params Assembly[] assemblies)
        {
            var transformerLookUp = new EventTransformerLookUp();
            if(assemblies.Length > 0)
            {
                foreach (var assembly in assemblies)
                    transformerLookUp.AddTypesFromAssembly(assembly);
            }
            services.AddSingleton<IEventTransformerLookUp>(transformerLookUp);
            return this;
        }

        public OutboxProcessorConfigurator WithNoEventTransformer()
        {
            return UseEventTransformersInAssemblies();
        }
    }
}