using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CartApi.Controllers;

public class CartController : Controller
{
	private readonly ICartService _cartService;

	public CartController(ICartService cartService)
	{
		_cartService = cartService;
	}

	[HttpPost]
	[Route("api/cart/addtocart")]
	public async Task AddToCart(AddToCartRequest request)
	{
		await this._cartService.AddToCart(request);
	}

	[HttpPost]
	[Route("api/cart/removefromcart")]
	public async Task RemoveFromCart(RemoveFromCartRequest request)
	{
		await this._cartService.RemoveFromCart(request);
	}
}
