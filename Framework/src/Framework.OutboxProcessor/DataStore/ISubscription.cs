using System;

namespace Framework.OutboxProcessor.DataStore
{
    public interface ISubscription : IDisposable
    {
        void CancelSubscription();
    }
}