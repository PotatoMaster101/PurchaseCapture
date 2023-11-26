using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PurchaseCapture.Domain.Common;
using PurchaseCapture.Domain.Customers;
using PurchaseCapture.Domain.Items;

namespace PurchaseCapture.Domain.Purchases;

/// <summary>
/// A customer purchase.
/// </summary>
[Table("Purchase")]
public class Purchase : IEntity
{
    /// <inheritdoc cref="IEntity.Id"/>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <inheritdoc cref="IEntity.CreationTime"/>
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the purchase customer ID.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the purchase item ID.
    /// </summary>
    public Guid ItemId { get; set; }

    /// <summary>
    /// Gets or sets the purchase amount.
    /// </summary>
    [Required, Range(PurchaseConstants.MinimumAmount, PurchaseConstants.MaximumAmount)]
    public int Amount { get; set; } = 1;

    /// <summary>
    /// Gets or sets the purchase customer. This is a navigation property.
    /// </summary>
    [ForeignKey(nameof(CustomerId))]
    public virtual Customer Customer { get; set; } = null!;

    /// <summary>
    /// Gets or sets the purchase item. This is a navigation property.
    /// </summary>
    [ForeignKey(nameof(ItemId))]
    public virtual Item Item { get; set; } = null!;
}
