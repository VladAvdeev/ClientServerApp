using CommonLibrary1.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GymClient.ClientsREST
{
    public class BaseRestServer
    {
        protected string adress = "https://localhost:5001";


       
        public RestClient CreateClient() 
        {
            RestClient client = new RestClient(adress);
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            return client;
        }
    }
}
