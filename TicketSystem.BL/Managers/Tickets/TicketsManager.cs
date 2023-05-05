using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.DTOs.Tickets;
using TicketSystem.DAL.Data.Models;
using TicketSystem.DAL.Repos.Tickets;

namespace TicketSystem.BL.Managers.Tickets
{
    public class TicketsManager : ITicketsManager
    {
        private readonly ITicketsRepo _ticketsRepo;

        public TicketsManager(ITicketsRepo ticketsRepo)
        {
            _ticketsRepo = ticketsRepo;
        }

        public List<TicketReadDto> GetAll()
        {
            IEnumerable<Ticket> ticketsFromDb = _ticketsRepo.GetAll();
            return ticketsFromDb.Select(t => new TicketReadDto
            {
                Id = t.Id,
                Description = t.Description,
                Title = t.Title,
                DepartmentId = t.DepartmentId,
            }).ToList();
        }

        public TicketReadDto? GetById(int id)
        {
            var ticket = _ticketsRepo.GetById(id);
            if (ticket == null)
            {
                return null;
            }

            return new TicketReadDto
            {
                Id = ticket.Id,
                Description = ticket.Description,
                Title = ticket.Title,
                DepartmentId = ticket.DepartmentId,
            };
        }

        public int Add(TicketAddDto ticketDto)
        {
            var ticket = new Ticket
            {
                Description = ticketDto.Description,
                Title = ticketDto.Title,
                DepartmentId = ticketDto.DepartmentId,
            };
            _ticketsRepo.Add(ticket);
            _ticketsRepo.SaveChanges();

            return ticket.Id;
        }

        public bool Update(TicketUpdateDto ticketDto)
        {
            var ticketFromDb = _ticketsRepo.GetById(ticketDto.Id);
            if (ticketFromDb == null)
            {
                return false;
            }

            ticketFromDb.Description = ticketDto.Description;
            ticketFromDb.Title = ticketDto.Title;
            ticketFromDb.DepartmentId = ticketDto.DepartmentId;

            _ticketsRepo.Update(ticketFromDb);
            _ticketsRepo.SaveChanges();
            return true;
        }

        public void Delete(int id)
        {
            var ticketFromDb = _ticketsRepo.GetById(id);
            if (ticketFromDb == null)
            {
                return;
            }

            _ticketsRepo.Delete(ticketFromDb);
            _ticketsRepo.SaveChanges();
        }
    }
}
