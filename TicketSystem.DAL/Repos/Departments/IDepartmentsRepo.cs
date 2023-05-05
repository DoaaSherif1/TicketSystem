using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Data.Models;

namespace TicketSystem.DAL.Repos.Departments
{
    public interface IDepartmentsRepo
    {
        IEnumerable<Department> GetAll();
        Department? GetById(int id);
        void Add(Department entity);
        void Update(Department entity);
        void Delete(Department entity);

        int SaveChanges();


        Department? GetWithTicketsAndDevelopers(int id);
    }
}
