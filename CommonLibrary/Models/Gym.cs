﻿using CommonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary
{
    public class Gym : BaseEntity
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Review { get; set; }
        public int EmployeeCount { get; set; }
    }
}
