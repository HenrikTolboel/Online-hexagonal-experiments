
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
       
        IPersistence persistence = new MemoryPersistence();
        OnlineService onlineService = new("asjkla", persistence);
        builder.Services.AddSingleton<IOnlineUseCase>(onlineService);

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

        app.Run();
    }
}
