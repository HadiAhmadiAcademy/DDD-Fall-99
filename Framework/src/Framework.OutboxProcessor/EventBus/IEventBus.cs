using System.Collections.Generic;
using Framework.Core;
using Framework.Domain;

namespace Framework.OutboxProcessor.EventBus
{
    public interface IEventBus
    {
        void Publish(IEvent @event);
    }
    public interface IDataStore
    {
        List<object> ReadUnsentEvents();
        void MarkAsSent(object item);
    }

}