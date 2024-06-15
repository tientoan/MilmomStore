using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Response.AccountApplication;
using Milmom_Service.Model.Response.Product;

namespace MilmomStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("base")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetAllProductsResponse>>>> GetAllProductsFromBase()
        {
            var products = await _productService.GetAllProductsFromBase();
            return Ok(products);
        }

        [HttpGet]
        [Route("base/{id}")]
        public async Task<ActionResult<BaseResponse<GetProductByIdResponse>>> GetProductByIdFromBase(int id)
        {
            return await _productService.GetProductByIdFromBase(id);
        }

        [HttpGet]
        [Route("base/string")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetSearchProductResponse>>>> GetSearchProductFromBase(string search, int pageIndex, int pageSize)
        {
            return await _productService.GetSearchProductFromBase(search, pageIndex, pageSize);
        }

        [HttpGet]
        [Route("base/filter")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetFilterProductResponse>>>> GetFilterProductFromBase(double? lowPrice, double? highPrice, int? category, string? sortBy, int pageIndex, int pageSize)
        {
            return await _productService.FilterProductFromBase(lowPrice, highPrice, category, sortBy, pageIndex, pageSize);
        }
    }
}
