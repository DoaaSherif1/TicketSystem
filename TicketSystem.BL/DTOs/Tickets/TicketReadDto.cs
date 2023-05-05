using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.BL.DTOs.Tickets
{
    public class TicketReadDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }
}
