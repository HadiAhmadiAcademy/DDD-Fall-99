namespace Framework.Core.Events
{
    public interface IEventPublisher
    {
        ISubscription Subscribe<T>(IEventHandler<T> handler) where T : IEvent;
    }
}