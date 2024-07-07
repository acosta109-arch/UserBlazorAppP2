using System.Net.Http.Json;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.UI.Services;

public class RoleService(HttpClient _httpClient) : IClientService<AspNetRoles>
{
	public async Task<List<AspNetRoles>> GetAllAsync()
	{
		return await _httpClient.GetFromJsonAsync<List<AspNetRoles>>("api/AspNetRoles");
	}

	public async Task<AspNetRoles> GetByIdAsync(int id)
	{
		return (await _httpClient.GetFromJsonAsync<AspNetRoles>($"api/AspNetRoles/{id}"))!;
	}

	public async Task<AspNetRoles> AddAsync(AspNetRoles entity)
	{
		var response = await _httpClient.PostAsJsonAsync("api/AspNetRoles", entity);
		return await response.Content.ReadFromJsonAsync<AspNetRoles>();
	}

	public async Task<bool> UpdateAsync(AspNetRoles entity)
	{
		var response = await _httpClient.PutAsJsonAsync($"api/AspNetRoles/{entity.Id}", entity);
		return response.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var response = await _httpClient.DeleteAsync($"api/AspNetRoles/{id}");
		return response.IsSuccessStatusCode;
	}
}
