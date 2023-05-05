using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.DTOs.Login;

namespace TicketSystem.BL.Managers.AccountManager
{
    public interface IAccountManager
    {
        Task<TokenDto> Login(LoginDto credentials);
        Task<RegisterResult> Register(RegisterDto registerDto, string role);
    }
}
