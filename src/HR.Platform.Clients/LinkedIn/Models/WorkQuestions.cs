using Newtonsoft.Json;

namespace HR.Platform.Clients.LinkedIn.Models
{
	public partial class WorkQuestions
    {
        [JsonProperty("workExperienceQuestionSet")]
        public VoluntarySelfIdentificationQuestions WorkExperienceQuestionSet { get; set; }
    }
}
