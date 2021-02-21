using CommonLibrary1.Models;
using GymClient.ClientsREST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymClient.Entities
{
    public class Handbook
    {
        public static List<CareerPost> CareerPosts { get; set; }
        public static void Load()
        {
            PostServer post = new PostServer();
            CareerPosts = post.GetCareerPosts() ?? new List<CareerPost>();
        }
    }
}
