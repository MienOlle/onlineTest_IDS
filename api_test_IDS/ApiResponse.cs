using System.Text.Json.Serialization;

public class ApiResponse
{
    [JsonPropertyName("data")]
    public List<dataTransaction> Data { get; set; } = new List<dataTransaction>();

    [JsonPropertyName("status")]
    public List<statusInfo> Status { get; set; } = new List<statusInfo>();
}