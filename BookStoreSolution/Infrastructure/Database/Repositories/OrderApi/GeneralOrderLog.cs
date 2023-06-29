using Application.Enums;
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

	public async void InsertGeneralLog(LogTypes logType, string logData)
	{
		var log = new GeneralLog
		{
			LogType = logType.ToString(),
			LogData = logData,
			InsertDateTime = DateTime.Now,
		};

		await _dbContext.GeneralLogs.AddAsync(log);
	}
}
