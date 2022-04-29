using Newtonsoft.Json;

namespace HR.Platform.Clients.LinkedIn.Models
{
	public partial class AdditionalQuestions
    {
        [JsonProperty("customQuestionSets")]
        public List<CustomQuestionSet> CustomQuestionSets { get; set; }
    }
}
