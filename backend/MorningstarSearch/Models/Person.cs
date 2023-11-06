using System.ComponentModel.DataAnnotations;

namespace MorningstarSearch.Models;

public class Person
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [MaxLength(100)]
    public string Email { get; set; }
    
    [MaxLength(10)]
    public string Gender { get; set; }
}