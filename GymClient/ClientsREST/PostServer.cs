using CommonLibrary1.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymClient.ClientsREST
{
    public class PostServer : BaseRestServer
    {
        private RestClient client;
       
        public PostServer()
        {
            client = CreateClient();
        }
        public List<CareerPost> GetCareerPosts()
        {
            var request = new RestRequest("api/posts", Method.GET);
            return client.Execute<List<CareerPost>>(request).Data;
        }
    }
}
