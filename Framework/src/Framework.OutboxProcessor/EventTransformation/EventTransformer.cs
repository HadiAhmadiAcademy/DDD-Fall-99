using Framework.Core.Events;

namespace Framework.OutboxProcessor.EventTransformation
{
    public abstract class EventTransformer<T> : IEventTransformer where T : IEvent
    {
        public abstract IEvent Transform(T @event);
        public IEvent Transform(IEvent @event)
        {
            return Transform((T) @event);
        }
    }
}