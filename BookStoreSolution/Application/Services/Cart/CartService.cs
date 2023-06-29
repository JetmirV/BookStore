using Application.DTOs;
using Application.Enums;
using Application.Interfaces;
using Domain.Entities.CartApi;
using Newtonsoft.Json;

namespace Application.Services.Cart;

public class CartService : ICartService
{
    private readonly ICartRepo _cartRepo;
    private readonly ICartItemRepo _cartItemsRepo;
    private readonly IGeneralCartLogRepo _generalCartLogRepo;

    public CartService(ICartRepo cartRepo, ICartItemRepo cartItemsRepo, IGeneralCartLogRepo generalCartLogRepo)
    {
        _cartRepo = cartRepo;
        _cartItemsRepo = cartItemsRepo;
        _generalCartLogRepo = generalCartLogRepo;
    }

    public async Task<CartDto> GetCustomerCart(int customerId)
    {
        try
        {
            if (customerId == 0)
                return new CartDto();

            var cart = await _cartRepo.GetCustomerCartByCustomerId(customerId);

            if (cart == null)
                return new CartDto();

            var cartItems = await _cartItemsRepo.GetAllCartItemsByCartId(cart.Id);

            if (cartItems.Count == 0)
                return new CartDto();

            return new CartDto
            {
                Id = cart.Id,
                CustomerId = cart.CustomerId,
                CartItems = cartItems.Select(x => new CartItemsDto { Price = x.Price, ProductId = x.ProductId }).ToList()
            };
        }
        catch (Exception ex)
        {
            _generalCartLogRepo.InsertGeneralLog(LogTypes.Error, $"CartService threw an exception while getting customer cart: {ex.Message}");
            return new CartDto();
        }
    }

    public async Task AddToCart(AddToCartRequest request)
    {
        try
        {
            if (request.CustomerId != 0 && request.ProductId != 0 && request.ProductPrice > 0)
            {
                var currentCustomerCart = await _cartRepo.GetCustomerCartByCustomerId(request.CustomerId);

                if (currentCustomerCart == null)
                {
                    var newCart = new Domain.Entities.CartApi.Cart
                    {
                        CustomerId = request.CustomerId,
                        CreateDateTime = DateTime.Now
                    };

                    var created = await _cartRepo.CreateCart(newCart);

                    if (created)
                        currentCustomerCart = await _cartRepo.GetCustomerCartByCustomerId(request.CustomerId);
                }

                var cartItem = new CartItem
                {
                    CartId = currentCustomerCart!.Id,
                    ProductId = request.ProductId,
                    Price = request.ProductPrice,
                    CreateDateTime = DateTime.Now
                };

                await _cartItemsRepo.InsertCartItems(new List<CartItem> { cartItem });
            }
            else
            {
                _generalCartLogRepo.InsertGeneralLog(LogTypes.ValidationError, $"Incomming request is not valid, request: {JsonConvert.SerializeObject(request)}");
            }
        }
        catch (Exception ex)
        {
            _generalCartLogRepo.InsertGeneralLog(LogTypes.Error, $"CartService threw an exception while adding item to cart: {ex.Message}");
        }
    }

    public async Task RemoveFromCart(RemoveFromCartRequest request)
    {
        try
        {
            if (request.CustomerId != 0 && request.ProductId != 0)
            {
                var custmerCart = await _cartRepo.GetCustomerCartByCustomerId(request.CustomerId);

                if (custmerCart != null)
                {
                    var cartId = custmerCart.Id;

                    var cartItemDoBeRemoved = await _cartItemsRepo.GetCartItemByCartIdAndProductId(cartId, request.ProductId);

                    if (cartItemDoBeRemoved != null)
                        await _cartItemsRepo.RemoveCartItem(cartItemDoBeRemoved);
                }
            }
            else
            {
                _generalCartLogRepo.InsertGeneralLog(LogTypes.ValidationError, $"Incomming request is not valid, request: {JsonConvert.SerializeObject(request)}");
            }
        }
        catch (Exception ex)
        {
            _generalCartLogRepo.InsertGeneralLog(LogTypes.Error, $"CartService threw an exception while removing item from cart: {ex.Message}");
        }
    }
}
