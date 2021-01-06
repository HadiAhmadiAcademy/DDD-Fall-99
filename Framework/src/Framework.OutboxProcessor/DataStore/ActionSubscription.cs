using System;

namespace Framework.OutboxProcessor.DataStore
{
    public class ActionSubscription : ISubscription
    {
        private Action _cancel;
        public ActionSubscription(Action cancel)
        {
            _cancel = cancel;
        }

        public void CancelSubscription()
        {
            _cancel.Invoke();
        }
        public void Dispose()
        {
            CancelSubscription();
        }
    }
}