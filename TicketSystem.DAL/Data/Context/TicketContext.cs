using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using TicketSystem.DAL.Data.Models;

namespace TicketSystem.DAL.Data.Context
{
    public class TicketContext : IdentityDbContext<Developer>
    {
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Developer> Developers => Set<Developer>();

        public TicketContext(DbContextOptions<TicketContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Bad idea
            //1. You don't have access to the Configuration.
            //2. You dont' have access to the current environment app.Environment.
            //3. You can't configure the database connection string based on the eenvironment
            //optionsBuilder.UseSqlServer("YOUR_CONNECTION_STRING");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seeding Tickets

            var tickets = new List<Ticket>
            {
                  new Ticket {
                    Id= 1,
                    Description= "Doaa",
                    Title= "Hematology",
                    DepartmentId= 1,
                  },
                  new Ticket {
                    Id= 2,
                    Description= "Doaa",
                    Title= "Hematology",
                    DepartmentId= 2,
                  },
                 new Ticket {
                    Id= 3,
                    Description= "Doaa",
                    Title= "Hematology",
                    DepartmentId= 3,
                  },
                 new Ticket {
                    Id= 4,
                    Description= "Doaa",
                    Title= "Hematology",
                    DepartmentId= 4,
                  },
                 new Ticket {
                    Id= 5,
                    Description= "Doaa",
                    Title= "Hematology",
                    DepartmentId= 5,
                  },
                 new Ticket {
                    Id= 6,
                    Description= "Doaa",
                    Title= "Hematology",
                    DepartmentId= 6,
                  },
                  new Ticket {
                    Id= 7,
                    Description= "Doaa",
                    Title= "Hematology",
                    DepartmentId= 7,
                  },
                  new Ticket {
                    Id= 8,
                    Description= "Doaa",
                    Title= "Hematology",
                    DepartmentId= 5,
                  },
                  new Ticket {
                    Id= 9,
                    Description= "Doaa",
                    Title= "Hematology",
                    DepartmentId= 7,
                  },
                 new Ticket {
                     Id = 10,
                     Description = "Doaa",
                     Title = "Hematology",
                     DepartmentId = 3
                 },
                };

            #endregion
            #region Departments

            var departments = new List<Department>
                {
                  new Department { Id= 1, Name= "Diabetes" },
                  new Department { Id= 2, Name= "Hypertension" },
                  new Department { Id= 3, Name= "Asthma" },
                  new Department { Id= 4, Name= "Depression" },
                  new Department { Id= 5, Name= "Arthritis" },
                  new Department { Id= 6, Name= "Allergy" },
                  new Department { Id= 7, Name= "Flu" },
                };

            #endregion
            #region Developers

            //var developers = new List<Developer>
            //    {

            //      new Developer { Id= 1, Name= "Doaa"},
            //      new Developer { Id= 2, Name= "Emy"},
            //      new Developer { Id= 3, Name= "Rowan",},
            //      new Developer { Id= 4, Name= "Miriam" },
            //      new Developer { Id= 5, Name= "Yasmeen "},
            //      new Developer { Id= 6, Name= "Rosy= 1 "},
            //      new Developer { Id= 7, Name= "Andrew "},
            //      new Developer { Id= 8, Name= "Ammar "},
            //      new Developer { Id= 9, Name= "Tasha"},
            //      new Developer { Id= 10, Name= "Max" },
            //      new Developer { Id= 11, Name= "Bridge 2 "},
            //      new Developer { Id= 12, Name= "Juan"},
            //      new Developer { Id= 13, Name= "Krysta 10 "},
            //      new Developer { Id= 14, Name= "Erma"},
            //      new Developer { Id= 15, Name= "Orland 6 "},
            //      new Developer { Id= 16, Name= "Leen "},
            //      new Developer { Id= 17, Name= "Lama" },
            //      new Developer { Id= 18, Name= "Joe" } ,
            //      new Developer { Id= 19, Name= "Youmna8 "},
            //      new Developer { Id= 20, Name= "Ola "},
            //      new Developer { Id= 21, Name= "Sophy= 6 "},
            //      new Developer { Id= 22, Name= "Erenie" },
            //      new Developer { Id= 23, Name= "Bamba",},
            //      new Developer { Id= 24, Name= "amal= 7 "},
            //      new Developer { Id= 25, Name= "Gamal= 2 "},
            //      new Developer { Id= 26, Name= "Jeje" },
            //      new Developer { Id= 27, Name= "Michael= 6 "},
            //      new Developer { Id= 28, Name= "Maggie "},
            //      new Developer { Id= 29, Name= "Sally" },
            //      new Developer { Id= 30, Name= "Karim" }
            //    };

            #endregion

            modelBuilder.Entity<Ticket>().HasData(tickets);
            modelBuilder.Entity<Department>().HasData(departments);
            //modelBuilder.Entity<Developer>().HasData(developers);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Developer>().ToTable("Developers");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("DeveloperClaims");
        }
    }
}
