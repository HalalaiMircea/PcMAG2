#nullable enable
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PcMAG2.Helpers;
using PcMAG2.Models;
using PcMAG2.Models.DTOs;
using PcMAG2.Models.Entities;
using PcMAG2.Repositories;

namespace PcMAG2.Services
{
    public class UserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User? GetById(int id)
        {
            return _userRepository.FindById(id);
        }

        public AuthResponse? Login(AuthRequest request)
        {
            // find user
            var user = _userRepository.GetByEmailAndPassword(request.Email, request.Password);
            if (user == null) return null;

            // attach token
            var token = GenerateJwtForUser(user);

            // return user & token
            return new AuthResponse(user.UserId, user.Email, user.FirstName, user.LastName, token);
        }

        private string GenerateJwtForUser(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {new Claim("id", user.UserId.ToString())}),
                Expires = null /*DateTime.UtcNow.AddDays(7)*/,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}