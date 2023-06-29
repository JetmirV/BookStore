using Domain.Entities.CartApi;

namespace Application.Interfaces;

public interface ICartItemRepo
{
	Task<List<CartItem>> GetAllCartItemsByCartId(int cartId);
	Task<CartItem?> GetCartItemByCartIdAndProductId(int cartId, int productId);
	Task<bool> InsertCartItems(List<CartItem> carItems);
	Task<bool> RemoveCartItem(CartItem carItem);
}