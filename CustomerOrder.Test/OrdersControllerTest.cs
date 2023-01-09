using AutoFixture;
using AutoFixture.Xunit2;
using CustomerOrder.API.Controllers;
using CustomerOrder.Core.DTOs;
using CustomerOrder.Core.Models;
using CustomerOrder.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerOrder.Test
{
    public class OrdersControllerTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<IOrderService> _mockRepo;
        private readonly OrdersController _controller;
        public OrdersControllerTest()
        {
            _fixture = new Fixture();
            _mockRepo = new Mock<IOrderService>();
            _controller = new OrdersController(_mockRepo.Object);
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
        }

        [Fact]
        public async void GetAll_ActionExecutes_ReturnResult()
        {
            CustomResponseDTO<IEnumerable<OrderDTO>> ordersDtos = _fixture.Build<CustomResponseDTO<IEnumerable<OrderDTO>>>().With(x => x.StatusCode, StatusCodes.Status200OK).Without(x => x.Errors).Create();

            _mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(ordersDtos);

            var response = await _controller.GetAll();

            var actionResult = Assert.IsType<ObjectResult>(response);

            var returnOrder = Assert.IsAssignableFrom<CustomResponseDTO<IEnumerable<OrderDTO>>>(actionResult.Value);

            Assert.NotNull(returnOrder.Data);

        }

        [Theory, AutoData]
        public async void GetById_ReturnNotFound(int orderId)
        {
            CustomResponseDTO<OrderDTO> order = _fixture.Build<CustomResponseDTO<OrderDTO>>().With(x => x.StatusCode, StatusCodes.Status200OK).Without(x => x.Errors).Without(x => x.Data).Create();

            _mockRepo.Setup(x => x.GetByIdAsync(orderId)).ReturnsAsync(order);

            var result = await _controller.GetById(orderId);

            var actionResult = Assert.IsType<ObjectResult>(result);

            var returnOrder = Assert.IsAssignableFrom<CustomResponseDTO<OrderDTO>>(actionResult.Value);

            Assert.Null(returnOrder.Data);
        }

        [Theory, AutoData]
        public async void GetById_ReturnResult(int orderId)
        {
            var createdResultObject = _fixture.Build<CustomResponseDTO<OrderDTO>>().With(d => d.StatusCode, StatusCodes.Status200OK).Without(x => x.Errors).Create();

            _mockRepo.Setup(x => x.GetByIdAsync(orderId)).ReturnsAsync(createdResultObject);

            var result = await _controller.GetById(orderId);

            var actionResult = Assert.IsType<ObjectResult>(result);

            var returnOrder = Assert.IsAssignableFrom<CustomResponseDTO<OrderDTO>>(actionResult.Value);

            Assert.NotNull(returnOrder.Data);
        }

        [Theory, AutoData]
        public void PutOrder_ActionExecutes_ReturnNoContentResult(OrderDTO ordersDto)
        {
            _mockRepo.Setup(x => x.UpdateAsync(ordersDto));

            var result = _controller.Update(ordersDto);

            var actionResult = Assert.IsType<ObjectResult>(result.Result);

            Assert.Equal((int)HttpStatusCode.OK, actionResult.StatusCode);
        }

        [Theory, AutoData]
        public async void PostOrder_ActionExecutes_ReturnCreatedAtAction(OrderDTO orderDTO)
        {
            var createdResultObject = _fixture.Build<CustomResponseDTO<OrderDTO>>().With(d => d.StatusCode, StatusCodes.Status201Created).Without(x => x.Errors).Create();

            _mockRepo.Setup(x => x.AddAsync(orderDTO)).ReturnsAsync(createdResultObject);

            var result = await _controller.Save(orderDTO);

            var actionResult = Assert.IsType<ObjectResult>(result);

            var returnOrder = Assert.IsAssignableFrom<CustomResponseDTO<OrderDTO>>(actionResult.Value);

            Assert.Equal((int)HttpStatusCode.Created, returnOrder.StatusCode);

        }

        [Theory, AutoData]
        public async void DeleteOrder_ActionExecute_ReturnOkResult(int id)
        {
            _mockRepo.Setup(x => x.RemoveAsync(id));

            var result = await _controller.Remove(id);

            var actionResult = Assert.IsType<ObjectResult>(result);

            Assert.Equal((int)HttpStatusCode.OK, actionResult.StatusCode);
        }
    }
}
