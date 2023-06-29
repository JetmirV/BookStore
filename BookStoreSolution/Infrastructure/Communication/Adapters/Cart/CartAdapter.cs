using Application.DTOs;

namespace Infrastructure.Communication.Adapters.Cart;

public static class CartAdapter
{
	public static AddToCartRequest ToAddToCartRequest(this CartDto cart)
	{
		return new AddToCartRequest
		{
			CustomerId = cart.CustomerId,
			ProductId = cart.CartItems.First().ProductId,
			ProductPrice = cart.CartItems.First().Price,
		};
	}

	public static RemoveFromCartRequest ToRemoveFromCartRequest(this CartDto cart)
	{
		return new RemoveFromCartRequest
		{
			CustomerId = cart.CustomerId,
			ProductId = cart.CartItems.First().ProductId,
		};
	}
}
