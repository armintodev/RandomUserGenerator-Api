using Microsoft.Extensions.DependencyInjection;
using UserGenerator.Api.Http;

namespace UserGenerator.Api.Extensions
{
    public static class ClientHelperExtension
    {
        public static void AddClientHelper(this IServiceCollection services)
        {
            services.AddScoped<IClientHelper, ClientHelper>();
        }
    }
}
