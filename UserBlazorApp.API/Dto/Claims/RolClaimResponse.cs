namespace UserBlazorApp.API.Dto.Claims;

public class RolClaimResponse
{
	public int Id { get; set; }

	public int RoleId { get; set; }

	public string? ClaimType { get; set; }

	public string? ClaimValue { get; set; }
}
