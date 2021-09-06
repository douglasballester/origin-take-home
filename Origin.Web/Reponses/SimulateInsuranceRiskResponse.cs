using Newtonsoft.Json;

namespace Origin.Web.Reponses
{
    public class SimulateInsuranceRiskResponse
    {
        [JsonProperty("auto")]
        public string Auto { get; set; }

        [JsonProperty("disability")]
        public string Disability { get; set; }

        [JsonProperty("home")]
        public string Home { get; set; }

        [JsonProperty("life")]
        public string Life { get; set; }
    }
}
