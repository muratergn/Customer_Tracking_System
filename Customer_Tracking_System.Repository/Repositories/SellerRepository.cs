using Customer_Tracking_System.Core.Models;
using Customer_Tracking_System.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Repository.Repositories
{
    public class SellerRepository : GenericRepository<Seller>, ISellerRepository
    {
        public SellerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Order>> GetSellerByIdWithOrderAsync(int sellerId)
        {
            return await _context.Order
            .Where(o => o.SellerId == sellerId)
            .ToListAsync();
        }

        public async Task<List<Product>> GetSellerByIdWithProductAsync(int sellerId)
        {
            return await _context.Products.Where(ci => ci.SellerId == sellerId).ToListAsync();
        }
    }
}
