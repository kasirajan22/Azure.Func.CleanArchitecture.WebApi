using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Azure.Func.CleanArchitecture.WebApi;
using ApplicationLayer;
using InfrastructureLayer;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(worker => { 
        worker.UseMiddleware<AuthMiddleware>(); 
    })
    .ConfigureServices(s =>
    {
         s.AddSingleton<IMyService, MyService>();
        var connectionString = "";
        s.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("InfrastructureLayer")));
        s.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        s.AddScoped<IApplicationWrapper, ApplicationWrapper>();
    })
    .Build();

await host.RunAsync();