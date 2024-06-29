using Microsoft.AspNetCore.Mvc;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Category;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Response.Category;
using Milmom_Service.Model.Response.Product;
using Milmom_Service.Service;

namespace MilmomStore.Server.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetAllCategoryResponse>>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoryFromBase();
            return Ok(categories);
        }

        [HttpGet]
        [Route("GetCategory/{id}")]
        public async Task<ActionResult<BaseResponse<GetAllCategoryResponse>>> GetCategoryDetailByIdFromBase(int id)
        {
            return await _categoryService.GetCategoryDetailByIdFromBase(id);
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<ActionResult<BaseResponse<CreateCategoryRequest>>> CreateProductFromBase([FromBody] CreateCategoryRequest request)
        {
            var user = await _categoryService.CreateCategoryFromBase(request);
            return user;
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<ActionResult<BaseResponse<UpdateCategoryRequest>>> UpdateCategoryFromBase(int id,
            [FromBody] UpdateCategoryRequest category)
        {
            return await _categoryService.UpdateCategoryFromBase(id, category);
        }

        [HttpGet]
        [Route("base/search")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetAllCategoryResponse>>>> GetSearchCategoryFromBase(string search, int pageIndex, int pageSize)
        {
            return await _categoryService.GetSearchCategoryFromBase(search, pageIndex, pageSize);
        }

    }
}
