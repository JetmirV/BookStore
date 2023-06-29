using Application.DTOs;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<ResultDto> GetProductById(int id);
        Task<ResultDto> GetProducts();
    }
}