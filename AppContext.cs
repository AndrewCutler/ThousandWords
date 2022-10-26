using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    public AppContext()
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

    }

    public virtual DbSet<Image> Images { get; set; }

}