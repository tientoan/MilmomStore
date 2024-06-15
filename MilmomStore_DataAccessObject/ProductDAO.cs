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
           .Include(p => p.ImageProducts)
           .ToListAsync();

        }

        public async Task<Product> GetByIdAsync(int id)
        {
<<<<<<< Updated upstream
            return await _context.Products
                .Include(p => p.ImageProducts)
                .SingleOrDefaultAsync(p => p.ProductID == id);
        }
=======
            return await _context.Set<Product>()
                .Include(p => p.ImageProducts)
                .Include(p => p.Ratings)
                .SingleOrDefaultAsync(p => p.ProductID == id);
        }

        public async Task<int> DeleteProduct(Product product)
        {
            product.Status = false;
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> ViewProductForHomePage()
        {
            return await _context.Products
           .Include(p => p.ImageProducts)
           .Include(p => p.Ratings)
           .Where(p => p.Status == true)
           .ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            var existingProduct = await _context.Products
            .Include(p => p.ImageProducts)
            .FirstOrDefaultAsync(p => p.ProductID == entity.ProductID); // Ensure you fetch the existing entity with its relationships

            if (existingProduct == null)
            {
                return null; // Or handle the case where the product doesn't exist in your preferred way
            }

            // Update the main product properties
            _context.Entry(existingProduct).CurrentValues.SetValues(entity);

            // Update the related ImageProducts collection
            existingProduct.ImageProducts.Clear();
            foreach (var imageProduct in entity.ImageProducts)
            {
                existingProduct.ImageProducts.Add(imageProduct);
            }

            await _context.SaveChangesAsync();
            return existingProduct;
        }
>>>>>>> Stashed changes
    }
    
}
