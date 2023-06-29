using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities.BookStore;
using Infrastructure.Database.DbContexts.BookStore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories.BookStore;

public class BookRepo : IBookRepo
{
	private readonly BookStoreApiDbContext _dbContext;

	public BookRepo(BookStoreApiDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<List<Book>> GetAllBooks()
	{
		try
		{
			return await _dbContext.Books.Where(x => x.Id >= 0).ToListAsync();
		}
		catch (Exception ex)
		{
			throw new DataFetchException(ex.Message);
		}
	}

	public async Task<List<Book>> GetBookByIds(List<int> ids)
	{
		try
		{
			return await _dbContext.Books.Where(x => ids.Contains(x.Id)).ToListAsync();
		}
		catch (Exception ex)
		{
			throw new DataFetchException(ex.Message);
		}
	}

}
