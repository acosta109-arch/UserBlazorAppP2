using UserBlazorApp.API.Dto.Claims;

namespace UserBlazorApp.API.Dto.Roles;

public class RolRequest
{
	public string? Name { get; set; }

	public ICollection<RolClaimRequest> AspNetRoleClaims { get; set; } = new List<RolClaimRequest>();
}
