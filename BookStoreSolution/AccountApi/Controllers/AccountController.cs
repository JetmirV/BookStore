using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountApi.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpPost]
		[Route("api/Account/Insert")]
		public async Task<AccountDto> CreateAccount([FromBody] AccountRequestDto account)
		{
			return await this._accountService.CreateAccount(account);
		}
	}
}
