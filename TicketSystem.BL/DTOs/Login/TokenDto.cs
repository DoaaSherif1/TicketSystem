using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.BL.DTOs.Login
{
    public enum TokenResult
    {
        Success = 0,
        UserNameError = 1,
        UserpasswordError = 2,
        Failure = 3,
    }
    public class TokenDto
    {
        public TokenDto(TokenResult result, string token = "", DateTime expire = default)
        {
            Result = result;
            Token = token;
            Expiry = expire;
        }
        

        public TokenResult Result;
        public string Token { get; set; } = string.Empty;
        public DateTime Expiry { get; set; }
    }
}
