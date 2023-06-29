using Application.Enums;

namespace Infrastructure.Communication.Order;

public class OrderResponse : CreateOrderRequest
{
	public int Id { get; set; }
	public OrderStatus Status { get; set; }
}
