using Application.Interfaces;
using Domain.Entities.AccountApi;
using Infrastructure.Database.DbContexts.AccountApi;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.AccountApi;

public class AccountRepo : IAccountRepo
{
	private readonly AccountApiDbContext _dbContext;

	public AccountRepo(AccountApiDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<int> InsertAccount(Account account)
	{
		try
		{
			await _dbContext.Accounts.AddAsync(account);

			await _dbContext.SaveChangesAsync();

			var lastInserted = await _dbContext.Addresses.OrderByDescending(x => x.Id).FirstOrDefaultAsync();

			await _dbContext.AccountLogs.AddAsync(CreateLog(account, lastInserted.Id));

			await _dbContext.SaveChangesAsync();

			return lastInserted.Id;
		}
		catch (Exception)
		{
			return 0;
		}
	}

	private AccountLog CreateLog(Account account, int id)
	{
		return new AccountLog
		{
			AccountId = id,
			FirstName = account.FirstName,
			LastName = account.LastName,
			AddressId = account.AddressId,
			Email = account.Email,
			InsertDateTime = DateTime.UtcNow,
		};
	}
}
