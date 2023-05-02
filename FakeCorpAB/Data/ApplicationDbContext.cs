using FakeCorpAB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FakeCorpAB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationList> VacationLists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 2,
                FirstName = "Tom",
                LastName = "Havafort",
                Address = "Road 2",
                City = "Pawne"
            },
            new Employee
            {
                EmployeeId = 3,
                FirstName = "Ann",
                LastName = "Perkins",
                Address = "Corner 1",
                City = "Pawne"
            },
            new Employee
            {
                EmployeeId = 4,
                FirstName = "Andy",
                LastName = "Dvier",
                Address = "The Pit 1",
                City = "Pawne"
            },
            new Employee()
            {
                EmployeeId = 5,
                FirstName = "Leslie",
                LastName = "Knope",
                Address = "Mansion road",
                City = "Pawne"
            });

            modelBuilder.Entity<Vacation>().HasData(
            new Vacation
            {
                VacationId = 2,
                VacationType = "VAB",
                Description = "Taking care of sick child"
            },
            new Vacation
            {
                VacationId = 3,
                VacationType = "COMP",
                Description = "Time off using saved overtime hours"
            });

            modelBuilder.Entity<VacationList>().HasData(
            new VacationList
            {
                VacationListId = 5,
                ApplicationTime = new DateTime(2022 - 04 - 20),
                FK_EmployeeId = 1,
                FK_VacationId = 1,
                Start = new DateTime(2022 - 06 - 20),
                End = new DateTime(2022 - 06 - 20),
                Status = "Done"
            }); modelBuilder.Entity<VacationList>().HasData(
            new VacationList
            {
                VacationListId = 6,
                ApplicationTime = new DateTime(2022 - 11 - 07),
                FK_EmployeeId = 2,
                FK_VacationId = 2,
                Start = new DateTime(2022 - 11 - 07),
                End = new DateTime(2022 - 11 - 11),
                Status = "Done"
            }); modelBuilder.Entity<VacationList>().HasData(
            new VacationList
            {
                VacationListId = 7,
                ApplicationTime = new DateTime(2022 - 04 - 12),
                FK_EmployeeId = 5,
                FK_VacationId = 1,
                Start = new DateTime(2022 - 07 - 14),
                End = new DateTime(2022 - 08 - 13),
                Status = "Done"
            }); modelBuilder.Entity<VacationList>().HasData(
            new VacationList
            {
                VacationListId = 8,
                ApplicationTime = new DateTime(2022 - 02 - 24),
                FK_EmployeeId = 4,
                FK_VacationId = 1,
                Start = new DateTime(2022 - 07 - 20),
                End = new DateTime(2022 - 08 - 20),
                Status = "Done"
            }); modelBuilder.Entity<VacationList>().HasData(
            new VacationList
            {
                VacationListId = 9,
                ApplicationTime = new DateTime(2022 - 03 - 20),
                FK_EmployeeId = 3,
                FK_VacationId = 1,
                Start = new DateTime(2022 - 06 - 25),
                End = new DateTime(2022 - 07 - 25),
                Status = "Done"
            });
            modelBuilder.Entity<VacationList>().HasData(
            new VacationList
            {
                VacationListId = 10,
                ApplicationTime = new DateTime(2022 - 04 - 10),
                FK_EmployeeId = 2,
                FK_VacationId = 1,
                Start = new DateTime(2022 - 06 - 10),
                End = new DateTime(2022 - 07 - 10),
                Status = "Done"
            });
        }
    }
}