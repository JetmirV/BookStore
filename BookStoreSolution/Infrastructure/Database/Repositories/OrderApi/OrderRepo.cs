using Application.Interfaces;
using Domain.Entities.OrderApi;
using Infrastructure.Database.DbContexts.OrderApi;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.OrderApi;

public class OrderRepo : IOrderRepo
{
	private readonly CartApiDbContext _dbContext;

	public OrderRepo(CartApiDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<List<Order>> GetAllOrders()
	{
		try
		{
			return await _dbContext.Orders.Where(x => x.Id > 0).ToListAsync();
		}
		catch (Exception)
		{
			return new List<Order>();
		}
	}

	public async Task<Order?> GetOrderById(int id)
	{
		try
		{
			return await _dbContext.Orders.Where(x => x.Id == id).FirstOrDefaultAsync();
		}
		catch (Exception)
		{
			return new Order();
		}
	}

	public async Task<List<Order>> GetOrderByClientId(int clientId)
	{
		try
		{
			return await _dbContext.Orders.Where(x => x.ClientId == clientId).ToListAsync();
		}
		catch (Exception)
		{
			return new List<Order>();
		}
	}

	public async Task<bool> InsertOrder(Order order)
	{
		try
		{
			await _dbContext.Orders.AddAsync(order);

			var result = await _dbContext.SaveChangesAsync() > 0;

			var lastItemInserted = _dbContext.Orders.Last().Id;

			await _dbContext.OrderLogs.AddAsync(CreateLog(order, lastItemInserted));

			await _dbContext.SaveChangesAsync();

			return result;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private OrderLog CreateLog(Order order, int Id)
	{
		return new OrderLog
		{
			OrderId = Id,
			ClientId = order.ClientId,
			Status = order.Status,
			InsertDateTime = DateTime.Now
		};
	}
}
