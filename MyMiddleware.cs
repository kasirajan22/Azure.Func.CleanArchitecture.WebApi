using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;

namespace Azure.Func.CleanArchitecture.WebApi;

public class MyMiddleware : IFunctionsWorkerMiddleware
{
    private readonly ILogger<MyMiddleware> _logger;
    public MyMiddleware(ILogger<MyMiddleware> logger) =>
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        _logger.LogInformation("Am from middleware");
        // Middleware logic before function execution
        await next(context);
        // Middleware logic after function execution
    }
}