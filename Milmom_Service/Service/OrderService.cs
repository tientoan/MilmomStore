using AutoMapper;
using Milmom_Repository.IRepository;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Order;
using Milmom_Service.Model.Response.Order;
using Milmom_Service.Models.Enums;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task UpdateOrderStatus(int orderId, string status)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null)
        {
            throw new Exception("Order not found");
        }
        order.Status = Enum.Parse<OrderStatus>(status);
        await _orderRepository.UpdateAsync(order);
    }

    public async Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersAsync()
    {
        var orders = await _orderRepository.GetAllOrderAsync();
        var ordersResponse = _mapper.Map<IEnumerable<OrderResponse>>(orders);
        return new BaseResponse<IEnumerable<OrderResponse>>("Get ok", StatusCodeEnum.OK_200, ordersResponse);
    }

    public async Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersByDateAsync(DateTime date)
    {
        var orders = await _orderRepository.GetOrdersByDateAsync(date);
        var ordersResponse = _mapper.Map<IEnumerable<OrderResponse>>(orders);
        return new BaseResponse<IEnumerable<OrderResponse>>("Get ok", StatusCodeEnum.OK_200, ordersResponse);
    }

    public async Task<BaseResponse<IEnumerable<OrderResponse>>> GetAllOrdersByAccountIdAsync(string accountId)
    {
        var orders = await _orderRepository.GetOrdersByAccountId(accountId);
        var ordersResponse = _mapper.Map<IEnumerable<OrderResponse>>(orders);
        return new BaseResponse<IEnumerable<OrderResponse>>("Get ok", StatusCodeEnum.OK_200, ordersResponse);
    }

    public async Task<BaseResponse<OrderResponse>> ChangeOrderStatus(int orderId, OrderStatus status)
    {
        var order = await _orderRepository.ChangeOrderStatus(orderId, status);
        var orderResponse = _mapper.Map<OrderResponse>(order);
        return new BaseResponse<OrderResponse>("Change status ok", StatusCodeEnum.OK_200, orderResponse);
    }

    public async Task<BaseResponse<IEnumerable<OrderResponse>>> GetOrdersByStatusAsync(OrderStatus status)
    {
        var orders = await _orderRepository.GetOrdersByStatusAsync(status);
        var ordersResponse = _mapper.Map<IEnumerable<OrderResponse>>(orders);
        return new BaseResponse<IEnumerable<OrderResponse>>("Get ok", StatusCodeEnum.OK_200, ordersResponse);
    }

    public async Task<BaseResponse<OrderResponse>> GetOrderByIdAsync(int orderId)
    {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            var orderResponse = _mapper.Map<OrderResponse>(order);
            return new BaseResponse<OrderResponse>("Get ok", StatusCodeEnum.OK_200, orderResponse);
    }

    public async Task<BaseResponse<OrderRequest>> UpdateOrderAsync(int orderId, OrderRequest request)
    {
        var orderExist = await _orderRepository.GetByIdAsync(orderId);
        if (orderExist == null)
        {
            throw new Exception("Order not found");
        }
        orderExist.ReportID = request.ReportID;
        var OrderUpdate = await _orderRepository.UpdateAsync(orderExist);
        var orderResponse = _mapper.Map<OrderRequest>(OrderUpdate);
        return new BaseResponse<OrderRequest>("Get ok", StatusCodeEnum.OK_200, orderResponse);
    }
}