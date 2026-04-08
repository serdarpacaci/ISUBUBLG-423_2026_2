
using IsubuSatis.Indirim.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace IsubuSatis.Indirim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IIndirimService, MyIndirimService>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(x =>
              {
                  x.Authority = "http://localhost:8080/realms/isubu";
                  x.Audience = "indirim";
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
                  x.Audience = "indirim";
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

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
