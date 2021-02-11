using CommonLibrary1.Models;
using GymClientServer.Sources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymClientServer.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly EmployeeRepository employeeRepository;
        public ModelsController(IConfiguration configuration)
        {
            employeeRepository = new EmployeeRepository(configuration);
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return employeeRepository.FindAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
