using AutoMapper;
using CustomerOrder.Core.DTOs;
using CustomerOrder.Core.Models;

namespace CustomerOrder.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Order, OrderWithCustomerDTO>();
        }
    }
}
