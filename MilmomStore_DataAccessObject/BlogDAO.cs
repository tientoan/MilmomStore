using Microsoft.EntityFrameworkCore;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject.BaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_DataAccessObject
{
    public class BlogDAO : BaseDAO<Blog>
    {
        private readonly MilmomSystemContext _context;

        public BlogDAO(MilmomSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetBlogForHomepage()
        {
            return await _context.Blogs
                .Where(p => p.Status == true)
                .ToListAsync();

        }

        public async Task<bool> DeleteBlog(Blog blog)
        {
            blog.Status = false;
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
