using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using simulacro.Application.Models;

namespace simulacro.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Users> users { get; set; }
    public DbSet<Products> products { get; set; }
}