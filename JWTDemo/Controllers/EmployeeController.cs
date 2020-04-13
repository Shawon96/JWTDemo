using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTDemo.Entity;
using JWTDemo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTDemo.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeProvider _employeeProvider;
        public EmployeeController(IEmployeeProvider employeeProvider)
        {
            this._employeeProvider = employeeProvider;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeProvider.GetEmployees();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Employee employee)
        {
            _employeeProvider.Create(employee);
        }

        // PUT api/<controller>/5

        public void Put([FromBody]Employee employee)
        {
            _employeeProvider.UpDate(employee);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeProvider.Delete(id);
        }
    }
}
