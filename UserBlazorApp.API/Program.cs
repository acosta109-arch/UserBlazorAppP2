
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
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		builder.Services.AddDbContext<UsersDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));

		builder.Services.AddScoped<IApiService<AspNetUsers>, UserService>();

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

		app.UseCors("AllowAnyOrigin"); // Use the CORS policy

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}
