namespace Atlas.Connector.ShopManagement;

public class ProductCategoriesInformation
{
    private readonly HttpClient? _client;
    private readonly string apiAddress = "https://localhost:7063/Api/ProductCategory";
    private readonly HttpClientHandler? ClientHandler;

    public ProductCategoriesInformation()
    {
        ClientHandler = new HttpClientHandler();
        ClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        _client = new HttpClient(ClientHandler);
    }

    public async Task<IList<ProductCategoryViewModel>> GetAllAsync()
    {
        try
        {
            using StringReader treader =
                new(await Task.Run(() => _client?.GetStringAsync(apiAddress + "/AllProductCategories")));
            await using JsonTextReader jReader = new(treader);
            return new JsonSerializer().Deserialize<List<ProductCategoryViewModel>>(jReader)!;
        }
        catch
        {
            return null;
        }
    }

    public async Task<ProductCategoryViewModel?> GetByIdAsync(int id)
    {
        try
        {
            return await Task.Run(() =>
                JsonConvert.DeserializeObject<ProductCategoryViewModel>(
                    _client?.GetStringAsync($"{apiAddress}/ProductCategoryById/{id}").Result ?? string.Empty));
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> InsertAsync(CreateProductCategory itemList)
    {
        try
        {
            var result = await Task.Run(() => _client?.PostAsync($"{apiAddress}/Insert",
                new StringContent(JsonConvert.SerializeObject(itemList), Encoding.UTF8, "application/Json")));
            return result.StatusCode == HttpStatusCode.OK;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(EditProductCategory itemList)
    {
        try
        {
            var result = await Task.Run(() => _client?.PutAsync($"{apiAddress}/Update",
                new StringContent(JsonConvert.SerializeObject(itemList), Encoding.UTF8, "application/Json")));
            return result.StatusCode == HttpStatusCode.OK;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(Ulid id)
    {
        try
        {
            var result = await Task.Run(() => _client?.DeleteAsync($"{apiAddress}/Delete/{id}"));
            return result.StatusCode == HttpStatusCode.OK;
        }
        catch
        {
            return false;
        }
    }
}