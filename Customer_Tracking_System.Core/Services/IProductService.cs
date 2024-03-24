using Customer_Tracking_System.Core.DTOs;
using Customer_Tracking_System.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.Services
{
    public interface IProductService : IService<Product>
    {
        public Task<CustomResponseDto<CustomerWithProductCommentDto>> GetProductByIdWithProductCommentsAsync(int productId);
        public Task<CustomResponseDto<CustomerWithOrderDto>> GetProductByIdWithOrderAsync(int productId);
    }
}
