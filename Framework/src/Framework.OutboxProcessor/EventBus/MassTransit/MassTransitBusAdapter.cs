using System.Threading.Tasks;
using Framework.Core.Events;
using MassTransit;
using Microsoft.Extensions.Options;

namespace Framework.OutboxProcessor.EventBus.MassTransit
{
    public class MassTransitBusAdapter : IEventBus
    {
        private readonly IOptions<MassTransitConfig> _config;
        private bool isStarted;
        private IBusControl _bus;
        public MassTransitBusAdapter(IOptions<MassTransitConfig> config)
        {
            _config = config;
            isStarted = false;
        }
        public Task Publish(IEvent @event)
        {
            if (!isStarted) throw new BusNotStartedException();
            return _bus.Publish((dynamic)@event);
        }
        public async Task Start()
        {
            _bus =  Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                sbc.Host(_config.Value.RabbitMqConnectionString);
            });
            await _bus.StartAsync();
            this.isStarted = true;
        }
    }
}