using Application.DTOs;
using Application.Interfaces;

namespace Application.Services.BookStore;

public class AccountService : IBookStoreAccountService
{
	private readonly IAccountCommunicator _accountCommunicator;

	public AccountService(IAccountCommunicator accountCommunicator)
	{
		_accountCommunicator = accountCommunicator;
	}

	public async Task<ResultDto> CreateAccount(AccountRequestDto request)
	{
		if (request == null)
			return new ErrorResultDto("Unable to create account");

		var result = await _accountCommunicator.CreateAccount(request);

		return result.Id != 0 ? new SuccessResult(result) : new ErrorResultDto("Unable to create account");
	}
}
