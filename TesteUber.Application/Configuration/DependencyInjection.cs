using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TesteUber.Application.Configuration
{
    public static class DependencyInjection
    {
        public static void AddServiceMediatr(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }

        public static void AddServiceAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
