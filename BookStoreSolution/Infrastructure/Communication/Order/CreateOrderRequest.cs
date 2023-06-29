using Application.Enums;

namespace Infrastructure.Communication.Order;

public class CreateOrderRequest
{
	public int ClientId { get; set; }
	public List<OrderItems> OrderItems { get; set; }
    public OrderType OrderType { get; set; }
}

public class OrderItems
{
	public int ProductId { get; set; }
	public decimal Price { get; set; }
}