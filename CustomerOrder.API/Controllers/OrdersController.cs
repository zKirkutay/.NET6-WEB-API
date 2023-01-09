using CustomerOrder.API.Filters;
using CustomerOrder.Core.DTOs;
using CustomerOrder.Core.Models;
using CustomerOrder.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrder.API.Controllers
{
    public class OrdersController : CustomBaseController
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService orderService)
        {
            _service = orderService;
        }


        /// <summary>
        /// Get  Orders With Customer
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetOrdersWithCustomer")]
        public async Task<IActionResult> GetOrdersWithCustomer()
        {
            return CreateActionResult(await _service.GetOrdersWithCustomerAsync());
        }

        /// <summary>
        /// To List All Orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _service.GetAllAsync());
        }


        /// <summary>
        /// To List By OrderId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ServiceFilter(typeof(NotFoundFilter<Order, OrderDTO>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _service.GetByIdAsync(id));
        }

        /// <summary>
        /// To Add a New Order
        /// </summary>
        /// <param name="orderDTo"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> Save(OrderDTO orderDTo)
        {
            return CreateActionResult(await _service.AddAsync(orderDTo));
        }

        /// <summary>
        /// To Update a Order
        /// </summary>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<IActionResult> Update(OrderDTO orderDto)
        {
            return CreateActionResult(await _service.UpdateAsync(orderDto));
        }

        /// <summary>
        /// To Remove a Order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ServiceFilter(typeof(NotFoundFilter<Order, OrderDTO>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _service.RemoveAsync(id));
        }
    }
}
