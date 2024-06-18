using Milmom_Repository.IRepository;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject;
using Milmom_Repository.BaseRepository;
namespace Milmom_Repository.Repository;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    private readonly OrderDAO _orderDao;
    public OrderRepository(OrderDAO orderDao) : base(orderDao)
    {
        _orderDao = orderDao;
    }

    public async Task AddOrderAsync(Order order)
    {
         await _orderDao.AddOrderAsync(order);
    }

    public async Task<bool> HasPurchasedProductAsync(string accountId, int productId)
    {
        return await _orderDao.HasPurchasedProductAsync(accountId, productId);
    }

    public Task<Order?> GetOrderByIdAsync(int orderId)
    {
        return _orderDao.GetOrderByIdAsync(orderId);
    }
}