public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception _)
        {
             context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An error occurred.");
        }
    }
}
