using Newtonsoft.Json;

namespace HR.Platform.Clients.LinkedIn.Models
{
	public partial class Element
    {
        [JsonProperty("externalJobPostingId")]
        public string ExternalJobPostingId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("integrationContext")]
        public string IntegrationContext { get; set; }

        [JsonProperty("listedAt")]
        public long ListedAt { get; set; }

        [JsonProperty("jobPostingOperationType")]
        public string JobPostingOperationType { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("availability")]
        public string Availability { get; set; }

        [JsonProperty("industries")]
        public List<string> Industries { get; set; }

        [JsonProperty("categories")]
        public List<string> Categories { get; set; }

        [JsonProperty("trackingPixelUrl")]
        public Uri TrackingPixelUrl { get; set; }

        [JsonProperty("companyApplyUrl")]
        public Uri CompanyApplyUrl { get; set; }

        [JsonProperty("posterEmail")]
        public string PosterEmail { get; set; }

        [JsonProperty("onsiteApplyConfiguration")]
        public OnsiteApplyConfiguration OnsiteApplyConfiguration { get; set; }
    }
}
