using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Core;
using Framework.Core.Events;
using Framework.Domain;

namespace Framework.OutboxProcessor.EventBus
{
    public interface IEventBus
    {
        Task Publish(IEvent @event);
        Task Start();
    }
}