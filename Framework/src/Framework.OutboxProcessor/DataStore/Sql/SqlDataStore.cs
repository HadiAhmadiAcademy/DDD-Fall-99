using System;
using System.Timers;
using Microsoft.Extensions.Options;

namespace Framework.OutboxProcessor.DataStore.Sql
{
    public class SqlDataStore : IDataStore
    {
        private readonly IOptions<SqlStoreConfig> _config;
        public SqlDataStore(IOptions<SqlStoreConfig> config)
        {
            _config = config;
        }
        public ISubscription SubscribeForChanges(IDataStoreChangeTracker changeTracker)
        {
            var timer = new Timer(_config.Value.PullingInterval);
            timer.Elapsed += TimerOnElapsed;
            timer.Start();
            return new ActionSubscription(timer.Stop);
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            //if (anyNewEventArrived)
            //      notifyChangeTrackers();
        }
    }
}