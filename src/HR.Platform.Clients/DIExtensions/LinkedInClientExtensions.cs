using HR.Platform.Clients.LinkedIn;
using HR.Platform.Clients.LinkedIn.Configurations;
using HR.Platform.Clients.LinkedIn.Interfaces;

using Microsoft.Extensions.DependencyInjection;

namespace HR.Platform.Clients.DIExtensions
{
	public static class LinkedInClientExtensions
	{
		public static IServiceCollection AddLinkedInClients(this IServiceCollection services, Action<LinkedInClientConfiguration> setupAction)
		{
			if (setupAction == null)
			{
				throw new ArgumentNullException(nameof(setupAction));
			}

			services.AddOptions<LinkedInClientConfiguration>().Configure(setupAction);

			services.AddLinkedInClients();

			return services;
		}

		private static IServiceCollection AddLinkedInClients(this IServiceCollection services)
		{
			services.AddMemoryCache();

			services.AddHttpClient<LinkedInDelegatingHandler>((client) =>
			{
				client.BaseAddress = new Uri("https://www.linkedin.com/");
			});

			services.AddHttpClient<ILinkedInClient, LinkedInClient>((client) =>
			{
				client.BaseAddress = new Uri("https://api.linkedin.com/");

			}).AddHttpMessageHandler<LinkedInDelegatingHandler>();

			return services;
		}
	}
}
