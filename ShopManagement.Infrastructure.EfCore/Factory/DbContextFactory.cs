namespace ShopManagement.Infrastructure.EfCore.Factory;

public class DbContextFactory : IDesignTimeDbContextFactory<ShopContext>
{
    public ShopContext CreateDbContext(string[] arg)
    {
        return new(new DbContextOptionsBuilder<ShopContext>()
            .UseSqlServer("Server=.;Database=Atlas;Trusted_Connection=True;TrustServerCertificate=True").Options);
    }
}