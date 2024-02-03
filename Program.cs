using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Azure.Func.CleanArchitecture.WebApi;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(worker => worker.UseMiddleware<MyMiddleware>())
    .ConfigureServices(s =>
    {
        s.AddSingleton<IMyService, MyService>();
        // Register services and Dependency injections
    })
    .Build();

await host.RunAsync();