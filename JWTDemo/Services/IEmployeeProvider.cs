using JWTDemo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo.Services
{
    public interface IEmployeeProvider
    {
        IEnumerable<Employee> GetEmployees();
        void Create(Employee employee);
        void UpDate(Employee employee);
        void Delete(int employee);
    }
}
