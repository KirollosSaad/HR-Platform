using Newtonsoft.Json;

namespace HR.Platform.Clients.LinkedIn.Models
{
	public partial class FavorableMultipleChoiceAnswer
    {
        [JsonProperty("favorableSymbolicNames")]
        public List<string> FavorableSymbolicNames { get; set; }
    }
}
