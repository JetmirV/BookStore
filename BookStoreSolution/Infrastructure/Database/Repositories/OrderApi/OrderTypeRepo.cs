using Application.Interfaces;
using Domain.Entities.OrderApi;
using Infrastructure.Database.DbContexts.OrderApi;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.OrderApi;

public class OrderTypeRepo : IOrderTypeRepo
{
	private readonly CartApiDbContext _dbContext;

	public OrderTypeRepo(CartApiDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<OrderType?> GetOrderTypeByName(string orderType)
	{
		try
		{
			return await _dbContext.OrderTypes.Where(x => x.Type == orderType).FirstOrDefaultAsync();
		}
		catch (Exception)
		{
			return new OrderType();
		}
	}
}
