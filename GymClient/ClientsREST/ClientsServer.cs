using CommonLibrary.Models;
using CommonLibrary1;
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
    public class ClientsServer
    {
        private string adress = "https://localhost:5001";
        private RestClient client;
        public ClientsServer()
        {
            client = new RestClient(adress);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }
        public List<Client> GetClients()
        {
            var request = new RestRequest("Api/Clients", Method.GET);
            return client.Execute<List<Client>>(request).Data;
        }
        public ResponseServer AddClient(Client newClient)
        {
            var request = new RestRequest("Api/Clients/Add", Method.POST);
            request.JsonSerializer = new JsonSerializer();
            request.AddJsonBody(newClient);
            return client.Execute<ResponseServer>(request).Data;
        }
        public ResponseServer UpdateClient(Client updClient)
        {
            var request = new RestRequest("Api/Clients/Update", Method.PUT);
            request.JsonSerializer = new JsonSerializer();
            request.AddJsonBody(updClient);
            return client.Execute<ResponseServer>(request).Data;
        }
        public ResponseServer DeleteClient(int? id)
        {
            var request = new RestRequest("Api/Clients/Delete", Method.DELETE);
            return client.Execute<ResponseServer>(request).Data;
        }
    }
}
