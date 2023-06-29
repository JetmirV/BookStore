using Domain.Entities.OrderApi;

namespace Application.Interfaces;

public interface IOrderRepo
{
	Task<List<Order>> GetAllOrders();
	Task<List<Order>> GetOrderByClientId(int clientId);
	Task<Order?> GetOrderById(int id);
	Task<bool> InsertOrder(Order order);
}