using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Dapper;
using Framework.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Framework.OutboxProcessor.DataStore.Sql
{
    public class SqlDataStore : IDataStore
    {
        private readonly IOptions<SqlStoreConfig> _config;
        private readonly ILogger<OutboxWorker> _logger;
        private readonly Timer _timer;
        private IDataStoreChangeTracker _changeTracker;
        public SqlDataStore(IOptions<SqlStoreConfig> config, ILogger<OutboxWorker> logger)
        {
            _config = config;
            _logger = logger;
            _timer = new Timer(_config.Value.PullingInterval);
            _timer.Elapsed += TimerOnElapsed;
        }

        public void SetSubscriber(IDataStoreChangeTracker changeTracker)
        {
            _changeTracker = changeTracker;
        }

        public ISubscription SubscribeForChanges()
        {
            if (_changeTracker == null) throw new NoChangeTrackerException();
            _timer.Start();
            return new ActionSubscription(_timer.Stop);
        }
        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            using (var connection = new SqlConnection(_config.Value.ConnectionString))
            {
                var position = connection.GetOutboxCursorPosition(_config.Value.CursorTable);
                var items = connection.GetOutboxItemsFromPosition(position, _config.Value.OutboxTable);
                if (items.Any())
                {
                    _logger.LogInformation($"{items.Count} Events found in outbox");
                    _changeTracker.ChangeDetected(items);
                    connection.MovePosition(items.Last().Id, _config.Value.CursorTable);
                    _logger.LogInformation($"Cursor moved to position {items.Last().Id}");
                }
            }
            _timer.Start();
        }
    }
}