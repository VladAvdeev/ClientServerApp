﻿using System;
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
        public int ScheduleId { get; set; }
        public CareerPost PostName { get; set; }
        public Gym Gym { get; set; }

    }
    public class CareerPost : BaseEntity
    {
        public int Id { get; set; }
        public string PostName { get; set; }
    }
   
}
