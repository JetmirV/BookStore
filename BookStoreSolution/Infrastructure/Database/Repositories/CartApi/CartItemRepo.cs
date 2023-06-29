using Application.Interfaces;
using Domain.Entities.CartApi;
using Infrastructure.Database.DbContexts.CartApi;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.CartApi;

public class CartItemRepo : ICartItemRepo
{
	private readonly CartApiDbContext _dbContext;

	public CartItemRepo(CartApiDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<List<CartItem>> GetAllCartItemsByCartId(int cartId)
	{
		try
		{
			return await _dbContext.CartItems.Where(x => x.CartId == cartId).ToListAsync();
		}
		catch (Exception)
		{
			return new List<CartItem>();
		}
	}

	public async Task<CartItem?> GetCartItemByCartIdAndProductId(int cartId, int productId)
	{
		try
		{
			return await _dbContext.CartItems.Where(x => x.CartId == cartId && x.ProductId == productId).FirstOrDefaultAsync();
		}
		catch (Exception)
		{
			return new CartItem();
		}
	}

	public async Task<bool> InsertCartItems(List<CartItem> carItems)
	{
		try
		{
			await _dbContext.CartItems.AddRangeAsync(carItems);

			return await _dbContext.SaveChangesAsync() > 0;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public async Task<bool> RemoveCartItem(CartItem carItem)
	{
		try
		{
			_dbContext.CartItems.Remove(carItem);

			return await _dbContext.SaveChangesAsync() > 0;
		}
		catch (Exception)
		{
			return false;
		}
	}
}
