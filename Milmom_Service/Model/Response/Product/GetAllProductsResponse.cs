using Milmom_Service.Model.Response.ImageProduct;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilmomStore_BusinessObject;

namespace Milmom_Service.Model.Response.Product
{
    public class GetAllProductsResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double PurchasePrice { get; set; }
        //thieu rating voi image
        public ICollection<GetAllImageProductsResponse> ImageProducts { get; set; }
    }
}
