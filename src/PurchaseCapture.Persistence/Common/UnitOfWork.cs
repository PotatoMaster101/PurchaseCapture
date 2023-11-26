using PurchaseCapture.Application.Interfaces.Persistence;

namespace PurchaseCapture.Persistence.Common;

/// <summary>
/// Implementation for unit of work pattern.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly IApplicationDbContext _dbContext;

    /// <summary>
    /// Constructs a new instance of <see cref="UnitOfWork"/>.
    /// </summary>
    public UnitOfWork(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc cref="IUnitOfWork.SaveChanges"/>
    public Task SaveChanges(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChanges(cancellationToken);
    }
}
