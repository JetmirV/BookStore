using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

public class AccountController : Controller
{
	private readonly IBookStoreAccountService _bookStoreAccountService;

	public AccountController(IBookStoreAccountService bookStoreAccountService)
	{
		_bookStoreAccountService = bookStoreAccountService;
	}

	[HttpPost]
	[Route("api/account/create")]
	public async Task<ResultDto> InsertAccount([FromBody] AccountRequestDto account)
	{
		return await this._bookStoreAccountService.CreateAccount(account);
	}
}
