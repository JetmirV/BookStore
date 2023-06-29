using Application.Exceptions;
using Application.Interfaces;
using System.Net;

namespace BookStore.CustomeExceptionsMiddleware;

public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;
	private readonly IGeneralLogRepo _generalLogRepo;

	public ExceptionMiddleware(RequestDelegate next, IGeneralLogRepo generalLogRepo)
	{
		_next = next;
		_generalLogRepo = generalLogRepo;
	}

	public async Task InvokeAsync(HttpContext httpContext)
	{
		try
		{
			await _next(httpContext);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(httpContext, ex);
		}
	}

	private async Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		_generalLogRepo.InsertGeneralLog(Application.Enums.LogTypes.Error, $"Unhandeled error, Error: {exception.Message}");

		context.Response.StatusCode = 500;
	}
}
