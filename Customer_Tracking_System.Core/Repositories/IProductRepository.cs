using Customer_Tracking_System.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<ProductComment>> GetProductByIdWithProductCommentsAsync(int productId);
        Task<List<Order>> GetProductByIdWithOrderAsync(int productId);
    }
}
