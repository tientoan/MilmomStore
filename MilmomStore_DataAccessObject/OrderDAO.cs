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

    public async Task<IEnumerable<Order>> GetAllOrderAsync(DateTime? date = null, OrderStatus? status = null)
    {
        IQueryable<Order> orders = _context.Orders
            .Include(o => o.AccountApplication)
            .Include(o => o.ShippingInfor)
            .Include(o => o.Transaction)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .ThenInclude(p => p.ImageProducts);

        // Apply date filter if provided
        if (date.HasValue)
        {
            orders = orders.Where(o => o.OrderDate.Date == date.Value.Date);
        }

        // Apply status filter if provided
        if (status.HasValue)
        {
            orders = orders.Where(o => o.Status == status.Value);
        }

        // Execute the query and return the results as a list
        return await orders.ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersByAccountId(string accountId)
    {
        return await _context.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(o => o.Product)
            .ThenInclude(o=>o.ImageProducts)
            .Include(o => o.ShippingInfor)
            .Include(o => o.Transaction)
            .Where(o => o.AccountID == accountId)
            .ToListAsync();
    }
    public async Task<Order?> ChangeOrderStatus(int orderId, OrderStatus status)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (order != null)
        {
            order.Status = status;
            await _context.SaveChangesAsync();
        }

        return await _context.Orders.FindAsync(orderId);
    }
    public async Task AddOrderAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> HasPurchasedProductAsync(string accountId, int productId)
    {
        return await _context.OrderDetails
            .AnyAsync(od => od.Order.AccountID == accountId && od.ProductID == productId);
    }
    public async Task<IEnumerable<Order>> GetOrdersByDateAsync(DateTime date)
    {
        return await _context.Orders
            .Include(o => o.AccountApplication)
            .Include(o => o.ShippingInfor)
            .Include(o => o.Transaction)
            .Include(o => o.OrderDetails)
            .ThenInclude(o => o.Product)
            .ThenInclude(o=>o.ImageProducts)
            .Where(o => o.OrderDate.Date == date.Date)
            .ToListAsync();
    }
    public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
    {
        return await _context.Orders
            .Include(o => o.AccountApplication)
            .Include(o => o.OrderDetails)
            .Where(o => o.Status == status)
            .ToListAsync();
    }
    public async Task<Order?> GetOrderByIdAsync(int orderId)
    {
        return await _context.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(o => o.Product)
            .ThenInclude(o=>o.ImageProducts)
            .Include(o => o.ShippingInfor)
            .Include(o => o.Transaction)
            
            .FirstOrDefaultAsync(o => o.OrderID == orderId);
    }

    public async Task<Order?> UpdateOrderAsync(int orderId, Order order)
    {

        var existOrder = await _context.Orders.FindAsync(orderId);
        if (existOrder != null)
        {
            existOrder.ReportID = order.ReportID;
        }
        await _context.SaveChangesAsync();
        return existOrder;
    }
    
}