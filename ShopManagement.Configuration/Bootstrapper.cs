namespace ShopManagement.Configuration;

public static class Bootstrapper
{
    public static void Config(IServiceCollection service, string connectionString)
    {
        service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
        service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();

        service.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
    }
}