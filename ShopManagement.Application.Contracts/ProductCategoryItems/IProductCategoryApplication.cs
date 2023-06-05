namespace ShopManagement.Application.Contracts.ProductCategoryItems;

public interface IProductCategoryApplication
{
    ValueTask<ICollection<ProductCategoryViewModel>> GetAllAsync();
    ValueTask<OperationResult> CreateAsync(CreateProductCategory entity);
    ValueTask<OperationResult> UpdateAsync(EditProductCategory entity);
    ValueTask<OperationResult> DeleteAsync(Ulid id);
    ValueTask<ICollection<ProductCategoryViewModel>> SearchAsync(ProductCategorySearchModel searchModel);
    ValueTask<EditProductCategory> GetByDetailsAsync(Ulid id);
}