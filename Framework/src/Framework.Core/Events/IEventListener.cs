namespace Framework.Core.Events
{
    public interface IEventListener
    {
        void Publish<T>(T eventToPublish) where T : IEvent;
    }
}