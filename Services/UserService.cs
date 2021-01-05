#nullable enable
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PcMAG2.Helpers;
using PcMAG2.Models.DTOs;
using PcMAG2.Models.Entities;
using PcMAG2.Repositories;

namespace PcMAG2.Services
{
    public class UserService
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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

        public AuthResponse? Register(RegisterRequest request)
        {
            // If user with the same email exists, return null
            if (_userRepository.FindByEmail(request.Email) != null)
                return null;
            var user = _mapper.Map<RegisterRequest, User>(request);

            _userRepository.Create(user);
            // If we can't save the new user, return null
            if (!_userRepository.SaveChanges())
                return null;
            var authResponse = _mapper.Map<User, AuthResponse>(user);
            authResponse.Token = GenerateJwtForUser(user);
            return authResponse;
        }

        public AuthResponse? Login(AuthRequest request)
        {
            // find user
            var user = _userRepository.GetByEmailAndPassword(request.Email, request.Password);
            if (user == null) return null;

            // attach token to DTO
            var authResponse = _mapper.Map<User, AuthResponse>(user);
            authResponse.Token = GenerateJwtForUser(user);
            
            return authResponse;
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