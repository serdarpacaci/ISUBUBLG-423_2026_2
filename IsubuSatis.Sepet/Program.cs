
using IsubuSatis.Ortak;
using IsubuSatis.Sepet.Models;
using IsubuSatis.Sepet.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace IsubuSatis.Sepet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<RedisService>();
            builder.Services.AddScoped<ISepetService, MySepetService>();
            builder.Services.AddScoped<IIdentityHelperService, IdentityHelperService>();

            var redisSection = builder.Configuration.GetSection("RedisSettings");
            builder.Services.Configure<RedisSettings>(redisSection);

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddMemoryCache();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(x =>
              {
                  x.Authority = "http://localhost:8080/realms/isubu";
                  x.Audience = "katalog";
                  x.RequireHttpsMetadata = false;
                  x.TokenValidationParameters = new TokenValidationParameters()
                  {
                      RequireExpirationTime = true,
                      ValidateAudience = true,
                      ValidateIssuerSigningKey = true,
                      ValidateLifetime = true,
                      ValidateIssuer = true,
                      RoleClaimType = "roles",
                      NameClaimType = "preferred_username",
                      ClockSkew = TimeSpan.FromSeconds(15)
                  };
              }).AddJwtBearer("ClientCredentialSchema", x =>
              {
                  x.Authority = "http://localhost:8080/realms/isubu";
                  x.Audience = "katalog";
                  x.RequireHttpsMetadata = false;

                  x.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidateAudience = true,
                      ValidateIssuerSigningKey = true,
                      ValidateLifetime = true,
                      ValidateIssuer = true,
                  };
              });

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

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


            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.Run();
        }
    }
}
