using PurchaseCapture.Domain.Items;

namespace PurchaseCapture.Application.Items;

/// <summary>
/// Maps between <see cref="ItemModel"/> and <see cref="Item"/>.
/// </summary>
public static class ItemMapper
{
    /// <summary>
    /// Maps a <see cref="ItemModel"/> to <see cref="Item"/>.
    /// </summary>
    /// <param name="model">The model to map.</param>
    /// <returns>The mapped entity.</returns>
    public static Item ToEntity(this ItemModel model)
    {
        return new Item
        {
            Id = model.Id,
            CreationTime = model.CreationTime,
            Name = model.Name,
            Price = model.Price
        };
    }

    /// <summary>
    /// Maps a <see cref="Item"/> to <see cref="ItemModel"/>.
    /// </summary>
    /// <param name="entity">The entity to map.</param>
    /// <returns>The mapped model.</returns>
    public static ItemModel ToModel(this Item entity)
    {
        return new ItemModel
        {
            Id = entity.Id,
            CreationTime = entity.CreationTime,
            Name = entity.Name,
            Price = entity.Price
        };
    }
}
