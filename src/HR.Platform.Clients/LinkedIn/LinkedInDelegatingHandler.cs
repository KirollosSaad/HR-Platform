using HR.Platform.Clients.LinkedIn.Configurations;
using HR.Platform.Clients.LinkedIn.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

using Newtonsoft.Json;

namespace HR.Platform.Clients.LinkedIn
{
	public class LinkedInDelegatingHandler : DelegatingHandler
	{
		private const string LINKEDIN_TOKEN_KEY = "LINKEDIN_TOKEN_KEY";

		private readonly HttpClient _httpClient;
		private readonly IMemoryCache _memoryCache;
		private readonly LinkedInClientConfiguration _clientOptions;

		public LinkedInDelegatingHandler(IMemoryCache memoryCache, HttpClient httpClient, IOptions<LinkedInClientConfiguration> clientOptions)
		{
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
			_memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
			_clientOptions = clientOptions.Value ?? throw new ArgumentNullException(nameof(clientOptions));
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (!_memoryCache.TryGetValue(LINKEDIN_TOKEN_KEY, out TokenResponseModel jwtSecurityToken))
			{
				jwtSecurityToken = await GetTokenAsync();
				_memoryCache.Set(LINKEDIN_TOKEN_KEY, jwtSecurityToken, TimeSpan.FromSeconds(jwtSecurityToken.ExpiresIn - 1));
			}

			request.Headers.Authorization = new  ("Authorization", $"Bearer {jwtSecurityToken.AccessToken}");

			var response = await base.SendAsync(request, cancellationToken);
			response.EnsureSuccessStatusCode();

			return response;
		}

		private async Task<TokenResponseModel> GetTokenAsync()
		{
			const string RequestPath = "oauth/v2/accessToken";

			var parameteres = new Dictionary<string, string>
			{
				{ "grant_type", "client_credentials" },
				{ "client_id", _clientOptions.ClientId },
				{ "client_secret", _clientOptions.ClientSecret }
			};

			var content = new FormUrlEncodedContent(parameteres);
			
			var response = await _httpClient.PostAsync(RequestPath, content);

			response.EnsureSuccessStatusCode();

			var responseText = await response.Content.ReadAsStringAsync();
			var token = JsonConvert.DeserializeObject<TokenResponseModel>(responseText);

			return token;
		}
	}
}
