using auth_service.Application.Interfaces.Services;
using auth_service.Infrastructure;

namespace auth_service.Configuration
{
    public static class LocalDependencyRegistration
    {
        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            return services;
        }
    }
}
