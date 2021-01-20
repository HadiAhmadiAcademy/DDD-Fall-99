using System.Collections.Generic;
using Framework.Core;
using Framework.Persistence;

namespace Framework.OutboxProcessor.DataStore
{
    public interface IDataStoreChangeTracker
    {
        void ChangeDetected(List<OutboxItem> item);
    }

}