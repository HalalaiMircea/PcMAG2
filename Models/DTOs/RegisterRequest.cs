using System.ComponentModel.DataAnnotations;

namespace PcMAG2.Models.DTOs
{
    public class RegisterRequest
    {
        public RegisterRequest(string email, string password, string firstName, string lastName)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }

        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
    }
}