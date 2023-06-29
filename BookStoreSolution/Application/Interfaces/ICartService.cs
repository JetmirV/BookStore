using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICartService
    {
        Task AddToCart(AddToCartRequest request);
        Task<CartDto> GetCustomerCart(int customerId);
        Task RemoveFromCart(RemoveFromCartRequest request);
    }
}