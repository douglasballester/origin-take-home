using System.Text.Json.Serialization;

namespace Origin.Web.Requests
{
    public class VehicleRequest
    {
        [JsonPropertyName("year")]
        public int Year { get; set; }
    }
}
