using BackendBusinessLogic.Endpoints;

using Microsoft.AspNetCore.Builder;

namespace BackendBusinessLogic;


public static class BackendBLEndpoints
{
    public static void MapBackendBLEndpoints(this WebApplication app)
    {
        app.MapShopEndpoints();
    }
}
