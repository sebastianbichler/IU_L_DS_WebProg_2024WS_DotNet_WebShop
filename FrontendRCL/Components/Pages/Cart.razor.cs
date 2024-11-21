using BackendBusinessObject;
using BackendDatabaseAccess;
using Radzen;
using System.Net.Http.Json;
using FrontendRCL.Components.Pages;

namespace FrontendRCL.Components.Pages;
public partial class Cart
{

    public List<Products>? ProductData;
    public List<Products> ProductsInCart = [];
    private string? errorMessage;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            HttpClient Backend = HttpClientFactory.CreateClient("ApiHttpClient");
            List<Products>? response = await Backend.GetFromJsonAsync<List<Products>>("/api/products") ?? [];
            ProductData = response;
        }
        catch (Exception ex)
        {
            errorMessage = $"Error fetching data: {ex.Message}";
            Console.WriteLine(errorMessage);
        }

    }

    public void OnRowDoubleClick(DataGridRowMouseEventArgs<Products> args)
    {
        Products product = args.Data;

        ProductsInCart.Remove(product);

    }
}