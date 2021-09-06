using System.Text.Json.Serialization;

namespace Origin.Web.Requests
{
    public class HouseRequest
    {
        [JsonPropertyName("ownership_status")]
        public string OwnershipStatus { get; set; }
    }
}
