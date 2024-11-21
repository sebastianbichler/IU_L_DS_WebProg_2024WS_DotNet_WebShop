using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Radzen;

namespace FrontendRCL;

public static class FrontendRCLServiceDI
{
    public static IServiceCollection AddFrontendRCLServiceDI(this IServiceCollection Services, IConfiguration Configuration)
    {
        _ = Services.AddRadzenComponents();
        return Services;
    }
}
