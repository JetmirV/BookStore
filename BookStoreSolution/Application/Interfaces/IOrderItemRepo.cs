using Domain.Entities.OrderApi;

namespace Application.Interfaces;

public interface IOrderItemRepo
{
	Task<List<OrderItem>> GetAllOrderItemsByOrderIds(List<int> orderIds);
	Task<bool> InsertOrderItems(List<OrderItem> orderItems);
}