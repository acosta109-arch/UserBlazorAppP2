using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersBlazorApp.Data.Models;

public partial class AspNetUserClaims
{
	[Key]
	public int Id { get; set; }

	public int UserId { get; set; }

	public string? ClaimType { get; set; }

	public string? ClaimValue { get; set; }

	[ForeignKey("UserId")]
	[InverseProperty("AspNetUserClaims")]
	public virtual AspNetUsers User { get; set; } = null!;
}
