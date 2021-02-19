using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymClientServer.ViewDB
{
    public class ScheduleGymView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string SportName { get; set; }
        public string PostName { get; set; }
        public string FromTo { get; set; }
    }
}
