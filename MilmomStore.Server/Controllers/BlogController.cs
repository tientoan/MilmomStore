using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Blog;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Response.Blog;
using Milmom_Service.Model.Response.Product;
using Milmom_Service.Service;
using MilmomStore_BusinessObject.Model;

namespace MilmomStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        
        [HttpGet]
        [Route("GetAllBlogs")]
        public async Task<ActionResult<BaseResponse<IEnumerable<BlogResponse>>>> GetAllBlogsForManager()
        {
            var blogs = await _blogService.GetAllBlogFromBase();
            return Ok(blogs);
        }

       
        [HttpGet]
        [Route("BlogDetails/{id}")]
        public async Task<ActionResult<BaseResponse<BlogResponse>>> GetBlogDetailForHomePage(int id)
        {
            return await _blogService.GetBlogByIdFromBase(id);
        }

        /*[Authorize(Roles = "Staff")]*/
        [HttpPost]
        [Route("CreateBlog")]
        public async Task<ActionResult<BaseResponse<BlogRequest>>> CreateBlogFromBase([FromBody] BlogRequest request)
        {
            var blog = await _blogService.CreateBlogFromBase(request);
            return blog;
        }

        /*[Authorize(Roles = "Staff")]*/
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<BaseResponse<Blog>>> DeleteBlog(int id)
        {
            var existingBlog = await _blogService.GetBlogByIdFromBase(id);
            if (existingBlog == null)
            {
                return NotFound(new { message = "Blog not found" });
            }

            var success = await _blogService.DeleteBlog(id);

            if (!success)
            {
                return BadRequest(new { message = "Failed to delete Blog" });
            }

            return Ok(new { message = "Delete Blog successfully" });
        }

        /*[Authorize(Roles = "Staff")]*/
        [HttpPut]
        [Route("UpdateBlog")]
        public async Task<ActionResult<BaseResponse<UpdateBlogRequest>>> UpdateBlogFromBase(int id,
            [FromBody] UpdateBlogRequest blog)
        {
            return await _blogService.UpdateBlogFromBase(id, blog);
        }

        /*[Authorize(Roles = "Staff")]*/
        [HttpGet]
        [Route("base/search")]
        public async Task<ActionResult<BaseResponse<IEnumerable<BlogResponse>>>> GetSearchProductFromBase(string search, int pageIndex, int pageSize)
        {
            return await _blogService.GetSearchBlogFromBase(search, pageIndex, pageSize);
        }
    }
}
