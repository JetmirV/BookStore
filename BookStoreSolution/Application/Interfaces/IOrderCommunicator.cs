using Application.DTOs;

namespace Application.Interfaces;

public interface IOrderCommunicator
{
	Task<bool> CreateOrder(OrderDto orderRequest);
	Task<List<OrderDto>> GetOrdersByClientId(int clientId);
}