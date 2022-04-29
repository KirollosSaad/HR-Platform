using Newtonsoft.Json;

namespace HR.Platform.Clients.LinkedIn.Models
{
	public partial class MultipleChoiceQuestionDetails
    {
        [JsonProperty("choices")]
        public List<Choice> Choices { get; set; }

        [JsonProperty("selectMultiple")]
        public bool SelectMultiple { get; set; }

        [JsonProperty("defaultValueSymbolicName")]
        public string DefaultValueSymbolicName { get; set; }

        [JsonProperty("preferredFormComponent")]
        public string PreferredFormComponent { get; set; }

        [JsonProperty("favorableMultipleChoiceAnswer")]
        public FavorableMultipleChoiceAnswer FavorableMultipleChoiceAnswer { get; set; }
    }
}
