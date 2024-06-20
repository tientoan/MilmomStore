using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Response.Order;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.IService;

public interface IOrderService
{
    public Task UpdateOrderStatus(int orderId, string status);

    public Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersAsync();
    public Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersByDateAsync(DateTime date);
    public Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersByAccountIdAsync(string accountId);
    
    public Task<BaseResponse<OrderResponse>> ChangeOrderStatus(int orderId, OrderStatus status);
    public Task<BaseResponse<IEnumerable<OrderResponse>>> GetOrdersByStatusAsync(OrderStatus status);
    public Task<BaseResponse<OrderResponse>> GetOrderByIdAsync(int orderId);
}