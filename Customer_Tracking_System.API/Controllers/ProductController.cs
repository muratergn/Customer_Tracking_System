using AutoMapper;
using Customer_Tracking_System.Core.Services;
using Customer_Tracking_System.Core;
using Customer_Tracking_System.Core.Models;
using Customer_Tracking_System.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Tracking_System.API.Controllers
{
    public class ProductController :  CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService service;

        public ProductController(IMapper mapper, IProductService service)
        {
            _mapper = mapper;
            this.service = service;
        }

        [HttpGet("[action]/{productId}")]
        public async Task<IActionResult> GetProductByIdWithOrder(int productId)
        {

            return CreateIActionResult(await service.GetProductByIdWithOrderAsync(productId));
        }

        [HttpGet("[action]/{productId}")]
        public async Task<IActionResult> GetProductByIdWithProductComment(int productId)
        {

            return CreateIActionResult(await service.GetProductByIdWithProductCommentsAsync(productId));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await service.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateIActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var product = await service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateIActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto productDto)
        {
            var product = await service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateIActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await service.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateIActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await service.GetByIdAsync(id);
            await service.RemoveAsync(product);
            return CreateIActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
