using Application.DTOs;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<BookDto> GetProductById(int id);
        Task<List<BookDto>> GetProducts();
    }
}