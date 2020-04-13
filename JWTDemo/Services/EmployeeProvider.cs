using Dapper;
using JWTDemo.Controllers;
using JWTDemo.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo.Services
{
    public class EmployeeProvider:IEmployeeProvider
    {
        private readonly string _connectionString;
        public EmployeeProvider(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void Create(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("insert into Employee(firstName  , lastName , address , home_phone , cell_Phone) values(@firstName, @lastName, @address, @home_phone, @cell_phone)", new { employee.firstName, employee.lastName, employee.address, employee.home_phone, employee.cell_Phone });
            }
        }

        public void Delete(int employeeid)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("delete from Employee where id = @id", new { id = employeeid });
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            IEnumerable<Employee> employees;
            using (var connection = new SqlConnection(_connectionString))
            {
                employees = connection.Query<Employee>("SELECT id , firstName  , lastName , address , home_phone , cell_Phone FROM Employee");
            }
            return employees;
        }

        public void UpDate(Employee employee)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("update Employee set firstName = @firstName, lastName = @lastName, address = @address, home_phone = @home_phone, cell_Phone =@cell_phone where id = @id", new { employee.id, employee.firstName, employee.lastName, employee.address, employee.home_phone, employee.cell_Phone });
            }
        }
    }
}
