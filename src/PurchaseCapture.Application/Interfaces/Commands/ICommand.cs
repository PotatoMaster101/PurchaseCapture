namespace PurchaseCapture.Application.Interfaces.Commands;

/// <summary>
/// Base command for implementing CQRS.
/// </summary>
/// <typeparam name="TModel">The model object type.</typeparam>
public interface ICommand<in TModel>
{
    /// <summary>
    /// Executes this command.
    /// </summary>
    /// <param name="model">The model object.</param>
    Task Execute(TModel model);
}
