using PurchaseCapture.Application.Interfaces.Commands;
using PurchaseCapture.Application.Interfaces.Persistence;
using PurchaseCapture.Domain.Items;

namespace PurchaseCapture.Application.Items.Commands;

/// <summary>
/// Command for creating an item.
/// </summary>
public class CreateItem : ICommand<ItemModel>
{
    private readonly IRepository<Item> _repository;
    private readonly IUnitOfWork _uow;

    /// <summary>
    /// Constructs a new instance of <see cref="CreateItem"/>.
    /// </summary>
    public CreateItem(IRepository<Item> repository, IUnitOfWork uow)
    {
        _repository = repository;
        _uow = uow;
    }

    /// <inheritdoc cref="ICommand{TModel}.Execute"/>
    public Task Execute(ItemModel model)
    {
        _repository.Add(model.ToEntity());
        return _uow.SaveChanges();
    }
}
