using Application.DTOs;

namespace Application.Services.BookStore
{
	public interface IBookStoreCartService
	{
		Task<ResultDto> AddProductToCart(int customerId, int productId, decimal productPrice);
		Task<ResultDto> RemoveProductFromCart(int customerId, int productId);
	}
}