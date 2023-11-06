using System.Text.Json.Serialization;

namespace MorningstarSearch.Models.DTOs;

public class PersonDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }
    
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("gender")]
    public string Gender { get; set; }
}