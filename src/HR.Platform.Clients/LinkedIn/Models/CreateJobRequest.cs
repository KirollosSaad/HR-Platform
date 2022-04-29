using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System.Globalization;

namespace HR.Platform.Clients.LinkedIn.Models
{
	public partial class CreateJobRequest
    {
        [JsonProperty("elements")]
        public List<Element> Elements { get; set; }
    }

    public partial class CreateJobRequest
    {
        public static CreateJobRequest FromJson(string json) => JsonConvert.DeserializeObject<CreateJobRequest>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CreateJobRequest self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new()
		{
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
