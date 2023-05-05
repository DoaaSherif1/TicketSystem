using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Data.Context;
using TicketSystem.DAL.Data.Models;

namespace TicketSystem.DAL.Repos.Departments
{
    public class DepartmentsRepo : IDepartmentsRepo
    {
        private readonly TicketContext _context;

        public DepartmentsRepo(TicketContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Set<Department>().AsNoTracking(); 
        }

        public Department? GetById(int id)
        {
            return _context.Set<Department>().Find(id);
        }

        public void Add(Department entity)
        {
            _context.Set<Department>().Add(entity);
        }

        public void Update(Department entity)
        {
        }

        public void Delete(Department entity)
        {
            _context.Set<Department>().Remove(entity);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Department? GetWithTicketsAndDevelopers(int id)
        {
            return _context.Departments
                .Include(d => d.Tickets)
                    .ThenInclude(p => p.Developers)
                .FirstOrDefault(d => d.Id == id);
        }
    }
}
