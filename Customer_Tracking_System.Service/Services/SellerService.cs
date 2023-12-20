using AutoMapper;
using Customer_Tracking_System.Core.DTOs;
using Customer_Tracking_System.Core.Models;
using Customer_Tracking_System.Core.Repositories;
using Customer_Tracking_System.Core.Services;
using Customer_Tracking_System.Core.UnitOfWork;
using Customer_Tracking_System.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Service.Services
{
    public class SellerService : Service<Seller>, ISellerService
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;

        public SellerService(IGenericRepository<Seller> genericRepository, IUnitOfWork unitOfWork, IMapper mapper, ISellerRepository sellerRepository) : base(genericRepository, unitOfWork)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<CustomerWithOrderDto>>> GetSellerByIdWithOrderAsync(int sellerId)
        {
            var Order = await _sellerRepository.GetSellerByIdWithOrderAsync(sellerId);
            var OrderList = _mapper.Map<List<CustomerWithOrderDto>>(Order);

            int statusCode = 200;

            if (OrderList == null)
                statusCode = 204;

            return CustomResponseDto<List<CustomerWithOrderDto>>.Success(statusCode, OrderList);
        }

        public async Task<CustomResponseDto<List<SellerWithProductDto>>> GetSellerByIdWithProductAsync(int sellerId)
        {
            var Order = await _sellerRepository.GetSellerByIdWithProductAsync(sellerId);
            var OrderList = _mapper.Map<List<SellerWithProductDto>>(Order);

            int statusCode = 200;

            if (OrderList == null)
                statusCode = 204;

            return CustomResponseDto<List<SellerWithProductDto>>.Success(statusCode, OrderList);
        }
    }
}
