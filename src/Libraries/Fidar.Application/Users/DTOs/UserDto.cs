using System.ComponentModel.DataAnnotations;

namespace Fidar.Application.Users.DTOs;

public class UserDto
{
    
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public int Age { get; set; }
    public decimal Credit { get; set; } = 0;
}
