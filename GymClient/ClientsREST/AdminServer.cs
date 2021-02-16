using CommonLibrary1;
using CommonLibrary1.Models;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GymClient.ClientsREST
{
    public class AdminServer
    {
        private string adress = "https://localhost:5001";
        private RestClient client;

        public AdminServer()
        {
            client = new RestClient(adress);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }
        public List<Employee> GetEmployees()
        {
            var request = new RestRequest("api/employeers", Method.GET);
            return client.Execute<List<Employee>>(request).Data; 
        }
        public ResponseServer AddEmployee(Employee employee)
        {
            var request = new RestRequest("Api/Employee/Add", Method.POST);
            request.JsonSerializer = new JsonSerializer();
            request.AddJsonBody(employee);
            return client.Execute<ResponseServer>(request).Data;
        }
        public ResponseServer ChangeEmployee(Employee employee)
        {
            var request = new RestRequest("Api/Employee/Update", Method.PUT);
            request.JsonSerializer = new JsonSerializer();
            request.AddJsonBody(employee);
            return client.Execute<ResponseServer>(request).Data;
        }
        public ResponseServer DeleteEmployee(int id)
        {
            var request = new RestRequest("Api/Employee/Delete", Method.DELETE);
            return client.Execute<ResponseServer>(request).Data;
        }
    }
}
