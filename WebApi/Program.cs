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

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(worker => worker.UseMiddleware<MyMiddleware>())
    .ConfigureServices(s =>
    {
        s.AddAuthentication();
        s.AddSingleton<IMyService, MyService>();
        var connectionString = "";
        s.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("InfrastructureLayer")));
        s.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        s.AddScoped<IApplicationWrapper, ApplicationWrapper>();
        string securityKey = "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";
        string issuer = "https://localhost:7024";
        string audience = "https://localhost:7024";
        s.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).
        AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)),
                ClockSkew = TimeSpan.Zero
            };
        });
    })
    .Build();

await host.RunAsync();