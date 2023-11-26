using PurchaseCapture.Application.Interfaces.Persistence;
using PurchaseCapture.Application.Interfaces.Queries;
using PurchaseCapture.Domain.Purchases;

namespace PurchaseCapture.Application.Purchases.Queries;

/// <summary>
/// Command for retrieving purchases.
/// </summary>
public class GetPurchases : IQuery<PurchaseModel>
{
    private readonly IRepository<Purchase> _repository;

    /// <summary>
    /// Constructs a new instance of <see cref="GetPurchases"/>.
    /// </summary>
    public GetPurchases(IRepository<Purchase> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc cref="IQuery{TModel}.GetAll"/>
    public IEnumerable<PurchaseModel> GetAll()
    {
        return _repository
            .GetAll()
            .ToList()
            .Select(x => x.ToModel());
    }

    /// <inheritdoc cref="IQuery{TModel}.GetById"/>
    public async Task<PurchaseModel> GetById(Guid id)
    {
        var entity = await _repository.Get(id).ConfigureAwait(false);
        return entity.ToModel();
    }
}
