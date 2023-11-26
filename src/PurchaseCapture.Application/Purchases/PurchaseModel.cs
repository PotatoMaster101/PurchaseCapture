using System.ComponentModel.DataAnnotations;
using PurchaseCapture.Application.Customers;
using PurchaseCapture.Application.Items;
using PurchaseCapture.Domain.Purchases;

namespace PurchaseCapture.Application.Purchases;

/// <summary>
/// Model object for a purchase.
/// </summary>
public class PurchaseModel
{
    /// <summary>
    /// Gets or sets the purchase ID.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the purchase time.
    /// </summary>
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the purchasing customer.
    /// </summary>
    [Required]
    public CustomerModel Customer { get; set; } = null!;

    /// <summary>
    /// Gets or sets the purchase item.
    /// </summary>
    [Required]
    public ItemModel Item { get; set; } = null!;

    /// <summary>
    /// Gets or sets the purchase amount.
    /// </summary>
    [Range(PurchaseConstants.MinimumAmount, PurchaseConstants.MaximumAmount)]
    public int Amount { get; set; } = 1;
}
