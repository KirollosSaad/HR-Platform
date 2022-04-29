using Newtonsoft.Json;

namespace HR.Platform.Clients.LinkedIn.Models
{
	public partial class EducationQuestions
    {
        [JsonProperty("educationExperienceQuestionSet")]
        public VoluntarySelfIdentificationQuestions EducationExperienceQuestionSet { get; set; }
    }
}
