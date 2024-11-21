using Microsoft.AspNetCore.Components;

using System.Net.Http.Json;

using BackendBusinessObject;


namespace FrontendRCL.Components.Pages;
public partial class ProductInfo
{
    [Parameter]
    public Products? Product { get; set; }
    public List<Products>? ProductData;



    protected override async Task OnInitializedAsync()
    {
        HttpClient Backend = HttpClientFactory.CreateClient("ApiHttpClient");
        List<Products>? response = await Backend.GetFromJsonAsync<List<Products>>("/api/products");
        ProductData = response ?? [];

    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    private void UpdateDate()
    {
        Product!.UpdateDate = DateOnly.FromDateTime(DateTime.Now);
    }
    
    private async Task OnClickBuy()
    {
        HttpClient Backend = HttpClientFactory.CreateClient("ApiHttpClient");

        List<Products>? data = await Backend.GetFromJsonAsync<List<Products>>("/api/products");

        ProductData = data ?? [];

        //ProductsInCart.Add(Product);

}



}
