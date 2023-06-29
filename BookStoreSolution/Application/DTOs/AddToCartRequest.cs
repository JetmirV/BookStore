namespace Application.DTOs;

public class AddToCartRequest
{
	public int CustomerId { get; set; }
	public int ProductId { get; set; }
	public decimal ProductPrice { get; set; }
}
