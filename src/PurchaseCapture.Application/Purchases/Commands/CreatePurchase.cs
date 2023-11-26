using PurchaseCapture.Application.Interfaces.Commands;
using PurchaseCapture.Application.Interfaces.Persistence;
using PurchaseCapture.Domain.Customers;
using PurchaseCapture.Domain.Items;
using PurchaseCapture.Domain.Purchases;

namespace PurchaseCapture.Application.Purchases.Commands;

/// <summary>
/// Command for creating a purchase.
/// </summary>
public class CreatePurchase : ICommand<PurchaseModel>
{
    private readonly IRepository<Purchase> _purchaseRepository;
    private readonly IRepository<Item> _itemRepository;
    private readonly IRepository<Customer> _customerRepository;
    private readonly IUnitOfWork _uow;

    /// <summary>
    /// Constructs a new instance of <see cref="CreatePurchase"/>.
    /// </summary>
    public CreatePurchase(
        IRepository<Purchase> purchaseRepository,
        IRepository<Item> itemRepository,
        IRepository<Customer> customerRepository,
        IUnitOfWork uow)
    {
        _purchaseRepository = purchaseRepository;
        _itemRepository = itemRepository;
        _customerRepository = customerRepository;
        _uow = uow;
    }

    /// <inheritdoc cref="ICommand{TModel}.Execute"/>
    public async Task Execute(PurchaseModel model)
    {
        var (customer, customerExists) = GetOrCreateCustomerEntity(model.Customer.FirstName, model.Customer.LastName);
        if (!customerExists)
            _customerRepository.Add(customer);

        var (item, itemExists) = GetOrCreateItemEntity(model.Item.Name);
        if (!itemExists)
            _itemRepository.Add(item);

        var entity = model.ToEntity();
        entity.CustomerId = customer.Id;
        entity.ItemId = item.Id;
        _purchaseRepository.Add(entity);
        await _uow.SaveChanges().ConfigureAwait(false);
    }

    /// <summary>
    /// Gets a customer using the first name and last name.
    /// Creates a new customer if the name does not exist.
    /// </summary>
    /// <param name="firstName">The customer first name.</param>
    /// <param name="lastName">The customer last name.</param>
    /// <returns>The customer entity, and whether the customer already exists.</returns>
    private (Customer, bool) GetOrCreateCustomerEntity(string firstName, string lastName)
    {
        var customer = _customerRepository.GetAll().FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        if (customer is null)
        {
            return (new Customer
            {
                FirstName = firstName,
                LastName = lastName
            }, false);
        }
        return (customer, true);
    }

    /// <summary>
    /// Gets an item using the item name.
    /// Creates a new item if the name does not exist.
    /// </summary>
    /// <param name="name">The name of the item.</param>
    /// <returns>The item entity, and whether the item already exists.</returns>
    private (Item, bool) GetOrCreateItemEntity(string name)
    {
        var item = _itemRepository.GetAll().FirstOrDefault(x => x.Name == name);
        if (item is null)
        {
            return (new Item
            {
                Name = name
            }, false);
        }
        return (item, true);
    }
}
