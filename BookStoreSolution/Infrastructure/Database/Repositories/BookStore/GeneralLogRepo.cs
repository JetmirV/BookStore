using Application.Enums;
using Application.Interfaces;
using Domain.Entities.BookStore;
using Infrastructure.Database.DbContexts.BookStore;

namespace Infrastructure.Database.Repositories.BookStore;

public class GeneralLogRepo : IGeneralLogRepo
{
	private readonly BookStoreApiDbContext _dbContext;

	public GeneralLogRepo(BookStoreApiDbContext dbContext)
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
