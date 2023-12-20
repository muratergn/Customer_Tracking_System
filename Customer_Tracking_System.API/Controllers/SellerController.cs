using AutoMapper;
using Customer_Tracking_System.Core.DTOs;
using Customer_Tracking_System.Core;
using Customer_Tracking_System.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Customer_Tracking_System.Core.Models;

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

        public async Task<IActionResult> All()
        {
            var customers = await service.GetAllAsync();
            var customerDtos = _mapper.Map<List<CustomerDto>>(customers.ToList());
            return CreateIActionResult(CustomResponseDto<List<CustomerDto>>.Success(200, customerDtos));
        }

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
            var sellerDtos = _mapper.Map<SellerDto>(seller);
            return CreateIActionResult(CustomResponseDto<SellerDto>.Success(201, sellerDtos));
        }
        /*----------------------------------------will continue-----------------------------*/
        [HttpPut]
        public async Task<IActionResult> Update(CustomerUpdateDto customerDto)
        {
            await service.UpdateAsync(_mapper.Map<Customer>(customerDto));
            return CreateIActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var customer = await service.GetByIdAsync(id);
            await service.RemoveAsync(customer);
            return CreateIActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
