﻿using Milmom_Repository.IBaseRepository;
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
        public Task<bool> DeleteTest(Product product);
        Task<IEnumerable<Product>> GetProductsAsync(string? search ,double? lowPrice ,double? highPrice ,int? category,string sortBy,int pageIndex,int pageSize);
    }
}
