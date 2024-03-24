using AutoMapper;
using Customer_Tracking_System.Core.DTOs;
using Customer_Tracking_System.Core;
using Customer_Tracking_System.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Customer_Tracking_System.Core.Models;
using Customer_Tracking_System.API.Filters;

namespace Customer_Tracking_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ISellerService service;

        public SellerController(IMapper mapper, ISellerService service)
        {
            _mapper = mapper;
            this.service = service;
        }

        [HttpGet("[action]/{sellerId}")]
        public async Task<IActionResult> GetSellerByIdWithOrder(int sellerId)
        {

            return CreateIActionResult(await service.GetSellerByIdWithOrderAsync(sellerId));
        }

        [HttpGet("[action]/{sellerId}")]
        public async Task<IActionResult> GetSellerByIdWithProduct(int sellerId)
        {

            return CreateIActionResult(await service.GetSellerByIdWithProductAsync(sellerId));
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var sellers = await service.GetAllAsync();
            var sellerDtos = _mapper.Map<List<SellerDto>>(sellers.ToList());
            return CreateIActionResult(CustomResponseDto<List<SellerDto>>.Success(200, sellerDtos));
        }

        [ServiceFilter(typeof(NotFoundFilterUser<Seller>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var seller = await service.GetByIdAsync(id);
            var sellerDto = _mapper.Map<SellerDto>(seller);
            return CreateIActionResult(CustomResponseDto<SellerDto>.Success(200, sellerDto));
        }

        [HttpPost]
        public async Task<IActionResult> Add(SellerDto sellerDto)
        {
            var seller = await service.AddAsync(_mapper.Map<Seller>(sellerDto));
            seller.CreatedTime = DateTime.Now;
            seller.LastLoginDate = DateTime.Now;
            var sellerDtos = _mapper.Map<SellerDto>(seller);
            return CreateIActionResult(CustomResponseDto<SellerDto>.Success(201, sellerDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update(SellerUpdateDto sellerDto)
        {
            await service.UpdateAsync(_mapper.Map<Seller>(sellerDto));
            return CreateIActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var seller = await service.GetByIdAsync(id);
            await service.RemoveAsync(seller);
            return CreateIActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
