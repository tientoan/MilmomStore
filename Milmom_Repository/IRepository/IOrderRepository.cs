using MilmomStore_BusinessObject.Model;
using Milmom_Repository.IBaseRepository;
namespace Milmom_Repository.IRepository;

public interface IOrderRepository:IBaseRepository<Order>
{
    public Task AddOrderAsync(Order order);
    public Task<bool> HasPurchasedProductAsync(string accountId, int productId);
    public Task<Order?> GetOrderByIdAsync(int orderId);
    public Task<IEnumerable<Order>> GetOrdersByAccountId(string accountId);
    public Task<IEnumerable<Order>> GetOrdersByDateAsync(DateTime date);
    public Task<Order> ChangeOrderStatus(int orderId, OrderStatus status);
    public Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
    public Task<IEnumerable<Order>> GetAllOrderAsync();
}