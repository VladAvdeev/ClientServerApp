using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary1.Models
{
    public class Employee : Person
    {
        public int Id { get; set; }
        //public string CareerPost { get; set; }
        public int EmpId { get; set; }
        public int ClubId { get; set; }
        public int ShceduleId { get; set; }
        public CareerPost CareerPost { get; set; }
        public Gym GymAcces { get; set; }

    }
    public class CareerPost
    {
        public int Id { get; set; }
        public string PostName { get; set; }
    }
   
}
