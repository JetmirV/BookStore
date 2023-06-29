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

	public async void InsertGeneralLog(GeneralLog log)
	{
		await _dbContext.GeneralLogs.AddAsync(log);
	}
}
