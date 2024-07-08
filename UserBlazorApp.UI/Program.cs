using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UserBlazorApp.UI.Services;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.UI
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");
			builder.RootComponents.Add<HeadOutlet>("head::after");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7210/") });
			//inyecci�n de users
			builder.Services.AddScoped<IClientService<AspNetUsers>, UsuarioService>();
            //inyecci�n de rol
            builder.Services.AddScoped<IClientService<AspNetRoles>, RoleService>();
            //inyecci�n de claim
            builder.Services.AddScoped<IClientService<AspNetRoleClaims>, ClaimService>();
            //inyecci�n de bootstrap
            builder.Services.AddBlazorBootstrap();

            await builder.Build().RunAsync();
		}
	}
}
