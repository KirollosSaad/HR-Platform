using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Internal;

using MediatR;

using System.Reflection;

namespace HR.Platform.Application.DIExtensions
{
    public static class ApplicationDIExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<ISystemClock, SystemClock>();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
