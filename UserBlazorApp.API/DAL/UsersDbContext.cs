using Microsoft.EntityFrameworkCore;
using UsersBlazorApp.Data.Models;

namespace UserBlazorApp.API.DAL;

public partial class UsersDbContext : DbContext
{
	public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }

	public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }

	public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }

	public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }

	public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<AspNetUsers>(entity =>
		{
			entity.HasMany(d => d.Roles).WithMany(p => p.Users)
				.UsingEntity<Dictionary<string, object>>(
					"AspNetUserRoles",
					r => r.HasOne<AspNetRoles>().WithMany().HasForeignKey("RoleId"),
					l => l.HasOne<AspNetUsers>().WithMany().HasForeignKey("UserId"),
					j =>
					{
						j.HasKey("UserId", "RoleId");
					});
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
