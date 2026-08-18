namespace AuthChallenge.Service;
public class TokenValidationMiddleware
{
    private readonly RequestDelegate _next;

    public TokenValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var Validator = new TokenValidation();
        var Token = context.Request.Headers["Authorization"];
        if (!Validator.IsValid(Token))
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Invalid token");
            return;
        }
        await _next(context);
    }
}