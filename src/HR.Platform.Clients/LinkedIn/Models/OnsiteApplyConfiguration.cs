using Newtonsoft.Json;

namespace HR.Platform.Clients.LinkedIn.Models
{
	public partial class OnsiteApplyConfiguration
    {
        [JsonProperty("jobApplicationWebhookUrl")]
        public Uri JobApplicationWebhookUrl { get; set; }

        [JsonProperty("questions")]
        public Questions Questions { get; set; }
    }
}
