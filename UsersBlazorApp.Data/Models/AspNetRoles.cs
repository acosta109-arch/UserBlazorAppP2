using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersBlazorApp.Data.Models;

public partial class AspNetRoles
{
	[Key]
	public int Id { get; set; }

	[StringLength(256)]
	public string? Name { get; set; }

	[InverseProperty("Role")]
	public virtual ICollection<AspNetRoleClaims> AspNetRoleClaims { get; set; } = new List<AspNetRoleClaims>();

	public virtual ICollection<AspNetUsers> Users { get; set; } = new List<AspNetUsers>();
}
