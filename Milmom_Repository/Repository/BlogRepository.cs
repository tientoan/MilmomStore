using Milmom_Repository.BaseRepository;
using Milmom_Repository.IRepository;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject;
using MilmomStore_DataAccessObject.BaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Repository.Repository
{
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        private readonly BlogDAO _blogDAO;

        public BlogRepository(BlogDAO blogDao) : base(blogDao)
        {
            _blogDAO = blogDao;
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _blogDAO.GetAllAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogDAO.GetByIdAsync(id);
        }

        public async Task<Blog> GetByStringIdAsync(string id)
        {
            return await _blogDAO.GetByStringIdAsync(id);
        }

        public async Task<Blog> AddAsync(Blog entity)
        {
            return await _blogDAO.AddAsync(entity);
        }

        public async Task<Blog> UpdateAsync(Blog entity)
        {
            return await _blogDAO.UpdateAsync(entity);
        }

        public async Task<Blog > DeleteAsync(Blog entity)
        {
            return await _blogDAO.DeleteAsync(entity);
        }
        public async Task<bool> DeleteBlog(Blog blog)
        {
            return await _blogDAO.DeleteBlog(blog);
        }

        public async Task<IEnumerable<Blog>> GetBlogForHomepage()
        {
            return await _blogDAO.GetBlogForHomepage();
        }
    }
}
