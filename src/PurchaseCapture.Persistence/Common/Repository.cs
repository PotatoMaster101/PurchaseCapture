using Microsoft.EntityFrameworkCore;
using PurchaseCapture.Application.Interfaces.Persistence;
using PurchaseCapture.Domain.Common;

namespace PurchaseCapture.Persistence.Common;

/// <summary>
/// Implementation for a generic repository.
/// </summary>
/// <typeparam name="TEntity">The entity type.</typeparam>
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly IApplicationDbContext _dbContext;

    /// <summary>
    /// Constructs a new instance of <see cref="Repository{TEntity}"/>.
    /// </summary>
    public Repository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc cref="IRepository{TEntity}.GetAll"/>
    public virtual IQueryable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>();
    }

    /// <inheritdoc cref="IRepository{TEntity}.Get"/>
    public virtual Task<TEntity> Get(Guid id, CancellationToken cancellationToken = default)
    {
        return _dbContext.Set<TEntity>().SingleAsync(cancellationToken);
    }

    /// <inheritdoc cref="IRepository{TEntity}.Add"/>
    public virtual void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }
}
