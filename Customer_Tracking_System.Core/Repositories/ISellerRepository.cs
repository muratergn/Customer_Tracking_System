using Customer_Tracking_System.Core.DTOs;
using Customer_Tracking_System.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.Repositories
{
    public interface ISellerRepository : IGenericRepository<Seller>
    {
        Task<List<Order>> GetSellerByIdWithOrderAsync(int sellerId);
        Task<List<Product>> GetSellerByIdWithProductAsync(int sellerId);

    }
}
