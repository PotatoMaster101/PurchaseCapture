using System.ComponentModel.DataAnnotations;

namespace PurchaseCapture.Application.Customers;

/// <summary>
/// Model object for a customer.
/// </summary>
public class CustomerModel
{
    /// <summary>
    /// Gets or sets the customer ID.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the customer creation time.
    /// </summary>
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

    /// <summary>
    /// Gets the customer full name.
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";
}
