using Milmom_Service.Model.Response.Product;

namespace Milmom_Service.Model.Response.Cart;

public class CartItemResponse
{
    public int Quantity { get; set; }
    public GetAllProductsResponse Product { get; set; }
    
}