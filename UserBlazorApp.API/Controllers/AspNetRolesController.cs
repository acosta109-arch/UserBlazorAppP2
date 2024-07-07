using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserBlazorApp.API.Dto.Claims;
using UserBlazorApp.API.Dto.Roles;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AspNetRolesController : ControllerBase
	{
		private readonly IApiService<AspNetRoles> _apiService;

		public AspNetRolesController(IApiService<AspNetRoles> apiService)
		{
			_apiService = apiService;
		}

		// GET: api/AspNetRoles
		[HttpGet]
		public async Task<ActionResult<IEnumerable<RolResponse>>> GetAspNetRoles()
		{
			var roles = await _apiService.GetAllAsync();
			var roleResponses = roles.Select(r => new RolResponse
			{
				Id = r.Id,
				Name = r.Name,
				RoleClaims = r.AspNetRoleClaims.Select(rc => new RolClaimResponse
				{
					Id = rc.Id,
					ClaimType = rc.ClaimType,
					ClaimValue = rc.ClaimValue
				}).ToList()
			}).ToList();

			return Ok(roleResponses);
		}

		// GET: api/AspNetRoles/5
		[HttpGet("{id}")]
		public async Task<ActionResult<RolResponse>> GetAspNetRoles(int id)
		{
			var role = await _apiService.GetByIdAsync(id);
			if (role == null)
			{
				return NotFound();
			}

			var roleResponse = new RolResponse
			{
				Id = role.Id,
				Name = role.Name,
				RoleClaims = role.AspNetRoleClaims.Select(rc => new RolClaimResponse
				{
					Id = rc.Id,
					ClaimType = rc.ClaimType,
					ClaimValue = rc.ClaimValue
				}).ToList()
			};

			return Ok(roleResponse);
		}

		// POST: api/AspNetRoles
		[HttpPost]
		public async Task<ActionResult<RolResponse>> PostAspNetRoles(RolRequest roleRequest)
		{
			var role = new AspNetRoles
			{
				Name = roleRequest.Name,
				AspNetRoleClaims = roleRequest.AspNetRoleClaims.Select(rc => new AspNetRoleClaims
				{
					ClaimType = rc.ClaimType,
					ClaimValue = rc.ClaimValue
				}).ToList()
			};

			var createdRole = await _apiService.AddAsync(role);

			var roleResponse = new RolResponse
			{
				Id = createdRole.Id,
				Name = createdRole.Name,
				RoleClaims = createdRole.AspNetRoleClaims.Select(rc => new RolClaimResponse
				{
					Id = rc.Id,
					ClaimType = rc.ClaimType,
					ClaimValue = rc.ClaimValue
				}).ToList()
			};

			return CreatedAtAction(nameof(GetAspNetRoles), new { id = createdRole.Id }, roleResponse);
		}

		// PUT: api/AspNetRoles/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAspNetRoles(int id, RolRequest roleRequest)
		{
			var role = await _apiService.GetByIdAsync(id);
			if (role == null)
			{
				return NotFound();
			}

			role.Name = roleRequest.Name;
			role.AspNetRoleClaims = roleRequest.AspNetRoleClaims.Select(rc => new AspNetRoleClaims
			{
				ClaimType = rc.ClaimType,
				ClaimValue = rc.ClaimValue
			}).ToList();

			var result = await _apiService.UpdateAsync(role);
			if (!result)
			{
				return BadRequest("Failed to update role");
			}

			return NoContent();
		}

		// DELETE: api/AspNetRoles/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAspNetRoles(int id)
		{
			var result = await _apiService.DeleteAsync(id);
			if (!result)
			{
				return NotFound();
			}

			return NoContent();
		}
	}
}
