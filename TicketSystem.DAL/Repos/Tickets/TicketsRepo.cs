using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Data.Context;
using TicketSystem.DAL.Data.Models;

namespace TicketSystem.DAL.Repos.Tickets
{
    public class TicketsRepo : ITicketsRepo
    {
        private readonly TicketContext _context;

        public TicketsRepo(TicketContext context)
        {
            _context = context;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _context.Set<Ticket>().AsNoTracking(); 
        }

        public Ticket? GetById(int id)
        {
            return _context.Set<Ticket>().Find(id);
        }

        public void Add(Ticket entity)
        {
            _context.Set<Ticket>().Add(entity);
        }

        public void Update(Ticket entity)
        {
        }

        public void Delete(Ticket entity)
        {
            _context.Set<Ticket>().Remove(entity);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
