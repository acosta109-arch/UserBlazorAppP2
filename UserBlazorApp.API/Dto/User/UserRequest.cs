namespace UserBlazorApp.API.Dto.User;

public class UserRequest
{
	public string? UserName { get; set; }
	public string? Email { get; set; }
	public string? PasswordHash { get; set; }
	public string? PhoneNumber { get; set; }
	public DateTimeOffset? LockoutEnd { get; set; }


}
