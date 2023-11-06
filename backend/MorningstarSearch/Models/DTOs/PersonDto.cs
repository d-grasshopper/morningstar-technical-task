using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MorningstarSearch.Models.DTOs;

public class PersonDto
{
    public int Id { get; set; }
    
    [JsonProperty("first_name")]
    public string FirstName { get; set; }
    
    [JsonProperty("last_name")]
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string Gender { get; set; }
}