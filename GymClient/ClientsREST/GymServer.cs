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

namespace GymClient.RestClients
{
    public class GymServer
    {
        private string adress = "https://localhost:5001";
        private RestClient client;
        public GymServer()
        {
            client = new RestClient(adress);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }
        public IEnumerable<Gym> GetGyms()
        {
            var request = new RestRequest("Api/Clubes", Method.GET);
            return client.Execute<IEnumerable<Gym>>(request).Data;
        }
        public ResponseServer AddGym(Gym gym)
        {
            var request = new RestRequest("Api/Clubes/Add", Method.POST);
            request.JsonSerializer = new JsonSerializer();
            request.AddJsonBody(gym);
            return client.Execute<ResponseServer>(request).Data;
        }
        public ResponseServer ChangeGym(Gym gym)
        {
            var request = new RestRequest($"Api/Clubes/Update/{gym.Id}", Method.PUT);
            request.JsonSerializer = new JsonSerializer();
            request.AddJsonBody(gym);
            return client.Execute<ResponseServer>(request).Data;
        }
        public ResponseServer DeleteGym(int id)
        {
            var request = new RestRequest($"Api/Clubes/Delete/{id}", Method.DELETE);
            return client.Execute<ResponseServer>(request).Data;
        }
    }
}
