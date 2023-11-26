using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PurchaseCapture.Domain.Common;

namespace PurchaseCapture.Domain.Customers;

/// <summary>
/// A customer.
/// </summary>
[Table("Customer")]
public class Customer : IEntity
{
    /// <inheritdoc cref="IEntity.Id"/>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <inheritdoc cref="IEntity.CreationTime"/>
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the customer first name.
    /// </summary>
    [Required]
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the customer last name.
    /// </summary>
    [Required]
    public string LastName { get; set; } = null!;
}
