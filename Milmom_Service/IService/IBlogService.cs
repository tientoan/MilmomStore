using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Blog;
using Milmom_Service.Model.Request.Slider;
using Milmom_Service.Model.Response.Blog;
using Milmom_Service.Model.Response.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.IService
{
    public interface IBlogService
    {
        Task<BaseResponse<IEnumerable<GetBlogForHomepageResponse>>> GetBlogForHomepage();
        Task<Boolean> DeleteBlog(int id);
        Task<BaseResponse<GetBlogByIdResponse>> GetBlogByIdFromBase(int id);
        Task<BaseResponse<IEnumerable<GetBlogForManageResponse>>> GetBlogForManagement();
        Task<BaseResponse<UpdateBlogRequest>> UpdateBlogFromBase(int id, UpdateBlogRequest request);
        Task<BaseResponse<AddBlogRequest>> CreateBlogFromBase(AddBlogRequest request);

    }
}
