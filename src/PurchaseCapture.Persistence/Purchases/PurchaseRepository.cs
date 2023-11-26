using Microsoft.EntityFrameworkCore;
using PurchaseCapture.Domain.Purchases;
using PurchaseCapture.Persistence.Common;

namespace PurchaseCapture.Persistence.Purchases;

/// <summary>
/// Implementation for a repository that handles purchases.
/// </summary>
public class PurchaseRepository : Repository<Purchase>
{
    /// <summary>
    /// Creates a new instance of <see cref="PurchaseRepository"/>.
    /// </summary>
    public PurchaseRepository(IApplicationDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc cref="Repository{TEntity}.GetAll"/>
    public override IQueryable<Purchase> GetAll()
    {
        // need to include FKs
        return _dbContext
            .Purchases
            .Include(x => x.Customer)
            .Include(x => x.Item);
    }
}
