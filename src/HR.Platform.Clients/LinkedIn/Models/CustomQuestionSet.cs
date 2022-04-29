using Newtonsoft.Json;

namespace HR.Platform.Clients.LinkedIn.Models
{
	public partial class CustomQuestionSet
    {
        [JsonProperty("repeatLimit")]
        public long RepeatLimit { get; set; }

        [JsonProperty("questions")]
        public List<Question> Questions { get; set; }
    }
}
