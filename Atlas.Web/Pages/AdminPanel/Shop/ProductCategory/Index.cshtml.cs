namespace Atlas.Web.Pages.AdminPanel.Shop.ProductCategory;

public class IndexModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnGetCreate()
        => Partial("./Create", new CreateProductCategory());
}