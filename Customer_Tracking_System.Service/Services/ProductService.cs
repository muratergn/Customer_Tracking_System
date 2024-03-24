using Customer_Tracking_System.Core.Services;
using Customer_Tracking_System.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer_Tracking_System.Core.Models;
using AutoMapper;
using Customer_Tracking_System.Core.Repositories;
using Customer_Tracking_System.Core.UnitOfWork;
using Customer_Tracking_System.Core.DTOs;
using Customer_Tracking_System.Repository.Repositories;

namespace Customer_Tracking_System.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> genericRepository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(genericRepository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CustomerWithOrderDto>> GetProductByIdWithOrderAsync(int productId)
        {
            var Order = await _productRepository.GetProductByIdWithOrderAsync(productId);
            var OrderList = _mapper.Map<CustomerWithOrderDto>(Order);

            int statusCode = 200;

            if (OrderList == null)
                statusCode = 204;

            return CustomResponseDto<CustomerWithOrderDto>.Success(statusCode, OrderList);
        }

        public async Task<CustomResponseDto<CustomerWithProductCommentDto>> GetProductByIdWithProductCommentsAsync(int productId)
        {
            var Comments = await _productRepository.GetProductByIdWithProductCommentsAsync(productId);
            var CommentList = _mapper.Map<CustomerWithProductCommentDto>(Comments);

            int statusCode = 200;

            if (CommentList == null)
                statusCode = 204;

            return CustomResponseDto<CustomerWithProductCommentDto>.Success(statusCode, CommentList);
        }
    }
}
