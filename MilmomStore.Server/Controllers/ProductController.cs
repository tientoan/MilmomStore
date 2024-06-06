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
        [Route("/ProductDetail/base/{id}")]
        public async Task<ActionResult<BaseResponse<GetProductDetailsResponse>>> GetProductDetailByIdFromBase(int id)
        {
            return await _productService.GetProductDetailByIdFromBase(id);
        }
    }
}
