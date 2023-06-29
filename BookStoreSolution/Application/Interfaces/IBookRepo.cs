using Domain.Entities.BookStore;

namespace Application.Interfaces;

public interface IBookRepo
{
	Task<List<Book>> GetAllBooks();
	Task<List<Book>> GetBookByIds(List<int> ids);
}
