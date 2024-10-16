
using H_API.Services.Interfaces;
using H_API.Services.Services;
using HARMONIA.Core.Interfaces;
using HARMONIA.Core.Services;
using Microsoft.Extensions.Hosting;

namespace H_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services
                .AddSingleton<IDbService>(new DbService(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"), 
                builder.Configuration.GetValue<string>("DatabaseSettings:DatabaseName")));
            
            
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ITellemetryService, TellemetryService>();
            builder.Services.AddScoped<IInitService, InitService>();
            var app = builder.Build();

            using (var scope = app.Services.CreateScope()) { 
                IInitService initService = scope.ServiceProvider.GetService<IInitService>();
                initService.Init();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || !app.Environment.IsDevelopment())
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
}
