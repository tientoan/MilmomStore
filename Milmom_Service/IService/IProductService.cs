using Microsoft.AspNetCore.Mvc;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.AccountApplication;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Response.AccountApplication;
using Milmom_Service.Model.Response.Product;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.IService
{
    public interface IProductService
    {
<<<<<<< Updated upstream
        Task<BaseResponse<IEnumerable<GetAllProductsResponse>>> GetAllProductsFromBase();
        Task<BaseResponse<GetProductByIdResponse>> GetProductByIdFromBase(int id);
        Task<BaseResponse<GetProductDetailsResponse>> GetProductDetailByIdFromBase(int id);

=======
        Task<BaseResponse<IEnumerable<GetAllProductsForManagerResponse>>> GetAllProductsFromBase();
        Task<BaseResponse<GetProductDetailForHP>> GetProductByIdFromBase(int id);
        Task<BaseResponse<Product>> DeleteProduct(int id);
        Task<BaseResponse<UpdateProductRequest>> UpdateProductFromBase(int id, UpdateProductRequest product);
        Task<BaseResponse<IEnumerable<ViewProductHomePageResponse>>> ViewProductHomePage();
>>>>>>> Stashed changes
    }
}
