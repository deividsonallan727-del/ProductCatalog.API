using ProductCatalog.API.Configurations;
using ProductCatalog.API.Services.Implementation;
using ProductCatalog.API.Services.Interfaces;
using Serilog;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.addDatabaseConfiguration(builder.Configuration);//addDatabaseConfiguration vem do DataBaseConfig

        builder.Services.AddScoped<ICustomerServices, CustomerServices>();

        builder.Services.AddScoped<IProductServices, ProductServices>();

        builder.Services.AddScoped<ICartServices, CartServices>();

        builder.Services.AddScoped<ICartItemServices, CartItemService>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}