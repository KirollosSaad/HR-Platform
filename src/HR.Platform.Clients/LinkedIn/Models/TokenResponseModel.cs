using Newtonsoft.Json;

namespace HR.Platform.Clients.LinkedIn.Models
{
	public class TokenResponseModel
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		[JsonProperty("expires_in")]
		public int ExpiresIn { get; set; }
	}
}
