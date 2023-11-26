using PurchaseCapture.Domain.Customers;

namespace PurchaseCapture.Application.Customers;

/// <summary>
/// Maps between <see cref="CustomerModel"/> and <see cref="Customer"/>.
/// </summary>
public static class CustomerMapper
{
    /// <summary>
    /// Maps a <see cref="CustomerModel"/> to <see cref="Customer"/>.
    /// </summary>
    /// <param name="model">The model to map.</param>
    /// <returns>The mapped entity.</returns>
    public static Customer ToEntity(this CustomerModel model)
    {
        return new Customer
        {
            Id = model.Id,
            CreationTime = model.CreationTime,
            FirstName = model.FirstName,
            LastName = model.LastName
        };
    }

    /// <summary>
    /// Maps a <see cref="Customer"/> to <see cref="CustomerModel"/>.
    /// </summary>
    /// <param name="entity">The entity to map.</param>
    /// <returns>The mapped model.</returns>
    public static CustomerModel ToModel(this Customer entity)
    {
        return new CustomerModel
        {
            Id = entity.Id,
            CreationTime = entity.CreationTime,
            FirstName = entity.FirstName,
            LastName = entity.LastName
        };
    }
}
