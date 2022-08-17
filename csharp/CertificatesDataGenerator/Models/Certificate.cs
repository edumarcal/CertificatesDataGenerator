using System.Text.Json.Serialization;

namespace CertificatesDataGenerator.Models
{
    public class Certificate
    {
        [JsonPropertyName("institute")]
        public string Institute { get; set; }

        [JsonPropertyName("workload")]
        public string Workload { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("year")]
        public string Year { get; set; }

        public Certificate(string institute, string workload, string link, string description, string year)
        {
            Institute = institute;
            Workload = workload;
            Link = link;
            Description = description;
            Year = year;
        }
    }
}
