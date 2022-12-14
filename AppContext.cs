using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

    }

    public virtual DbSet<Image> Images { get; set; }
    public virtual DbSet<Link> Links { get; set; }
    public virtual DbSet<Album> Albums { get; set; }
}