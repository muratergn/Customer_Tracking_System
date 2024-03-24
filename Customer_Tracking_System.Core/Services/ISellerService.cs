using Customer_Tracking_System.Core.DTOs;
using Customer_Tracking_System.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.Services
{
    public interface ISellerService : IService<Seller>
    {
        public Task<CustomResponseDto<SellerWithProductDto>> GetSellerByIdWithProductAsync(int sellerId);
        public Task<CustomResponseDto<CustomerWithOrderDto>> GetSellerByIdWithOrderAsync(int sellerId);
    }
}
