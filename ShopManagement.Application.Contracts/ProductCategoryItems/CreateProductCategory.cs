namespace ShopManagement.Application.Contracts.ProductCategoryItems;

public class CreateProductCategory
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string? Picture { get; set; }
    public string? PictureAlt { get; set; }
    public string? PictureTitle { get; set; }
    public string? MetaDescription { get; set; }
    public required string KeyWords { get; set; }
    public required string Slug { get; set; }

}