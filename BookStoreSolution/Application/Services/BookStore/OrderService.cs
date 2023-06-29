using Application.DTOs;
using Application.Interfaces;

namespace Application.Services.BookStore;

public class OrderService : IBookStoreOrderService
{
	private readonly IOrderCommunicator _orderCommunicator;
	private readonly IBookRepo _bookRepo;

	public OrderService(IOrderCommunicator orderCommunicator, IBookRepo bookRepo)
	{
		_orderCommunicator = orderCommunicator;
		_bookRepo = bookRepo;
	}

	public async Task<ResultDto> CreateOrder(OrderDto order)
	{
		if (order == null) return new ErrorResultDto("No order given!");

		var result = await this._orderCommunicator.CreateOrder(order);

		if (result)
			return new SuccessResult(result);

		return new ErrorResultDto("Unable to create order!");
	}

	public async Task<ResultDto> GetCustomerOrders(int customerId)
	{
		if (customerId == 0)
			return new ErrorResultDto("No customerId provided!");

		var orders = await this._orderCommunicator.GetOrdersByClientId(customerId);

		var productIds = orders.SelectMany(x => x.OrderItems.Select(x => x.ProductId)).ToList();

		var products = await this._bookRepo.GetBookByIds(productIds);
		var productNameDictionary = products.GroupBy(x => x.Id).ToDictionary(x => x.Key, y => $"{y.FirstOrDefault()?.Name}");

		var result = orders.Select(x => new OrderDto
		{
			ClientId = customerId,
			Status = x.Status,
			OrderItems = x.OrderItems.Select(y => new OrderItemDto
			{
				Price = y.Price,
				ProductId = y.ProductId,
			}).ToList()
		}).ToList();

		return new SuccessResult(result);
	}
}
