using System.Threading.Tasks;
using Admin_Portfolio.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (UserAuthStatus.Authenticated || context.Request.Path == "/Account" || context.Request.Path == "/Account/Login")
        {
            // User is authenticated, allow the request to proceed
            await _next(context);
        }
        else
        {
            if(context.Request.Path != "/Account")       // User is not authenticated, redirect to login page
            context.Response.Redirect("/Account");
        }
    }
}
