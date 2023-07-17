namespace ShopManagement.Infrastructure.EfCore.Context;

public class ShopContext : DbContext
{
    public ShopContext(DbContextOptions<ShopContext> options) : base(options)
    {
    }

    public DbSet<ProductCategory>? ProductCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductCategoryMapping).Assembly);

        new DnInitializer(modelBuilder).Seed();

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var properties = entityType.ClrType.GetProperties()
                .Where(p => p.PropertyType == typeof(Ulid) || p.PropertyType == typeof(Ulid?));

            foreach (var property in properties)
                modelBuilder.Entity(entityType.Name).Property(property.Name)
                    .HasConversion(new UlidToStringConverter());
        }

        base.OnModelCreating(modelBuilder);
    }
}