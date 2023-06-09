﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.BL.DTOs.Tickets
{
    public class TicketDeveloperReadDto
    {
        public int Id { get; set; }
        public required string Description { get; set; } = string.Empty;
        public required string Title { get; set; } = string.Empty;
        public int DevelopersCount { get; set; }
    }
}
