using Framework.Core.Events;

namespace Framework.OutboxProcessor.EventTransformation
{
    public interface IEventTransformer
    {
        IEvent Transform(IEvent @event);

    }
}