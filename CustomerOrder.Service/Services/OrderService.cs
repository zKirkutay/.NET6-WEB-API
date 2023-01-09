using AutoMapper;
using CustomerOrder.Core.DTOs;
using CustomerOrder.Core.Models;
using CustomerOrder.Core.Repositories;
using CustomerOrder.Core.Services;
using CustomerOrder.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;

namespace CustomerOrder.Service.Services
{
    public class OrderService : Service<Order, OrderDTO>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IGenericRepository<Order> repository, IUnitOfWork unitOfWork, IOrderRepository orderRepository, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDTO<List<OrderWithCustomerDTO>>> GetOrdersWithCustomerAsync()
        {
            var orders = await _orderRepository.GetOrdersWithCustomerAsync();
            var orderDTOs = _mapper.Map<List<OrderWithCustomerDTO>>(orders);
            return CustomResponseDTO<List<OrderWithCustomerDTO>>.Success(StatusCodes.Status200OK, orderDTOs);
        }
    }
}
