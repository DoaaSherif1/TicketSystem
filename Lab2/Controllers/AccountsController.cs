using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketSystem.BL.DTOs.Login;
using TicketSystem.BL.Managers.AccountManager;
using TicketSystem.BL.Managers.Tickets;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountManager _accountsManager;

        public AccountsController(IAccountManager accountsManager)
        {
            _accountsManager = accountsManager;
        }
        [HttpPost]
        [Route("Login")]
        public Task<TokenDto> Login(LoginDto credentials)
        {
            return _accountsManager.Login(credentials);
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> ManagerRegister(RegisterDto registerDto,string role)
        {
            RegisterResult result = await _accountsManager.Register(registerDto, role);
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return NoContent();
        }

        [HttpPost]
        [Route("AdminRegister")]
        public async Task<ActionResult> AdminRegister(RegisterDto registerDto)
        {
            RegisterResult result = await _accountsManager.Register(registerDto, "admin");
            if(result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return NoContent();
        }

        [HttpPost]
        [Route("UserRegister")]
        public async Task<ActionResult> UserRegister(RegisterDto registerDto)
        {
            RegisterResult result = await _accountsManager.Register(registerDto, "user");
            if (result.IsSuccess == false)
            {
                return BadRequest(result);
            }
            return NoContent();
        }
    }
}
