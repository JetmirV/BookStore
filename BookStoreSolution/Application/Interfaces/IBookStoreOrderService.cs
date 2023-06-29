using Application.DTOs;

namespace Application.Services.BookStore
{
	public interface IBookStoreOrderService
	{
		Task<ResultDto> CreateOrder(OrderDto order);
		Task<ResultDto> GetCustomerOrders(int customerId);
	}
}