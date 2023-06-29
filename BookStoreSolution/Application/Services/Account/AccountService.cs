using Application.DTOs;
using Application.Enums;
using Application.Interfaces;
using Domain.Entities.AccountApi;

namespace Application.Services.Account;

public class AccountService : IAccountService
{
	private readonly IAccountRepo _accountRepo;
	private readonly IAddressRepo _addressRepo;
	private readonly IGeneralAccountLog _generalAccountLog;

	public AccountService(IAccountRepo accountRepo, IAddressRepo addressRepo, IGeneralAccountLog generalAccountLog)
	{
		_accountRepo = accountRepo;
		_addressRepo = addressRepo;
		_generalAccountLog = generalAccountLog;
	}

	public async Task<AccountDto> CreateAccount(AccountRequestDto request)
	{
		try
		{
			if (request == null)
				return new AccountDto { Id = 0, Message = "Request was null", Status = "Failed" };

			var address = new Address
			{
				Address1 = request.Address1,
				City = request.City,
				Country = request.Country,
			};

			var addressId = await _addressRepo.InsertAddress(address);

			if (addressId == 0)
				return new AccountDto { Id = 0, Message = "Error inserting address", Status = "Failed" };

			var account = new Domain.Entities.AccountApi.Account
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				AddressId = addressId,
				CreateDateTime = DateTime.UtcNow,
				UpdateDateTime = DateTime.UtcNow,
			};

			var accountId = await _accountRepo.InsertAccount(account);

			return new AccountDto { Id = accountId, Message = "Success", Status = "Success" };
		}
		catch (Exception ex)
		{
			_generalAccountLog.InsertGeneralLog(LogTypes.Error, $"AccountService threw an exception while creating an account: {ex.Message}");
			return new AccountDto { Id = 0, Message = "Failed", Status = "Failed" };
		}
	}
}
