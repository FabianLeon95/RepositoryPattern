using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryMVC.Models;

namespace RepositoryMVC.Repositories
{
    public interface IEmployeeRepository: IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetByGender(string gender);
        IEnumerable<Employee> GetByDepartment(string department);
    }
}
