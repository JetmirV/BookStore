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

	public async void InsertGeneralLog(GeneralLog log)
	{
		await _dbContext.GeneralLogs.AddAsync(log);
	}
}
