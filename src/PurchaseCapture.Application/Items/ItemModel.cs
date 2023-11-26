using PurchaseCapture.Domain.Items;
using System.ComponentModel.DataAnnotations;

namespace PurchaseCapture.Application.Items;

/// <summary>
/// Model object for an item.
/// </summary>
public class ItemModel
{
    /// <summary>
    /// Gets or sets the item ID.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the item creation time.
    /// </summary>
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

    /// <summary>
    /// Gets the total price.
    /// </summary>
    /// <param name="count">The count of items.</param>
    /// <returns>The total price.</returns>
    public double GetTotalPrice(int count)
    {
        return count <= 0 ? 0 : count * Price;
    }
}
