using System.Collections.Generic;

namespace Framework.Domain
{
    public class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
    }
}