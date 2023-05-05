using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.DAL.Data.Models
{
    public class Developer : IdentityUser
    {
        //public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
