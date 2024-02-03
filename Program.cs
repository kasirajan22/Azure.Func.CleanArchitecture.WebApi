using Microsoft.Extensions.Hosting;
using Azure.Func.CleanArchitecture.WebApi;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(worker => worker.UseMiddleware<MyMiddleware>())
    .ConfigureServices(_ =>
    {
        // Register services and Dependency injections
    })
    .Build();
    
await host.RunAsync();