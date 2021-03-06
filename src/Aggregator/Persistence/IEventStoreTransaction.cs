using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aggregator.Persistence
{
    /// <summary>
    /// Interface for an event store transaction.
    /// </summary>
    public interface IEventStoreTransaction<in TIdentifier, in TEventBase> : IDisposable
        where TIdentifier : IEquatable<TIdentifier>
    {
        /// <summary>
        /// Commit the transaction.
        /// </summary>
        Task Commit();

        /// <summary>
        /// Rollback the transaction.
        /// </summary>
        Task Rollback();

        /// <summary>
        /// Store events for a specific aggregate root.
        /// </summary>
        /// <param name="identifier">The aggregate identifier.</param>
        /// <param name="expectedVersion">The expected version.</param>
        /// <param name="events">The events to store for the aggregate root.</param>
        /// <param name="cancellationToken">A cancellation token that allows cancelling the process.</param>
        /// <returns>An awaitable <see cref="Task"/>.</returns>
        Task StoreEvents(TIdentifier identifier, long expectedVersion, IEnumerable<TEventBase> events, CancellationToken cancellationToken = default(CancellationToken));
    }
}
