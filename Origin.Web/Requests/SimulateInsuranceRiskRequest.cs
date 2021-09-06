using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Origin.Web.Requests
{
    public class SimulateInsuranceRiskRequest
    {
        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("dependents")]
        public int Dependents { get; set; }

        [JsonPropertyName("income")]
        public double Income { get; set; }

        [JsonPropertyName("marital_status")]
        public string MaritalStatus { get; set; }

        [JsonPropertyName("risk_questions")]
        public List<byte> RiskQuestions { get; set; }

        [JsonPropertyName("house")]
        public HouseRequest House { get; set; }

        [JsonPropertyName("vehicle")]
        public VehicleRequest Vehicle { get; set; }
    }
}
