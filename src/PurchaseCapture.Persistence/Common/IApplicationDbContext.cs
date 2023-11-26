using Microsoft.EntityFrameworkCore;
using PurchaseCapture.Domain.Customers;
using PurchaseCapture.Domain.Items;
using PurchaseCapture.Domain.Purchases;

namespace PurchaseCapture.Persistence.Common;

/// <summary>
/// Base interface for DB context for this application.
/// </summary>
public interface IApplicationDbContext
{
    /// <summary>
    /// Gets or sets the collection of customers.
    /// </summary>
    DbSet<Customer> Customers { get; set; }

    /// <summary>
    /// Gets or sets the collection of items.
    /// </summary>
    DbSet<Item> Items { get; set; }

    /// <summary>
    /// Gets or sets the collection of purchases.
    /// </summary>
    DbSet<Purchase> Purchases { get; set; }

    /// <summary>
    /// Retrieves the <see cref="DbSet{TEntity}"/> for a specific entity type.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity to retrieve the <see cref="DbSet{TEntity}"/>.</typeparam>
    /// <returns>The <see cref="DbSet{TEntity}"/> for a specific entity type.</returns>
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    /// <summary>
    /// Saves all changes to the database.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token for cancelling this operation.</param>
    /// <returns>The number of rows saved.</returns>
    Task<int> SaveChanges(CancellationToken cancellationToken = default);
}
