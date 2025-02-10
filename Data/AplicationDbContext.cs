using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class AplicationDbContext : IdentityDbContext<AppUser>
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = "59c02f7e-854f-4604-9d76-ca115763ddcb", // Static GUID
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Id = "653e4e34-e0c6-4d94-8735-f261b1d223f4", // Static GUID
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
        };
        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }
}