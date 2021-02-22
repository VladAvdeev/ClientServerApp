using CommonLibrary1.Models;
using GymClient.ClientsREST;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymClient.Entities
{
    public static class Handbook
    {
        public static List<CareerPost> PostNames { get; set; }
        public static void Load()
        {
            PostServer post = new PostServer();
            PostNames = post.GetCareerPosts() ?? new List<CareerPost>();
        }
    }
}
