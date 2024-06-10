using Milmom_Repository.IRepository;
using Milmom_Service.IService;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.Service;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    
    public CartService(ICartRepository cartRepository, IProductRepository productRepository)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
    }
    
    public async Task AddToCart(string accountId, int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null || product.InventoryQuantity < 1)
        {
            throw new Exception("Product not found or out of stock");
        }

        await _cartRepository.AddToCart(accountId, productId);
    }

    public async Task RemoveFromCart(string accountId, int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null || product.InventoryQuantity < 1)
        {
            throw new Exception("Product not found or out of stock");
        }

        await _cartRepository.AddToCart(accountId, productId);
    }

    public async Task<Cart?> GetCart(string accountId)
    {
        return await _cartRepository.GetCart(accountId);
    }

    public async Task ClearCart(string accountId)
    {
        await _cartRepository.ClearCart(accountId);
    }
}