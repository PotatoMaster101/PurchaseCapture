using PurchaseCapture.Application.Customers;
using PurchaseCapture.Application.Items;
using PurchaseCapture.Domain.Purchases;

namespace PurchaseCapture.Application.Purchases;

/// <summary>
/// Maps between <see cref="PurchaseModel"/> and <see cref="Purchase"/>.
/// </summary>
public static class PurchaseMapper
{
    /// <summary>
    /// Maps a <see cref="PurchaseModel"/> to <see cref="Purchase"/>.
    /// </summary>
    /// <param name="model">The model to map.</param>
    /// <returns>The mapped entity.</returns>
    public static Purchase ToEntity(this PurchaseModel model)
    {
        return new Purchase
        {
            Id = model.Id,
            CreationTime = model.CreationTime,
            Amount = model.Amount,
            CustomerId = model.Customer.Id,
            ItemId = model.Item.Id
        };
    }

    /// <summary>
    /// Maps a <see cref="Purchase"/> to <see cref="PurchaseModel"/>.
    /// </summary>
    /// <param name="entity">The entity to map.</param>
    /// <returns>The mapped model.</returns>
    public static PurchaseModel ToModel(this Purchase entity)
    {
        return new PurchaseModel
        {
            Id = entity.Id,
            CreationTime = entity.CreationTime,
            Customer = entity.Customer.ToModel(),
            Item = entity.Item.ToModel(),
            Amount = entity.Amount,
        };
    }
}
