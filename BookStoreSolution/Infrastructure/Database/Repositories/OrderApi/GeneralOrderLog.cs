using Application.Interfaces;
using Domain.Entities.OrderApi;
using Infrastructure.Database.DbContexts.OrderApi;

namespace Infrastructure.Database.Repositories.OrderApi;

public class GeneralOrderLog : IGeneralOrderLog
{
	private readonly CartApiDbContext _dbContext;

	public GeneralOrderLog(CartApiDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async void InsertGeneralLog(GeneralLog log)
	{
		await _dbContext.GeneralLogs.AddAsync(log);
	}
}
