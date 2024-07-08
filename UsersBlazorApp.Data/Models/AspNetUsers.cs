using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersBlazorApp.Data.Models;

public partial class AspNetUsers
{
	[Key]
	public int Id { get; set; }

	[StringLength(256)]
	public string? UserName { get; set; }

	[StringLength(256)]
	public string? Email { get; set; }

	public string? PasswordHash { get; set; }

	public string? PhoneNumber { get; set; }

	public DateTimeOffset? LockoutEnd { get; set; }

	[InverseProperty("User")]
	public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; } = new List<AspNetUserClaims>();

	[ForeignKey("Id")]
	public virtual ICollection<AspNetRoles> Roles { get; set; } = new List<AspNetRoles>();
}
