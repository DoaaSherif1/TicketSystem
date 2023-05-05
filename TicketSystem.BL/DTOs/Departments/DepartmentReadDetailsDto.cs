using TicketSystem.BL.DTOs.Tickets;

namespace TicketSystem.BL.DTOs.Departments
{
    public class DepartmentReadDetailsDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public ICollection<TicketDeveloperReadDto> Tickets { get; set; } = new HashSet<TicketDeveloperReadDto>();

    }
}

