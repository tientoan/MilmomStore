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
}