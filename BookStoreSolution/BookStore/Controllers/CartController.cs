using Application.DTOs;
using Application.Services.BookStore;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class CartController : Controller
{
	private readonly IBookStoreCartService _bookStoreCartService;

	public CartController(IBookStoreCartService bookStoreCartService)
	{
		_bookStoreCartService = bookStoreCartService;
	}

	[HttpPost]
	[Route("api/Cart/AddItem")]
	public async Task<ResultDto> AddCartItem(int customerId, int productId, decimal productPrice)
	{
		return await _bookStoreCartService.AddProductToCart(customerId, productId, productPrice);
	}

	[HttpPut]
	[Route("api/Cart/RemoveItem")]
	public async Task<ResultDto> RemoveCartItem(int customerId, int productId)
	{
		return await _bookStoreCartService.RemoveProductFromCart(customerId, productId);
	}
}
