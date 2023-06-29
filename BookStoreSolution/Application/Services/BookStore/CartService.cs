using Application.DTOs;
using Application.Interfaces;

namespace Application.Services.BookStore;

public class CartService : IBookStoreCartService
{
	private readonly ICartCommunicator _communicator;

	public CartService(ICartCommunicator communicator)
	{
		_communicator = communicator;
	}

	public async Task<ResultDto> AddProductToCart(int customerId, int productId, decimal productPrice)
	{
		if (customerId == 0 || productId == 0 || productPrice <= 0)
			return new ErrorResultDto("Unable to add to cart, some of the data not valid");

		var addToCartRequest = new CartDto
		{
			CustomerId = customerId,
			CartItems = new List<CartItemsDto>
			{
				new CartItemsDto
				{
					Price = productPrice,
					ProductId = productId,
				}
			}
		};

		var result = await _communicator.AddProductToCart(addToCartRequest);

		return new ResultDto { Message = result ? "Adding product to cart.." : "Unable to add product" };
	}

	public async Task<ResultDto> RemoveProductFromCart(int customerId, int productId)
	{
		if (customerId == 0 || productId == 0)
			return new ErrorResultDto("Unable to remove to cart, some of the data not valid");

		var removeFromCartRequest = new CartDto
		{
			CustomerId = customerId,
			CartItems = new List<CartItemsDto>
			{
				new CartItemsDto
				{
					ProductId = productId,
				}
			}
		};

		var result = await _communicator.RemoveProductFromCart(removeFromCartRequest);

		return new ResultDto { Message = result ? "Removing product from cart.." : "Unable to remove!" };
	}

}
