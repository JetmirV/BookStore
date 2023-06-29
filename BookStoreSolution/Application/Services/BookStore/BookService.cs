using Application.DTOs;
using Application.Enums;
using Application.Interfaces;

namespace Application.Services.BookStore;

public class BookService : IBookService
{
	private readonly IBookRepo _bookRepo;
	private readonly IGeneralLogRepo _generalLogRepo;

	public BookService(IBookRepo bookRepo, IGeneralLogRepo generalLogRepo)
	{
		_bookRepo = bookRepo;
		_generalLogRepo = generalLogRepo;
	}

	public async Task<BookDto> GetProductById(int id)
	{
		try
		{
			if (id == 0) return new BookDto();

			var product = await this._bookRepo.GetBookById(id);

			if (product == null) return new BookDto();

			return new BookDto
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description ?? string.Empty,
				Price = product.Price,
				ImgUrl = product.Picture,
				Code = product.Code,
				Quantity = product.Quantity
			};
		}
		catch (Exception ex)
		{
			_generalLogRepo.InsertGeneralLog(LogTypes.Error, $"BookService threw an exception while getting book: {ex.Message}");
			return new BookDto();
		}
	}

	public async Task<List<BookDto>> GetProducts()
	{
		try
		{
			var productsResult = new List<BookDto>();

			var products = await this._bookRepo.GetAllBooks();

			var productIds = products.Select(x => x.Id).ToList();

			products.ForEach(x =>
			{

				productsResult.Add(new BookDto
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description ?? string.Empty,
					Price = x.Price,
					ImgUrl = x.Picture,
					Code = x.Code,
					Quantity = x.Quantity
				});
			});

			return productsResult;
		}
		catch (Exception ex)
		{
			_generalLogRepo.InsertGeneralLog(LogTypes.Error, $"BookService threw an exception while getting books: {ex.Message}");
			return new List<BookDto>();
		}

	}
}
