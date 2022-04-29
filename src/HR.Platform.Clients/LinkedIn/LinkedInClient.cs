using HR.Platform.Clients.LinkedIn.Interfaces;
using HR.Platform.Clients.LinkedIn.Models;

namespace HR.Platform.Clients.LinkedIn
{
	public class LinkedInClient : ILinkedInClient
	{
		private readonly HttpClient _httpClient;
		private const string _requestPath = "v2/simpleJobPostings";

		public LinkedInClient(HttpClient httpClient)
		{
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
		}

		public async Task PostJobAsync(CreateJobRequest jobRequest, CancellationToken cancellationToken = default)
		{
			var content = new StringContent(jobRequest.ToJson());
			content.Headers.Add("x-restli-method", "batch_create");

			var response = await _httpClient.PostAsync(_requestPath, content, cancellationToken);

			response.EnsureSuccessStatusCode();
		}
	}
}
