using System.ComponentModel.DataAnnotations;

#nullable disable
namespace PcMAG2.Models.DTOs
{
    public class AuthRequest
    {
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
    }
}