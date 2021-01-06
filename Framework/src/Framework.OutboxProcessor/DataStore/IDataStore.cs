using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core;
using Framework.Domain;

namespace Framework.OutboxProcessor.DataStore
{
    public interface IDataStore
    {
        ISubscription SubscribeForChanges(IDataStoreChangeTracker changeTracker);
    }
}
