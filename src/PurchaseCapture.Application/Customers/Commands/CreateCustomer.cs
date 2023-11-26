using PurchaseCapture.Application.Interfaces.Commands;
using PurchaseCapture.Application.Interfaces.Persistence;
using PurchaseCapture.Domain.Customers;

namespace PurchaseCapture.Application.Customers.Commands;

/// <summary>
/// Command for creating a customer.
/// </summary>
public class CreateCustomer : ICommand<CustomerModel>
{
    private readonly IRepository<Customer> _repository;
    private readonly IUnitOfWork _uow;

    /// <summary>
    /// Constructs a new instance of <see cref="CreateCustomer"/>.
    /// </summary>
    public CreateCustomer(IRepository<Customer> repository, IUnitOfWork uow)
    {
        _repository = repository;
        _uow = uow;
    }

    /// <inheritdoc cref="ICommand{TModel}.Execute"/>
    public Task Execute(CustomerModel model)
    {
        _repository.Add(model.ToEntity());
        return _uow.SaveChanges();
    }
}
