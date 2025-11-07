using Microsoft.EntityFrameworkCore;

using DataAccess;
using DataAccess.Repositories;
using DataAccess.RepositoryInterfaces;

using Entities;
using Entities.Context;


namespace Api
{
    /// <summary>
    /// Entry point for the API application.
    /// Configures services, middleware, and endpoints for the ASP.NET Core Web API.
    /// </summary>
    /// <remarks>
    /// - Registers Entity Framework Core with SQL Server using the connection string "ExampleConnection".
    /// - Adds repository and unit of work services for data access.
    /// - Configures controllers and Swagger/OpenAPI for API documentation.
    /// - Sets up HTTPS redirection and authorization middleware.
    /// - Maps controller endpoints.
    /// </remarks>
    public class Program
    {
        // "DbName + Connection"
        static readonly string ConnectionName = "ExampleConnection";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DbContext, ExampleContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString(ConnectionName));
            });

            

            builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            builder.Services.AddScoped<UnitOfWork>();

            // ---  Example ---
            builder.Services.AddScoped<IExampleRepository, ExampleRepository>();
            builder.Services.AddScoped<IGenericRepository<Entities.Example>, ExampleRepository>();


            builder.Services.AddControllers();

            // --- ADD SWASHBUCKLE/SWAGGER SERVICES HERE ---
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(); // This registers the Swagger generator

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
