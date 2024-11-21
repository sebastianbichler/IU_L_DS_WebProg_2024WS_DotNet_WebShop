using System.Net.Http;
using System.Net.Http.Json;

using BackendBusinessObject;

using Radzen;

namespace FrontendRCL.Components.Pages;
public partial class Homepage
{
    public List<Products>? ProductData;
    private string? errorMessage;
    private List<Products> ProductsInCart = [];

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


    private async Task ShowDialogAddNewDevice()
    {
        _ = await DialogService.OpenAsync<Homepage>("",
               null,
               new DialogOptions()
               {
                   Resizable = true,
                   Draggable = true,
                   CloseDialogOnEsc = true
               });

        await OnInitializedAsync();
    }


    public async void OnRowDoubleClick(DataGridRowMouseEventArgs<Products> args)
    {
        Products product = args.Data;

        await ShowDialogProductInformation(product);

    }

    private async Task ShowDialogProductInformation(Products product)
    {

        _ = await DialogService.OpenAsync<Homepage>(null,
              new Dictionary<string, object> { { "Product", product } },
               new DialogOptions()
               {
                   Resizable = false,
                   Draggable = true,
                   CloseDialogOnEsc = true
               });

        await OnInitializedAsync();
    }



}
