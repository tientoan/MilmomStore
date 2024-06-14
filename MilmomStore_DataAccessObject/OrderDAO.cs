using Microsoft.EntityFrameworkCore;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject.BaseDAO;

namespace MilmomStore_DataAccessObject;

public class OrderDAO : BaseDAO<Order>
{
    private readonly MilmomSystemContext _context;
    public OrderDAO(MilmomSystemContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.AccountApplication)
            //.Include(o => o.ShippingInfor)
            //.Include(o => o.Transaction)
            .Include(o => o.OrderDetails)
            .ToListAsync();
    }
    public async Task<IEnumerable<Order>> GetOrdersByAccountId(string accountId)
    {
        return await _context.Orders
            .Include(o => o.AccountApplication)
            .Include(o => o.OrderDetails)
            .Where(o => o.AccountID == accountId)
            .ToListAsync();
    }
    public async Task<Order?> GetOrderByIdAsync(int orderId)
    {
        return await _context.Orders
            .Include(o => o.AccountApplication)
            .Include(o => o.OrderDetails)
            .FirstOrDefaultAsync(o => o.OrderID == orderId);
    }
    public async Task ChangeOrderStatus(int orderId, OrderStatus status)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (order != null)
        {
            order.Status = status;
            await _context.SaveChangesAsync();
        }
    }
    public async Task AddOrderAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }
}