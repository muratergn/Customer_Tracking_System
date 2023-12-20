using Customer_Tracking_System.Core;
using Customer_Tracking_System.Core.DTOs;
using Customer_Tracking_System.Core.Models;
using Customer_Tracking_System.Core.Repositories;
using Customer_Tracking_System.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Repository.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<CustomerInterests>> GetCustomerByIdWithInterestsAsync(int customerId)
        {
            return await _context.CustomerInterests.Where(ci => ci.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<Order>> GetCustomerByIdWithOrderAsync(int customerId)
        {
            return await _context.Order.Where(ci => ci.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<ProductComment>> GetCustomerByIdWithProductCommentsAsync(int customerId)
        {
            return await _context.ProductComments.Where(ci => ci.CustomerId == customerId).ToListAsync();
        }
    }
}
