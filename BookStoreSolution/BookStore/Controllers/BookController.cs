using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class BookController : Controller
{
	private readonly IBookService _bookService;

	public BookController(IBookService bookService)
	{
		_bookService = bookService;
	}

	[HttpGet]
	[Route("api/Product/GetBooks")]
	public async Task<ResultDto> GetProducts()
	{
		return await this._bookService.GetProducts();
	}
}
