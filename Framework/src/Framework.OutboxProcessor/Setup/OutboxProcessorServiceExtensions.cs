using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Framework.OutboxProcessor.Setup
{
    public static class OutboxProcessorServiceExtensions
    {
        public static OutboxProcessorConfigurator AddOutboxProcessor(this IServiceCollection services, HostBuilderContext hostingContext)
        {
            services.AddHostedService<OutboxWorker>();
            var configurator = new OutboxProcessorConfigurator(services, hostingContext.Configuration);
            return configurator;
        }
    }
}