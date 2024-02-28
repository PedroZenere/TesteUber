using Microsoft.Extensions.DependencyInjection;
using TesteUber.Infra.EmailGateway.AmazonMailGateway.Interfaces;
using TesteUber.Infra.EmailGateway.AmazonMailGateway.Services;

namespace TesteUber.Infra.IoC
{
    public static class DependencyInjectionBootstrapper
    {
        public static void BoostrapDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IMailGateway, MailGateway>();
        }
    }
}
