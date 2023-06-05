namespace ShopManagement.Application.Contracts.ProductCategoryItems;

public struct ProductCategoryViewModel
{
    public Ulid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? Picture { get; set; }
    public string CreationDate { get; set; }
    public StatusType Status { get; set; }
    public uint ProductCount { get; set; }
}