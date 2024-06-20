﻿using Milmom_Repository.IBaseRepository;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Repository.IRepository
{
    public interface IBlogRepository:IBaseRepository<Blog>
    {
        public Task<IEnumerable<Blog>> GetBlogForHomepage();
        public Task<bool> DeleteBlog(Blog blog);
    }
}
