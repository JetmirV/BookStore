using Application.Interfaces;
using Domain.Entities.CartApi;
using Infrastructure.Database.DbContexts.CartApi;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.CartApi;

public class CartRepo : ICartRepo
{
	private readonly CartApiDbContext _dbContext;

	public CartRepo(CartApiDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Cart?> GetCustomerCartByCustomerId(int customerId)
	{
		try
		{
			return await _dbContext.Carts.Where(x => x.CustomerId == customerId).FirstOrDefaultAsync();
		}
		catch (Exception)
		{
			return new Cart();
		}
	}

	public async Task<bool> CreateCart(Cart cart)
	{
		try
		{
			await _dbContext.Carts.AddAsync(cart);

			var result = await _dbContext.SaveChangesAsync() > 0;

			var lastItemInserted = _dbContext.Carts.Last().Id;

			await _dbContext.CartLogs.AddAsync(CreateLog(cart, lastItemInserted));

			return result;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private CartLog CreateLog(Cart cart, int id)
	{
		return new CartLog
		{
			CartId = id,
			CustomerId = cart.CustomerId,
			InsertDateTime = DateTime.Now
		};
	}
}
