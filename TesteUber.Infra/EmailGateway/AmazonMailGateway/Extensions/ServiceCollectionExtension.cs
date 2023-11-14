using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TesteUber.Infra.EmailGateway.AmazonMailGateway.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServiceAmazonSES(this IServiceCollection services)
        { 
            services.AddServiceAmazonSES();
        }
    }
}
