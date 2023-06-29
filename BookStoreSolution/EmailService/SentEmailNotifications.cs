using Confluent.Kafka;

namespace EmailService;

public class SentEmailNotifications
{
	public void ConsumeEvents()
	{
		var config = new ConsumerConfig
		{
			BootstrapServers = "localhost:9092",
			GroupId = "foo"
		};

		using (var consumer = new ConsumerBuilder<string, string>(config).Build())
		{
			consumer.Subscribe("RentOrders");

			while (true)
			{
				try
				{
					var message = consumer.Consume();

					if (!string.IsNullOrEmpty(message.Message.Value))
					{
						Console.WriteLine(message.Message.Value);
					}
				}
				catch (ConsumeException e)
				{
					Console.WriteLine($"Error occured: {e.Error.Reason}");
				}
			}
		}
	}
}
