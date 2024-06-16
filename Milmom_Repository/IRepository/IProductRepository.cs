using Milmom_Repository.IBaseRepository;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Repository.IRepository
{
    public interface IProductRepository:IBaseRepository<Product>
    {
        public Task<int> DeleteProduct(Product product);
        public Task<IEnumerable<Product>> ViewProductForHomePage();
        Task<IEnumerable<Product>> SearchProductAsync(string search, int pageIndex, int pageSize);
        Task<IEnumerable<Product>> FilterProductAsync(double? lowPrice, double? highPrice, int? category, string? sortBy, int pageIndex, int pageSize);
    }
}
