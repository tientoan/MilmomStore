using Microsoft.AspNetCore.Mvc;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Response.Order;
using MilmomStore_BusinessObject.Model;

namespace MilmomStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpGet("get-all-orders-by-id/{accountId}")]
        public async Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersByAccountIdAsync(string accountId)
        {
            return await _orderService.GetAllOrdersByAccountIdAsync(accountId);
        }
        [HttpGet("get-all-orders")]
        public async Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersAsync(DateTime? date, OrderStatus? status)
        {
            return await _orderService.GetAllOrderAsync(date, status);
        }
        
        [HttpPut("update-order-status")]
        public async Task<BaseResponse<OrderResponse>> ChangeOrderStatus(int orderId, OrderStatus status)
        {
            return await _orderService.ChangeOrderStatus(orderId, status);
        }
        [HttpGet("get-order-by-id/{orderId}")]
        public async Task<BaseResponse<OrderResponse>> GetOrderByIdAsync(int orderId)
        {
            return await _orderService.GetOrderByIdAsync(orderId);
        }
    }
}