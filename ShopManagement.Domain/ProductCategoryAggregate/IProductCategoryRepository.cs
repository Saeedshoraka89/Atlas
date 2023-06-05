namespace ShopManagement.Domain.ProductCategoryAggregate;

public interface IProductCategoryRepository : IGenericRepository<Ulid, ProductCategory>
{
    ValueTask<ICollection<ProductCategoryViewModel>> SearchAsync(ProductCategorySearchModel searchModel);
    ValueTask<EditProductCategory> GetByDetailsAsync(Ulid id);
    ValueTask Delete(Ulid id);
}