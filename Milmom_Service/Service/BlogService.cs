using AutoMapper;
using Milmom_Repository.IRepository;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Blog;
using Milmom_Service.Model.Request.Slider;
using Milmom_Service.Model.Response.Blog;
using Milmom_Service.Model.Response.Slider;
using Milmom_Service.Models.Enums;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Service
{
    public class BlogService:IBlogService
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;

        public BlogService(IMapper mapper, IBlogRepository blogRepository)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
        }

        public async Task<BaseResponse<AddBlogRequest>> CreateBlogFromBase(AddBlogRequest request)
        {
            Blog blog = _mapper.Map<Blog>(request);
            await _blogRepository.AddAsync(blog);

            var response = _mapper.Map<AddBlogRequest>(blog);
            return new BaseResponse<AddBlogRequest>("Create blog as base success", StatusCodeEnum.Created_201, response);
        }

        public async Task<bool> DeleteBlog(int id)
        {
            var existingBlog = await _blogRepository.GetByIdAsync(id);
            if (existingBlog == null)
            {
                return false;
            }
            return await _blogRepository.DeleteBlog(existingBlog);
        }

        public async Task<BaseResponse<IEnumerable<GetBlogForManageResponse>>> GetBlogForManagement()
        {
            IEnumerable<Blog> blogs = await _blogRepository.GetAllAsync();
            var blog = _mapper.Map<IEnumerable<GetBlogForManageResponse>>(blogs);
            return new BaseResponse<IEnumerable<GetBlogForManageResponse>>("Get all  for staff as base success",
                StatusCodeEnum.OK_200, blog);
        }

        public async Task<BaseResponse<GetBlogByIdResponse>> GetBlogByIdFromBase(int id)
        {
            Blog blog = await _blogRepository.GetByIdAsync(id);
            var result = _mapper.Map<GetBlogByIdResponse>(blog);
            return new BaseResponse<GetBlogByIdResponse>("Get blog by id success", StatusCodeEnum.OK_200,
                result);
        }

        public async Task<BaseResponse<IEnumerable<GetBlogForHomepageResponse>>> GetBlogForHomepage()
        {
            IEnumerable<Blog> blogs = await _blogRepository.GetBlogForHomepage();
            var blog = _mapper.Map<IEnumerable<GetBlogForHomepageResponse>>(blogs);
            return new BaseResponse<IEnumerable<GetBlogForHomepageResponse>>("Get all blogs for home page success",
                StatusCodeEnum.OK_200, blog);
        }

        public async Task<BaseResponse<UpdateBlogRequest>> UpdateBlogFromBase(int id, UpdateBlogRequest request)
        {
            Blog existingBlog = await _blogRepository.GetByIdAsync(id);
            _mapper.Map(request, existingBlog);
            await _blogRepository.UpdateAsync(existingBlog);

            var result = _mapper.Map<UpdateBlogRequest>(existingBlog);
            return new BaseResponse<UpdateBlogRequest>("Update blog as base success", StatusCodeEnum.OK_200, result);
        }

        
    }
}
