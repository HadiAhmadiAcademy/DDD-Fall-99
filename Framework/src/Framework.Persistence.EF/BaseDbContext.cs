using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace Framework.Persistence.EF
{
    public abstract class BaseDbContext : DbContext
    {
        public override int SaveChanges()
        {
            AddOutboxItemsToTransaction();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AddOutboxItemsToTransaction();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddOutboxItemsToTransaction();
            return base.SaveChangesAsync(cancellationToken);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            AddOutboxItemsToTransaction();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddOutboxItemsToTransaction()
        {
            var outboxItems = this.ChangeTracker.Entries()
                                .Select(a=>a.Entity)
                                .OfType<IAggregateChange>()
                                .SelectMany(a=> a.UncommittedEvents)
                                .Select(OutboxItemFactory.CreateOutboxItem)
                                .ToList();

            //Save outbox items in database
        }
    }
}