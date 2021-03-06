﻿using System.ComponentModel.DataAnnotations;

#nullable disable
namespace PcMAG2.Models.DTOs
{
    public class RegisterRequest
    {
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
    }
}