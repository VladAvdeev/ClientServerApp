﻿using CommonLibrary1;
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
        public List<Gym> GetGyms()
        {
            var request = new RestRequest("api/clubes", Method.GET);
            return client.Execute<List<Gym>>(request).Data;
        }
        public ResponseServer AddGym(Gym gym)
        {
            var request = new RestRequest("api/clubes/add", Method.POST);
            request.JsonSerializer = new JsonSerializer();
            request.AddJsonBody(gym);
            return client.Execute<ResponseServer>(request).Data;
        }
        public ResponseServer ChangeGym(Gym gym)
        {
            var request = new RestRequest("api/clubes/update", Method.PUT);
            request.JsonSerializer = new JsonSerializer();
            request.AddJsonBody(gym);
            return client.Execute<ResponseServer>(request).Data;
        }
        public ResponseServer DeleteGym(int id)
        {
            var request = new RestRequest("api/clubes/delete", Method.DELETE);
            return client.Execute<ResponseServer>(request).Data;
        }
    }
}
