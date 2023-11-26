namespace PurchaseCapture.Application.Interfaces.Persistence;

/// <summary>
/// Base interface for unit of work pattern implementations.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Saves all changes to database.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token for cancelling this operation.</param>
    Task SaveChanges(CancellationToken cancellationToken = default);
}
