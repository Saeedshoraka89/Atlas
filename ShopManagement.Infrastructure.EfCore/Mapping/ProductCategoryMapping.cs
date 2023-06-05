namespace ShopManagement.Infrastructure.EfCore.Mapping;

public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategories");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.Picture).HasMaxLength(2500);
        builder.Property(x => x.PictureAlt).HasMaxLength(50);
        builder.Property(x => x.PictureTitle).HasMaxLength(50);
        builder.Property(x => x.MetaDescription).HasMaxLength(50);
        builder.Property(x => x.KeyWords).HasMaxLength(80).IsRequired();
        builder.Property(x => x.Slug).HasMaxLength(50).IsRequired();
        builder.Property(x => x.CreationDate).HasMaxLength(50).IsRequired();
    }
}