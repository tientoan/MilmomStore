﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    public class ProductDAO : BaseDAO<Product>
    {
        private readonly MilmomSystemContext _context;

        public ProductDAO(MilmomSystemContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
           .Include(p => p.ImageProducts).ToListAsync();

        }
        public async Task<IEnumerable<Product>> SearchProductAsync(string search, int pageIndex, int pageSize)
        {
            IQueryable<Product> searchProducts = _context.Products;

            if (!string.IsNullOrEmpty(search))
            {
                searchProducts = searchProducts.Include(p => p.ImageProducts)
                            .Where(p => p.Name.ToLower().Contains(search.ToLower()));
            }

            var result = PaginatedList<Product>.Create(searchProducts, pageIndex, pageSize).ToList();
            return result;
        }

        public async Task<IEnumerable<Product>> FilterProductAsync(double? lowPrice, double? highPrice, int? category, string? sortBy, int pageIndex, int pageSize)
        {
            IQueryable<Product> filterProducts = _context.Products.Include(p => p.ImageProducts);

            if (lowPrice.HasValue)
            {
                filterProducts = filterProducts.Where(p => p.PurchasePrice >= lowPrice.Value);
            }

            if (highPrice.HasValue)
            {
                filterProducts = filterProducts.Where(p => p.PurchasePrice <= highPrice);
            }

            if (category.HasValue && category > 0)
            {
                filterProducts = filterProducts.Where(p => p.CategoryID == category);
            }

            // Apply default sorting
            filterProducts = filterProducts.OrderBy(p => p.Name);

            // Apply sorting based on sortBy parameter, if provided
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "price_asc":
                        filterProducts = filterProducts.OrderBy(p => p.PurchasePrice);
                        break;
                    case "price_desc":
                        filterProducts = filterProducts.OrderByDescending(p => p.PurchasePrice);
                        break;
                }
            }
            
            var result = PaginatedList<Product>.Create(filterProducts, pageIndex, pageSize).ToList();
            // Execute the query and return the results as a list
            return result;
        }

    }
    
}
