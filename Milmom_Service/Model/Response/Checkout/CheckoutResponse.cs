﻿using MilmomStore_BusinessObject.Model;

namespace Milmom_Service.Model.Response.Checkout;

public class CheckoutResponse
{
    public int OrderID { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public double Total { get; set; }
    public ICollection<OrderDetailResponse> OrderDetails { get; set; }
    public ShippingInfor ShippingInfor { get; set; } = null!;
}