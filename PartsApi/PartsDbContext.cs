using Microsoft.EntityFrameworkCore;

namespace PartsApi;

public class PartsDbContext(DbContextOptions<PartsDbContext> options) : DbContext(options)
{
    public DbSet<Part> Parts {  get; set; }
}
