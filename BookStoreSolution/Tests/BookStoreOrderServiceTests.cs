using Application.DTOs;
using Application.Interfaces;
using Application.Services.BookStore;
using Domain.Entities.BookStore;
using Domain.Entities.OrderApi;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
	public class OrderServiceTests
	{
		private readonly Mock<IOrderCommunicator> _orderCommunicatorMock;
		private readonly Mock<IBookRepo> _bookRepoMock;
		private readonly OrderService _orderService;

		public OrderServiceTests()
		{
			_orderCommunicatorMock = new Mock<IOrderCommunicator>();
			_bookRepoMock = new Mock<IBookRepo>();
			_orderService = new OrderService(_orderCommunicatorMock.Object, _bookRepoMock.Object);
		}

		[Fact]
		public async Task CreateOrder_WithValidOrder_ReturnsSuccessResult()
		{
			// Arrange
			var order = new OrderDto { /* Valid order properties */ };
			_orderCommunicatorMock.Setup(x => x.CreateOrder(order)).ReturnsAsync(true);

			// Act
			var result = await _orderService.CreateOrder(order);

			// Assert
			Assert.IsType<SuccessResult>(result);
		}

		[Fact]
		public async Task CreateOrder_WithNullOrder_ReturnsErrorResult()
		{
			// Arrange
			OrderDto order = null;

			// Act
			var result = await _orderService.CreateOrder(order);

			// Assert
			Assert.IsType<ErrorResultDto>(result);
			Assert.Equal("No order given!", result.Message);
		}

		[Fact]
		public async Task CreateOrder_WhenOrderCreationFails_ReturnsErrorResult()
		{
			// Arrange
			var order = new OrderDto { /* Valid order properties */ };
			_orderCommunicatorMock.Setup(x => x.CreateOrder(order)).ReturnsAsync(false);

			// Act
			var result = await _orderService.CreateOrder(order);

			// Assert
			Assert.IsType<ErrorResultDto>(result);
			Assert.Equal("Unable to create order!", result.Message);
		}

		
		[Fact]
		public async Task GetCustomerOrders_WithZeroCustomerId_ReturnsErrorResult()
		{
			// Arrange
			int customerId = 0;

			// Act
			var result = await _orderService.GetCustomerOrders(customerId);

			// Assert
			Assert.IsType<ErrorResultDto>(result);
			Assert.Equal("No customerId provided!", result.Message);
		}

		// Add more tests for different scenarios, edge cases, and exceptions
	}

}
