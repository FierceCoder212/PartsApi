using Microsoft.EntityFrameworkCore;
using PartsApi.Models;

namespace PartsApi;

public class PartsDbContext(DbContextOptions<PartsDbContext> options) : DbContext(options)
{
    public DbSet<Part> Parts {  get; set; }
    public DbSet<TempPart> TempParts {  get; set; }
}
