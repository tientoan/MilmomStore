using Milmom_Service.Model.Response.OrderDetail;
using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.Model.Response.Order;

public class OrderResponse
{
    public int OrderID { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public OrderStatus Status { get; set; }
    public double Total { get; set; }
    //
    public ICollection<OrderDetailResponse> OrderDetails { get; set; }
    public Transaction? Transaction { get; set; }
    public ShippingInfor ShippingInfor { get; set; } = null!;
}