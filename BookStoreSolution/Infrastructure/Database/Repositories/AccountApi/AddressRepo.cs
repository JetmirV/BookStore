using Application.Interfaces;
using Domain.Entities.AccountApi;
using Infrastructure.Database.DbContexts.AccountApi;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.AccountApi;

public class AddressRepo : IAddressRepo
{
	private readonly AccountApiDbContext _dbContext;

	public AddressRepo(AccountApiDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<int> InsertAddress(Address address)
	{
		try
		{
			await _dbContext.Addresses.AddAsync(address);

			await _dbContext.SaveChangesAsync();

			var lastInserted = await _dbContext.Addresses.OrderByDescending(x=>x.Id).FirstOrDefaultAsync();

			return lastInserted.Id;
		}
		catch (Exception)
		{
			return 0;
		}
	}
}
