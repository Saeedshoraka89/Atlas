namespace ShopManagement.Domain.ProductCategoryAggregate;

public class ProductCategory : BaseEntity
{
    public ProductCategory(string name, string description, string? picture, string? pictureAlt, string? pictureTitle,
        string? metaDescription, string keyWords, string slug)
    {
        Id = Ulid.NewUlid();
        Name = name;
        Description = description;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        MetaDescription = metaDescription;
        KeyWords = keyWords;
        Slug = slug;
        Status = StatusType.Show;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public string? Picture { get; private set; }
    public string? PictureAlt { get; private set; }
    public string? PictureTitle { get; private set; }
    public string? MetaDescription { get; private set; }
    public string KeyWords { get; private set; }
    public string Slug { get; private set; }
    public StatusType Status { get; private set; }

    public void Edit(string name, string description, string? picture, string? pictureAlt, string? pictureTitle,
        string? metaDescription, string keyWords, string slug)
    {
        Name = name;
        Description = description;
        Picture = picture;
        PictureAlt = pictureAlt;
        PictureTitle = pictureTitle;
        MetaDescription = metaDescription;
        KeyWords = keyWords;
        Slug = slug;
    }

    public void Delete(StatusType status)
    {
        Status = status;
    }
}