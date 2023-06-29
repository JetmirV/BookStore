using Infrastructure.Database.DbContexts.AccountApi;
using Infrastructure.Database.DbContexts.BookStore;
using Infrastructure.Database.DbContexts.CartApi;
using Infrastructure.Database.DbContexts.OrderApi;
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

		services.AddDbContextFactory<OrderApiDbContext>(
		options => options.UseSqlServer(configuration["ConnectionStrings:OrderApi"]));

		services.AddDbContextFactory<CartApiDbContext>(
		options => options.UseSqlServer(configuration["ConnectionStrings:CartApi"]));

		services.AddDbContextFactory<AccountApiDbContext>(
		options => options.UseSqlServer(configuration["ConnectionStrings:AccountApi"]));

		return services;
	}
}
