using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TBA.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var sqlServerConnection = builder.Configuration.GetConnectionString("AppDbContext");
            var postgresConnection = builder.Configuration.GetConnectionString("PostgresDbContext");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(sqlServerConnection));

            builder.Services.AddDbContext<PostgresDbContext>(options =>
                options.UseNpgsql(postgresConnection));

            //Serialización JSON ajustada para evitar ciclos
            builder.Services
                .AddControllers()
                .AddNewtonsoftJson(
                    options => options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("Error interno en la API. Revisa los logs.");
                });
            });

            app.Run();
        }
    }
}
