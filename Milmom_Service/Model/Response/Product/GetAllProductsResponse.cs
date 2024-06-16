using Milmom_Service.Model.Response.ImageProduct;

namespace Milmom_Service.Model.Response.Product;

public class GetAllProductsResponse
{
    public int ProductID { get; set; }

    public string Name { get; set; }

    public double PurchasePrice { get; set; }

    public bool Status { get; set; }

    public ICollection<GetAllImageProductsResponse> ImageProducts { get; set; }
}