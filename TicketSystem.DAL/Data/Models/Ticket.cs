using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DAL.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
    }
}
