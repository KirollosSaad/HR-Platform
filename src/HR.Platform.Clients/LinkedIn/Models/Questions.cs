using Newtonsoft.Json;

namespace HR.Platform.Clients.LinkedIn.Models
{
	public partial class Questions
    {
        [JsonProperty("voluntarySelfIdentificationQuestions")]
        public VoluntarySelfIdentificationQuestions VoluntarySelfIdentificationQuestions { get; set; }

        [JsonProperty("educationQuestions")]
        public EducationQuestions EducationQuestions { get; set; }

        [JsonProperty("workQuestions")]
        public WorkQuestions WorkQuestions { get; set; }

        [JsonProperty("additionalQuestions")]
        public AdditionalQuestions AdditionalQuestions { get; set; }
    }
}
