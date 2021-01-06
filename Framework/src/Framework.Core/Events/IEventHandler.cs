namespace Framework.Core.Events
{
    public interface IEventHandler<T> where T : IEvent
    {
        void Handle(T @event);
    }
}