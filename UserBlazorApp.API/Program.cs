using Microsoft.EntityFrameworkCore;
using UserBlazorApp.API.DAL;
using UserBlazorApp.API.Services;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.API;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		// Configure DbContext with SQL Server
		var connectionString = builder.Configuration.GetConnectionString("ConStr");
		builder.Services.AddDbContext<UsersDbContext>(options =>
			options.UseSqlServer(connectionString));

		// Register application services
		builder.Services.AddScoped<IApiService<AspNetUsers>, UserService>();
		builder.Services.AddScoped<IApiService<AspNetRoles>, RolService>();
        builder.Services.AddScoped<IApiService<AspNetRoleClaims>, ClaimService>();

        // Configure CORS
        builder.Services.AddCors(options => {
			options.AddPolicy("AllowAnyOrigin",
				builder => builder.AllowAnyOrigin() // Allow any origin
								  .AllowAnyMethod()
								  .AllowAnyHeader());
		});

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		// Use CORS policy
		app.UseCors("AllowAnyOrigin");

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}
