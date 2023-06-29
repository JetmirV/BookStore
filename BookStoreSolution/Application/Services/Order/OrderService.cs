using Application.DTOs;
using Application.Enums;
using Application.Interfaces;
using Domain.Entities.OrderApi;

namespace Application.Services.Order;

public class OrderService : IOrderService
{
    private readonly IOrderRepo _orderRepo;
    private readonly IOrderItemRepo _orderItemRepo;
    private readonly IGeneralOrderLog _generalOrderLog;
    private readonly IOrderTypeRepo _orderTypeRepo;

    public OrderService(IOrderRepo orderRepo, IOrderItemRepo orderItemRepo, IGeneralOrderLog generalOrderLog, IOrderTypeRepo orderTypeRepo)
    {
        _orderRepo = orderRepo;
        _orderItemRepo = orderItemRepo;
        _generalOrderLog = generalOrderLog;
        _orderTypeRepo = orderTypeRepo;
    }

    public async Task<List<OrderDto>> GetOrdersByClientId(int clientId)
    {
        try
        {
            var result = new List<OrderDto>();

            if (clientId == 0)
                return new List<OrderDto>();

            var orders = await _orderRepo.GetOrderByClientId(clientId);

            if (orders.Count == 0)
                return new List<OrderDto>();

            var orderIds = orders.Select(x => x.Id).Distinct().ToList();

            var orderItems = await _orderItemRepo.GetAllOrderItemsByOrderIds(orderIds);

            var orderItemsDictionary = orderItems.GroupBy(x => x.OrderId).ToDictionary(x => x.Key, y => y.ToList());

            orders.ForEach(x =>
            {
                var items = new List<OrderItemDto>();
                orderItemsDictionary.TryGetValue(x.Id, out var orderItems);

                orderItems?.ForEach(x =>
                {
                    items.Add(new OrderItemDto
                    {
                        Id = x.Id,
                        Price = x.Price,
                        ProductId = x.ProductId
                    });
                });

                result.Add(new OrderDto
                {
                    Id = x.Id,
                    ClientId = clientId,
                    CreateDateTime = DateTime.UtcNow,
                    Status = (OrderStatus)x.Status,
                    OrderItems = items,
                    OrderType = (Enums.OrderType)x.OrderTypeId
                });
            });

            return result;
        }
        catch (Exception ex)
        {
            _generalOrderLog.InsertGeneralLog(LogTypes.Error, $"OrderService threw an exception while getting orders: {ex.Message}");
            return new List<OrderDto>();
        }
    }

    public async Task<bool> InsertOrder(OrderDto order)
    {
        try
        {
            if (order == null) return false;

            if (order.OrderItems.Count == 0) return false;

            var orderType = await _orderTypeRepo.GetOrderTypeByName(order.OrderType.ToString());

            var orderToInsert = new Domain.Entities.OrderApi.Order
            {
                Status = (int)OrderStatus.Created,
                ClientId = order.ClientId,
                OrderTypeId = orderType.Id,
                CreateDateTime = DateTime.Now,
            };

            var inserted = await _orderRepo.InsertOrder(orderToInsert);

            if (inserted)
            {
                var orders = await _orderRepo.GetOrderByClientId(order.ClientId);

                var orderId = orders.OrderByDescending(x => x.CreateDateTime).FirstOrDefault()?.Id;

                var orderItemsToInsert = order.OrderItems.Select(x => new OrderItem
                {
                    OrderId = (int)orderId!,
                    Price = x.Price,
                    ProductId = x.ProductId
                }).ToList();

                inserted = await _orderItemRepo.InsertOrderItems(orderItemsToInsert);

                if (inserted)
                    return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            _generalOrderLog.InsertGeneralLog(LogTypes.Error, $"OrderService threw an exception while inserting order: {ex.Message}");
            return false;
        }
    }

    public async Task<List<OrderDto>> GetRentOrders()
    {
        var orders = await _orderRepo.GetAllRentOrders();

        return orders.Select(x => new OrderDto
        {
            ClientId = x.ClientId,
            Status = (OrderStatus)x.Status,
            CreateDateTime = x.CreateDateTime
        }).ToList();
    }
}
