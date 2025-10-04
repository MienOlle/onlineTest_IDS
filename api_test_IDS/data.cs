using System.Text.Json.Serialization;

public class dataTransaction
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("productID")]
    public string ProductID { get; set; } = string.Empty;
    [JsonPropertyName("productName")]
    public string ProductName { get; set; } = string.Empty;
    [JsonPropertyName("amount")]
    public string Amount { get; set; } = string.Empty;
    [JsonPropertyName("customerName")]
    public string CustomerName { get; set; } = string.Empty;
    [JsonPropertyName("status")]
    public int Status { get; set; }
    [JsonPropertyName("transactionDate")]
    public DateTime TransactionDate { get; set; }
    [JsonPropertyName("createBy")]
    public string CreateBy { get; set; } = string.Empty;
    [JsonPropertyName("createOn")]
    public DateTime CreateOn { get; set; }
}