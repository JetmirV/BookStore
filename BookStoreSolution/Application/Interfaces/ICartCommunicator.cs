using Application.DTOs;

namespace Application.Interfaces;

public interface ICartCommunicator
{
	Task<bool> AddProductToCart(CartDto addToCart);
	Task<bool> RemoveProductFromCart(CartDto addToCart);
}