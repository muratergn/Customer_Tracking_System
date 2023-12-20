using AutoMapper;
using Customer_Tracking_System.Core;
using Customer_Tracking_System.Core.DTOs;
using Customer_Tracking_System.Core.Models;
using Customer_Tracking_System.Core.Repositories;
using Customer_Tracking_System.Core.Services;
using Customer_Tracking_System.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Service.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IGenericRepository<Customer> genericRepository, IUnitOfWork unitOfWork, IMapper mapper, ICustomerRepository customerRepository) : base(genericRepository, unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<CustomerWithInterestDto>>> GetCustomerByIdWithInterestsAsync(int customerId)
        {
            var Interest = await _customerRepository.GetCustomerByIdWithInterestsAsync(customerId);
            var InterestList = _mapper.Map<List<CustomerWithInterestDto>>(Interest);

            int statusCode = 200;

            if (InterestList == null)
                statusCode = 204;

            return CustomResponseDto<List<CustomerWithInterestDto>>.Success(statusCode, InterestList);
        }

        public async Task<CustomResponseDto<List<CustomerWithOrderDto>>> GetCustomerByIdWithOrderAsync(int customerId)
        {
            var Order = await _customerRepository.GetCustomerByIdWithOrderAsync(customerId);
            var OrderList = _mapper.Map<List<CustomerWithOrderDto>>(Order);

            int statusCode = 200;

            if (OrderList == null)
                statusCode = 204;

            return CustomResponseDto<List<CustomerWithOrderDto>>.Success(statusCode, OrderList);
        }

        public async Task<CustomResponseDto<List<CustomerWithProductCommentDto>>> GetCustomerByIdWithProductCommentsAsync(int customerId)
        {
            var Comments = await _customerRepository.GetCustomerByIdWithProductCommentsAsync(customerId);
            var CommentList = _mapper.Map<List<CustomerWithProductCommentDto>>(Comments);

            int statusCode = 200;

            if (CommentList == null)
                statusCode = 204;

            return CustomResponseDto<List<CustomerWithProductCommentDto>>.Success(statusCode, CommentList);
        }
    }
}
