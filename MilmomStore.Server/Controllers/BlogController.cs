using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Blog;
using Milmom_Service.Model.Request.Slider;
using Milmom_Service.Model.Response.Blog;
using Milmom_Service.Model.Response.Slider;
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
        [Route("BlogForHomepage")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetBlogForHomepageResponse>>>> GetBlogForHomepage()
        {
            var blogs = await _blogService.GetBlogForHomepage();
            return Ok(blogs);
        }

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
                return BadRequest(new { message = "Failed to delete blog" });
            }

            return Ok(new { message = "Delete blog success" });
        }

        [HttpGet]
        [Route("Get For Staff")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetBlogForManageResponse>>>> GetAllBlogForManagement()
        {
            var blogs = await _blogService.GetBlogForManagement();
            return Ok(blogs);
        }

        [HttpPost]
        [Route("Add For Staff")]
        public async Task<ActionResult<BaseResponse<AddBlogRequest>>> CreateBlogFromBase([FromBody] AddBlogRequest request)
        {
            var blog = await _blogService.CreateBlogFromBase(request);
            return blog;
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<BaseResponse<UpdateBlogRequest>>> UpdateBlogFromBase(int id,
            [FromBody] UpdateBlogRequest blog)
        {
            return await _blogService.UpdateBlogFromBase(id, blog);
        }
    }
}
