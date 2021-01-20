using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Framework.OutboxProcessor.Setup
{
    public static class OutboxProcessorServiceExtensions
    {
        public static void AddOutboxProcessor(this IServiceCollection services,
            HostBuilderContext hostingContext, Action<OutboxProcessorConfigurator> config)
        {
            services.AddHostedService<OutboxWorker>();
            var configurator = new OutboxProcessorConfigurator(services, hostingContext.Configuration);
            config.Invoke(configurator);
        }
    }
}