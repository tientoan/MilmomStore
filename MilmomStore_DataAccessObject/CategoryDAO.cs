﻿using Microsoft.EntityFrameworkCore;
using MilmomStore_BusinessObject.IdentityModel;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject.BaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_DataAccessObject
{
    public class CategoryDAO :  BaseDAO<Category>
    {
        private readonly MilmomSystemContext _context;

        public CategoryDAO(MilmomSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories
            .ToListAsync();
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            if (id == null || id <= 0)
            {
                throw new ArgumentNullException($"id {id} not found");
            }
             var entity = await _context.Set<Category>()
                .SingleOrDefaultAsync(c => c.CategoryID == id);
            if (entity == null)
            {
                throw new ArgumentNullException($"Entity with id {id} not found");
            }
            return entity;
        }

        public async Task<IEnumerable<Category>> SearchCategoryAsync(string? search, int pageIndex, int pageSize)
        {
            IQueryable<Category> searchCategories = _context.Categories;

            if (!string.IsNullOrEmpty(search))
            {
                searchCategories = searchCategories
                            .Where(c => c.Name.ToLower().Contains(search.ToLower()));
            }

            var result = PaginatedList<Category>.Create(searchCategories, pageIndex, pageSize).ToList();
            return result;
        }
    }
}
