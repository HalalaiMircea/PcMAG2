using Microsoft.AspNetCore.Mvc;
using PcMAG2.Helpers;
using PcMAG2.Models.DTOs;
using PcMAG2.Services;

namespace PcMAG2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            var response = _userService.Register(model);
            if (response == null)
                return Conflict(new {message = "Account with this email already exists!"});

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(AuthRequest model)
        {
            var response = _userService.Login(model);
            if (response == null)
                return BadRequest(new {message = "Username or password is incorrect"});

            return Ok(response);
        }

        [HttpGet("all")]
        [Authorize]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("isLoggedIn")]
        [Authorize]
        public IActionResult IsLoggedIn()
        {
            return Ok(true);
        }
    }
}