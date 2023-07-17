namespace Atlas.API.ShopManagement;

public static class ProductCategoryRoute
{
    public static void MapProductCategoryRoute(this IEndpointRouteBuilder app)
    {
        var item = app.MapGroup("Api/ProductCategory");

        item.MapGet("/AllProductCategories", async (IProductCategoryApplication application) =>
        {
            try
            {
                return Results.Ok(await application.GetAllAsync());
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        item.MapGet("/ProductCategoryById/{id}", async (Ulid id, IProductCategoryApplication application) =>
        {
            try
            {
                return Results.Ok(await application.GetByDetailsAsync(id));
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        item.MapGet("/Search",
            async ([FromBody] ProductCategorySearchModel searchModel, IProductCategoryApplication application) =>
            {
                try
                {
                    return Results.Ok(await application.SearchAsync(searchModel));
                }
                catch (Exception e)
                {
                    return Results.BadRequest(e.Message);
                }
            });

        item.MapPost("/Insert", async (CreateProductCategory entity, IProductCategoryApplication application) =>
        {
            try
            {
                return Results.Ok(await application.CreateAsync(entity));
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        item.MapPut("/Update", async (EditProductCategory entity, IProductCategoryApplication application) =>
        {
            try
            {
                return Results.Ok(await application.UpdateAsync(entity));
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        item.MapDelete("/Delete/{id}", async (Ulid id, IProductCategoryApplication application) =>
        {
            try
            {
                return Results.Ok(await application.DeleteAsync(id));
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });
    }
}