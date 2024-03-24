using Customer_Tracking_System.Core.Repositories;
using Customer_Tracking_System.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer_Tracking_System.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer_Tracking_System.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Order>> GetProductByIdWithOrderAsync(int productId)
        {
            return await _context.Order
            .Where(o => o.ProductId == productId)
            .ToListAsync();
        }

        public async Task<List<ProductComment>> GetProductByIdWithProductCommentsAsync(int productId)
        {
            return await _context.ProductComments
            .Where(o => o.ProductId == productId)
            .ToListAsync();
        }
    }
}
