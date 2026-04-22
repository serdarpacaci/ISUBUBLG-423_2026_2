
using IsubuSatis.Siparis.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IsubuSatis.Siparis.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var conStr = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<SiparisDbContext>(x => x.UseSqlServer(conStr,
                y=> y.MigrationsAssembly("IsubuSatis.Siparis.Persistence")));


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMediatR(x=> 
            x.RegisterServicesFromAssembly(
                typeof(IsubuSatis.Siparis.Application.Commands.CreateSiparisCommand).Assembly));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapGet("/", context =>
                {
                    context.Response.Redirect("/swagger");
                    return Task.CompletedTask;
                });
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
