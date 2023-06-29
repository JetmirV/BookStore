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

	public async Task<ResultDto> GetProductById(int id)
	{
		try
		{
			if (id == 0) return new ErrorResultDto("");

			var product = await this._bookRepo.GetBookByIds(new List<int> { id });

			if (product == null) return new ErrorResultDto("");

			var book = new BookDto
			{
				Id = product.FirstOrDefault().Id,
				Name = product.FirstOrDefault().Name,
				Description = product.FirstOrDefault().Description ?? string.Empty,
				Price = product.FirstOrDefault().Price,
				ImgUrl = product.FirstOrDefault().Picture,
				Code = product.FirstOrDefault().Code,
				Quantity = product.FirstOrDefault().Quantity
			};

			return new SuccessResult(book);
		}
		catch (Exception ex)
		{
			_generalLogRepo.InsertGeneralLog(LogTypes.Error, $"BookService threw an exception while getting book: {ex.Message}");
			return new ErrorResultDto("BookService threw an exception while getting book");
		}
	}

	public async Task<ResultDto> GetProducts()
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

			return new SuccessResult(productsResult);
		}
		catch (Exception ex)
		{
			_generalLogRepo.InsertGeneralLog(LogTypes.Error, $"BookService threw an exception while getting books: {ex.Message}");
			return new ErrorResultDto("BookService threw an exception while getting books");
		}

	}
}
