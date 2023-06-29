using Application.DTOs;
using Application.Services.BookStore;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class OrderController : Controller
{
	private readonly IBookStoreOrderService _bookStoreOrderService;

	public OrderController(IBookStoreOrderService bookStoreOrderService)
	{
		_bookStoreOrderService = bookStoreOrderService;
	}

	[HttpGet]
	[Route("api/order/getCustomerOrders/{customerId}")]
	public async Task<ResultDto> GetCustomerOrders(int customerId)
	{
		return await this._bookStoreOrderService.GetCustomerOrders(customerId);
	}

	[HttpPost]
	[Route("api/order/create")]
	public async Task<ResultDto> InsertOrder([FromBody] OrderDto order)
	{
		return await this._bookStoreOrderService.CreateOrder(order);
	}
}
