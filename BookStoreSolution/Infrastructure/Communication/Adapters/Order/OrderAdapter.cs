using Application.DTOs;
using Infrastructure.Communication.Order;

namespace Infrastructure.Communication.Adapters.Order;

public static class OrderAdapter
{
	public static CreateOrderRequest ToOrderRequest(this OrderDto order)
	{
		return new CreateOrderRequest
		{
			ClientId = order.ClientId,
			OrderItems = order.OrderItems.Select(x => new OrderItems { ProductId = x.ProductId, Price = x.Price }).ToList(),
			OrderType = order.OrderType,
		};
	}
}