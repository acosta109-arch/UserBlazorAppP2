using Microsoft.EntityFrameworkCore;
using UserBlazorApp.API.DAL;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.API.Services;

public class RolService(UsersDbContext Contexto) : IApiService<AspNetRoles>
{
	public async Task<List<AspNetRoles>> GetAllAsync()
	{
		return await Contexto.AspNetRoles.ToListAsync();
	}

	public async Task<AspNetRoles> GetByIdAsync(int id)
	{
		return await Contexto.AspNetRoles.FindAsync(id);
	}

	public async Task<AspNetRoles> AddAsync(AspNetRoles rol)
	{
		Contexto.AspNetRoles.Add(rol);
		await Contexto.SaveChangesAsync();
		return rol;
	}

	public async Task<bool> UpdateAsync(AspNetRoles rol)
	{
		Contexto.Entry(rol).State = EntityState.Modified;
		return await Contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var rol = await Contexto.AspNetRoles.FindAsync(id);
		if (rol == null)
			return false;

		Contexto.AspNetRoles.Remove(rol);
		return await Contexto.SaveChangesAsync() > 0;
	}
}
