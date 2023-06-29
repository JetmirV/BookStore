namespace EmailService
{
	internal class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				var notifications = new SentEmailNotifications();
				notifications.ConsumeEvents();
			}
		}
	}
}