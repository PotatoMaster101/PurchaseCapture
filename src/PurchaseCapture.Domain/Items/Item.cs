using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PurchaseCapture.Domain.Common;

namespace PurchaseCapture.Domain.Items;

/// <summary>
/// An item for purchase.
/// </summary>
[Table("Item")]
public class Item : IEntity
{
    /// <inheritdoc cref="IEntity.Id"/>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <inheritdoc cref="IEntity.CreationTime"/>
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the item name.
    /// </summary>
    [Required, MinLength(1)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the item price.
    /// </summary>
    [Required, Range(ItemConstants.MinimumPrice, ItemConstants.MaximumPrice)]
    public double Price { get; set; } = 1;
}
