using System;

namespace Framework.Core.Events
{
    public class DelegatingHandler<T> : IEventHandler<T> where T : IEvent
    {
        private Action<T> _handler;
        public DelegatingHandler(Action<T> handler)
        {
            _handler = handler;
        }

        public void Handle(T @event)
        {
            _handler.Invoke(@event);
        }
    }
}