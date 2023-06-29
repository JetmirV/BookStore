using Application.Interfaces;
using Infrastructure.Communication.Account;
using Infrastructure.Communication.Cart;
using Infrastructure.Communication.Common;
using Infrastructure.Communication.Order;
using Infrastructure.Database.DbContexts.AccountApi;
using Infrastructure.Database.DbContexts.BookStore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureRegistrationExtensions
{
	public static IServiceCollection AddDatabaseInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddMemoryCache();

		// Register the current project's dependencies
		services.Scan(scanner => scanner.FromAssemblies(typeof(InfrastructureRegistrationExtensions).Assembly)
			.AddClasses(c => c.Where(type => !type.IsNested), publicOnly: false)
			.AsSelfWithInterfaces().WithSingletonLifetime());

		//Add the DbContext
		services.AddDbContextFactory<BookStoreApiDbContext>(
		options => options.UseSqlServer(configuration["ConnectionStrings:BookStore"]));

		services.AddDbContextFactory<Database.DbContexts.OrderApi.CartApiDbContext>(
		options => options.UseSqlServer(configuration["ConnectionStrings:OrderApi"]));

		services.AddDbContextFactory<Database.DbContexts.CartApi.CartApiDbContext>(
		options => options.UseSqlServer(configuration["ConnectionStrings:CartApi"]));

		services.AddDbContextFactory<AccountApiDbContext>(
		options => options.UseSqlServer(configuration["ConnectionStrings:AccountApi"]));

		return services;
	}

	public static IServiceCollection AddCommunicationInfrastructureLayer(this IServiceCollection services, IConfiguration config)
	{
		services.AddSingleton(typeof(IGenericRequestBuilder), typeof(GenericRequestBuilder));
		services.AddSingleton<IOrderCommunicator, OrderCommunicator>();
		services.AddSingleton<IAccountCommunicator, AccountCommunicator>();
		services.AddSingleton<ICartCommunicator, CartCommunicator>();

		services.AddHttpClient<IGenericRequestBuilder, GenericRequestBuilder>();

		return services;
	}
}
