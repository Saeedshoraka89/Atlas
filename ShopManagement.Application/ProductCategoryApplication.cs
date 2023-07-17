namespace ShopManagement.Application;

public class ProductCategoryApplication : IProductCategoryApplication
{
    private readonly IProductCategoryRepository _repository;

    public ProductCategoryApplication(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<ICollection<ProductCategoryViewModel>> GetAllAsync()
    {
        return (await _repository.GetAllAsync()).Select(x => new ProductCategoryViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Picture = x.Picture,
            CreationDate = x.CreationDate,
            Status = x.Status
        }).Where(x => x.Status == StatusType.Show).ToList();
    }

    public async ValueTask<OperationResult> CreateAsync(CreateProductCategory entity)
    {
        OperationResult result = new();

        try
        {
            if (await _repository.CheckExistAsync(x => x.Name == entity.Name))
                return result.Failed("لطفا از درج مقادیر تکراری خود داری فرمائید");

            await _repository.CreateAsync(new ProductCategory(entity.Name, entity.Description, entity.Picture,
                entity.PictureAlt,
                entity.PictureTitle, entity.MetaDescription, entity.KeyWords, entity.Slug.Slugify()));

            await _repository.SaveAsync();

            return result.Succeeded();
        }
        catch (Exception e)
        {
            return result.Failed(e.Message);
        }
    }

    public async ValueTask<OperationResult> UpdateAsync(EditProductCategory entity)
    {
        OperationResult result = new();

        try
        {
            if (await _repository.CheckExistAsync(x => x.Name == entity.Name))
                return result.Failed("لطفا از درج مقادیر تکراری خود داری فرمائید");

            if (await _repository.CheckExistAsync(x => x.Name == entity.Name && x.Id != entity.Id))
                return result.Failed("موردی یافت نشد\nخطا در ویرایش");

            var productCategory = await _repository.GetById(entity.Id);

            productCategory.Edit(entity.Name, entity.Description, entity.Picture, entity.PictureAlt,
                entity.PictureTitle, entity.MetaDescription, entity.KeyWords, entity.Slug.Slugify());

            await _repository.SaveAsync();

            return result.Succeeded();
        }
        catch (Exception e)
        {
            return result.Failed(e.Message);
        }
    }

    public async ValueTask<OperationResult> DeleteAsync(Ulid id)
    {
        OperationResult result = new();

        try
        {
            if (!await _repository.CheckExistAsync(x => x.Id == id))
                return result.Failed("موردی یافت نشد\nخطا در حذف");

            var productCategory = await _repository.GetById(id);

            productCategory.Delete(StatusType.Deleted);

            await _repository.SaveAsync();

            return result.Succeeded();
        }
        catch (Exception e)
        {
            return result.Failed(e.Message);
        }
    }

    public async ValueTask<ICollection<ProductCategoryViewModel>> SearchAsync(ProductCategorySearchModel searchModel)
    {
        return await _repository.SearchAsync(searchModel);
    }

    public async ValueTask<EditProductCategory> GetByDetailsAsync(Ulid id)
    {
        return await _repository.GetByDetailsAsync(id);
    }
}