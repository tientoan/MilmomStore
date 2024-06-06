using Milmom_Service.Model.Response.ImageProduct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Model.Response.Product
{
    public class GetProductDetailsResponse
    {
        public string Name { get; set; }
        
        public int InventoryQuantity { get; set; }
        
        public string Description { get; set; }
        public double PurchasePrice { get; set; }
        
        public string Supplier { get; set; }
        public string Original { get; set; }

        public ICollection<GetAllImageProductsResponse> ImageProducts { get; set; }

    }
}
