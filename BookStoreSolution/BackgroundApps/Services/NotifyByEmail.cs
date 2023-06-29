using Application.Interfaces;
using Confluent.Kafka;

namespace BackgroundApps.Services;

public class NotifyByEmail
{
	private readonly IOrderService _orderService;

	public NotifyByEmail(IOrderService orderService)
	{
		_orderService = orderService;
	}

	public void SendNotifications()
	{
		var rentOrders = _orderService.GetRentOrders().Result;

		foreach (var order in rentOrders)
		{
			ProduceMessage("RentOrders", "Rent is due");
		}
	}

	public async Task ProduceMessage(string topic, string message)
	{
		var config = new ProducerConfig
		{
			BootstrapServers = "localhost:9092"
		};

		using (var producer = new ProducerBuilder<Null, string>(config).Build())
		{
			await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
		}
	}
}
