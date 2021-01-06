using Framework.Core;
using Framework.Persistence;

namespace Framework.OutboxProcessor.DataStore
{
    public interface IDataStoreChangeTracker
    {
        void ChangeDetected(OutboxItem item);
    }
}