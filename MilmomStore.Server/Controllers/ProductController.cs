using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Response.AccountApplication;
using Milmom_Service.Model.Response.Product;
using MilmomStore_BusinessObject.Model;

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
        [Route("GetForManagement")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetAllProductsForManagerResponse>>>> GetAllProductsForManager()
        {
            var products = await _productService.GetAllProductsFromBase();
            return Ok(products);
        }

        [HttpGet]

        [Route("productDetails/{id}")]
        public async Task<ActionResult<BaseResponse<GetProductDetailForHP>>> GetProductDetailForHomePage(int id)
        {
            return await _productService.GetProductByIdFromBase(id);
        }

        //[HttpGet]
        //[Route("/ProductDetail/base/{id}")]
        //public async Task<ActionResult<BaseResponse<GetProductDetailsResponse>>> GetProductDetailByIdFromBase(int id)
        //{
        //    return await _productService.GetProductDetailByIdFromBase(id);
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //public async Task<ActionResult<BaseResponse<Product>>> DeleteProduct(int id)
        //{
        //    return await _productService.DeleteProduct(id);
        //}

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<BaseResponse<Product>>> DeleteProduct(int id)
        {
            var existingProduct = await _productService.GetProductByIdFromBase(id);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            var success = await _productService.DeleteTest(id);

            if (!success)
            {
                return BadRequest(new { message = "Failed to delete product" });
            }

            return Ok(new { message = "Delete successful" });
        }

        // [HttpGet]
        // [Route("viewProduct")]
        // public async Task<ActionResult<BaseResponse<IEnumerable<ViewProductHomePageResponse>>>> ViewProductForHomePage()
        // {
        //     var products = await _productService.ViewProductHomePage();
        //     return Ok(products);
        // }

        [HttpPut]
        [Route("UpdateForManagement")]
        public async Task<ActionResult<BaseResponse<UpdateProductRequest>>> UpdateProductFromBase(int id,
            [FromBody] UpdateProductRequest product)
        {
            return await _productService.UpdateProductFromBase(id, product);
        }

        [HttpPost]
        [Route("AddForManagement")]
        public async Task<ActionResult<BaseResponse<AddProductRequest>>> CreateProductFromBase([FromBody] AddProductRequest request)
        {
            var user = await _productService.AddProductByIdFromBase(request);
            return user;
        }

        //[HttpGet]
        //[Route("base/{id}")]
        //public async Task<ActionResult<BaseResponse<GetProductDetailForHP>>> GetProductByIdFromBase(int id)
        //{
        //    return await _productService.GetProductByIdFromBase(id);
        //}

        // [HttpGet]
        // [Route("base/search")]
        // public async Task<ActionResult<BaseResponse<IEnumerable<GetSearchProductResponse>>>> GetSearchProductFromBase(string search, int pageIndex, int pageSize)
        // {
        //     return await _productService.GetSearchProductFromBase(search, pageIndex, pageSize);
        // }
        //
        // [HttpGet]
        // [Route("base/filter")]
        // public async Task<ActionResult<BaseResponse<IEnumerable<GetFilterProductResponse>>>> GetFilterProductFromBase(double? lowPrice, double? highPrice, int? category, string? sortBy, int pageIndex, int pageSize)
        // {
        //     return await _productService.FilterProductFromBase(lowPrice, highPrice, category, sortBy, pageIndex, pageSize);
        // }
        
        [HttpGet]
        [Route("base/getProducts")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetFilterProductResponse>>>> GetProductsAsync(string? search, double? lowPrice, double? highPrice, int? category, string sortBy, int pageIndex,
            int pageSize)
        {
            return await _productService.GetProductsAsync(search, lowPrice, highPrice, category, sortBy, pageIndex, pageSize);
        }
    }
}