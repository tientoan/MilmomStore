using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.AccountApplication;
using Milmom_Service.Model.Response.AccountApplication;
using Milmom_Service.Model.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.IService
{
    public interface IProductService
    {
        Task<BaseResponse<IEnumerable<GetAllProductsResponse>>> GetAllProductsFromBase();
        Task<BaseResponse<GetProductByIdResponse>> GetProductByIdFromBase(int id);
        Task<BaseResponse<GetProductDetailsResponse>> GetProductDetailByIdFromBase(int id);

    }
}
