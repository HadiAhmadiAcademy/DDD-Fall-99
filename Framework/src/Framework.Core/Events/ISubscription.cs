using System;

namespace Framework.Core.Events
{
    public interface ISubscription : IDisposable
    {
        void Unsubscribe();
    }
}