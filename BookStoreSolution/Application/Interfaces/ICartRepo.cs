using Domain.Entities.CartApi;

namespace Application.Interfaces;

public interface ICartRepo
{
	Task<bool> CreateCart(Cart cart);
	Task<Cart?> GetCustomerCartByCustomerId(int customerId);
}