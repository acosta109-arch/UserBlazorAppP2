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
			builder.Services.AddScoped<IClientService<AspNetUsers>, UsuarioService>();

			await builder.Build().RunAsync();
		}
	}
}
