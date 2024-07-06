using UserBlazorApp.API.Dto.Claims;

namespace UserBlazorApp.API.Dto.Roles;

public class RolResponse
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public List<RolClaimResponse> RoleClaims { get; set; } = new List<RolClaimResponse>();
}
