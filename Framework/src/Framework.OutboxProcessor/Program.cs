using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.OutboxProcessor.DataStore;
using Framework.OutboxProcessor.DataStore.Sql;
using Framework.OutboxProcessor.EventBus;
using Framework.OutboxProcessor.EventBus.MassTransit;
using Framework.OutboxProcessor.Types;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Framework.OutboxProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IDataStore, SqlDataStore>();
                    services.AddSingleton<IEventBus, MassTransitBusAdapter>();
                    services.Configure<SqlStoreConfig>(hostContext.Configuration.GetSection("SqlStoreConfig"));
                    services.Configure<MassTransitConfig>(hostContext.Configuration.GetSection("RabbitMqConnectionString"));
                    services.AddHostedService<OutboxWorker>();
                });

        // AddOutboxProcessor()
        //      .UseMassTransitAsBus(...)
        //      .ReadFromSqlStore(...);
        //      .AddEventTransformersFromAssembly( ... );
    }
}
