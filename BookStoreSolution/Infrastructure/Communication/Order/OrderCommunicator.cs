using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Communication.Adapters.Order;
using Infrastructure.Communication.Common;

namespace Infrastructure.Communication.Order;

public class OrderCommunicator : IOrderCommunicator
{
	private readonly string BaseURL = "https://localhost:44334";

	private readonly IGenericRequestBuilder _genericRequestBuilder;

	public OrderCommunicator(IGenericRequestBuilder genericRequestBuilder)
	{
		_genericRequestBuilder = genericRequestBuilder;
	}

	public async Task<bool> CreateOrder(OrderDto orderRequest)
	{
		if (orderRequest == null)
			return false;

		var request = orderRequest.ToOrderRequest();

		var requestModel = new GenericRequestModel
		{
			Body = request,
			Method = "POST",
			Url = $"{BaseURL}/api/Order/Insert"
		};

		var result = await this._genericRequestBuilder.CreateRequest<String>(requestModel);

		return Convert.ToBoolean(result);
	}

	public async Task<List<OrderDto>> GetOrdersByClientId(int clientId)
	{
		var requestModel = new GenericRequestModel
		{
			Method = "GET",
			Url = $"{BaseURL}/api/order/{clientId}"
		};

		var result = await this._genericRequestBuilder.CreateRequest<List<OrderResponse>>(requestModel);

		return result.Select(x => new OrderDto
		{
			ClientId = x.ClientId,
			Status = x.Status,
			OrderItems = x.OrderItems.Select(y => new OrderItemDto { Price = y.Price, ProductId = y.ProductId }).ToList()
		}).ToList();
	}
}
