using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Order;
using Milmom_Service.Model.Response.Order;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.IService;

public interface IOrderService
{
    public Task UpdateOrderStatus(int orderId, string status);
    public Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersByAccountIdAsync(string accountId);
    public Task<BaseResponse<OrderResponse>> ChangeOrderStatus(int orderId, OrderStatus status);
    public Task<BaseResponse<OrderResponse>> GetOrderByIdAsync(int orderId);
    public Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrderAsync(DateTime? date, OrderStatus? status);
}