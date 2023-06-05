namespace ShopManagement.Infrastructure.EfCore.Repository;

public class ProductCategoryRepository : GenericRepository<Ulid, ProductCategory>, IProductCategoryRepository
{
    private readonly ShopContext _context;

    public ProductCategoryRepository(ShopContext context) : base(context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<ProductCategoryViewModel>> SearchAsync(ProductCategorySearchModel searchModel)
    {
        var result = _context.ProductCategories!.Select(x => new ProductCategoryViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Picture = x.Picture,
            CreationDate = x.CreationDate,
            Status = x.Status
        });

        if (!string.IsNullOrWhiteSpace(searchModel.Name))
            result = result.Where(x => x.Name.Contains(searchModel.Name));

        if (!string.IsNullOrWhiteSpace(searchModel.Description))
            result = result.Where(x => x.Description.Contains(searchModel.Description));

        return await result.OrderBy(x => x.Name).Where(x => x.Status == StatusType.Show).ToListAsync();
    }

    public async ValueTask<EditProductCategory> GetByDetailsAsync(Ulid id)
        => (await _context.ProductCategories!.Select(x => new EditProductCategory
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Picture = x.Picture,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle,
            KeyWords = x.KeyWords,
            MetaDescription = x.MetaDescription,
            Slug = x.Slug
        }).FirstOrDefaultAsync(x => x.Id == id))!;

    public async ValueTask Delete(Ulid id)
    {
        (await _context.ProductCategories!.FindAsync(id))!.Delete(StatusType.Deleted);
        await _context.SaveChangesAsync();
    }
}