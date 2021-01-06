using System.Collections.Generic;
using Framework.Core;
using Framework.Core.Events;
using Framework.Domain;

namespace Framework.OutboxProcessor.EventBus
{
    public interface IEventBus
    {
        void Publish(IEvent @event);
    }
}