using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Communication.Adapters.Cart;
using Infrastructure.Communication.Common;

namespace Infrastructure.Communication.Cart;

public class CartCommunicator : ICartCommunicator
{
	private readonly string BaseURL = "https://localhost:44315";

	private readonly IGenericRequestBuilder _genericRequestBuilder;

	public CartCommunicator(IGenericRequestBuilder genericRequestBuilder)
	{
		_genericRequestBuilder = genericRequestBuilder;
	}

	public async Task<bool> AddProductToCart(CartDto addToCart)
	{
		if (addToCart == null)
			return false;

		var request = addToCart.ToAddToCartRequest();

		var requestModel = new GenericRequestModel
		{
			Body = request,
			Method = "POST",
			Url = $"{BaseURL}/api/cart/addtocart"
		};

		var result = await this._genericRequestBuilder.CreateRequest<String>(requestModel);

		return Convert.ToBoolean(result);
	}

	public async Task<bool> RemoveProductFromCart(CartDto addToCart)
	{
		if (addToCart == null)
			return false;

		var request = addToCart.ToRemoveFromCartRequest();

		var requestModel = new GenericRequestModel
		{
			Body = request,
			Method = "POST",
			Url = $"{BaseURL}/api/cart/removefromcart"
		};

		var result = await this._genericRequestBuilder.CreateRequest<String>(requestModel);

		return Convert.ToBoolean(result);
	}

}
