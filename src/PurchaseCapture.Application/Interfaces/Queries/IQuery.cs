namespace PurchaseCapture.Application.Interfaces.Queries;

/// <summary>
/// Base query for implementing CQRS.
/// </summary>
/// <typeparam name="TModel">The model object type.</typeparam>
public interface IQuery<TModel>
{
    /// <summary>
    /// Gets all the model objects.
    /// </summary>
    /// <returns>All the model objects.</returns>
    IEnumerable<TModel> GetAll();

    /// <summary>
    /// Gets a specific model object.
    /// </summary>
    /// <param name="id">The ID of the model object.</param>
    /// <returns>A specific model object.</returns>
    Task<TModel> GetById(Guid id);
}
