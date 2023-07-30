namespace Choon.Api.Middleware
{
	public class UserDetectionMiddleware : IMiddleware
	{
		public Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			throw new NotImplementedException();
		}
	}
}