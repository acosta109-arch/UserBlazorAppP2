using UserBlazorApp.API.Dto.Roles;

namespace UserBlazorApp.API.Dto.User;

public class UserResponse
{
	public int Id { get; set; }
	public string? UserName { get; set; }
	public string? Email { get; set; }
	public string? PasswordHash { get; set; }
	public string? PhoneNumber { get; set; }
	public DateTimeOffset? LockoutEnd { get; set; }

	public ICollection<RolResponse> Role { get; set; } = new List<RolResponse>();
}
