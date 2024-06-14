using MilmomStore_BusinessObject.Model;

namespace Milmom_Repository.IRepository;

public interface ICartRepository
{
    public Task AddToCart(string accountId, int productId);
    public Task RemoveFromCart(string accountId, int productId);
    public Task<Cart?> GetCart(string accountId);
    public Task ClearCart(string accountId);
    public Task<double> GetAmount(string accountId);
}