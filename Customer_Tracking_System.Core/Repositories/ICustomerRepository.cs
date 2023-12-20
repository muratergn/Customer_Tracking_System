using Customer_Tracking_System.Core.DTOs;
using Customer_Tracking_System.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {

        Task<List<CustomerInterests>> GetCustomerByIdWithInterestsAsync(int customerId);
        Task<List<ProductComment>> GetCustomerByIdWithProductCommentsAsync(int customerId);
        Task<List<Order>> GetCustomerByIdWithOrderAsync(int customerId);
    }
}
