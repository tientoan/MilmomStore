using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.IService;

public interface ICartService
{
    public Task AddToCart(string accountId, int productId);

    public Task RemoveFromCart(string accountId, int productId);
    
    public Task<Cart?> GetCart(string accountId);
    
    public Task ClearCart(string accountId);
}