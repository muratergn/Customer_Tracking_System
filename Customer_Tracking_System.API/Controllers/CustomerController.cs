using AutoMapper;
using Customer_Tracking_System.Core;
using Customer_Tracking_System.Core.DTOs;
using Customer_Tracking_System.Core.Models;
using Customer_Tracking_System.Core.Services;
using Customer_Tracking_System.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Tracking_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService service;

        public CustomerController(IMapper mapper, ICustomerService service)
        {
            _mapper = mapper;
            this.service = service;
        }

        [HttpGet("[action]/{customerId}")]
        public async Task<IActionResult> GetCustomerByIdWithInterests(int customerId)
        {

            return CreateIActionResult(await service.GetCustomerByIdWithInterestsAsync(customerId));
        }

        [HttpGet("[action]/{customerId}")]
        public async Task<IActionResult> GetCustomerByIdWithOrder(int customerId)
        {

            return CreateIActionResult(await service.GetCustomerByIdWithOrderAsync(customerId));
        }

        [HttpGet]
        public async Task<IActionResult> All() 
        {
            var customers = await service.GetAllAsync();
            var customerDtos = _mapper.Map<List<CustomerDto>>(customers.ToList());
            return CreateIActionResult(CustomResponseDto<List<CustomerDto>>.Success(200, customerDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var customer = await service.GetByIdAsync(id);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return CreateIActionResult(CustomResponseDto<CustomerDto>.Success(200, customerDto));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomerDto customerDto)
        {
            var customer = await service.AddAsync(_mapper.Map<Customer>(customerDto));
            var customersDto = _mapper.Map<CustomerDto>(customer);
            return CreateIActionResult(CustomResponseDto<CustomerDto>.Success(201, customersDto));
        }

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
