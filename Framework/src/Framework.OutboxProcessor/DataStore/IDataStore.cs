using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core;
using Framework.Domain;

namespace Framework.OutboxProcessor.DataStore
{
    public interface IDataStore
    {
        void SetSubscriber(IDataStoreChangeTracker changeTracker);
        ISubscription SubscribeForChanges();
    }
}
