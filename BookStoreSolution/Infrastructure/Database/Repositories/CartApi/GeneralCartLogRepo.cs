using Application.Enums;
using Application.Interfaces;
using Domain.Entities.CartApi;
using Infrastructure.Database.DbContexts.CartApi;

namespace Infrastructure.Database.Repositories.CartApi;

public class GeneralCartLogRepo : IGeneralCartLogRepo
{
	private readonly CartApiDbContext _dbContext;

	public GeneralCartLogRepo(CartApiDbContext dbContext)
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
