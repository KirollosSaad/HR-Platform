using Newtonsoft.Json;

namespace HR.Platform.Clients.LinkedIn.Models
{
	public partial class Question
    {
        [JsonProperty("required")]
        public bool QuestionRequired { get; set; }

        [JsonProperty("partnerQuestionIdentifier")]
        public string PartnerQuestionIdentifier { get; set; }

        [JsonProperty("questionText")]
        public string QuestionText { get; set; }

        [JsonProperty("questionDetails")]
        public QuestionDetails QuestionDetails { get; set; }
    }
}
