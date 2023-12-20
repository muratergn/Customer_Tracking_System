using Customer_Tracking_System.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.Services
{
    public interface ICustomerService : IServices<Customer>
    {
        public Task<CustomResponseDto<List<CustomerWithInterestDto>>> GetCustomerByIdWithInterestsAsync(int customerId);
        public Task<CustomResponseDto<List<CustomerWithProductCommentDto>>> GetCustomerByIdWithProductCommentsAsync(int customerId);
        public Task<CustomResponseDto<List<CustomerWithOrderDto>>> GetCustomerByIdWithOrderAsync(int customerId);
    }
}
