using Application.Interfaces;
using Domain.Entities.OrderApi;
using Infrastructure.Database.DbContexts.OrderApi;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.OrderApi;

public class OrderItemRepo : IOrderItemRepo
{
	private readonly CartApiDbContext _dbContext;

	public OrderItemRepo(CartApiDbContext orderApiDbContext)
	{
		_dbContext = orderApiDbContext;
	}

	public async Task<List<OrderItem>> GetAllOrderItemsByOrderIds(List<int> orderIds)
	{
		try
		{
			return await _dbContext.OrderItems.Where(x => orderIds.Contains(x.OrderId)).ToListAsync();
		}
		catch (Exception)
		{
			return new List<OrderItem>();
		}
	}

	public async Task<bool> InsertOrderItems(List<OrderItem> orderItems)
	{
		try
		{
			await _dbContext.OrderItems.AddRangeAsync(orderItems);

			return await _dbContext.SaveChangesAsync() > 0;
		}
		catch (Exception)
		{
			return false;
		}
	}

}
