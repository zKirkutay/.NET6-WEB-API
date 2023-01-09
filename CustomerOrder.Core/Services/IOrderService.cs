using CustomerOrder.Core.DTOs;
using CustomerOrder.Core.Models;

namespace CustomerOrder.Core.Services
{
    public interface IOrderService : IService<Order, OrderDTO>
    {
        Task<CustomResponseDTO<List<OrderWithCustomerDTO>>> GetOrdersWithCustomerAsync();
    }
}
