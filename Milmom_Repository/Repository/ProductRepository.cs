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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ProductDAO _productDao;
        public ProductRepository(ProductDAO productDao) : base(productDao)
        {
            _productDao = productDao;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productDao.GetAllAsync();
        }
        public async Task<IEnumerable<Product>> SearchProductAsync(string search, int pageIndex, int pageSize)
        {
            return await _productDao.SearchProductAsync(search, pageIndex, pageSize);
        }
        public async Task<IEnumerable<Product>> FilterProductAsync(double? lowPrice, double? highPrice, int? category, string? sortBy, int pageIndex, int pageSize)
        {
           return await _productDao.FilterProductAsync(lowPrice, highPrice, category, sortBy, pageIndex, pageSize);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productDao.GetByIdAsync(id);
        }

        public async Task<Product> AddAsync(Product entity)
        {
            return await _productDao.AddAsync(entity);
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            return await _productDao.UpdateAsync(entity);
        }

        public async Task<Product> DeleteAsync(Product entity)
        {
            return await _productDao.DeleteAsync(entity);
        }

        
    }
}
