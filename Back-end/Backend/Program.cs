using Backend.Entities;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "CORS", builder =>
                {
                    builder.AllowAnyHeader()
                    .WithOrigins("http://localhost:3000")
                    .AllowCredentials()
                    .AllowAnyMethod();
                });
            });
            builder.Services.AddDbContext<LoanDBContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("LoanAPIConnection")));
            builder.Services.AddScoped<IAdminMastersRepository, AdminMastersRepository>();
            var connection = builder.Configuration.GetConnectionString("LoanAPIConnection");
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            var app = builder.Build();
            app.UseCors("CORS");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}