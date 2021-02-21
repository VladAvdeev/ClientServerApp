using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymClientServer.ViewDB
{
    public class EmployeeView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int PostId { get; set; }
        public string PostName { get; set; }
        public string Adress { get; set; }
        public int EmpId { get; set; }
        public int ClubId { get; set; }
        public int ScheduleId { get; set; }
    }
}
