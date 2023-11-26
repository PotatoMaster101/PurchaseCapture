using Microsoft.EntityFrameworkCore;
using PurchaseCapture.Domain.Customers;
using PurchaseCapture.Domain.Items;
using PurchaseCapture.Domain.Purchases;

namespace PurchaseCapture.Persistence.Common;

/// <summary>
/// DB context for this application.
/// </summary>
public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
{
    /// <inheritdoc cref="IApplicationDbContext.Customers"/>
    public DbSet<Customer> Customers { get; set; } = null!;

    /// <inheritdoc cref="IApplicationDbContext.Items"/>
    public DbSet<Item> Items { get; set; } = null!;

    /// <inheritdoc cref="IApplicationDbContext.Purchases"/>
    public DbSet<Purchase> Purchases { get; set; } = null!;

    /// <summary>
    /// Constructs a new instance of <see cref="ApplicationDbContext"/>.
    /// </summary>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
        ChangeTracker.LazyLoadingEnabled = false;
    }

    /// <inheritdoc cref="IApplicationDbContext.SaveChanges"/>
    public Task<int> SaveChanges(CancellationToken cancellationToken = default)
    {
        return SaveChangesAsync(cancellationToken);
    }
}
