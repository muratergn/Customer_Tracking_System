using AutoMapper;
using Customer_Tracking_System.Core;
using Customer_Tracking_System.Core.DTOs;
using Customer_Tracking_System.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<CustomerInterests, CustomerInterestsDto>().ReverseMap();
            CreateMap<ProductComment, ProductCommentDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Customer, CustomerWithInterestDto>();
            CreateMap<Customer, CustomerWithOrderDto>();
            CreateMap<Customer, CustomerWithProductCommentDto>();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CustomerWithOrderDto>();
            CreateMap<Product, CustomerWithProductCommentDto>();
            CreateMap<Seller, SellerDto>().ReverseMap();
            CreateMap<Seller, CustomerWithOrderDto>();
            CreateMap<List<Order>, CustomerWithOrderDto>();
            CreateMap<List<Product>, SellerWithProductDto>();
            CreateMap<SellerUpdateDto, Seller>();

        }
    }
}
