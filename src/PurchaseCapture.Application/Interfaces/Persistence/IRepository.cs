using PurchaseCapture.Domain.Common;

namespace PurchaseCapture.Application.Interfaces.Persistence;

/// <summary>
/// Base interface for all repositories.
/// </summary>
/// <typeparam name="TEntity">The entity type.</typeparam>
public interface IRepository<TEntity> where TEntity : class, IEntity
{
    /// <summary>
    /// Gets all of the entities.
    /// </summary>
    /// <returns>A collection of all of the entities.</returns>
    IQueryable<TEntity> GetAll();

    /// <summary>
    /// Gets a specific entity.
    /// </summary>
    /// <param name="id">The ID of the entity.</param>
    /// <returns>The entity matching the ID.</returns>
    /// <param name="cancellationToken">The cancellation token for cancelling this operation.</param>
    Task<TEntity> Get(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new entity.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    void Add(TEntity entity);
}
