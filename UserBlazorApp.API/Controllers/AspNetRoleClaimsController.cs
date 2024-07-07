using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetRoleClaimsController : ControllerBase
    {
        private readonly IClientService<AspNetRoleClaims> _roleClaimService;

        public AspNetRoleClaimsController(IClientService<AspNetRoleClaims> roleClaimService)
        {
            _roleClaimService = roleClaimService;
        }

        // GET: api/AspNetRoleClaims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetRoleClaims>>> GetAspNetRoleClaims()
        {
            try
            {
                return await _roleClaimService.GetAllAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database: {ex.Message}");
            }
        }

        // GET: api/AspNetRoleClaims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetRoleClaims>> GetAspNetRoleClaims(int id)
        {
            try
            {
                var aspNetRoleClaims = await _roleClaimService.GetByIdAsync(id);

                if (aspNetRoleClaims == null)
                {
                    return NotFound($"Claim with Id = {id} not found");
                }

                return aspNetRoleClaims;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data from the database: {ex.Message}");
            }
        }

        // PUT: api/AspNetRoleClaims/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetRoleClaims(int id, AspNetRoleClaims aspNetRoleClaims)
        {
            if (id != aspNetRoleClaims.Id)
            {
                return BadRequest("Claim ID mismatch");
            }

            try
            {
                var result = await _roleClaimService.UpdateAsync(aspNetRoleClaims);
                if (!result)
                {
                    return NotFound($"Claim with Id = {id} not found");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating data: {ex.Message}");
            }
        }

        // POST: api/AspNetRoleClaims
        [HttpPost]
        public async Task<ActionResult<AspNetRoleClaims>> PostAspNetRoleClaims(AspNetRoleClaims aspNetRoleClaims)
        {
            try
            {
                var result = await _roleClaimService.AddAsync(aspNetRoleClaims);
                return CreatedAtAction("GetAspNetRoleClaims", new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating new claim: {ex.Message}");
            }
        }

        // DELETE: api/AspNetRoleClaims/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspNetRoleClaims(int id)
        {
            try
            {
                var result = await _roleClaimService.DeleteAsync(id);
                if (!result)
                {
                    return NotFound($"Claim with Id = {id} not found");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting claim: {ex.Message}");
            }
        }
    }
}
