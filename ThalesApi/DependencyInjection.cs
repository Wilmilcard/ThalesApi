using ThalesApi.BLL;
using ThalesApi.Interfaces;
using ThalesApi.Services;

namespace ThalesApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomizedServicesProject(this IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IProductBusiness, ProductBusiness>();


            return services;
        }
    }
}
