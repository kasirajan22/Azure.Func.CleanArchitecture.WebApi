using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;
using ApplicationLayer;
using AzureFunctions.Extensions.Middleware;
using System.Net;
using System.Reflection;

namespace Azure.Func.CleanArchitecture.WebApi;

public class AuthMiddle : IFunctionsWorkerMiddleware
{
    private readonly ILogger<AuthMiddle> _logger;
    public AuthMiddle(ILogger<AuthMiddle> logger) =>
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        MethodInfo? method = GetCustomAttributesMethods(context);
        List<AuthorizeAttribute>? authorizeAttributes = method?.GetCustomAttributes<AuthorizeAttribute>().ToList();
        HttpRequestData? req = await context.GetHttpRequestDataAsync();
        if (authorizeAttributes is not null && authorizeAttributes.Count > 0)
        {
            foreach (var attribute in authorizeAttributes)
            {
                var roles = attribute.UserRoles;
 
                // Perform your authentication and authorization logic here
                // For example, check if the user has one of the required roles
            }

            string? authHeader = req?.Headers.Where(a => a.Key.Equals("Authorization")).ToList().FirstOrDefault().Value?.FirstOrDefault()?.ToString();

            if (authHeader != null && authHeader.ToString().StartsWith("Bearer "))
            {
                var token = authHeader.ToString().Substring("Bearer ".Length).Trim();

                // Validate the token
                // This is just a placeholder. In a real-world application, 
                // you would use a library or service to validate the token.
                if (TokenIsValid(token))
                {
                    await next(context);
                }
                else
                {
                    var response = req.CreateResponse(HttpStatusCode.Unauthorized);
                    await response.WriteStringAsync("Unauthorized");
                    context.GetInvocationResult().Value = response; // Assign the response to the function context
                }
            }
            else
            {
                var response = req.CreateResponse(HttpStatusCode.Unauthorized);
                await response.WriteStringAsync("Unauthorized");
                context.GetInvocationResult().Value = response; // Assign the response to the function context
            }
        }
        else
        {
            await next(context);
        }
    }

    private static MethodInfo? GetCustomAttributesMethods(FunctionContext context)
    {
        var entryPoint = context.FunctionDefinition.EntryPoint;
        var assemblyPath = context.FunctionDefinition.PathToAssembly;
        var assembly = Assembly.LoadFrom(assemblyPath);
        var typeName = entryPoint.Substring(0, entryPoint.LastIndexOf('.'));
        var type = assembly.GetType(typeName);
        var methodName = entryPoint.Substring(entryPoint.LastIndexOf('.') + 1);
        var method = type.GetMethod(methodName);
        return method;
    }

    private bool TokenIsValid(string token)
    {
        // Validate the token
        // This is just a placeholder. In a real-world application, 
        // you would use a library or service to validate the token.
        return true;
    }
}