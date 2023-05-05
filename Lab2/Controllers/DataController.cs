using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DAL.Data.Models;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly UserManager<Developer> _userManager;

        public DataController(UserManager<Developer> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetSecuredData()
        {
            var user = await _userManager.GetUserAsync(User);

            return Ok(new string[] {
            user!.UserName,
            user!.Email!,
            user!.Position
            });
        }

        [HttpGet]
        [Authorize(Policy = "Admins")]
        [Route("ForAdmins")]
        public async Task<ActionResult> GetSecuredDataForManagers()
        {
            var user = await _userManager.GetUserAsync(User);

            return Ok(new string[] {
            user!.UserName,
            user!.Email!,
            user!.Position,
            "This Data For Admins Only"
            });
        }

        [HttpGet]
        [Authorize(Policy = "Users")]
        [Route("ForUsers")]
        public async Task<ActionResult> GetSecuredDataForEmployees()
        {
            var user = await _userManager.GetUserAsync(User);

            return Ok(new string[] {
            user!.UserName,
            user!.Email!,
            user!.Position,
            "This Data For Users and Admins"
            });
        }
    }
}
