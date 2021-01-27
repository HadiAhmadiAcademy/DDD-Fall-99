using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Scoring.Application.EventHandlers.External;
using Scoring.Config.Configuration;

namespace Scoring.Config
{
    public static class BusExtensions
    {
        public static void AddMassTransitConsumers(this IServiceCollection services, BusConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                //x.AddConsumers(typeof(EmployeeProfileCompletedHandler).Assembly);
                x.AddConsumer<EmployeeProfileCompletedHandler>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("Scoring", e =>
                    {
                        e.ConfigureConsumer<EmployeeProfileCompletedHandler>(context);
                    });
                    cfg.Host(configuration.RabbitMqConnection);
                });
            });

            services.AddMassTransitHostedService();
        }
    }
}