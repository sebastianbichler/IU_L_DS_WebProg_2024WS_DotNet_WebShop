using BackendBusinessLogic.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackendBusinessLogic;
public static class BackendBLServiceDI
{
    public static void AddBackendBLServiceDI(this IServiceCollection services, ConfigurationManager configuration)
    {
        _ = services.AddTransient<ShopServices>();
    }
}
