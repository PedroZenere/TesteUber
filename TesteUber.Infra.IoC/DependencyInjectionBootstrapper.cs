using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteUber.Infra.EmailGateway.AmazonMailService.Interfaces;
using TesteUber.Infra.EmailGateway.AmazonMailService.Services;

namespace TesteUber.Infra.IoC
{
    public static class DependencyInjectionBootstrapper
    {
        public static void BoostrapDependencyInjection(this IServiceCollection services, IConfiguration cfg)
        {
            services.AddScoped<IMailGateway, MailGateway>();
        }
    }
}
