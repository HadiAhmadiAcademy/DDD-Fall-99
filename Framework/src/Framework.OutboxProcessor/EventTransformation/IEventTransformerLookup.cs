using Framework.Core.Events;
using GreenPipes;
using GreenPipes.Internals.Extensions;

namespace Framework.OutboxProcessor.EventTransformation
{
    public interface IEventTransformerLookUp
    {
        IEventTransformer LookUpTransformer(IEvent @event);
    }
}