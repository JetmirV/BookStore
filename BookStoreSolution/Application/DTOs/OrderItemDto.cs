namespace Application.DTOs;

public class OrderItemDto : Base
{
	public int ProductId { get; set; }
	public decimal Price { get; set; }
}
