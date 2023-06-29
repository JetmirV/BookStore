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

	public async Task<Book?> GetBookById(int id)
	{
		try
		{
			return await _dbContext.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
		}
		catch (Exception ex)
		{
			throw new DataFetchException(ex.Message);
		}
	}

}
