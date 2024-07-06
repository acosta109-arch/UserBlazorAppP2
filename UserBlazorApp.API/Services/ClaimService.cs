using Microsoft.EntityFrameworkCore;
using UserBlazorApp.API.DAL;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.API.Services;

public class ClaimService(UsersDbContext Contexto) : IApiService<AspNetRoleClaims>
{
	public async Task<List<AspNetRoleClaims>> GetAllAsync()
	{
		return await Contexto.AspNetRoleClaims.ToListAsync();
	}

	public async Task<AspNetRoleClaims> GetByIdAsync(int id)
	{
		return await Contexto.AspNetRoleClaims.FindAsync(id);
	}

	public async Task<AspNetRoleClaims> AddAsync(AspNetRoleClaims rol)
	{
		Contexto.AspNetRoleClaims.Add(rol);
		await Contexto.SaveChangesAsync();
		return rol;
	}

	public async Task<bool> UpdateAsync(AspNetRoleClaims rol)
	{
		Contexto.Entry(rol).State = EntityState.Modified;
		return await Contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> DeleteAsync(int id)
	{
		var rol = await Contexto.AspNetRoleClaims.FindAsync(id);
		if (rol == null)
			return false;

		Contexto.AspNetRoleClaims.Remove(rol);
		return await Contexto.SaveChangesAsync() > 0;
	}
}
