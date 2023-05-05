using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.DTOs.Login;
using TicketSystem.DAL.Data.Models;
using TicketSystem.DAL.Repos.Tickets;

namespace TicketSystem.BL.Managers.AccountManager
{
    public class AccountManager : IAccountManager
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Developer> _userManager;

        public AccountManager(IConfiguration configuration, UserManager<Developer> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        private TokenDto GenerateToken(IList<Claim> claimsList)
        {
            string keyString = _configuration.GetValue<string>("SecretKey") ?? string.Empty;
            var keyInBytes = Encoding.ASCII.GetBytes(keyString);
            var key = new SymmetricSecurityKey(keyInBytes);

            var signingCredentials = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256Signature);

            var expiry = DateTime.Now.AddMinutes(15);

            var jwt = new JwtSecurityToken(
                    expires: expiry,
                    claims: claimsList,
                    signingCredentials: signingCredentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwt);

            return new TokenDto(TokenResult.Success, tokenString, expiry);
            

        }

        public async Task<TokenDto> Login(LoginDto credentials)
        {
            Developer? user = await _userManager.FindByNameAsync(credentials.UserName);
            if (user == null)
            {
                // you can send a message
                return new TokenDto(TokenResult.Failure);
            }

            bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, credentials.Password);
            if (!isPasswordCorrect)
            {
                // you can send a message
                return new TokenDto(TokenResult.UserpasswordError);
            }

            var claimsList = await _userManager.GetClaimsAsync(user);

            return GenerateToken(claimsList);
        }

        public async Task<RegisterResult> Register(RegisterDto registerDto, string role)
        {
            var newAdmin = new Developer
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Position = registerDto.Position
            };

            var creationResult = await _userManager.CreateAsync(newAdmin,
                registerDto.Password);
            if (!creationResult.Succeeded)
            {
                return new RegisterResult(false, creationResult.Errors);
            }

            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.NameIdentifier, newAdmin.Id),
            new Claim(ClaimTypes.Role, role),
            new Claim("Nationality", "Egyptian")
            };

            await _userManager.AddClaimsAsync(newAdmin, claims);
            return new RegisterResult(true);
        }

        
    }
}
