using System.ComponentModel.DataAnnotations;

namespace PurchaseCapture.Domain.Common;

/// <summary>
/// Base interface for all entities.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Gets or sets the entity ID.
    /// </summary>
    [Key]
    Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the entity creation time.
    /// </summary>
    DateTime CreationTime { get; set; }
}
