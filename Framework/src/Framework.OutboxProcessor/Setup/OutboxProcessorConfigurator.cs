using Framework.OutboxProcessor.DataStore;
using Framework.OutboxProcessor.DataStore.Sql;
using Framework.OutboxProcessor.EventBus;
using Framework.OutboxProcessor.EventBus.MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.OutboxProcessor.Setup
{
    public class OutboxProcessorConfigurator
    {
        private readonly IServiceCollection services;
        private readonly IConfiguration _configuration;

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
            services.Configure<MassTransitConfig>(_configuration.GetSection("RabbitMqConnectionString"));
            return this;
        }
    }
}