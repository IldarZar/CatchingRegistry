using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchingRegistry.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public static int currentId { get; private set; }

        public Employee() { }

        public Employee(string Name, string Password)
        {
            this.Name = Name;
            this.Password = Password;
        } 

        public bool IsUserExists()
        {
            var db = new Context();

            var employees = db
                .Employees
                .Where(employee =>
                    employee.Name == Name
                    && employee.Password == Password
                );

            if (employees.Any())
            {
                FillFields();
                return true;
            }

            return false;
        }

        public void FillFields()
        {
            var db = new Context();

            var employees = db
              .Employees
              .Include(p => p.Role)
              .Where(employee =>
                  employee.Name == Name
                  && employee.Password == Password
                ).First();

            currentId = employees.Id;

            Id = employees.Id;
            Role = new Role { Id = employees.Role.Id, Name = employees.Role.Name, CanUpdate = employees.Role.CanUpdate };
        }
    }
}
