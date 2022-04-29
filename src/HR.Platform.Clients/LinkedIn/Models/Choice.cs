using Newtonsoft.Json;

namespace HR.Platform.Clients.LinkedIn.Models
{
	public partial class Choice
    {
        [JsonProperty("symbolicName")]
        public string SymbolicName { get; set; }

        [JsonProperty("displayValue")]
        public string DisplayValue { get; set; }
    }
}
