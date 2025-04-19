using Microsoft.EntityFrameworkCore;
using MvcProductCrud.Models;

namespace MvcProductCrud.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Product { get; set; }
}
