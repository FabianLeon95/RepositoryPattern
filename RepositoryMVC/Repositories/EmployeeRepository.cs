using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RepositoryMVC.Models;

namespace RepositoryMVC.Repositories
{
    public class EmployeeRepository: GenericRepository<Employee>, IEmployeeRepository
    {
        public IEnumerable<Employee> GetByGender(string gender)
        {
            return Context.Employees.Where(e => e.Gender == gender).ToList();
        }

        public IEnumerable<Employee> GetByDepartment(string department)
        {
            return Context.Employees.Where(e => e.Department == department).ToList();
        }
    }
}