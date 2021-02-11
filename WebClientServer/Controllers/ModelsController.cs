using CommonLibrary.Models;
using CommonLibrary1;
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
    [Route("api")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly ClientRepository clientRepository;
        public ModelsController(IConfiguration configuration)
        {
            employeeRepository = new EmployeeRepository(configuration);
            clientRepository = new ClientRepository(configuration);
        }
        // GET: api/employeers
        [Route("employeers")]
        [HttpGet]
        public IEnumerable<Employee> GetAllEmp()
        {
            return employeeRepository.FindAll();
        }
        // Get : api/clients
        [Route("clients")]
        [HttpGet]
        public IEnumerable<Client> GetAllClients()
        {
            return clientRepository.FindAll();
        }
        // GET api/employeers/5
        //[Route("employeers/GetId/'{id}'")]
        [HttpGet("employeers/{id}")]
        public Employee GetEmpById(int id)
        {
            return employeeRepository.FindById(id);
        }
        //GET api/clients/5
        //[Route("api/clients/{id}")]
        [HttpGet("clients/{id}")]
        public Client GetClientById(int id)
        {
            return clientRepository.FindById(id);
        }

        // POST api/employee
        [Route("employee/add")]
        [HttpPost]
        public void AddEmp(Employee employee)
        {
            employeeRepository.Add(employee);
        }
        [Route("client/add")]
        [HttpPost]
        public void Add(Client client)
        {
            clientRepository.Add(client);
        }

        // PUT api/employee/5
        //[Route("{api/employee/update/{id}}")]
        [HttpPut("employee/update/{id}")]
        public ResponseServer UpdateEmp(Employee employee)
        {
            ResponseServer response = new ResponseServer() 
            { 
                Action = "Обновление данных работника", 
                IsSuccess=false, 
                Message = "Не удалось обновить данные работника" 
            };
            Employee oldEmp = employeeRepository.FindById(employee.Id);
            if(oldEmp.Phone != employee.Phone)
            {
                response.IsSuccess = true;
                employeeRepository.Update(employee);
                response.Message = "Данные обновлены";
            }
            return response;
        }
        [HttpPut("client/update/{id}")]
        public ResponseServer UpdateClient(Client client)
        {
            ResponseServer response = new ResponseServer()
            {
                Action = "Обновление данных клиента",
                IsSuccess = false,
                Message = "Не удалось обновить данные клиента"
            };
            Client oldClient = new Client();
            if (oldClient.Phone != clientRepository.FindById(client.Id).Phone)
            {
                response.IsSuccess = true;
                clientRepository.Update(client);
                response.Message = "Данные успешно обновлены";
            }
            return response;
        }
        // DELETE api/<ValuesController>/5
        [HttpDelete("employee/delete/{id}")]
        public ResponseServer DeleteEmp(int? id)
        {
            ResponseServer response = new ResponseServer()
            {
                Action = "Удаление работника из списка",
                IsSuccess = false,
                Message = "Не удалось удалить работника из списка"
            };
            if(id != null)
            {
                response.IsSuccess = true;
                employeeRepository.Remove(id.Value);
                if(employeeRepository.FindById(id.Value) == null)
                {
                    response.Message = "Успешно удалено";
                }
            }
            return response;

        }
        [HttpDelete("client/delete/{id}")]
        public ResponseServer DeleteClient(int? id)
        {
            ResponseServer response = new ResponseServer()
            {
                Action = "Удаление клиента из списка",
                IsSuccess = false,
                Message = "Не удалось удалить клиента из списка"
            };
            if(id != null)
            {
                response.IsSuccess = true;
                clientRepository.Remove(id.Value);
                if (clientRepository.FindById(id.Value) == null)
                {
                    response.Message = "Успешно удалено";
                }
            }
            return response;
        }
        
    }
}
