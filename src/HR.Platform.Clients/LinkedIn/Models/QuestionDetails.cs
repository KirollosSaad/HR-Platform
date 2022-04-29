using Newtonsoft.Json;

namespace HR.Platform.Clients.LinkedIn.Models
{
	public partial class QuestionDetails
    {
        [JsonProperty("multipleChoiceQuestionDetails")]
        public MultipleChoiceQuestionDetails MultipleChoiceQuestionDetails { get; set; }
    }
}
