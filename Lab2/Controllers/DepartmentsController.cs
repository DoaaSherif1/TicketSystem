using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.BL.DTOs.Departments;
using TicketSystem.BL.Managers.Departments;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsManager _departmentsManager;

        public DepartmentsController(IDepartmentsManager departmentsManager)
        {
            _departmentsManager = departmentsManager;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<DepartmentReadDetailsDto> GetDetails(int id)
        {
            DepartmentReadDetailsDto? dept = _departmentsManager.GetDetails(id);
            if (dept is null)
            {
                return NotFound();
            }
            return dept; 
        }
    }
}
