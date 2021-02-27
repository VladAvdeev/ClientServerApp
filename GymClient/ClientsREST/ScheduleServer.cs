using CommonLibrary.Models;
using CommonLibrary1;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymClient.ClientsREST
{
    public class ScheduleServer : BaseRestServer
    {
        private RestClient client;
        public ScheduleServer()
        {
            client = CreateClient();
        }
        public List<TimeSport> GetTimes()
        {
            var request = new RestRequest("Api/Times", Method.GET);
            return client.Execute<List<TimeSport>>(request).Data;
        }
        public ResponseServer AddTime(TimeSport time)
        {
            var request = new RestRequest("Api/Times/Add", Method.POST);
            request.JsonSerializer = new JsonSerializer();
            request.AddJsonBody(time);
            return client.Execute<ResponseServer>(request).Data;
        }
        public ResponseServer UpdateTime(TimeSport time)
        {
            var request = new RestRequest($"Api/Times/Update/{time.Id}", Method.PUT);
            request.JsonSerializer = new JsonSerializer();
            request.AddJsonBody(time);
            return client.Execute<ResponseServer>(request).Data;
        }
        public ResponseServer DeleteTime(int? id)
        {
            var request = new RestRequest($"Api/Times/Delete/{id.Value}", Method.DELETE);
            return client.Execute<ResponseServer>(request).Data;
        }
    }
}
