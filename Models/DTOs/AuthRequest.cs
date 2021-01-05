using System.ComponentModel.DataAnnotations;

namespace PcMAG2.Models.DTOs
{
    public class AuthRequest
    {
        [Required] public string Email { get; set; } = null!;
        [Required] public string Password { get; set; } = null!;
    }
}