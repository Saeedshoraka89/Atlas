namespace ShopManagement.Infrastructure.EfCore;

internal class DnInitializer
{
    private readonly ModelBuilder _modelBuilder;

    public DnInitializer(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        _modelBuilder.Entity<ProductCategory>().HasData(
            new ProductCategory("Test", "Test", "Test", "Test", "Test", "Test", "Test", "Test"));
    }
}