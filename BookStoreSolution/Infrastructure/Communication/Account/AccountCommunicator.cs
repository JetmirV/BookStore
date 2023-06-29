using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Communication.Adapters.Account;
using Infrastructure.Communication.Common;

namespace Infrastructure.Communication.Account;

public class AccountCommunicator : IAccountCommunicator
{
	private readonly string BaseURL = "https://localhost:44342";

	private readonly IGenericRequestBuilder _genericRequestBuilder;

	public AccountCommunicator(IGenericRequestBuilder genericRequestBuilder)
	{
		_genericRequestBuilder = genericRequestBuilder;
	}

	public async Task<AccountResponseDto> CreateAccount(AccountRequestDto accountRequest)
	{
		if (accountRequest == null)
			return new AccountResponseDto { Status = "Failed" };

		var request = accountRequest.ToAccountRequest();

		var requestModel = new GenericRequestModel
		{
			Body = request,
			Method = "POST",
			Url = $"{BaseURL}/api/Order/Insert"
		};

		var result = await this._genericRequestBuilder.CreateRequest<AccountResponseDto>(requestModel);

		return result;
	}
}
