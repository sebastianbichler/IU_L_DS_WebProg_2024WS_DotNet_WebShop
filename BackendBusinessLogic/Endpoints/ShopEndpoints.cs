using BackendBusinessLogic.Services;

using BackendBusinessObject;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BackendBusinessLogic.Endpoints;
public static class ShopEndpoints
{

    public static void MapShopEndpoints(this WebApplication app)
    {
        RouteGroupBuilder shopGroup = app.MapGroup("/api/products");

        _ = shopGroup.MapGet("/", async ([FromServices] ShopServices shopServices) =>
        {
            try
            {
                List<Products>? result = await shopServices.GetProducts();
                return Results.Ok(result);

            }
            catch (Exception ex)
            {
                ProductLogger.LogError($"An error occurred: {ex.Message}");
                return Results.Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        });

        _ = shopGroup.MapPost("/", async ([FromServices] ShopServices shopServices, [FromBody] Products products) =>
        {
            try
            {
                Products result = await shopServices.AddProducts(products);
                return Results.Created($"/api/products/{result.Id}", result);
            }
            catch (Exception ex)
            {
                ProductLogger.LogError($"An error occurred: {ex.Message}");
                return Results.Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        });

        _ = shopGroup.MapDelete("/{Id:int}", async ([FromServices] ShopServices shopServices, int Id) =>
        {
            try
            {
                bool deleted = await shopServices.DeleteProducts(Id);
                return deleted ? Results.NoContent() : Results.NotFound();
            }
            catch (Exception ex)
            {
                ProductLogger.LogError($"An error occurred: {ex.Message}");
                return Results.Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        });

        _ = shopGroup.MapPut("/{Id:int}", async ([FromServices] ShopServices shopServices, int Id, [FromBody] Products updatedProduct) =>
        {
            try
            {
                Products? result = await shopServices.UpdateProducts(Id, updatedProduct);
                return result == null ? Results.NotFound() : Results.Ok(result);
            }
            catch (Exception ex)
            {
                ProductLogger.LogError($"An error occurred: {ex.Message}");
                return Results.Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        });
    }

}
