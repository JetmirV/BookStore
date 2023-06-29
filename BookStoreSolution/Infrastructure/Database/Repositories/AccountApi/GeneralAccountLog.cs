using Application.Interfaces;
using Domain.Entities.AccountApi;
using Infrastructure.Database.DbContexts.AccountApi;

namespace Infrastructure.Database.Repositories.AccountApi;

public class GeneralAccountLog : IGeneralAccountLog
{
	private readonly AccountApiDbContext _dbContext;

	public GeneralAccountLog(AccountApiDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async void InsertGeneralLog(GeneralLog log)
	{
		await _dbContext.GeneralLogs.AddAsync(log);
	}
}
