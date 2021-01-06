using System.Collections.Generic;
using System.Linq;

namespace Framework.Core.Events
{
    public class EventAggregator : IEventPublisher, IEventListener
    {
        private List<object> _handlers = new List<object>();
        public ISubscription Subscribe<T>(IEventHandler<T> handler) where T : IEvent
        {
            _handlers.Add(handler);
            return new DelegatingSubscription(() => _handlers.Remove(handler));
        }

        public void Publish<T>(T eventToPublish) where T : IEvent
        {
            var candidates = _handlers.OfType<IEventHandler<T>>().ToList();
            candidates.ForEach(a=> a.Handle(eventToPublish));
        }
    }
}