using Domain.Entities.OrderApi;

namespace Application.Interfaces;

public interface IOrderTypeRepo
{
	Task<OrderType?> GetOrderTypeByName(string orderType);
}