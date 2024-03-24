using Customer_Tracking_System.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.Services
{
    public interface ICustomerService : IService<Customer>
    {
        public Task<CustomResponseDto<CustomerWithInterestDto>> GetCustomerByIdWithInterestsAsync(int customerId);
        public Task<CustomResponseDto<CustomerWithProductCommentDto>> GetCustomerByIdWithProductCommentsAsync(int customerId);
        public Task<CustomResponseDto<CustomerWithOrderDto>> GetCustomerByIdWithOrderAsync(int customerId);
    }
}
