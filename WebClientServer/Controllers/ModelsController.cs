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
        private readonly ClubesRepository clubesRepository;
        private readonly PostsRepository postsRepository;
        public ModelsController(IConfiguration configuration)
        {
            employeeRepository = new EmployeeRepository(configuration);
            clientRepository = new ClientRepository(configuration);
            clubesRepository = new ClubesRepository(configuration);
            postsRepository = new PostsRepository(configuration);
        }
        #region Employeers Methods
        // GET: api/employeers
        [Route("employeers")]
        [HttpGet]
        public IEnumerable<Employee> GetAllEmp()
        {
            return employeeRepository.FindAll();
            // GET api/employeers/5
            //[Route("employeers/GetId/'{id}'")]
        }
        [HttpGet("employeers/{id}")]
        public Employee GetEmpById(int id)
        {
            return employeeRepository.FindById(id);
        }
        // POST api/employee
        [Route("employee/add")]
        [HttpPost]
        public void AddEmp(Employee employee)
        {
            employeeRepository.Add(employee);
        }
        // PUT api/employee/5
        //[Route("{api/employee/update/{id}}")]
        [HttpPut("employee/update/{id}")]
        public ResponseServer UpdateEmp(Employee employee)
        {
            ResponseServer response = new ResponseServer()
            {
                Action = "Обновление данных работника",
                IsSuccess = false,
                Message = "Не удалось обновить данные работника"
            };
            Employee oldEmp = employeeRepository.FindById(employee.Id);
            if (oldEmp.Phone != employee.Phone)
            {
                response.IsSuccess = true;
                employeeRepository.Update(employee);
                response.Message = "Данные обновлены";
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
            if (id != null)
            {
                response.IsSuccess = true;
                employeeRepository.Remove(id.Value);
                if (employeeRepository.FindById(id.Value) == null)
                {
                    response.Message = "Успешно удалено";
                }
            }
            return response;

        }
        #endregion

        #region Clients Methods
        // Get : api/clients
        [Route("clients")]
        [HttpGet]
        public IEnumerable<Client> GetAllClients()
        {
            return clientRepository.FindAll();
        }
        //GET api/clients/5
        //[Route("api/clients/{id}")]
        [HttpGet("clients/{id}")]
        public Client GetClientById(int id)
        {
            return clientRepository.FindById(id);
        }

        [Route("client/add")]
        [HttpPost]
        public void Add(Client client)
        {
            clientRepository.Add(client);
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

        [HttpDelete("client/delete/{id}")]
        public ResponseServer DeleteClient(int? id)
        {
            ResponseServer response = new ResponseServer()
            {
                Action = "Удаление клиента из списка",
                IsSuccess = false,
                Message = "Не удалось удалить клиента из списка"
            };
            if (id != null)
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
        #endregion

        #region Clubes Methods
        [Route("clubes")]
        [HttpGet]
        public IEnumerable<Gym> GetGyms()
        {
            return clubesRepository.FindAll();
        }
        [HttpGet("clubes/{id}")]
        public Gym FindGymById(int id)
        {
            return clubesRepository.FindById(id);
        }
        [Route("clubes/add")]
        [HttpPost]
        public void GymAdd(Gym gym)
        {
            clubesRepository.Add(gym);
        }
        [HttpPut("clubes/update/{id}")]
        public ResponseServer UpdateGym(Gym gym)
        {
            ResponseServer response = new ResponseServer()
            {
                Action = "Обновление данных работника",
                IsSuccess = false,
                Message = "Не удалось обновить данные работника"
            };
            Gym oldGym = clubesRepository.FindById(gym.Id);
            if (oldGym.Adress != gym.Adress)
            {
                response.IsSuccess = true;
                clubesRepository.Update(gym);
                response.Message = "Данные обновлены";
            }
            return response;
        }
        [HttpDelete("clubes/delete/{id}")]
        public ResponseServer DeleteGym(int? id)
        {
            ResponseServer response = new ResponseServer()
            {
                Action = "Удаление работника из списка",
                IsSuccess = false,
                Message = "Не удалось удалить работника из списка"
            };
            if (id != null)
            {
                response.IsSuccess = true;
                clubesRepository.Remove(id.Value);
                if (clubesRepository.FindById(id.Value) == null)
                {
                    response.Message = "Успешно удалено";
                }
            }
            return response;

        }
        #endregion
        #region Post Methods
        [Route("posts")]
        [HttpGet]
        public IEnumerable<CareerPost> FindAllPosts()
        {
            var qwe = postsRepository.FindAll();
            return postsRepository.FindAll();
        }
        [HttpGet("posts/{id}")]
        public CareerPost GetCareerPost(int id)
        {
            return postsRepository.FindById(id);
        }
        [HttpPost("post/add")]
        public void AddPost(CareerPost careerPost)
        {
            postsRepository.Add(careerPost);
        }
        [HttpPut("post/update/{id}")]
        public ResponseServer Update(CareerPost careerPost)
        {
            ResponseServer response = new ResponseServer() 
            { 
                Action = "Обновление должностей", 
                IsSuccess = false, 
                Message = "Не удалось изменить данные" 
            };
            CareerPost oldCareerPost1 = postsRepository.FindById(careerPost.Id);
            if(oldCareerPost1.PostName != careerPost.PostName)
            {
                response.IsSuccess = true;
                response.Message = "Успешно обновлено";
            }
            return response;
        }
        [HttpDelete("post/delete/{id}")]
        public ResponseServer DeletePost(int? id)
        {
            ResponseServer response = new ResponseServer()
            {
                Action = "Удаление должности из списка",
                IsSuccess = false,
                Message = "Не удалось удалить должность из списка"
            };
            if (id != null)
            {
                response.IsSuccess = true;
                postsRepository.Remove(id.Value);
                if (postsRepository.FindById(id.Value) == null)
                {
                    response.Message = "Успешно удалено";
                }
            }
            return response;
        }
        #endregion
    }
}
