using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.DTOs.Departments;
using TicketSystem.DAL.Data.Models;

namespace TicketSystem.BL.Managers.Departments
{
    public interface IDepartmentsManager
    {
        DepartmentReadDetailsDto? GetDetails(int id);
    }
}
