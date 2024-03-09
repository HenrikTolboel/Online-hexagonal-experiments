
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Online.Application;
using Online.Application.Ports.Output;
using Online.Output.MemoryPersistence;

namespace Online.Input.Rest;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddApplicationHealth();

        builder.Services.AddApplicationServices();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(); 

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.MapHealthChecks("/healthz");
        app.MapHealthChecks("/ready");
        app.MapHealthChecks("/health/startup");


        app.Run();
    }
}

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        IPersistence persistence = new MemoryPersistence();
        OnlineService onlineService = new("asjkla", persistence);
        services.AddSingleton<IOnlineUseCase>(onlineService);

        return  services;
    }

    public static IServiceCollection AddApplicationHealth(this IServiceCollection services) {
        services.AddHealthChecks()        
        .AddCheck<RandomHealthCheck>("Random check");

        return  services;
    }
}

public class RandomHealthCheck : IHealthCheck
{
    private static readonly Random _rnd = new Random();

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var result = _rnd.Next(5) == 0
            ? HealthCheckResult.Healthy()
            : HealthCheckResult.Unhealthy("Failed random");

        return Task.FromResult(result);
    }
}

