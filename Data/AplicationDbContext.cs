using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions <AplicationDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Stock>Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }


}