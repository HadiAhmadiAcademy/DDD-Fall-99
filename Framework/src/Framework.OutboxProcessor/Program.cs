using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.OutboxProcessor.DataStore;
using Framework.OutboxProcessor.DataStore.Sql;
using Framework.OutboxProcessor.EventBus;
using Framework.OutboxProcessor.EventBus.MassTransit;
using Framework.OutboxProcessor.Setup;
using Framework.OutboxProcessor.TestEvents;
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
                    //services.AddOutboxProcessor(hostContext, a=>
                    //    a.ReadFromSqlServer()
                    //     .PublishWithMassTransit()
                    //     .UseEventsInAssemblies(typeof(UserRegistered).Assembly)
                    //     .UseEventTransformersInAssemblies(typeof(UserRegisteredTransformer).Assembly)
                    //     .WithNoFilter()
                    //);
                });
    }
}
