using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBlazorApp.API.DAL;
using UserBlazorApp.API.Dto.Claims;
using UserBlazorApp.API.Dto.Roles;
using UserBlazorApp.API.Dto.User;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AspNetUsersController(IApiService<AspNetUsers> apiService) : ControllerBase
	{
		// GET: api/AspNetUsers
		[HttpGet]
		public async Task<ActionResult<IEnumerable<AspNetUsers>>> GetAspNetUsers()
		{
			var users = await apiService.GetAllAsync();

			var userResponses = users.Select(u => new UserResponse
			{
				Id = u.Id,
				UserName = u.UserName,
				Email = u.Email,
				PasswordHash = u.PasswordHash,
				PhoneNumber = u.PhoneNumber,
				LockoutEnd = u.LockoutEnd,
				Role = u.Roles.Select(r => new RolResponse
				{
					Id = r.Id,
					Name = r.Name,
					RoleClaims = r.AspNetRoleClaims.Select(rc => new RolClaimResponse
					{
						Id = rc.Id,
						RoleId = rc.RoleId,
						ClaimType = rc.ClaimType,
						ClaimValue = rc.ClaimValue
					}).ToList()
				}).ToList()


			}).ToList();


			return Ok(userResponses);
		}

		// POST: api/AspNetUsers
		[HttpPost]
		public async Task<ActionResult<UserResponse>> PostAspNetUsers(UserRequest userRequest)
		{
			var user = new AspNetUsers
			{
				UserName = userRequest.UserName,
				Email = userRequest.Email,
				PasswordHash = userRequest.PasswordHash,
				PhoneNumber = userRequest.PhoneNumber,
				LockoutEnd = DateTime.Now
			};

			var userCreated = await apiService.AddAsync(user);

			var userResponse = new UserResponse
			{
				Id = userCreated.Id,
				UserName = userCreated.UserName,
				Email = userCreated.Email,
				PasswordHash = userCreated.PasswordHash,
				PhoneNumber = userCreated.PhoneNumber,
				LockoutEnd = userCreated.LockoutEnd,
				Role = userCreated.Roles.Select(r => new RolResponse
				{
					Id = r.Id,
					Name = r.Name
				}).ToList()
			};

			return Ok(userResponse);

			//return CreatedAtAction("GetAspNetUsers", new { id = aspNetUsers.Id }, aspNetUsers);
		}

		// GET: api/AspNetUsers/5
		[HttpGet("{id}")]
		public async Task<ActionResult<UserResponse>> GetAspNetUsers(int id)
		{
			var user = await apiService.GetByIdAsync(id);

			if (user == null)
			{
				return NotFound();
			}

			var userResponse = new UserResponse
			{
				Id = user.Id,
				UserName = user.UserName,
				Email = user.Email,
				PasswordHash = user.PasswordHash,
				PhoneNumber = user.PhoneNumber,
				LockoutEnd = user.LockoutEnd,
				Role = user.Roles.Select(r => new RolResponse
				{
					Id = r.Id,
					Name = r.Name
				}).ToList()
			};

			return userResponse;
		}

		// PUT: api/AspNetUsers/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAspNetUsers(int id, UserRequest userRequest)
		{

			var user = await apiService.GetByIdAsync(id);

			if (user == null)
			{
				return NotFound();
			}

			user.UserName = userRequest.UserName;
			user.Email = userRequest.Email;
			user.PasswordHash = userRequest.PasswordHash;
			user.PhoneNumber = userRequest.PhoneNumber;
			user.LockoutEnd = userRequest.LockoutEnd;


			await apiService.UpdateAsync(user);

			return NoContent();
		}



		// DELETE: api/AspNetUsers/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAspNetUsers(int id)
		{

			var user = await apiService.GetByIdAsync(id);
			if (user == null)
			{
				return NotFound();
			}

			await apiService.DeleteAsync(id);

			return NoContent();
		}

	}
}
